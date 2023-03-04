#include <iostream>
#include <time.h>
#include <algorithm>
#include <vector>
#include <cmath>
#include "../cpp1/include/gdal_priv.h"
#include "../cpp1/include/gdal.h"
#include "experi1.h"
using namespace std;



int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
	GDALDataset* gdalDsImg = (GDALDataset*)GDALOpen("D://img.tif", GA_ReadOnly);
	if (gdalDsImg == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsTemplate = (GDALDataset*)GDALOpen("D://template.tif", GA_ReadOnly);
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
	//gdalDs->GetGeoTransform(geotrans);
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
	int* pos = match_ncc(imgData, imgDataTem, xSizeImg, ySizeImg, xSizeTem, ySizeTem);
	cout << "匹配点坐标：" << pos[0] << "，" << pos[1] << endl;



	//释放内存
	delete[] imgData;
	delete[] imgDataTem;
	GDALClose(gdalDsImg);
	GDALClose(gdalDsTemplate);

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	system("pause");
}