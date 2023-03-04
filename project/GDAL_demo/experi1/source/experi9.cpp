#include <iostream>
#include <time.h>
#include <algorithm>
#include <vector>
#include <cmath>

#include "../experi1/include/gdal_priv.h"
#include "../experi1/include/gdal.h"
#include "../cpp1/include/gdalwarper.h"

using namespace std;

/// <summary>
/// 计算每个类的聚类中心
/// </summary>
/// <param name="dsImg"></param>
/// <param name="dsLabel"></param>
/// <returns></returns>
vector<vector<int>> ClassMean(GDALDataset* dsImg, GDALDataset* dsLabel)
{
	int bandCount = dsImg->GetRasterCount();
	//用一个多维数组存储多个波段的中心
	vector<vector<int>> means(bandCount);
	int xSize = dsImg->GetRasterXSize();
	int ySize = dsImg->GetRasterYSize();


	for (size_t b = 1; b <= bandCount; b++)
	{
		unsigned char* labelData = new unsigned char[xSize * ySize]();
		dsLabel->GetRasterBand(b)->RasterIO(GF_Read, 0, 0, xSize, ySize, labelData, xSize, ySize, GDT_Byte, 0, 0, NULL);

		unsigned char* ImgData = new unsigned char[xSize * ySize]();
		dsImg->GetRasterBand(b)->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgData, xSize, ySize, GDT_Byte, 0, 0, NULL);

		vector<int> num(5);
		vector<int> sum(5);
		for (size_t j = 0; j < ySize; j++)
		{
			for (size_t i = 0; i < xSize; i++)
			{
				int index = j * xSize + i;
				switch ((unsigned short)labelData[index])
				{
				case 0:
					sum.at(0) += ImgData[index];
					num.at(0)++;
					break;
				case 50:
					sum.at(1) += ImgData[index];
					num.at(1)++;
					break;
				case 100:
					sum.at(2) += ImgData[index];
					num.at(2)++;
					break;
				case 150:
					sum.at(3) += ImgData[index];
					num.at(3)++;
					break;
				case 200:
					sum.at(4) += ImgData[index];
					num.at(4)++;
					break;
				default:
					break;
				}
			}
		}
		//遍历完一个波段后计算其均值
		for (size_t i = 0; i < num.size(); i++)
		{
			if (num.at(i) != 0)
			{
				means.at(b - 1).push_back((float)sum.at(i) / num.at(i));
			}
			else
			{
				throw "这个类没有任何像元";
			}
		}
		delete[] ImgData;
	}
	return means;
}


/// <summary>
/// 求每类方差
/// </summary>
/// <param name="dsImg"></param>
/// <param name="dsLabel"></param>
/// <param name="means"></param>
/// <returns></returns>
vector<vector<float>> ClassVariance(GDALDataset* dsImg, GDALDataset* dsLabel, vector<vector<int>> means)
{
	int bandCount = dsImg->GetRasterCount();
	vector<vector<float>> variance(3);
	int xSize = dsImg->GetRasterXSize();
	int ySize = dsImg->GetRasterYSize();

	vector<int> num(5);
	vector<long> sum(5);

	for (size_t b = 1; b <= bandCount; b++)
	{
		unsigned char* labelData = new unsigned char[xSize * ySize]();
		dsLabel->GetRasterBand(b)->RasterIO(GF_Read, 0, 0, xSize, ySize, labelData, xSize, ySize, GDT_Byte, 0, 0, NULL);

		unsigned char* ImgData = new unsigned char[xSize * ySize]();
		dsImg->GetRasterBand(b)->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgData, xSize, ySize, GDT_Byte, 0, 0, NULL);

		for (size_t j = 0; j < ySize; j++)
		{
			for (size_t i = 0; i < xSize; i++)
			{
				int index = j * xSize + i;
				switch ((unsigned short)labelData[index])
				{
				case 0:
					sum[0] += pow(ImgData[index] - means[b - 1][0], 2);
					num[0]++;
					break;
				case 50:
					sum[1] += pow(ImgData[index] - means[b - 1][1], 2);
					num[1]++;
					break;
				case 100:
					sum[2] += pow(ImgData[index] - means[b - 1][2], 2);
					num[2]++;
					break;
				case 150:
					sum[3] += pow(ImgData[index] - means[b - 1][3], 2);
					num[3]++;
					break;
				case 200:
					sum[4] += pow(ImgData[index] - means[b - 1][4], 2);
					num[4]++;
					break;
				default:
					break;
				}
			}
		}

		for (size_t i = 0; i < num.size(); i++)
		{
			if (num[i] != 0)
				variance[b - 1].push_back((float)sum[i] / num[i]);
		}
	}
	return variance;
}


/// <summary>
/// 分类精度评定
/// </summary>
/// <param name="ySize"></param>
/// <param name="xSize"></param>
/// <param name="imgDataRef"></param>
/// <param name="imgData"></param>
void PrecisionJudge(int xSize, int ySize, unsigned char* imgDataRef, unsigned char* imgData)
{
	vector<vector<int>> num(5, vector<int>(5));

	//构成混淆矩阵
	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			if (imgData[index] == imgDataRef[index])
			{
				for (size_t ii = 0; ii < num.size(); ii++)
				{
					if ((unsigned short)imgData[index] / 50 == ii)
					{
						num[ii][ii]++;
						ii = INT_MAX;
					}
				}
			}
			else if (imgData[index] > imgDataRef[index])
			{
				switch ((unsigned short)imgData[index])
				{
				case 50:
					num[0][1]++;
					break;
				case 100:
					if (imgDataRef[index] == 0)
						num[0][2]++;
					else
						num[1][2]++;
					break;
				case 150:
					if (imgDataRef[index] == 0)
						num[0][3]++;
					else if (imgDataRef[index] == 50)
						num[1][3]++;
					else
						num[2][3]++;
					break;
				case 200:
					if (imgDataRef[index] == 0)
						num[0][4]++;
					else if (imgDataRef[index] == 50)
						num[1][4]++;
					else if (imgDataRef[index] == 100)
						num[2][4]++;
					else
						num[3][4]++;
					break;
				default:
					break;
				}
			}
			else
			{
				switch ((unsigned short)imgDataRef[index])
				{
				case 50:
					num[1][0]++;
					break;
				case 100:
					if (imgData[index] == 0)
						num[2][0]++;
					else
						num[2][1]++;
					break;
				case 150:
					if (imgData[index] == 0)
						num[3][0]++;
					else if (imgData[index] == 50)
						num[3][1]++;
					else
						num[3][2]++;
					break;
				case 200:
					if (imgData[index] == 0)
						num[4][0]++;
					else if (imgData[index] == 50)
						num[4][1]++;
					else if (imgData[index] == 100)
						num[4][2]++;
					else
						num[4][3]++;
					break;
				default:
					break;
				}
			}

		}
	}


	int sum = 0;
	int T = 0;
	vector<int> A(4);
	vector<int> B(4);
	//打印输出混淆矩阵
	cout << endl << "混淆矩阵：" << endl;
	for (size_t i = 0; i < num.size(); i++)
	{
		for (size_t j = 0; j < num[0].size(); j++)
		{
			cout << num[i][j] << "	";
			if (j == num.size() - 1)
			{
				cout << endl;
			}
			if (i == j)
			{
				T += num[i][j];
			}
			sum += num[i][j];
			if (i < 4 && j < 4)
			{
				A[i] += num[i][j];
				B[j] += num[i][j];
			}
		}
	}

	float pe = (float)(A[0] * B[0] + A[1] * B[1] + A[2] * B[2] + A[3] * B[3]) / T / T;
	cout << "总体精度：" << (float)T / sum << endl;
	cout << "Kappa系数：" << (((float)T / sum) - pe) / ((float)1 - pe) << endl;
	cout << "用户精度：" << endl;
	for (size_t i = 0; i < A.size(); i++)
	{
		cout << (float)num[0][i] / A[i] << endl;
	}
	cout << "制图精度：" << endl;
	for (size_t i = 0; i < B.size(); i++)
	{
		cout << (float)num[i][0] / B[i] << endl;
	}
}



/***********************最小距离法*************************/


/// <summary>
/// 最小距离分类
/// </summary>
/// <param name="dsSrc"></param>
/// <param name="means"></param>
/// <returns></returns>
unsigned char* TestClassification(GDALDataset* dsSrc, vector<vector<int>> means)
{
	int xSize = dsSrc->GetRasterXSize();
	int ySize = dsSrc->GetRasterYSize();

	unsigned char* classNum = new unsigned char[xSize * ySize]();

	unsigned char* ImgDataR = new unsigned char[xSize * ySize]();
	unsigned char* ImgDataG = new unsigned char[xSize * ySize]();
	unsigned char* ImgDataB = new unsigned char[xSize * ySize]();
	dsSrc->GetRasterBand(1)->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgDataR, xSize, ySize, GDT_Byte, 0, 0, NULL);
	dsSrc->GetRasterBand(2)->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgDataG, xSize, ySize, GDT_Byte, 0, 0, NULL);
	dsSrc->GetRasterBand(3)->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgDataB, xSize, ySize, GDT_Byte, 0, 0, NULL);


	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			int num = 0;
			float min = 256;
			for (size_t n = 0; n < means[0].size(); n++)
			{
				float eu = sqrt(pow((means[0][n] - ImgDataR[index]), 2) + pow((means[1][n] - ImgDataG[index]), 2) + pow((means[2][n] - ImgDataB[index]), 2));
				if (eu < min)
				{
					min = eu;
					num = n;
				}
			}
			classNum[index] = unsigned char(num * 50);
		}
	}
	delete[] ImgDataR;
	delete[] ImgDataG;
	delete[] ImgDataB;
	return classNum;
}



/***********************最大似然法*************************/



/// <summary>
/// 最大似然分类
/// </summary>
/// <param name="dsSrc"></param>
/// <param name="means"></param>
/// <param name="variance"></param>
/// <returns></returns>
unsigned char* TestClassification(GDALDataset* dsSrc, vector<vector<int>> means, vector<vector<float>> variance)
{
	int xSize = dsSrc->GetRasterXSize();
	int ySize = dsSrc->GetRasterYSize();

	unsigned char* p = new unsigned char[xSize * ySize]();

	GDALRasterBand* bandR = dsSrc->GetRasterBand(1);
	GDALRasterBand* bandG = dsSrc->GetRasterBand(2);
	GDALRasterBand* bandB = dsSrc->GetRasterBand(3);
	unsigned char* ImgDataR = new unsigned char[xSize * ySize]();
	unsigned char* ImgDataG = new unsigned char[xSize * ySize]();
	unsigned char* ImgDataB = new unsigned char[xSize * ySize]();
	bandR->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgDataR, xSize, ySize, GDT_Byte, 0, 0, NULL);
	bandG->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgDataG, xSize, ySize, GDT_Byte, 0, 0, NULL);
	bandB->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgDataB, xSize, ySize, GDT_Byte, 0, 0, NULL);

	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			float max = 0;
			int classNum;
			for (size_t n = 0; n < means[0].size(); n++)
			{
				float valueR = exp(-0.5 * pow(ImgDataR[index] - means[0][n], 2) / variance[0][n]) / pow(6.2831852, 5 / 2) / pow(variance[0][n], 0.5);
				float valueG = exp(-0.5 * pow(ImgDataG[index] - means[1][n], 2) / variance[1][n]) / pow(6.2831852, 5 / 2) / pow(variance[1][n], 0.5);
				float valueB = exp(-0.5 * pow(ImgDataB[index] - means[2][n], 2) / variance[2][n]) / pow(6.2831852, 5 / 2) / pow(variance[2][n], 0.5);
				float value = valueR + valueG + valueB;
				if (value > max)
				{
					max = value;
					classNum = n;
				}
			}
			p[index] += (unsigned char)classNum * 50;
		}
	}
	delete[] ImgDataR;
	delete[] ImgDataG;
	delete[] ImgDataB;
	return p;
}


int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
	GDALDataset* gdalDsImg = (GDALDataset*)GDALOpen(".//Resources//train.tiff", GA_ReadOnly);
	if (gdalDsImg == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsLabel = (GDALDataset*)GDALOpen(".//Resources//train_label.tiff", GA_ReadOnly);
	if (gdalDsLabel == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsSrc = (GDALDataset*)GDALOpen(".//Resources//test.tiff", GA_ReadOnly);
	if (gdalDsLabel == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsRes = (GDALDataset*)GDALOpen(".//Resources//test_label.tiff", GA_ReadOnly);
	if (gdalDsRes == NULL)
	{
		return 0;
	}
	//读取列宽以及行高
	int xSize = gdalDsImg->GetRasterXSize();
	std::cout << "img列宽：" << xSize << std::endl;
	int ySize = gdalDsImg->GetRasterYSize();
	std::cout << "img行高：" << ySize << std::endl;
	//波段数
	std::cout << "img波段数：" << gdalDsImg->GetRasterCount() << std::endl;
	std::cout << "label波段数：" << gdalDsLabel->GetRasterCount() << std::endl;
	//地理参考变换信息
	double geotrans[6];
	gdalDsImg->GetGeoTransform(geotrans);
	//投影信息
	const char* projectRef = gdalDsImg->GetProjectionRef();
	//读取波段
	GDALRasterBand* dsBandImg = gdalDsImg->GetRasterBand(1);
	//读取变量类型
	GDALDataType typeImg = dsBandImg->GetRasterDataType();
	std::cout << "img数据类型：" << typeImg << std::endl;
	//读取数据
	unsigned char* imgDataRef = new unsigned char[xSize * ySize];
	gdalDsRes->GetRasterBand(1)->RasterIO(GF_Read, 0, 0, xSize, ySize, imgDataRef, xSize, ySize, typeImg, 0, 0);

	//计算均值和方差
	vector<vector<int>> means = ClassMean(gdalDsImg, gdalDsLabel);
	vector<vector<float>> variance = ClassVariance(gdalDsImg, gdalDsLabel, means);
	//最小距离分类
	unsigned char* classNum = TestClassification(gdalDsSrc, means);
	//最大似然分类
	//unsigned char* classNum = TestClassification(gdalDsSrc, means, variance);

	//分类精度评定
	PrecisionJudge(xSize, ySize, imgDataRef, classNum);


	//输出影像
	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* res = driver->Create(".//Resources//result.tif", xSize, ySize, 1, GDT_Byte, NULL);
	res->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, classNum, xSize, ySize, GDT_Byte, 0, 0, NULL);




	//设置地理参考变换及投影信息
	res->SetGeoTransform(geotrans);
	res->SetProjection(projectRef);
	//释放内存
	delete[] imgDataRef;
	delete[] classNum;
	GDALClose(gdalDsImg);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}






