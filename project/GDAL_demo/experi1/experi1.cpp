#include <iostream>
#include <time.h>
#include <algorithm>
#include <numeric>
#include <vector>
#include <cmath>

#include "../experi1/include/gdal_priv.h"
#include "../experi1/include/gdal.h"
#include "../cpp1/include/gdalwarper.h"
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
	GDALDataset* gdalDsImg = (GDALDataset*)GDALOpen(".//Resources//ds.tif", GA_ReadOnly);
	if (gdalDsImg == NULL)
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
	unsigned char* imgData = new unsigned char[xSize * ySize];
	dsBandImg->RasterIO(GF_Read, 0, 0, xSize, ySize, imgData, xSize, ySize, typeImg, 0, 0);

	unsigned char* result = new unsigned char[xSize * ySize]();


	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* res = driver->Create(".//Resources//result.tif", xSize, ySize, 1, typeImg, NULL);
	res->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, result, xSize, ySize, GDT_Byte, 0, 0, NULL);




	//设置地理参考变换及投影信息
	res->SetGeoTransform(geotrans);
	res->SetProjection(projectRef);
	//释放内存
	delete[] imgData;
	delete[] result;
	GDALClose(gdalDsImg);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}






