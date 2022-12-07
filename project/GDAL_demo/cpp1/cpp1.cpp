#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <algorithm>
#include <time.h>
#include <iomanip>
#include <vector>
#include <cmath>

//#include <gdal.h>
//#include <gdal_priv.h>

#include <opencv2/opencv.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/features2d/features2d.hpp>
#include <opencv2/core/utils/logger.hpp>
using namespace std;
using namespace cv;

/// <summary>
/// K均值聚类
/// </summary>
/// <param name="xSize"></param>
/// <param name="ySize"></param>
/// <param name="imgData"></param>
/// <param name="resClass"></param>
/// <returns></returns>
vector<int> KMeans(int xSize, int ySize, unsigned char* imgData, int* resClass)
{
	const int n = 3;
	const int maxLoopNum = 6;

	vector<int> z0;
	vector<int> z0_x;
	vector<int> z0_y;

	int* sum = new int[n]();;
	int* num = new int[n]();;
	int* euclidean = new int[n]();

	for (int k = 0; k < n; k++)
	{
		//随机聚类中心坐标
		// x/y = [0,512)
		z0_x.push_back(rand() % (xSize));
		z0_y.push_back(rand() % (ySize));
		int index;
		for (int i = 0; i < xSize; i++)
		{
			for (int j = 0; j < ySize; j++)
			{
				if (i == z0_x[k] && j == z0_y[k])
				{
					index = i * xSize + j;
					z0.push_back(imgData[index]);
				}
			}
		}
	};

	//进行循环
	for (int i = 0; i < maxLoopNum; i++)
	{
		for (int j = 0; j < ySize; j++)
		{
			for (int k = 0; k < xSize; k++)
			{
				int index = xSize * j + k;
				int temp = 256;
				int nNum;
				for (int ii = 0; ii < n; ii++)
				{
					euclidean[ii] = abs(imgData[index] - z0[ii]);
					if (euclidean[ii] <= temp)
					{
						temp = euclidean[ii];
						nNum = ii;
					}
				}
				sum[nNum] += imgData[index];
				num[nNum] ++;
				resClass[index] = nNum;
			}
		};

		//判断是否满足跳出条件
		int flag = 0;
		for (int j = 0; j < n; j++)
		{
			int temp;
			temp = (int)round((float)sum[j] / num[j]);
			if (z0[j] == temp)
			{
				flag++;
				if (flag == n)
				{
					return z0;
				}
			}
			//清空变量
			z0[j] = temp;
			sum[j] = 0;
			num[j] = 0;
		};
	};
}

/// <summary>
/// 植被归一化指数
/// </summary>
/// <param name="imgData"></param>
/// <param name="imgDataNir"></param>
/// <param name="xSize"></param>
/// <param name="ySize"></param>
/// <returns></returns>
float* calcNDVI(unsigned short* imgData, unsigned short* imgDataNir, int xSize, int ySize)
{
	float* result = new float[xSize * ySize]();
	for (int j = 0; j < ySize; j++)
	{
		for (int i = 0; i < xSize; i++)
		{
			float red = (float)imgData[j * xSize + i];
			float nir = (float)imgDataNir[j * xSize + i];
			if ((nir + red) != 0)
			{
				result[j * xSize + i] = (nir - red) / (nir + red);
			}
		}
	}
	return result;
}

/// <summary>
/// 均值滤波
/// </summary>
/// <param name="imgData"></param>
/// <param name="xSize"></param>
/// <param name="ySize"></param>
/// <param name="winSize"></param>
/// <returns>返回unsigned char数组</returns>
unsigned char* MeanFilter(unsigned char* imgData, int xSize, int ySize, int winSize)
{
	unsigned char* result = new unsigned char[xSize * ySize]();
	int index;
	int sum = 0;
	int size = (winSize - 1) / 2;
	for (int j = 0; j < ySize; j++)
	{
		for (int i = 0; i < xSize; i++)
		{
			index = j * xSize + i;
			//如果为边界点则直接赋值
			if (i - size < 0 || j - size < 0 || i + size >= xSize || j + size >= ySize)
			{
				result[index] = imgData[index];
			}
			else
			{
				sum = 0;
				for (int l = j - size; l <= j + size; l++)
				{
					for (int k = i - size; k <= i + size; k++)
					{
						sum += imgData[l * xSize + k];
					}
				}
				//对于小数部分，取整后再转换
				result[index] = (unsigned char)round(sum / pow(winSize, 2));
			}
		}
	}
	return result;
}


/// <summary>
/// 中值滤波
/// </summary>
/// <param name="imgData"></param>
/// <param name="xSize"></param>
/// <param name="ySize"></param>
/// <param name="winSize"></param>
/// <returns>返回unsigned char数组</returns>
unsigned char* MedianFilter(unsigned char* imgData, int xSize, int ySize, int winSize)
{
	unsigned char* result = new unsigned char[xSize * ySize]();
	int index;
	int sum = 0;
	int size = (winSize - 1) / 2;
	vector<int> temp;
	for (int j = 0; j < ySize; j++)
	{
		for (int i = 0; i < xSize; i++)
		{
			index = j * xSize + i;
			//如果为边界点则直接赋值
			if (i - size < 0 || j - size < 0 || i + size >= xSize || j + size >= ySize)
			{
				result[index] = imgData[index];
			}
			else
			{
				temp.resize(0);
				for (int l = j - size; l <= j + size; l++)
				{
					for (int k = i - size; k <= i + size; k++)
					{
						temp.push_back(imgData[l * xSize + k]);
					}
				}
				//对邻域数组进行排序
				sort(temp.begin(), temp.end());
				result[index] = (unsigned char)round(temp[pow(winSize, 2) / 2]);
			}
		}
	}
	return result;
}


/// <summary>
/// 直方图匹配
/// </summary>
/// <param name="xSizeFc"></param>
/// <param name="ySizeFc"></param>
/// <param name="I"></param>
/// <param name="imgDataFc"></param>
/// <param name="imgDataFcNew"></param>
void HistogramMatch(int xSizeFc, int ySizeFc, float* I, unsigned char* imgDataFc, unsigned char* imgDataFcNew)
{
	int index = 0;
	//计算均值
	float sumFC = 0;
	float sumI = 0;
	for (int j = 0; j < ySizeFc; j++)
	{
		for (int i = 0; i < xSizeFc; i++)
		{
			index = j * xSizeFc + i;
			sumFC += imgDataFc[index];
			sumI += I[index];
		}
	}
	float avgFC = sumFC / (xSizeFc * ySizeFc);
	float avgI = sumI / (xSizeFc * ySizeFc);
	//计算标准差
	float stdFC = 0;
	float stdI = 0;
	for (int j = 0; j < ySizeFc; j++)
	{
		for (int i = 0; i < xSizeFc; i++)
		{
			index = j * xSizeFc + i;
			stdFC += pow(imgDataFc[index] - avgFC, 2);
			stdI += pow(I[index] - avgI, 2);
		}
	}
	stdFC /= (xSizeFc * ySizeFc - 1);
	stdFC = sqrt(stdFC);
	stdI /= (xSizeFc * ySizeFc - 1);
	stdI = sqrt(stdI);
	//遍历赋值
	for (int j = 0; j < ySizeFc; j++)
	{
		for (int i = 0; i < xSizeFc; i++)
		{
			index = j * xSizeFc + i;
			imgDataFcNew[index] = (imgDataFc[index] - avgFC) * stdI / stdFC + avgI;
		}
	}

	//直方图匹配
	//GDALRasterBand* dsBandR = resizeMul->GetRasterBand(1);
	//GDALRasterBand* dsBandG = resizeMul->GetRasterBand(2);
	//GDALRasterBand* dsBandB = resizeMul->GetRasterBand(3);
	//unsigned short* R = new unsigned short[xSizeMul * ySizeMul]();
	//unsigned short* G = new unsigned short[xSizeMul * ySizeMul]();
	//unsigned short* B = new unsigned short[xSizeMul * ySizeMul]();
	//dsBandR->RasterIO(GF_Read, 0, 0, xSizeMul, ySizeMul, R, xSizeMul, ySizeMul, type2, 0, 0);
	//dsBandG->RasterIO(GF_Read, 0, 0, xSizeMul, ySizeMul, G, xSizeMul, ySizeMul, type2, 0, 0);
	//dsBandB->RasterIO(GF_Read, 0, 0, xSizeMul, ySizeMul, B, xSizeMul, ySizeMul, type2, 0, 0);
	//float* mI = new float[xSizeMul * ySizeMul]();

	//for (int j = 0; j < ySizeMul; j++)
	//{
	//	for (int i = 0; i < xSizeMul; i++)
	//	{
	//		int index = j * ySizeMul + i;
	//		mI[index] = (R[index] + G[index] + B[index]) / 3.0;
	//	}
	//}
	//unsigned char* imgDataFcNew = new unsigned char[xSizeFc * ySizeFc]();
	//HistogramMatch(xSizeFc, ySizeFc, mI, imgDataFc, imgDataFcNew);
}



/// <summary>
/// 检查索引是否小于等于零
/// </summary>
/// <param name="a"></param>
/// <returns></returns>
int exam(int a)
{
	if (a <= 0)
	{
		return 0;
	}
	else
	{
		return a;
	}
};



/// <summary>
/// 分割字符串
/// </summary>
/// <param name="str"></param>
/// <param name="sig"></param>
/// <returns>返回转换后的float数组</returns>
vector<float> Split(string str, char sig)
{
	vector<float> split;
	string token;
	istringstream iss(str);
	while (getline(iss, token, sig))
	{
		if (atof(token.c_str()) != 0)
			split.push_back(atof(token.c_str()));
	}
	return split;
};



void main()
{
	clock_t start, end;
	start = clock();


	//只输出错误日志
	utils::logging::setLogLevel(utils::logging::LOG_LEVEL_ERROR);

	Mat img1, img2;
	img1 = imread("./Resources//1111.jpg");
	img2 = imread("./Resources//2222.jpg");
	Ptr<SIFT> sift = SIFT::create(500);
	vector<KeyPoint> kp1, kp2;
	sift->detect(img1, kp1);
	sift->detect(img2, kp2);
	//绘制特征点
	//Mat res;
	//drawKeypoints(img1, kp1, res, Scalar(0, 255, 255));
	//imshow("res", res);

	//计算特征点描述符,提取特征向量
	Mat dsc1, dsc2;
	Ptr<SiftDescriptorExtractor> descriptor = SiftDescriptorExtractor::create();
	descriptor->compute(img1, kp1, dsc1);
	descriptor->compute(img2, kp2, dsc2);



	/*得到的特征点个数：
	500 => 500
	1000 => (627, 128)(645, 128)
	*/

	//KNN-NNDR特征匹配
	Ptr<DescriptorMatcher> matcher = DescriptorMatcher::create(DescriptorMatcher::BRUTEFORCE);
	vector<vector<DMatch> > knn_matches;
	const float ratio_thresh = 0.7f;
	vector<DMatch> matches;
	matcher->knnMatch(dsc1, dsc2, knn_matches, 2);
	for (auto& knn_matche : knn_matches) {
		if (knn_matche[0].distance < ratio_thresh * knn_matche[1].distance) {
			matches.push_back(knn_matche[0]);
		}
	}


	////BFMatch匹配
	//BFMatcher matcher(NORM_L2);
	////定义匹配结果变量
	//vector<DMatch> matches;
	////实现描述符之间的匹配
	//matcher.match(dsc1, dsc2, matches);
	//
	////定义向量距离的最大值与最小值
	//double max_dist = 0;
	//double min_dist = 1000;
	//for (int i = 1; i < dsc1.rows; ++i)
	//{
	//	//通过循环更新距离，距离越小越匹配
	//	double dist = matches[i].distance;
	//	if (dist > max_dist)
	//		max_dist = dist;
	//	if (dist < min_dist)
	//		min_dist = dist;
	//}
	////匹配结果筛选    
	//vector<DMatch> goodMatches;
	//for (int i = 0; i < matches.size(); ++i)
	//{
	//	double dist = matches[i].distance;
	//	if (dist < 2 * min_dist)
	//		goodMatches.push_back(matches[i]);
	//}


	//绘制匹配结果
	Mat result;
	drawMatches(img1, kp1, img2, kp2, matches, result, Scalar(0, 255, 255), Scalar::all(-1));
	imshow("Result", result);
}

