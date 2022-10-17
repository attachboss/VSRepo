#include <iostream>
#include <time.h>
#include<algorithm>
#include <vector>
#include <cmath>
#include "../cpp1/include/gdal_priv.h"
#include "../cpp1/include/gdal.h"
#include "experi1.h"
using namespace std;

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
int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
	GDALDataset* gdalDs = (GDALDataset*)GDALOpen("D://test.tif", GA_ReadOnly);
	if (gdalDs == NULL)
	{
		return 0;
	}
	//读取列宽以及行高
	int xSize = gdalDs->GetRasterXSize();
	std::cout << "列宽：" << xSize << std::endl;
	int ySize = gdalDs->GetRasterYSize();
	std::cout << "行高：" << ySize << std::endl;
	//读取波段
	GDALRasterBand* dsBand1 = gdalDs->GetRasterBand(4);
	GDALRasterBand* dsBand2 = gdalDs->GetRasterBand(3);
	//读取变量类型
	GDALDataType type1 = dsBand1->GetRasterDataType();
	std::cout << "第一波段输入数据类型：" << type1 << std::endl;
	GDALDataType type2 = dsBand2->GetRasterDataType();
	std::cout << "第一波段输入数据类型：" << type2 << std::endl;
	//读取第一波段影像数据
	unsigned short* imgDataNir = new unsigned short[xSize * ySize];
	dsBand1->RasterIO(GF_Read, 0, 0, xSize, ySize, imgDataNir, xSize, ySize, type1, 0, 0);
	//读取第二波段影像数据
	unsigned short* imgData = new unsigned short[xSize * ySize];
	dsBand2->RasterIO(GF_Read, 0, 0, xSize, ySize, imgData, xSize, ySize, type2, 0, 0);
	//计算NDVI
	float* result = calcNDVI(imgData, imgDataNir, xSize, ySize);
	//保存输出影像
	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* newImgData = driver->Create("D://vegetable.tif", xSize, ySize, 1, GDT_Float32, NULL);
	newImgData->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, (void*)result, xSize, ySize, GDT_Float32, 0, 0);






	//释放内存
	GDALClose(gdalDs);
	GDALClose(newImgData);
	GDALDestroyDriverManager();
	delete[]imgData;
	delete[]imgDataNir;
	delete[] result;

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	system("pause");
}