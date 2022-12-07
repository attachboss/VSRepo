#include <iostream>
#include <time.h>
#include <algorithm>
#include <vector>
#include <cmath>

#include "../experi1/include/gdal_priv.h"
#include "../experi1/include/gdal.h"
#include "../cpp1/include/gdalwarper.h"
using namespace std;

vector<vector<int>> ClassMean(GDALDataset* dsImg, GDALDataset* dsLabel)
{
	//用一个多维数组存储多个波段的中心
	vector<vector<int>> means(3);
	int bandCount = dsImg->GetRasterCount();
	int xSize = dsImg->GetRasterXSize();
	int ySize = dsImg->GetRasterYSize();

	unsigned char* labelData = new unsigned char[xSize * ySize]();
	dsLabel->GetRasterBand(1)->RasterIO(GF_Read, 0, 0, xSize, ySize, labelData, xSize, ySize, GDT_Byte, 0, 0, NULL);

	for (size_t b = 1; b <= bandCount; b++)
	{
		GDALRasterBand* band = dsImg->GetRasterBand(b);
		unsigned char* ImgData = new unsigned char[xSize * ySize]();
		band->RasterIO(GF_Read, 0, 0, xSize, ySize, ImgData, xSize, ySize, GDT_Byte, 0, 0, NULL);

		vector<int> num(5);
		vector<int> sum(5);
		for (size_t j = 0; j < ySize; j++)
		{
			for (size_t i = 0; i < xSize; i++)
			{
				int index = j * xSize + j;
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
			for (size_t n = 1; n <= means.at(0).size(); n++)
			{
				float eu = sqrt(pow((means.at(0).at(n - 1) - ImgDataR[index]), 2) + pow((means.at(1).at(n - 1) - ImgDataG[index]), 2) + pow((means.at(2).at(n - 1) - ImgDataB[index]), 2));
				if (eu < min)
				{
					min = eu;
					num = n;
				}
			}
			try
			{
				classNum[index] = unsigned char(num * 50);
				//cout << classNum[index] << endl;
			}
			catch (const std::exception&)
			{
				system("pause");
			}
		}
	}
	delete[] ImgDataR;
	delete[] ImgDataG;
	delete[] ImgDataB;
	return classNum;
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

	vector<vector<int>> means = ClassMean(gdalDsImg, gdalDsLabel);
	unsigned char* classNum = TestClassification(gdalDsSrc, means);

	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* res = driver->Create(".//Resources//result.tif", xSize, ySize, 1, GDT_Byte, NULL);
	res->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, classNum, xSize, ySize, GDT_Byte, 0, 0, NULL);




	//设置地理参考变换及投影信息
	res->SetGeoTransform(geotrans);
	res->SetProjection(projectRef);
	//释放内存
	delete[] imgData;
	delete[] classNum;
	GDALClose(gdalDsImg);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}






