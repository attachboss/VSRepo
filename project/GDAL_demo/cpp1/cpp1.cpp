#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <algorithm>
#include <time.h>
#include <iomanip>
#include <vector>
#include <cmath>

#include <gdal.h>
#include <gdal_priv.h>
#include "cpp1.h"

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
void KMeans(int xSize, int ySize, unsigned char* imgData)
{
	const int n = 3;
	const int loopNum = 6;
	vector<int> z0;
	vector<int> z0_x;
	vector<int> z0_y;
	int* sum = new int[n]();;
	int* num = new int[n]();;
	int* euclidean = new int[n]();
	int* result = new int[xSize * ySize]();
	for (int k = 0; k < n; k++)
	{
		//[0,512)
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
	for (int i = 0; i < loopNum; i++)
	{
		for (int j = 0; j < xSize; j++)
		{
			for (int k = 0; k < ySize; k++)
			{
				int index = xSize * j + k;
				int temp = INT32_MAX;
				int nNum;
				for (int ii = 0; ii < n; ii++)
				{
					euclidean[ii] = abs(imgData[index] - z0[ii]);
					if (euclidean[ii] <= temp)
					{
						temp = euclidean[ii];
						nNum = ii;
						result[index] = temp;
					}
				}
				sum[nNum] += temp;
				num[nNum] += 1;
			}
		};
		for (int j = 0; j < n; j++)
		{
			int temp;
			temp = round(sum[j] / num[j]);
			if (z0[j] == temp)
			{
				return;
			}
			//
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


#pragma region GDAL
//int main()
//{
//	//注册驱动
//	GDALAllRegister();
//	//路径支持中文
//	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
//	GDALDataset* gdalDs = (GDALDataset*)GDALOpen("D://testImg.tif", GA_ReadOnly);
//	if (gdalDs == NULL)
//	{
//		return 0;
//	}
//	std::cout << "图像信息：" << gdalDs->GetDescription() << std::endl;
//	char** str = gdalDs->GetMetadataDomainList();
//	std::cout << "元数据信息：" << str << std::endl;
//	int xSize = gdalDs->GetRasterXSize();
//	std::cout << "列宽：" << xSize << std::endl;
//	int ySize = gdalDs->GetRasterYSize();
//	std::cout << "行高：" << ySize << std::endl;
//	//波段起始值为1
//	GDALRasterBand* dsBand1 = gdalDs->GetRasterBand(1);
//	std::cout << "第一波段信息：" << dsBand1 << std::endl;
//	GDALDataType type = dsBand1->GetRasterDataType();
//	std::cout << "数据类型：" << type << std::endl;
//	//std::cout << "波段数：" << gdalDs->GetRasterCount() << std::endl;
//	std::cout << "最小灰度值：" << dsBand1->GetMinimum() << std::endl;
//	std::cout << "最大灰度值：" << dsBand1->GetMaximum() << std::endl;
//	if (gdalDs->GetProjectionRef() != NULL)
//	{
//		std::cout << "投影信息：" << gdalDs->GetProjectionRef() << std::endl;
//	}
//	std::cout << "地理参考变换信息：" << std::endl;
//	//	GetGeoTransform[0] /* 左上角X坐标 */
//	//	GetGeoTransform[1] /* 西-东 方向像素分辨率 */
//	//	GetGeoTransform[2] /* 0 无关*/
//	//	GetGeoTransform[3] /* 左上角Y坐标 */
//	//	GetGeoTransform[4] /* 0 无关*/
//	//	GetGeoTransform[5] /* 北-南 方向像素分辨率(前面加负号) */
//	//建立影像与地理坐标之间的关系
//	double geotrans[6];
//	gdalDs->GetGeoTransform(geotrans);
//	for (int i = 0; i < 6; i++)
//	{
//		printf("%.6f\n", geotrans[i]);
//	};
//
//	unsigned char* imgData = new unsigned char[xSize * ySize * 1];
//	dsBand1->RasterIO(GF_Read, 0, 0, xSize, ySize, imgData, xSize, ySize, type, 0, 0);
//	//KMeans(xSize, ySize, imgData);
//
//
//
//	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
//	/*driver->CreateCopy("D://testImgCPP.tif", gdalDs, 1, NULL, NULL, NULL);*/
//	GDALClose(gdalDs);
//	GDALDestroyDriverManager();
//	delete[] imgData;
//	system("pause");
//	return 0;
//}
#pragma endregion
#pragma region 几何校正
	////计算NCC
////将图像分割为九宫格
//vector<float>split;
//for (int j = ySizeTem / 6; j < ySizeTem; j += ySizeTem / 3)
//{
//	for (int i = xSizeTem / 6; i < xSizeTem; i += xSizeTem / 3)
//	{
//		int* pos = match_ncc(gdalDsTemplate, gdalDsImg, j, i, 30);
//			cout << "待匹配点" << j << "，" << i << "--";
   //		cout << "匹配点坐标：" << pos[0] << "，" << pos[1] << endl;
   //		split.push_back(j);
   //		split.push_back(i);
   //		split.push_back(pos[0]);
   //		split.push_back(pos[1]);
   //	}
   //}


   ////读取同名点文件
   //ifstream fs;
   //string str, tem;
   //fs.open(".//Resources//同名点.txt");
   //while (getline(fs, tem))
   //{
   //	str.append(tem);
   //};
   //fs.close();
   ////分割字符
   //vector<float>split = Split(str, ' ');

   ////构造矩阵
   //Mat A, B;
   //Mat b(1, 3, CV_32F);
   //Mat a(1, 3, CV_32F);
   //for (int i = 0; i < split.size(); i++)
   //{
   //	switch (i % 4)
   //	{
   //	case 0:
   //		b.at<float>(0, 0) = (float)1;
   //		b.at<float>(0, 1) = split[i];
   //		break;
   //	case 1:
   //		b.at<float>(0, 2) = split[i];
   //		B.push_back(b);
   //		b.empty();
   //		break;
   //	case 2:
   //		a.at<float>(0, 0) = (float)1;
   //		a.at<float>(0, 1) = split[i];
   //		break;
   //	case 3:
   //		a.at<float>(0, 2) = split[i];
   //		A.push_back(a);
   //		b.empty();
   //		break;
   //	}
   //}
   //Mat A1 = A.col(1).clone();
   //Mat A2 = A.col(2).clone();
   //Mat B1 = B.col(1).clone();
   //Mat B2 = B.col(2).clone();
   ////F2
   ////Mat X = (B.t() * B).inv() * B.t() * A1;
   ////Mat Y = (B.t() * B).inv() * B.t() * A2;
   ////F1
   //Mat x = (A.t() * A).inv() * A.t() * B1;
   //Mat y = (A.t() * A).inv() * A.t() * B2;
   ////打印参数
   //for (int i = 0; i < x.total(); i++)
   //{
   //	cout << x.at<float>(i, 0) << endl;
   //}
   //for (int i = 0; i < y.total(); i++)
   //{
   //	cout << y.at<float>(i, 0) << endl;
   //}
   ////双线性内插
   //unsigned char* result = new unsigned char[xSizeImg * ySizeImg]();
   //for (int j = 0; j < ySizeImg; j++)
   //{
   //	for (int i = 0; i < xSizeImg; i++)
   //	{
   //		float srcx = x.at<float>(0, 0) + x.at<float>(1, 0) * i + x.at<float>(2, 0) * j;
   //		float srcy = y.at<float>(0, 0) + y.at<float>(1, 0) * i + y.at<float>(2, 0) * j;

   //		int x0 = (int)floor(srcx);
   //		int y0 = (int)floor(srcy);

   //		int x1 = (int)ceil(srcx);
   //		int y1 = (int)ceil(srcy);

   //		float dx = (srcx - (int)srcx);
   //		float dy = (srcy - (int)srcy);

   //		float value = (1 - dx) * (1 - dy) * imgDataTem[exam(y0 * xSizeTem + x0)] + (1 - dx) * dy * imgDataTem[exam(y0 * xSizeTem + x1)] + dx * (1 - dy) * imgDataTem[exam(y1 * xSizeTem + x0)] + dx * dy * imgDataTem[exam(y1 * xSizeTem + x1)];
   //		result[j * xSizeImg + i] = round(value);
   //	}

   //}  
#pragma endregion

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



	//得到的特征点个数：
	//500 => 500
	//1000 => (627, 128)(645, 128)

	//KNN-NNDR特征匹配
	//Ptr<DescriptorMatcher> matcher = DescriptorMatcher::create(DescriptorMatcher::BRUTEFORCE);
	//vector<vector<DMatch> > knn_matches;
	//const float ratio_thresh = 0.7f;
	//vector<DMatch> matches;
	//matcher->knnMatch(dsc1, dsc2, knn_matches, 2);
	//for (auto& knn_matche : knn_matches) {
	//	if (knn_matche[0].distance < ratio_thresh * knn_matche[1].distance) {
	//		matches.push_back(knn_matche[0]);
	//	}
	//}


	//BFMatch匹配
	BFMatcher matcher(NORM_L2);
	//定义匹配结果变量
	vector<DMatch> matches;
	//实现描述符之间的匹配
	matcher.match(dsc1, dsc2, matches);


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



	//结束计时
	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;

	waitKey(0);
	destroyAllWindows();
	system("pause");
	return;
}

