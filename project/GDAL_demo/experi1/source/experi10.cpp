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



unsigned short* initial(GDALDataset* imgIni)
{
	int xSize = imgIni->GetRasterXSize();
	int ySize = imgIni->GetRasterYSize();

	unsigned short* IX = new unsigned short[xSize * ySize];
	unsigned char* img = new unsigned char[xSize * ySize]();
	imgIni->GetRasterBand(1)->RasterIO(GF_Read, 0, 0, xSize, ySize, img, xSize, ySize, GDT_Byte, 0, 0, NULL);

	short v1 = 0;
	short v2 = 85;
	short v3 = 170;

	short v11 = 1;
	short v22 = 1;
	short v33 = 1;
	int tt = 0;

	while (tt < 50)
	{
		tt++;
		vector<short> y1;
		vector<short> y2;
		vector<short> y3;

		//初始分割
		for (size_t j = 0; j < ySize; j++)
		{
			for (size_t i = 0; i < xSize; i++)
			{
				int index = j * xSize + i;
				if (abs(img[index] - v1) < abs(img[index] - v2) && abs(img[index] - v1) < abs(img[index] - v3))
				{
					y1.push_back(img[index]);
					IX[index] = 1;
				}
				else if (abs(img[index] - v2) < abs(img[index] - v1) && abs(img[index] - v2) < abs(img[index] - v3))
				{
					y2.push_back(img[index]);
					IX[index] = 2;
				}
				else
				{
					y3.push_back(img[index]);
					IX[index] = 3;
				}
			}
		}

		double sum1 = accumulate(y1.begin(), y1.end(), 0);
		double v1 = sum1 / y1.size();

		double sum2 = accumulate(y2.begin(), y2.end(), 0);
		double v2 = sum2 / y2.size();

		double sum3 = accumulate(y3.begin(), y3.end(), 0);
		double v3 = sum3 / y3.size();

		vector<double> tem;
		tem.push_back(abs(v1 - v11) / v11);
		tem.push_back(abs(v2 - v22) / v22);
		tem.push_back(abs(v3 - v33) / v33);

		if (*max_element(tem.begin(), tem.end()) < 0.005)
		{
			break;
		}
		else
		{
			v11 = v1;
			v22 = v2;
			v33 = v3;
		}

	}
	delete[] img;
	return IX;
}

vector<vector<short>> histogram(unsigned short* IX, unsigned char* img, int xSize, int ySize)
{
	vector<short> y1;
	vector<short> y2;
	vector<short> y3;

	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			if (IX[index] == 1)
			{
				y1.push_back(img[index]);
			}
			else if (IX[index] == 2)
			{
				y2.push_back(img[index]);
			}
			else
			{
				y3.push_back(img[index]);
			}
		}
	}
	return { y1, y2, y3 };
}

int deta(int x, int y)
{
	if (x == y)
		return 1;
	else
		return 0;
}

vector<float*> changfenbu(unsigned short* IX, unsigned char* img, int xSize, int ySize)
{
	float* temp = new  float[xSize * ySize]();
	float* temp1 = new float[xSize * ySize]();
	float* temp2 = new float[xSize * ySize]();
	float* temp3 = new float[xSize * ySize]();

	float β = 1;
	float* σμ = new float[xSize * ySize];

	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			for (size_t m = 0; m < 3; m++)
			{
				temp[index] = temp[index] + deta(m, IX[index]) - 1;
				σμ[index] = exp(β * temp[index] + σμ[index]);

				if (m == 1)
					temp1[index] = temp[index];
				if (m == 2)
					temp2[index] = temp[index];
				if (m == 3)
					temp3[index] = temp[index];
				temp[index] = 0;

			}
		}
	}

	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			temp1[index] = exp(β * temp1[index]) / σμ[index];
			temp2[index] = exp(β * temp2[index]) / σμ[index];
			temp3[index] = exp(β * temp3[index]) / σμ[index];
		}
	}

	delete[] temp;
	return { temp1, temp2, temp3 };
}

float stdY2(vector<short>& y, std::vector<unsigned short>& means)
{
	long sum = 0;
	for (size_t i = 0; i < y.size(); i++)
	{
		sum += pow(y[i] - means[0], 2);
	}
	return (float)sum / y.size();
}

unsigned short meanY(vector<short>& y)
{
	long sum = 0;
	for (size_t i = 0; i < y.size(); i++)
	{
		sum += y[i];
	}
	return (short)round((float)sum / y.size());
}

vector<float*> qiujunzhifangcha(vector<vector<short>> yy, unsigned char* img, int xSize, int ySize)
{
	vector<unsigned short> means(3);
	vector<float> stds(3);

	float* guass1 = new float[xSize * ySize]();
	float* guass2 = new float[xSize * ySize]();
	float* guass3 = new float[xSize * ySize]();

	means[0] = meanY(yy[0]);
	means[1] = meanY(yy[1]);
	means[2] = meanY(yy[2]);
	stds[0] = stdY2(yy[0], means);
	stds[1] = stdY2(yy[1], means);
	stds[2] = stdY2(yy[2], means);
	vector<float> std2 = { 2 * (float)pow(stds[0], 2), 2 * (float)pow(stds[1], 2) , 2 * (float)pow(stds[2], 2) };

	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			guass1[index] = exp(-(img[index] - means[0]) * ((img[index] - means[0]) / (std2[0]))) / (sqrt(2 * 3.1415926) * abs(stds[0])) + 0.2;
			guass2[index] = exp(-(img[index] - means[1]) * ((img[index] - means[1]) / (std2[1]))) / (sqrt(2 * 3.1415926) * abs(stds[1]));
			guass3[index] = exp(-(img[index] - means[2]) * ((img[index] - means[2]) / (std2[2]))) / (sqrt(2 * 3.1415926) * abs(stds[2]));
		}
	}
	return { guass1, guass2, guass3 };
}

unsigned short* classification(int xSize, int ySize, vector<float*> stru, vector<float*> guass, unsigned short* IX)
{
	unsigned short* IX1 = new unsigned short[xSize * ySize]();
	vector<float*> temp1(3, new float[xSize * ySize]);
	//先验概率乘后验概率
	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			for (size_t k = 0; k < stru.size(); k++)
			{
				temp1[k][index] = stru[k][index] * guass[k][index];
			}
		}
	}
	for (size_t j = 0; j < ySize; j++)
	{
		for (size_t i = 0; i < xSize; i++)
		{
			int index = j * xSize + i;
			float tem = max(max(temp1[0][index], temp1[1][index]), temp1[2][index]);
			for (size_t k = 0; k < stru.size(); k++)
			{
				if (tem == temp1[k][index])
				{
					IX1[index] = k + 1;
				}
			}
			if (IX[index] == IX1[index])
				IX[index] = IX1[index];
			else
				IX[index] = IX1[index];
		}
	}

	return IX;
}

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

	unsigned char* IMMM = new unsigned char[xSize * ySize]();
	int I = 0;
	int times = 20;
	unsigned short* IX = initial(gdalDsImg);

	while (true)
	{
		I++;
		cout << I << endl;
		vector<vector<short>> yy = histogram(IX, imgData, xSize, ySize);
		vector<float*> stru = changfenbu(IX, imgData, xSize, ySize);
		vector<float*> guass = qiujunzhifangcha(yy, imgData, xSize, ySize);
		IX = classification(xSize, ySize, stru, guass, IX);

		for (size_t j = 0; j < ySize; j++)
		{
			for (size_t i = 0; i < xSize; i++)
			{
				int index = j * xSize + i;
				if (IX[index] == 3)
					IMMM[index] = (unsigned char)255;
				else
					IMMM[index] = (unsigned char)0;
			}
		}
		if (I == 20)
			break;
	}


	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* res = driver->Create(".//Resources//result.tif", xSize, ySize, 1, typeImg, NULL);
	res->GetRasterBand(1)->RasterIO(GF_Write, 0, 0, xSize, ySize, IMMM, xSize, ySize, GDT_Byte, 0, 0, NULL);




	//设置地理参考变换及投影信息
	res->SetGeoTransform(geotrans);
	res->SetProjection(projectRef);
	//释放内存
	delete[] imgData;
	GDALClose(gdalDsImg);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}






