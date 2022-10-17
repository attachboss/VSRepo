#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <iomanip>
#include <vector>
#include <cmath>
#include <gdal.h>
#include <gdal_priv.h>
#include "cpp1.h"
using namespace std;

#define BYTE float
int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
	GDALDataset* gdalDs = (GDALDataset*)GDALOpen("D://testImg.tif", GA_ReadOnly);
	if (gdalDs == NULL)
	{
		return 0;
	}
	std::cout << "图像信息：" << gdalDs->GetDescription() << std::endl;
	char** str = gdalDs->GetMetadataDomainList();
	std::cout << "元数据信息：" << str << std::endl;
	int xSize = gdalDs->GetRasterXSize();
	std::cout << "列宽：" << xSize << std::endl;
	int ySize = gdalDs->GetRasterYSize();
	std::cout << "行高：" << ySize << std::endl;
	//波段起始值为1
	GDALRasterBand* dsBand1 = gdalDs->GetRasterBand(1);
	std::cout << "第一波段信息：" << dsBand1 << std::endl;
	GDALDataType type = dsBand1->GetRasterDataType();
	std::cout << "数据类型：" << type << std::endl;
	//std::cout << "波段数：" << gdalDs->GetRasterCount() << std::endl;
	std::cout << "最小灰度值：" << dsBand1->GetMinimum() << std::endl;
	std::cout << "最大灰度值：" << dsBand1->GetMaximum() << std::endl;
	if (gdalDs->GetProjectionRef() != NULL)
	{
		std::cout << "投影信息：" << gdalDs->GetProjectionRef() << std::endl;
	}
	std::cout << "地理参考变换信息：" << std::endl;
	//	GetGeoTransform[0] /* 左上角X坐标 */
	//	GetGeoTransform[1] /* 西-东 方向像素分辨率 */
	//	GetGeoTransform[2] /* 0 无关*/
	//	GetGeoTransform[3] /* 左上角Y坐标 */
	//	GetGeoTransform[4] /* 0 无关*/
	//	GetGeoTransform[5] /* 北-南 方向像素分辨率(前面加负号) */
	//建立影像与地理坐标之间的关系
	double geotrans[6];
	gdalDs->GetGeoTransform(geotrans);
	for (int i = 0; i < 6; i++)
	{
		printf("%.6f\n", geotrans[i]);
	};

	unsigned char* imgData = new unsigned char[xSize * ySize * 1];
	dsBand1->RasterIO(GF_Read, 0, 0, xSize, ySize, imgData, xSize, ySize, type, 0, 0);
	//KMeans(xSize, ySize, imgData);
	OGRSpatialReference spatialRef;
	spatialRef.SetWellKnownGeogCS("WGS84");



	/*GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	driver->CreateCopy("D://testImgCPP.tif", gdalDs, 1, NULL, NULL, NULL);*/
	GDALClose(gdalDs);
	GDALDestroyDriverManager();
	delete[] imgData;
	//结束计时
	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;

	system("pause");
	return 0;
}

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
		//[0,511]
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
