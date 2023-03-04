#include <iostream>
#include <fstream>
#include <time.h>
#include <algorithm>
#include <vector>
#include <cmath>
#include "experi1.h"

#include "../experi1/include/gdal_priv.h"
#include "../experi1/include/gdal.h"
#include "../cpp1/include/gdalwarper.h"
using namespace std;


void PrecisionJudge(unsigned char* imgDataRef, unsigned char* imgData, int xSize, int ySize)
{
	//分类计数
	int N11 = 0, N12 = 0, N21 = 0, N22 = 0;
	//255为变化，0为未变化
	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			if (imgDataRef[index] == imgData[index])
			{
				if (imgData[index] == (unsigned char)255)
				{
					N11++;
				}
				else
				{
					N22++;
				}
			}
			else if (imgData[index] == (unsigned char)255)
			{
				N12++;
			}
			else if (imgData[index] == (unsigned char)0)
			{
				N21++;
			}
		}
	}
	int A = N11 + N21;
	int B = N12 + N22;
	int C = N11 + N12;
	int D = N21 + N22;
	int T = N11 + N12 + N21 + N22;

	//输出为txt文件
	//char path[] = ".//Resources//res.txt";
	//ofstream fout;
	//fout.open(path);
	//fout << "漏检率：" << (float)N21 / A << endl;
	//fout << "虚警率：" << (float)N12 / C << endl;
	//fout << "总分类精度：" << (float)(N11 + N22) / T << endl;
	//fout << "Kappa系数：" << (float)((N11 + N22) - (A * C + B * D) / T) / (T - (A * C + B * D) / T) << endl;
	//fout.close();

	cout << "漏检率：" << (float)N21 / A << endl;
	cout << "虚警率：" << (float)N12 / C << endl;
	cout << "总分类精度：" << (float)(N11 + N22) / T << endl;
	cout << "Kappa系数：" << (float)((N11 + N22) - (A * C + B * D) / T) / (T - (A * C + B * D) / T) << endl;
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
	GDALDataset* gdalDsSrc = (GDALDataset*)GDALOpen(".//Resources//result.tif", GA_ReadOnly);
	if (gdalDsSrc == NULL)
	{
		return 0;
	}
	//读取列宽以及行高
	int xSizeRef = gdalDsRef->GetRasterXSize();
	std::cout << "ref列宽：" << xSizeRef << std::endl;
	int ySizeRef = gdalDsRef->GetRasterYSize();
	std::cout << "ref行高：" << ySizeRef << std::endl;
	int xSizeImg = gdalDsSrc->GetRasterXSize();
	std::cout << "img列宽：" << xSizeImg << std::endl;
	int ySizeImg = gdalDsSrc->GetRasterYSize();
	std::cout << "img行高：" << ySizeImg << std::endl;
	//波段数
	std::cout << "ref波段数：" << gdalDsRef->GetRasterCount() << std::endl;
	std::cout << "img波段数：" << gdalDsSrc->GetRasterCount() << std::endl;
	//地理参考变换信息
	// double geotrans[6];
	// gdalDsRef->GetGeoTransform(geotrans);
	//投影信息
	// const char* projectRef = gdalDsRef->GetProjectionRef();
	//读取波段
	GDALRasterBand* dsBandRef = gdalDsRef->GetRasterBand(1);
	GDALRasterBand* dsBandSrc = gdalDsSrc->GetRasterBand(1);
	//读取变量类型
	GDALDataType typeRef = dsBandRef->GetRasterDataType();
	std::cout << "ref数据类型：" << typeRef << std::endl;
	GDALDataType typeImg = dsBandSrc->GetRasterDataType();
	std::cout << "img数据类型：" << typeImg << std::endl;
	//读取数据
	unsigned char* imgDataRef = new unsigned char[xSizeRef * ySizeRef];
	dsBandRef->RasterIO(GF_Read, 0, 0, xSizeRef, ySizeRef, imgDataRef, xSizeRef, ySizeRef, typeRef, 0, 0);

	unsigned char* imgData = new unsigned char[xSizeImg * ySizeImg]();
	dsBandSrc->RasterIO(GF_Read, 0, 0, xSizeImg, ySizeImg, imgData, xSizeImg, ySizeImg, typeImg, 0, 0);

	PrecisionJudge(imgDataRef, imgData, xSizeImg, ySizeImg);







	//释放内存
	delete[] imgDataRef;
	delete[] imgData;
	GDALClose(gdalDsRef);
	GDALClose(gdalDsSrc);

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}






