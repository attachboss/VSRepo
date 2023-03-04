#include <iostream>
#include <time.h>
#include <algorithm>
#include <vector>
#include <cmath>
#include "../include/gdal_priv.h"
#include "../include/gdal.h"
#include "experi1.h"
using namespace std;

unsigned char* MeanFilter(unsigned char* imgData, int xSize, int ySize, int winSize);
unsigned char* MedianFilter(unsigned char* imgData, int xSize, int ySize, int winSize);
int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
	GDALDataset* gdalDs = (GDALDataset*)GDALOpen("D://nosieImg.tif", GA_ReadOnly);
	if (gdalDs == NULL)
	{
		return 0;
	}
	//读取列宽以及行高
	int xSize = gdalDs->GetRasterXSize();
	std::cout << "列宽：" << xSize << std::endl;
	int ySize = gdalDs->GetRasterYSize();
	std::cout << "行高：" << ySize << std::endl;
	//波段数
	std::cout << "波段数：" << gdalDs->GetRasterCount() << std::endl;
	//地理参考变换信息
	double geotrans[6];
	gdalDs->GetGeoTransform(geotrans);
	//投影信息
	const char* projectRef = gdalDs->GetProjectionRef();
	//读取第一波段
	GDALRasterBand* dsBand1 = gdalDs->GetRasterBand(1);
	std::cout << "第一波段信息：" << dsBand1 << std::endl;
	//读取变量类型
	GDALDataType type = dsBand1->GetRasterDataType();
	std::cout << "数据类型：" << type << std::endl;
	//读取影像数据
	unsigned char* imgData = new unsigned char[xSize * ySize * 1];
	dsBand1->RasterIO(GF_Read, 0, 0, xSize, ySize, imgData, xSize, ySize, type, 0, 0);

	//均值滤波
	unsigned char* result = MeanFilter(imgData, xSize, ySize, 5);
	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* newImgData = driver->Create("D://Nosie_result5_5.tif", xSize, ySize, 1, type, NULL);
	newImgData->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, result, xSize, ySize, type, 0, 0);

	//中值滤波
	/*unsigned char* result = MedianFilter(imgData, xSize, ySize, 5);
	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* newImgData = driver->Create("D://Nosie_result5-5.tif", xSize, ySize, 1, type, NULL);
	newImgData->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, result, xSize, ySize, type, 0, 0);*/

	//设置地理参考变换及投影信息
	newImgData->SetGeoTransform(geotrans);
	newImgData->SetProjection(projectRef);
	//释放内存
	delete[] imgData;
	delete[] result;
	GDALClose(gdalDs);
	GDALClose(newImgData);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	system("pause");
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