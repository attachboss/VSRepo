using OpenCvSharp;
using OSGeo.GDAL;
using OSGeo.OGR;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace gdalCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            #region GDAL
            ////添加环境变量
            //GdalConfiguration.ConfigureGdal();
            //GdalConfiguration.ConfigureOgr();
            //Gdal.AllRegister();
            //Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            //Dataset ds = Gdal.Open(@"./Resources/testImg.tif", Access.GA_ReadOnly);
            //if (ds == null)
            //{
            //    return;
            //}
            //Console.WriteLine($"图像信息：{ds.GetDescription()}");
            //string[] strs = ds.GetMetadataDomainList();
            //Console.WriteLine("元数据信息：");
            //foreach (string str in strs)
            //{
            //    Console.WriteLine(str);
            //}
            //Console.WriteLine($"列宽：{ds.RasterXSize}");
            //Console.WriteLine($"行高：{ds.RasterYSize}");
            //var dsBand1 = ds.GetRasterBand(1);
            //Console.WriteLine($"第一波段信息：{dsBand1}");
            //Console.WriteLine($"数据类型{dsBand1.DataType}");
            //Console.WriteLine($"波段数：{ds.RasterCount}");
            ////Console.WriteLine($"最大灰度值：{dsBand1.GetMaximum(out val, out hasval)}");
            ////Console.WriteLine($"最小灰度值：{dsBand1.GetMinimum(out val, out hasval)}");
            //var projRef = ds.GetProjectionRef();
            //if (projRef != null)
            //{
            //    Console.WriteLine($"投影信息：{projRef}");
            //}
            //Console.WriteLine("地理参考变换信息：");
            //double[] geotrans = new double[6];
            //ds.GetGeoTransform(geotrans);
            //for (int i = 0; i < geotrans.Length; i++)
            //{
            //    Console.WriteLine("{0:f6}", geotrans[i]);
            //}


            ////逐波段读取数据
            //byte[] buffer = new byte[ds.RasterXSize * ds.RasterYSize];
            //dsBand1.ReadRaster(0, 0, ds.RasterXSize, ds.RasterYSize, buffer, ds.RasterXSize, ds.RasterYSize, 0, 0);


            ////创建驱动
            //OSGeo.GDAL.Driver driver = Gdal.GetDriverByName("GTiff");
            ////driver.CreateCopy("D://testImgCS.tif", ds, 1, null, null, null);
            ////创建新Dataset
            //Dataset dsNew = driver.Create("D://testImgCS.tif", ds.RasterXSize, ds.RasterYSize, 1, dsBand1.DataType, null);
            //dsNew.SetGeoTransform(geotrans);
            //dsNew.SetProjection(projRef);

            ////逐波段写入数据
            //dsNew.GetRasterBand(1).WriteRaster(0, 0, ds.RasterXSize, ds.RasterYSize, buffer, ds.RasterXSize, ds.RasterYSize, 0, 0);


            //ds.FlushCache();
            //ds.Dispose();
            //dsNew.FlushCache();
            //dsNew.Dispose(); 
            #endregion
            #region CvSharp
            string path = @"D:\File\vs\project\GDAL_demo\gdalCS\Resources\ds.tif";
            Mat img = Cv2.ImRead(path, ImreadModes.Grayscale);

            //Mat img = new Mat(1000, 1000, MatType.CV_32FC1);
            //Cv2.Line(img, new Point(0, 0), new Point(30, 30), Scalar.Red, 3, LineTypes.AntiAlias, 0);

            //Cv2.NamedWindow("track");
            //Cv2.SetMouseCallback("track", (Event, x, y, flags, param) =>
            //{
            //    if (Event == MouseEventTypes.LButtonDown)
            //    {
            //        Cv2.Circle(img, new Point(x, y), 30, Scalar.Brown, 3);
            //        Cv2.ImShow("track", img);
            //    }
            //});

            //while (true)
            //{
            //    if (Cv2.WaitKey(0) == 27)
            //    {
            //        Cv2.DestroyAllWindows();
            //        break;
            //    }
            //}


            Mat img2 = Cv2.ImRead(@"D:\File\vs\project\GDAL_demo\gdalCS\Resources\1.38-地形图.png", ImreadModes.Unchanged);
            //Cv2.AddWeighted(img, 0.5, img2, 0.5, 0, img2);
            Cv2.ImShow("track", img); 
            #endregion


            Cv2.WaitKey(0);
            sw.Stop();
            Console.WriteLine($"*******耗时：{sw.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }
    }
}