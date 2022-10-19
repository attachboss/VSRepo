#include <iostream>
#include <time.h>
#include<algorithm>
#include <vector>
#include <cmath>
#include "../cpp1/include/gdal_priv.h"
#include "../cpp1/include/gdal.h"
using namespace std;

/// <summary>
/// 归一化相关系数图像匹配
/// </summary>
/// <param name="imgData"></param>
/// <param name="imgDataTem"></param>
/// <param name="xSizeImg"></param>
/// <param name="ySizeImg"></param>
/// <param name="xSizeTem"></param>
/// <param name="ySizeTem"></param>
/// <returns>返回索引以零开始的匹配点坐标</returns>
int* match_ncc(unsigned char* imgData, unsigned char* imgDataTem, int xSizeImg, int ySizeImg, int xSizeTem, int ySizeTem)
{
	int imgLen = xSizeImg * ySizeImg;
	int temLen = xSizeTem * ySizeTem;
	int m = abs(xSizeImg - xSizeTem);
	int sum = 0;
	for (int j = 0; j < ySizeImg; j++)
	{
		for (int i = 0; i < xSizeImg; i++)
		{
			sum += imgData[j * xSizeImg + i];
		}
	}
	float imgMean = sum / imgLen;
	cout << "img均值：" << imgMean << endl;
	sum = 0;
	for (int j = 0; j < ySizeTem; j++)
	{
		for (int i = 0; i < xSizeTem; i++)
		{
			sum += imgData[j * xSizeTem + i];
		}
	}
	float temMean = sum / temLen;
	cout << "tem均值：" << temMean << endl;

	float* ncc = new float[imgLen]();
	int iIndex = 1;
	int jIndex = 1;
	float denominator = 0, moleculeA = 0, moleculeB = 0;
	for (int l = 0; l < m; l++)
	{
		for (int k = 0; k < m; k++)
		{
			for (int j = jIndex; j < xSizeTem + jIndex - 1; j++)
			{
				for (int i =iIndex; i < xSizeTem + iIndex - 1; i++)
				{
					denominator = denominator + (imgDataTem[(i - iIndex + 1) + xSizeTem * (j - jIndex + 1)] - temMean) * ((float)imgData[j * xSizeImg + i] - imgMean);
					moleculeA = moleculeA + pow(imgDataTem[(i - iIndex + 1) + xSizeTem * (j - jIndex + 1)] - temMean, 2);
					moleculeB = moleculeB + pow(imgData[j * xSizeImg + i] - imgMean, 2);
				}
			}

			float molecule = sqrt(abs(moleculeA * moleculeB));
			ncc[(iIndex + (xSizeImg - m - 1) / 2) + xSizeImg*(jIndex + (xSizeImg - m - 1) / 2)] = denominator / molecule;
			//计算完成一个NCC后清空变量值
			denominator = 0;
			moleculeA = 0;
			moleculeB = 0;
			jIndex = jIndex + 1;
		}

		iIndex = iIndex + 1;
		jIndex = 1;
	}
	float max = 0;
	int* pos = new int[2];
	for (int j = 0; j < ySizeImg; j++)
	{
		for (int i = 0; i < xSizeImg; i++)
		{
			if (ncc[j*xSizeImg +i] > max)
			{
				max = ncc[j * xSizeImg + i];
				pos[0] = i;
				pos[1] = j;
			}
		}
	}
	delete[] ncc;
	return pos;
}