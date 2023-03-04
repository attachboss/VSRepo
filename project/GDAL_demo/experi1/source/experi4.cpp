#include <iostream>
#include <fstream>
#include <time.h>
#include <algorithm>
#include <vector>
#include <cmath>
#include "../experi1/include/gdal_priv.h"
#include "../experi1/include/gdal.h"
#include <opencv2/opencv.hpp>
#include <opencv2/core/core.hpp>
#include "experi1.h"
#include "../cpp1/include/gdalwarper.h"
using namespace std;
using namespace cv;


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



int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
	GDALDataset* gdalDsImg = (GDALDataset*)GDALOpen(".//Resources//参考影像.tif", GA_ReadOnly);
	if (gdalDsImg == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsTemplate = (GDALDataset*)GDALOpen(".//Resources//待配准.tif", GA_ReadOnly);
	if (gdalDsTemplate == NULL)
	{
		return 0;
	}
	//读取列宽以及行高
	int xSizeImg = gdalDsImg->GetRasterXSize();
	std::cout << "img列宽：" << xSizeImg << std::endl;
	int ySizeImg = gdalDsImg->GetRasterYSize();
	std::cout << "img行高：" << ySizeImg << std::endl;
	int xSizeTem = gdalDsTemplate->GetRasterXSize();
	std::cout << "template列宽：" << xSizeTem << std::endl;
	int ySizeTem = gdalDsTemplate->GetRasterYSize();
	std::cout << "template行高：" << ySizeTem << std::endl;
	//波段数
	std::cout << "img波段数：" << gdalDsImg->GetRasterCount() << std::endl;
	std::cout << "template波段数：" << gdalDsTemplate->GetRasterCount() << std::endl;
	//地理参考变换信息
	//double geotrans[6];
	//gdalDsTemplate->GetGeoTransform(geotrans);
	//投影信息
	//const char* projectRef = gdalDs->GetProjectionRef();
	//读取波段
	GDALRasterBand* dsBand1 = gdalDsImg->GetRasterBand(1);
	GDALRasterBand* dsBand2 = gdalDsTemplate->GetRasterBand(1);
	//读取变量类型
	GDALDataType type1 = dsBand1->GetRasterDataType();
	std::cout << "波段输入数据类型：" << type1 << std::endl;
	GDALDataType type2 = dsBand2->GetRasterDataType();
	std::cout << "波段输入数据类型：" << type2 << std::endl;
	//读取数据
	unsigned char* imgData = new unsigned char[xSizeImg * ySizeImg];
	dsBand1->RasterIO(GF_Read, 0, 0, xSizeImg, ySizeImg, imgData, xSizeImg, ySizeImg, type1, 0, 0);

	unsigned char* imgDataTem = new unsigned char[xSizeTem * ySizeTem];
	dsBand2->RasterIO(GF_Read, 0, 0, xSizeTem, ySizeTem, imgDataTem, xSizeTem, ySizeTem, type2, 0, 0);
	//计算NCC
	vector<float>split;
	for (int j = ySizeTem / 6; j < ySizeTem; j += ySizeTem / 3)
	{
		for (int i = xSizeTem / 6; i < xSizeTem; i += xSizeTem / 3)
		{
			int* pos = match_ncc(gdalDsTemplate, gdalDsImg, j, i, 30);
 			cout << "待匹配点" << j << "，" << i << "--";
			cout << "匹配点坐标：" << pos[0] << "，" << pos[1] << endl;
			split.push_back(j);
			split.push_back(i);
			split.push_back(pos[0]);
			split.push_back(pos[1]);
		}
	}


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

	//构造矩阵
	Mat A, B;
	Mat b(1, 3, CV_32F);
	Mat a(1, 3, CV_32F);
	for (int i = 0; i < split.size(); i++)
	{
		switch (i % 4)
		{
		case 0:
			b.at<float>(0, 0) = (float)1;
			b.at<float>(0, 1) = split[i];
			break;
		case 1:
			b.at<float>(0, 2) = split[i];
			B.push_back(b);
			b.empty();
			break;
		case 2:
			a.at<float>(0, 0) = (float)1;
			a.at<float>(0, 1) = split[i];
			break;
		case 3:
			a.at<float>(0, 2) = split[i];
			A.push_back(a);
			b.empty();
			break;
		}
	}
	Mat A1 = A.col(1).clone();
	Mat A2 = A.col(2).clone();
	Mat B1 = B.col(1).clone();
	Mat B2 = B.col(2).clone();
	//F2
	//Mat X = (B.t() * B).inv() * B.t() * A1;
	//Mat Y = (B.t() * B).inv() * B.t() * A2;
	//F1
	Mat x = (A.t() * A).inv() * A.t() * B1;
	Mat y = (A.t() * A).inv() * A.t() * B2;
	//打印参数
	for (int i = 0; i < x.total(); i++)
	{
		cout << x.at<float>(i, 0) << endl;
	}
	for (int i = 0; i < y.total(); i++)
	{
		cout << y.at<float>(i, 0) << endl;
	}

	//双线性内插
	unsigned char* result = new unsigned char[xSizeImg * ySizeImg]();
	for (int j = 0; j < ySizeImg; j++)
	{
		for (int i = 0; i < xSizeImg; i++)
		{
			float srcx = x.at<float>(0, 0) + x.at<float>(1, 0) * i + x.at<float>(2, 0) * j;
			float srcy = y.at<float>(0, 0) + y.at<float>(1, 0) * i + y.at<float>(2, 0) * j;

			int x0 = (int)floor(srcx);
			int y0 = (int)floor(srcy);

			int x1 = (int)ceil(srcx);
			int y1 = (int)ceil(srcy);

			float dx = (srcx - (int)srcx);
			float dy = (srcy - (int)srcy);

			float value = (1 - dx) * (1 - dy) * imgDataTem[exam(y0 * xSizeTem + x0)] + (1 - dx) * dy * imgDataTem[exam(y0 * xSizeTem + x1)] + dx * (1 - dy) * imgDataTem[exam(y1 * xSizeTem + x0)] + dx * dy * imgDataTem[exam(y1 * xSizeTem + x1)];
			result[j * xSizeImg + i] = round(value);
		}

	}
	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* dsRes = driver->Create(".//Resources//res.tif", xSizeImg, ySizeImg, 1, type1, NULL);
	dsRes->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSizeImg, ySizeImg, result, xSizeImg, ySizeImg, type1, 0, 0);


	//设置地理参考变换及投影信息
	dsRes->SetGeoTransform(geotrans);
	dsRes->SetProjection(projectRef);
	//释放内存
	delete[] result;
	delete[] imgData;
	delete[] imgDataTem;
	GDALClose(gdalDsImg);
	GDALClose(gdalDsTemplate);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}


