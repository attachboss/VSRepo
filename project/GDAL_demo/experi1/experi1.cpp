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


/// <summary>
/// K均值聚类
/// </summary>
/// <param name="xSize"></param>
/// <param name="ySize"></param>
/// <param name="imgData"></param>
/// <param name="resClass"></param>
/// <returns></returns>
vector<int> KMeans(int xSize, int ySize, unsigned char* imgData, int* resClass)
{
	const int n = 3;
	const int maxLoopNum = 6;

	vector<int> z0;
	vector<int> z0_x;
	vector<int> z0_y;

	int* sum = new int[n]();;
	int* num = new int[n]();;
	int* euclidean = new int[n]();

	for (int k = 0; k < n; k++)
	{
		//随机聚类中心坐标
		// x/y = [0,512)
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

	//进行循环
	for (int i = 0; i < maxLoopNum; i++)
	{
		for (int j = 0; j < ySize; j++)
		{
			for (int k = 0; k < xSize; k++)
			{
				int index = xSize * j + k;
				int temp = 256;
				int nNum;
				for (int ii = 0; ii < n; ii++)
				{
					euclidean[ii] = abs(imgData[index] - z0[ii]);
					if (euclidean[ii] <= temp)
					{
						temp = euclidean[ii];
						nNum = ii;
					}
				}
				sum[nNum] += imgData[index];
				num[nNum] ++;
				resClass[index] = nNum;
			}
		};

		//判断是否满足跳出条件
		int flag = 0;
		for (int j = 0; j < n; j++)
		{
			int temp;
			temp = (int)round((float)sum[j] / num[j]);
			if (z0[j] == temp)
			{
				flag++;
				if (flag == n)
				{
					return z0;
				}
			}
			//清空变量
			z0[j] = temp;
			sum[j] = 0;
			num[j] = 0;
		};
	};
}

int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
	GDALDataset* gdalDsImg = (GDALDataset*)GDALOpen(".//Resources//testImg.tif", GA_ReadOnly);
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

	int* resClass = new int[xSize * ySize];
	//K均值聚类
	vector<int> z0 = KMeans(xSize, ySize, imgData, resClass);

	//每一类灰度值用聚类中心灰度代替
	unsigned char* result = new unsigned char[xSize * ySize]();
	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			for (size_t c = 0; c < z0.size(); c++)
			{
				if (resClass[index] == c)
				{
					result[index] = (unsigned char)z0[c];
				}

			}
		}
	}

	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* res = driver->Create(".//Resources//result.tif", xSize, ySize, 1, GDT_Byte, NULL);
	res->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, result, xSize, ySize, GDT_Byte, 0, 0, NULL);




	//设置地理参考变换及投影信息
	res->SetGeoTransform(geotrans);
	res->SetProjection(projectRef);
	//释放内存
	delete[] imgData;
	delete[] result;
	delete[] resClass;
	GDALClose(gdalDsImg);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}






