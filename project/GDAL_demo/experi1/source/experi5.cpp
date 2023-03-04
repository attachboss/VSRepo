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

void rgb2hsv(GDALDataset* MulDs, float* H, float* S, float* I)
{
	int xSizeMul = MulDs->GetRasterXSize();
	int ySizeMul = MulDs->GetRasterYSize();

	GDALRasterBand* dsBandR = MulDs->GetRasterBand(2);
	GDALRasterBand* dsBandG = MulDs->GetRasterBand(1);
	GDALRasterBand* dsBandB = MulDs->GetRasterBand(3);

	GDALDataType type = dsBandR->GetRasterDataType();

	unsigned short* R = new unsigned short[xSizeMul * ySizeMul]();
	unsigned short* G = new unsigned short[xSizeMul * ySizeMul]();
	unsigned short* B = new unsigned short[xSizeMul * ySizeMul]();
	dsBandR->RasterIO(GF_Read, 0, 0, xSizeMul, ySizeMul, R, xSizeMul, ySizeMul, type, 0, 0);
	dsBandG->RasterIO(GF_Read, 0, 0, xSizeMul, ySizeMul, G, xSizeMul, ySizeMul, type, 0, 0);
	dsBandB->RasterIO(GF_Read, 0, 0, xSizeMul, ySizeMul, B, xSizeMul, ySizeMul, type, 0, 0);


	for (int j = 0; j < ySizeMul; j++)
	{
		for (int i = 0; i < xSizeMul; i++)
		{
			int index = j * ySizeMul + i;
			float Min = min(R[index], min(G[index], B[index]));
			float molecule = ((R[index] - G[index]) - (R[index] - B[index])) * 0.5;
			float dominator = sqrt(abs(pow(R[index] - G[index], 2) + (R[index] - B[index]) * (G[index] - B[index])));
			float θ = acos(molecule / dominator);
			if (B[index] > G[index])
			{
				H[index] = 360 - θ * 180 / M_PI;
			}
			else
			{
				H[index] = θ * 180 / M_PI;
			}

			I[index] = 3.0 / (R[index] + G[index] + B[index]);

			S[index] = 1.0 - 3.0 / (R[index] + G[index] + B[index]) * Min;
		}
	}
	delete[] R;
	delete[] G;
	delete[] B;
};

double Hue2RGB(double v1, double v2, double vH)
{
	if (vH < 0) vH += 1;
	if (vH > 1) vH -= 1;
	if (6.0 * vH < 1) return v1 + (v2 - v1) * 6.0 * vH;
	if (2.0 * vH < 1) return v2;
	if (3.0 * vH < 2) return v1 + (v2 - v1) * ((2.0 / 3.0) - vH) * 6.0;
	return (v1);
}

void hsv2rgb(GDALDataset* res, float* H, float* S, float* I)
{
	int xSizeMul = res->GetRasterXSize();
	int ySizeMul = res->GetRasterYSize();

	GDALRasterBand* dsBandR = res->GetRasterBand(2);
	GDALRasterBand* dsBandG = res->GetRasterBand(1);
	GDALRasterBand* dsBandB = res->GetRasterBand(3);

	GDALDataType type = dsBandR->GetRasterDataType();
	unsigned short* R = new unsigned short[xSizeMul * ySizeMul];
	unsigned short* G = new unsigned short[xSizeMul * ySizeMul];
	unsigned short* B = new unsigned short[xSizeMul * ySizeMul];

	for (int j = 0; j < ySizeMul; j++)
	{
		for (int i = 0; i < xSizeMul; i++)
		{
			int index = j * xSizeMul + i;
			float v1, v2;
			if (S[index] == 0)
			{
				R[index] = (unsigned short)round(I[index] * 255.0);
				G[index] = (unsigned short)round(I[index] * 255.0);
				B[index] = (unsigned short)round(I[index] * 255.0);
			}
			else
			{
				if (I[index] < 0.5) v2 = I[index] * (1 + S[index]);
				else v2 = (I[index] + S[index]) - (I[index] * S[index]);

				v1 = 2.0 * I[index] - v2;
				H[index] /= 360;

				R[index] = (unsigned short)round(255.0 * Hue2RGB(v1, v2, H[index] + (1.0 / 3.0)));
				G[index] = (unsigned short)round(255.0 * Hue2RGB(v1, v2, H[index]));
				B[index] = (unsigned short)round(255.0 * Hue2RGB(v1, v2, H[index] - (1.0 / 3.0)));
			}
		}
	}

	dsBandR->RasterIO(GF_Write, 0, 0, xSizeMul, ySizeMul, R, xSizeMul, ySizeMul, type, 0, 0);
	dsBandG->RasterIO(GF_Write, 0, 0, xSizeMul, ySizeMul, G, xSizeMul, ySizeMul, type, 0, 0);
	dsBandB->RasterIO(GF_Write, 0, 0, xSizeMul, ySizeMul, B, xSizeMul, ySizeMul, type, 0, 0);
};

void MapResize(GDALDataset* srcDs, GDALDataset* refDs, GDALDataset* resize)
{
	int bandCount = srcDs->GetRasterCount();

	int xSizeS = srcDs->GetRasterXSize();
	int ySizeS = srcDs->GetRasterYSize();

	int xSizeR = refDs->GetRasterXSize();
	int ySizeR = refDs->GetRasterYSize();

	float ax = xSizeR / xSizeS;
	float ay = ySizeR / ySizeS;


	for (int b = 1; b <= bandCount; b++)
	{
		GDALRasterBand* bandS = srcDs->GetRasterBand(b);
		GDALDataType typeS = bandS->GetRasterDataType();

		//事先知道格式
		unsigned short* imgData = new unsigned short[xSizeS * ySizeS]();
		unsigned short* imgDataNew = new unsigned short[xSizeR * ySizeR]();

		bandS->RasterIO(GF_Read, 0, 0, xSizeS, ySizeS, imgData, xSizeS, ySizeS, typeS, 0, 0);
		for (int j = 0; j < ySizeR; j++)
		{
			for (int i = 0; i < xSizeR; i++)
			{
				int x = (int)round(j / ax);
				int y = (int)round(i / ay);

				int index = j * xSizeR + i;
				int dex = x * xSizeS + y;
				imgDataNew[index] = imgData[dex];
			}
		}
		resize->GetRasterBand(b)->RasterIO(GF_Write, 0, 0, xSizeR, ySizeR, imgDataNew, xSizeR, ySizeR, typeS, 0, 0, NULL);
		delete[] imgData;
		delete[] imgDataNew;
	}
};



int main()
{
	clock_t start, end;
	start = clock();
	//注册驱动
	GDALAllRegister();
	//路径支持中文
	CPLSetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
	GDALDataset* gdalDsFc = (GDALDataset*)GDALOpen(".//Resources//全色.tif", GA_ReadOnly);
	if (gdalDsFc == NULL)
	{
		return 0;
	}
	GDALDataset* gdalDsMul = (GDALDataset*)GDALOpen(".//Resources//多光谱.tif", GA_ReadOnly);
	if (gdalDsMul == NULL)
	{
		return 0;
	}
	//读取列宽以及行高
	int xSizeFc = gdalDsFc->GetRasterXSize();
	std::cout << "img列宽：" << xSizeFc << std::endl;
	int ySizeFc = gdalDsFc->GetRasterYSize();
	std::cout << "img行高：" << ySizeFc << std::endl;
	int xSizeMul = gdalDsMul->GetRasterXSize();
	std::cout << "多光谱图像列宽：" << xSizeMul << std::endl;
	int ySizeMul = gdalDsMul->GetRasterYSize();
	std::cout << "多光谱图像行高：" << ySizeMul << std::endl;
	//波段数
	std::cout << "img波段数：" << gdalDsFc->GetRasterCount() << std::endl;
	std::cout << "多光谱图像波段数：" << gdalDsMul->GetRasterCount() << std::endl;
	//地理参考变换信息
	double geotrans[6];
	gdalDsFc->GetGeoTransform(geotrans);
	//投影信息
	const char* projectRef = gdalDsFc->GetProjectionRef();
	//读取波段
	GDALRasterBand* dsBand1 = gdalDsFc->GetRasterBand(1);
	GDALRasterBand* dsBand2 = gdalDsMul->GetRasterBand(1);
	//读取变量类型
	GDALDataType type1 = dsBand1->GetRasterDataType();
	std::cout << "波段输入数据类型：" << type1 << std::endl;
	GDALDataType type2 = dsBand2->GetRasterDataType();
	std::cout << "波段输入数据类型：" << type2 << std::endl;
	//读取数据
	unsigned char* imgDataFc = new unsigned char[xSizeFc * ySizeFc];
	dsBand1->RasterIO(GF_Read, 0, 0, xSizeFc, ySizeFc, imgDataFc, xSizeFc, ySizeFc, type1, 0, 0);


	//调整多光谱图像分辨率
	GDALDriver* driver = GetGDALDriverManager()->GetDriverByName("GTiff");
	GDALDataset* resizeMul = driver->Create(".//Resources//resize.tif", xSizeFc, ySizeFc, 3, GDT_UInt16, NULL);
	MapResize(gdalDsMul, gdalDsFc, resizeMul);

	xSizeMul = resizeMul->GetRasterXSize();
	ySizeMul = resizeMul->GetRasterYSize();

	float* H = new float[xSizeMul * ySizeMul]();
	float* S = new float[xSizeMul * ySizeMul]();
	float* I = new float[xSizeMul * ySizeMul]();

	//RGB => HIS
	rgb2hsv(resizeMul, H, S, I);


	//灰度值替换
	for (int j = 0; j < ySizeFc; j++)
	{
		for (int i = 0; i < xSizeFc; i++)
		{
			int index = j * xSizeFc + i;
			I[index] = (float)(imgDataFc[index] / 255.0);
		}
	}

	//HIS => RGB逆变换
	hsv2rgb(resizeMul, H, S, I);

	//设置地理参考变换及投影信息
	resizeMul->SetGeoTransform(geotrans);
	resizeMul->SetProjection(projectRef);
	//释放内存
	delete[] imgDataFc;
	delete[] H;
	delete[] S;
	delete[] I;
	GDALClose(gdalDsFc);
	GDALClose(gdalDsMul);
	GDALDestroyDriverManager();

	end = clock();
	std::cout << "计时：*******" << double(end - start) / CLOCKS_PER_SEC * 1000 << "ms" << std::endl;
	std::system("pause");
	return 0;
}




