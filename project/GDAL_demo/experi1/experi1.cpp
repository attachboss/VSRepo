#include <iostream>
#include <time.h>
#include <algorithm>
#include <vector>
#include <cmath>
#include "experi1.h"

#include "../experi1/include/gdal_priv.h"
#include "../experi1/include/gdal.h"
#include "../cpp1/include/gdalwarper.h"
using namespace std;

vector<unsigned short> calcCVA(GDALDataset* DsBefore, GDALDataset* DsAfter)
{
	vector<unsigned short> v;

	int xSize = DsBefore->GetRasterXSize();
	int ySize = DsBefore->GetRasterYSize();

	GDALRasterBand* bandBefore1 = DsBefore->GetRasterBand(1);
	GDALRasterBand* bandBefore2 = DsBefore->GetRasterBand(2);
	GDALRasterBand* bandBefore3 = DsBefore->GetRasterBand(3);
	GDALRasterBand* bandBefore4 = DsBefore->GetRasterBand(4);
	GDALRasterBand* bandAfter1 = DsAfter->GetRasterBand(1);
	GDALRasterBand* bandAfter2 = DsAfter->GetRasterBand(2);
	GDALRasterBand* bandAfter3 = DsAfter->GetRasterBand(3);
	GDALRasterBand* bandAfter4 = DsAfter->GetRasterBand(4);
	GDALDataType type = bandBefore1->GetRasterDataType();

	unsigned short* B1 = new unsigned short[xSize * ySize]();
	unsigned short* B2 = new unsigned short[xSize * ySize]();
	unsigned short* B3 = new unsigned short[xSize * ySize]();
	unsigned short* B4 = new unsigned short[xSize * ySize]();
	unsigned short* A1 = new unsigned short[xSize * ySize]();
	unsigned short* A2 = new unsigned short[xSize * ySize]();
	unsigned short* A3 = new unsigned short[xSize * ySize]();
	unsigned short* A4 = new unsigned short[xSize * ySize]();

	bandBefore1->RasterIO(GF_Read, 0, 0, xSize, ySize, B1, xSize, ySize, type, 0, 0);
	bandBefore2->RasterIO(GF_Read, 0, 0, xSize, ySize, B2, xSize, ySize, type, 0, 0);
	bandBefore3->RasterIO(GF_Read, 0, 0, xSize, ySize, B3, xSize, ySize, type, 0, 0);
	bandBefore4->RasterIO(GF_Read, 0, 0, xSize, ySize, B4, xSize, ySize, type, 0, 0);
	bandAfter1->RasterIO(GF_Read, 0, 0, xSize, ySize, A1, xSize, ySize, type, 0, 0);
	bandAfter2->RasterIO(GF_Read, 0, 0, xSize, ySize, A2, xSize, ySize, type, 0, 0);
	bandAfter3->RasterIO(GF_Read, 0, 0, xSize, ySize, A3, xSize, ySize, type, 0, 0);
	bandAfter4->RasterIO(GF_Read, 0, 0, xSize, ySize, A4, xSize, ySize, type, 0, 0);

	for (int j = 0; j < ySize; j++)
	{
		for (int i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			double dv = sqrt(pow(B1[index] - A1[index], 2) + pow(B2[index] - A2[index], 2) + pow(B3[index] - A3[index], 2) + pow(B4[index] - A4[index], 2));
			if (dv > 255)
			{
				v.push_back(255);
			}
			else
			{
				v.push_back((unsigned short)round(dv));
			}
		}
	}
	delete[] B1;
	delete[] B2;
	delete[] B3;
	delete[] B4;
	delete[] A1;
	delete[] A2;
	delete[] A3;
	delete[] A4;

	return v;
};

unsigned short calcThreshold(int ySizeImg, int xSizeImg, std::vector<unsigned short> v)
{
	//确定阈值
	int bin[256];
	for (int c = 0; c < 256; c++)
	{
		int count = 0;
		for (int j = 0; j < ySizeImg; j++)
		{
			for (int i = 0; i < xSizeImg; i++)
			{
				int index = j * xSizeImg + i;
				if (v[index] == c)
				{
					//直方图计数
					count++;
				}
			}
		}
		bin[c] = count;
	}
	//求最大类间方差
	int total = xSizeImg * ySizeImg;
	double max = 0;
	unsigned short threshold;
	for (int c = 0; c < 256; c++)
	{
		int sumB = 0, sumF = 0, countB = 0, countF = 0;
		double avgB, avgF;
		for (int j = 0; j < ySizeImg; j++)
		{
			for (int i = 0; i < xSizeImg; i++)
			{
				int index = j * xSizeImg + i;
				if (v[index] < c)
				{
					sumB += v[index];
					countB++;
				}
				else
				{
					sumF += v[index];
					countF++;
				}
			}
		}
		if (countB == 0 || countF == 0)
		{
			continue;
		}
		avgB = (double)(sumB / countB);
		avgF = (double)(sumF / countF);
		double s = ((double)countB / total) * ((double)countF / total) * pow(avgB - avgF, 2);
		if (s > max)
		{
			max = s;
			threshold = c;
		}
	}

	return threshold;
}



int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
	GDALDataset* gdalDsRef = (GDALDataset*)GDALOpen(".//Resources//reference.tif", GA_ReadOnly);
	if (gdalDsRef == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsBefore = (GDALDataset*)GDALOpen(".//Resources//tsunami_before.tif", GA_ReadOnly);
	if (gdalDsBefore == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsAfter = (GDALDataset*)GDALOpen(".//Resources//tsunami_after.tif", GA_ReadOnly);
	if (gdalDsAfter == NULL)
	{
		return 0;
	}
	//读取列宽以及行高
	int xSizeRef = gdalDsRef->GetRasterXSize();
	std::cout << "ref列宽：" << xSizeRef << std::endl;
	int ySizeRef = gdalDsRef->GetRasterYSize();
	std::cout << "ref行高：" << ySizeRef << std::endl;
	int xSizeImg = gdalDsBefore->GetRasterXSize();
	std::cout << "img列宽：" << xSizeImg << std::endl;
	int ySizeImg = gdalDsBefore->GetRasterYSize();
	std::cout << "img行高：" << ySizeImg << std::endl;
	//波段数
	std::cout << "ref波段数：" << gdalDsRef->GetRasterCount() << std::endl;
	std::cout << "img波段数：" << gdalDsBefore->GetRasterCount() << std::endl;
	//地理参考变换信息
	double geotrans[6];
	gdalDsRef->GetGeoTransform(geotrans);
	//投影信息
	const char* projectRef = gdalDsRef->GetProjectionRef();
	//读取波段
	GDALRasterBand* dsBandRef = gdalDsRef->GetRasterBand(1);
	GDALRasterBand* dsBandBefore = gdalDsBefore->GetRasterBand(1);
	GDALRasterBand* dsBandAfter = gdalDsBefore->GetRasterBand(1);
	//读取变量类型
	GDALDataType typeRef = dsBandRef->GetRasterDataType();
	std::cout << "ref数据类型：" << typeRef << std::endl;
	GDALDataType typeImg = dsBandBefore->GetRasterDataType();
	std::cout << "img数据类型：" << typeImg << std::endl;
	//读取数据
	unsigned char* imgDataRef = new unsigned char[xSizeRef * ySizeRef];
	dsBandRef->RasterIO(GF_Read, 0, 0, xSizeRef, ySizeRef, imgDataRef, xSizeRef, ySizeRef, typeRef, 0, 0);

	//组成像元光谱向量
	vector<unsigned short> v = calcCVA(gdalDsBefore, gdalDsAfter);
	//显示光谱变化向量
	unsigned char* dv = new unsigned char[xSizeImg*ySizeImg]();
	for (int j = 0; j < ySizeImg; j++)
	{
		for (int i = 0; i < xSizeImg; i++)
		{
			int index = j * xSizeImg + i;
			dv[index] = (unsigned char)v[index];
		}
	}

	//计算阈值
	unsigned short threshold = calcThreshold(ySizeImg, xSizeImg, v);
	//输出变化检测结果
	unsigned char* result = new unsigned char[xSizeImg * ySizeImg]();
	for (int j = 0; j < ySizeImg; j++)
	{
		for (int i = 0; i < xSizeImg; i++)
		{
			int index = j * xSizeImg + i;
			if (v[index] < threshold)
			{
				result[index] = 0;
			}
			else
			{
				result[index] = 255;
			}
		}
	}


	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* res = driver->Create(".//Resources//result.tif", xSizeRef, ySizeRef, 1, GDT_Byte, NULL);
	res->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSizeImg, ySizeImg, result, xSizeImg, ySizeImg, GDT_Byte, 0, 0, NULL);

	GDALDataset* dsDv = driver->Create(".//Resources//ds.tif", xSizeRef, ySizeRef, 1, GDT_Byte, NULL);
	dsDv->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSizeImg, ySizeImg, dv, xSizeImg, ySizeImg, GDT_Byte, 0, 0, NULL);


	//设置地理参考变换及投影信息
	res->SetGeoTransform(geotrans);
	res->SetProjection(projectRef);
	//释放内存
	delete[] imgDataRef;
	delete[] dv;
	delete[] result;
	GDALClose(gdalDsRef);
	GDALClose(gdalDsBefore);
	GDALClose(gdalDsAfter);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}






