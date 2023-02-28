#include <iostream>
#include <boost/thread/thread.hpp>


#include<pcl/visualization/cloud_viewer.h>//pcl可视化
#include <pcl/visualization/pcl_visualizer.h>

#include<pcl/io/io.h>
#include<pcl/io/pcd_io.h>//pcd 读写类相关的头文件。
#include<pcl/io/ply_io.h>

#include<pcl/point_types.h> //PCL中支持的点类型头文件。
#include<pcl/point_cloud.h>

#include<pcl/kdtree/kdtree_flann.h>
#include<pcl/octree/octree.h>

#include <pcl/filters/passthrough.h>//直通滤波
#include <pcl/filters/voxel_grid.h>//体素滤波
#include <pcl/filters/statistical_outlier_removal.h>//SOR滤波

#include <pcl/console/parse.h>	//读取输入

using namespace pcl;
using namespace std;


/// <summary>
/// 回调函数，主函数注册后只执行一次
/// </summary>
/// <param name="viewer"></param>
void viewerOneOff(visualization::PCLVisualizer& viewer)
{
	viewer.setBackgroundColor(0, 0, 0);
}

/// <summary>
/// 回调，主函数注册后每帧执行
/// </summary>
/// <param name="viewer"></param>
void viewerPsycho(visualization::PCLVisualizer& viewer)
{
	static unsigned count = 0;
	std::stringstream ss;
	ss << "Once per viewer loop: " << count++;
	viewer.removeShape("text", 0);
	viewer.addText(ss.str(), 200, 300, "text", 0);
}



int main(int argc, char** argv)
{
	//error C2065 : ‘pop_t‘
	//错误双击，进入dist.h文件，进行修改，将503行代码移动到480行前面
	// 
	//报错：C2116和C2733
	//预处理器定义
	//_CRT_SECURE_NO_WARNINGS
	//_SCL_SECURE_NO_WARNINGS
	//_SILENCE_FPOS_SEEKPOS_DEPRECATION_WARNING
	//NOMINMAX
	//BOOST_USE_WINDOWS_H
	//
	//Flann冲突
	//注意添加include路径顺序， 先pcl库后opencv
	//加::作用域运算符
	//
	//error C4996: vtkMapper::ImmediateModeRenderingOff
	//解决办法：将sdl选择否

	PointCloud<PointXYZ>::Ptr cloud(new PointCloud<PointXYZ>);


	//从输入读取pcd文件
	//vector<int> fileNames;
	//fileNames = console::parse_file_extension_argument(argc, argv, "*.pcd");
	//io::loadPCDFile(argv[fileNames[0]], *cloud);


	char strfilepath[256] = "chef.pcd";
	//将数据读到共享指针中
	if (io::loadPCDFile(strfilepath, *cloud) == -1) {
		cout << "error input!" << endl;
		return -1;
	};


#pragma region 写入点云
	////写入点云
	//PointCloud<PointXYZ> cloud2;
	//cloud2.width = 10;
	//cloud2.height = 2;
	//cloud2.is_dense = false;
	// //更改大小后需要调用resize函数
	//cloud2.resize(cloud2.width * cloud2.height);
	//for (int i = 0; i < cloud2.width * cloud2.height; i++)
	//{
	//	//随机[0, 1024)
	//	cloud2.points[i].x = 1024 * rand() / (RAND_MAX + 1.0f);
	//	cloud2.points[i].y = 1024 * rand() / (RAND_MAX + 1.0f);
	//	cloud2.points[i].z = 1024 * rand() / (RAND_MAX + 1.0f);
	//}
	////保存数据
	//io::savePCDFileASCII("output.pcd", cloud2);  
#pragma endregion
#pragma region kdtree
	//KdTreeFLANN<PointXYZ> kdtree;
	////设置搜索范围
	//kdtree.setInputCloud(cloud);
	////随机生成查询点
	//PointXYZ searchPoint;
	//searchPoint.x = 1024 * rand() / (RAND_MAX + 1.0f);
	//searchPoint.y = 1024 * rand() / (RAND_MAX + 1.0f);
	//searchPoint.z = 1024 * rand() / (RAND_MAX + 1.0f);
	// 
	////K临近数量为10
	//int K = 10;
	//vector<int> pointIdxKNNSearch(K);
	//vector<float> pointKNNSquareDistance(K);
	//if (kdtree.nearestKSearch(searchPoint, K, pointIdxKNNSearch, pointKNNSquareDistance) > 0)
	//{
	//	cout << "(" << searchPoint.x << "," << searchPoint.y << "," << searchPoint.z << ") K = " << K << "邻域搜索结果：" << endl;
	//	for (size_t i = 0; i < pointIdxKNNSearch.size(); i++)
	//	{
	//		cout << cloud->points[pointIdxKNNSearch[i]].x << "," << cloud->points[pointIdxKNNSearch[i]].y << "," << cloud->points[pointIdxKNNSearch[i]].z << endl;
	//	}
	//}
	// 
	////半径内近邻搜索
	//float radius = 256.0f * rand() / (RAND_MAX + 1.0f);
	//vector<int> pointIdxRadiusSearch;
	//vector<float> pointRadiusSquareDistance;
	//if (kdtree.radiusSearch(searchPoint, radius, pointIdxRadiusSearch, pointRadiusSquareDistance) > 0)
	//{
	//	cout << "(" << searchPoint.x << "," << searchPoint.y << "," << searchPoint.z << ") Radius = " << radius << " 邻域搜索结果：" << endl;
	//	for (size_t i = 0; i < pointIdxRadiusSearch.size(); i++)
	//	{
	//		cout << cloud->points[pointIdxRadiusSearch[i]].x << "," << cloud->points[pointIdxRadiusSearch[i]].y << "," << cloud->points[pointIdxRadiusSearch[i]].z << endl;
	//	}
	//}
#pragma endregion
#pragma region octree
	//最低级八叉树的最小体素尺寸
	//float resolution = 128.0f;
	//octree::OctreePointCloudSearch<PointXYZ> octree(resolution);
	//octree.setInputCloud(cloud);
	//octree.addPointsFromInputCloud();
	////随机生成查询点
	//PointXYZ searchPoint;
	//searchPoint.x = 1024.0f * rand() / (RAND_MAX + 1.0f);
	//searchPoint.y = 1024.0f * rand() / (RAND_MAX + 1.0f);
	//searchPoint.z = 1024.0f * rand() / (RAND_MAX + 1.0f);
	//vector<int> pointIdxVoxel;
	//if (octree.voxelSearch(searchPoint, pointIdxVoxel))
	//{
	//	cout << "(" << searchPoint.x << "," << searchPoint.y << "," << searchPoint.z << "体素近邻搜索结果：" << endl;
	//	for (size_t i = 0; i < pointIdxVoxel.size(); i++)
	//	{
	//		cout << cloud->points[pointIdxVoxel[i]].x << "," << cloud->points[pointIdxVoxel[i]].y << "," << cloud->points[pointIdxVoxel[i]].z << endl;
	//	}
	//}
	// 
	////K近邻搜索
	//int K = 10;
	//vector<int> pointIdxKNNSearch(K);
	//vector<float> pointKNNSquareDistance(K);
	//if (octree.nearestKSearch(searchPoint, K, pointIdxKNNSearch, pointKNNSquareDistance) > 0)
	//{
	//	cout << "(" << searchPoint.x << "," << searchPoint.y << "," << searchPoint.z << ") K = " << K << "邻域搜索结果：" << endl;
	//	for (size_t i = 0; i < pointIdxKNNSearch.size(); i++)
	//	{
	//		cout << cloud->points[pointIdxKNNSearch[i]].x << "," << cloud->points[pointIdxKNNSearch[i]].y << "," << cloud->points[pointIdxKNNSearch[i]].z << endl;
	//	}
	//}
	// 
	//半径内近邻搜索
	//float radius = 256.0f * rand() / (RAND_MAX + 1.0f);
	//vector<int> pointIdxRadiusSearch;
	//vector<float> pointRadiusSquareDistance;
	//if (octree.radiusSearch(searchPoint, radius, pointIdxRadiusSearch, pointRadiusSquareDistance) > 0)
	//{
	//	cout << "(" << searchPoint.x << "," << searchPoint.y << "," << searchPoint.z << ") Radius = " << radius << " 邻域搜索结果：" << endl;
	//	for (size_t i = 0; i < pointIdxRadiusSearch.size(); i++)
	//	{
	//		cout << cloud->points[pointIdxRadiusSearch[i]].x << "," << cloud->points[pointIdxRadiusSearch[i]].y << "," << cloud->points[pointIdxRadiusSearch[i]].z << endl;
	//	}
	//}  
#pragma endregion
#pragma region 直通滤波
					////直通滤波
	//PointCloud<PointXYZ>::Ptr cloud_filtered(new PointCloud<PointXYZ>);

	//PassThrough<PointXYZ> pass;
	//pass.setInputCloud(cloud);
	//pass.setFilterFieldName("z");
	//pass.setFilterLimits(0.0, 1.0);
	//pass.filter(*cloud_filtered);  
#pragma endregion
#pragma region VoxelGrid滤波
	//使用体素化网格方式实现下采样，减少点云数据，同时保持点云形状特征
	//Voxel类在每个体素内，用体素的重心近似体素中其他的点
	//比用体素中心逼近的慢，对于采样点对应曲面的表示更准确

	////共享指针
	//PointCloud<PointXYZ>::Ptr cloudFiltered(new PointCloud<PointXYZ>);

	//cerr << "PointCloud before filtering:" << cloud->width * cloud->height << "data points(" << pcl::getFieldsList(*cloud) << ")." << std::endl;

	//VoxelGrid<PointXYZ> vox;
	//vox.setInputCloud(cloud);
	////体素大小
	//vox.setLeafSize(0.01, 0.01, 0.01);
	//vox.filter(*cloudFiltered);
	//cerr << "PointCloud after filtering:" << cloudFiltered->width * cloudFiltered->height << "data points(" << getFieldsList(*cloudFiltered) << ")." << endl;

	//io::savePCDFileASCII("output", *cloudFiltered);
#pragma endregion
#pragma region SOR滤波
	////对每一个点的邻域进行统计，将不符合标准的点删掉
	////计算它到所有临近点的平均距离，假设得到的结果呈高斯分布，那么平均距离在标准范围之外的可以被删去

	//PointCloud<PointXYZ>::Ptr cloudFiltered(new PointCloud<PointXYZ>);

	//StatisticalOutlierRemoval<PointXYZ> sor;
	//sor.setInputCloud(cloud);
	//sor.setMeanK(30);
	//sor.setStddevMulThresh(1.0);
	//sor.filter(*cloudFiltered);

	//PCDWriter writer;
	//writer.write<PointXYZ>("outputSOR.pcd", *cloudFiltered, false);
	//sor.setNegative(true);
	//sor.filter(*cloudFiltered);
	//writer.write<PointXYZ>("outputSOR.pcd", *cloudFiltered, false);
#pragma endregion
#pragma region ExtractIndices滤波
	//SAC平面参数模型提取符合几何模型的点云数据子集，利用分割算法提取符合几何平面的点云数据子集
	//利用negative变量提取剩余数据
	//剩余数据作为待处理点云循环提取

	PCLPointCloud2::Ptr cloudBlob(new PCLPointCloud2);
	PCLPointCloud2::Ptr cloudBlobFiltered(new PCLPointCloud2);
	PCDReader reader;
	reader.read("rs1.pcd", *cloudBlob);

	VoxelGrid<PCLPointCloud2> sor;
	sor.setInputCloud(cloudBlob);
	sor.setLeafSize(0.01, 0.01, 0.01);
	sor.filter(*cloudBlobFiltered);
#pragma endregion


	//可视化展示
	boost::shared_ptr<visualization::PCLVisualizer> viewer(new visualization::PCLVisualizer("3D viewer"));

	//boost::shared_ptr<visualization::PCLVisualizer> rgbVis(PointCloud<PointXYZRGB>::ConstPtr cloud);
	boost::shared_ptr<visualization::PCLVisualizer> customVis(PointCloud<PointXYZ>::ConstPtr cloud);

	//为带有RGB属性的点云赋色
	//visualization::PointCloudColorHandlerRGBField<PointXYZRGB> rgb(cloud);
	//渲染点云法线
	//viewer->addPointCloudNormals<pcl::PointXYZRGB, pcl::Normal>(cloud, normals, 10, 0.05, "normals");


	viewer->initCameraParameters();

	int v1(0);
	//viewer->createViewPort(0.0, 0.0, 0.5, 1.0, v1);
	viewer->setBackgroundColor(0, 0, 0, v1);
	visualization::PointCloudColorHandlerCustom<PointXYZ> singColor(cloud, 0, 255, 255);
	viewer->addPointCloud<PointXYZ>(cloud, singColor, "pointCloud1", v1);
	viewer->setPointCloudRenderingProperties(visualization::PCL_VISUALIZER_POINT_SIZE, 3, "pointCloud1");
	viewer->addText("Before", 10, 10, "text1", v1);

	//多窗口显示
	//int v2(0);
	//viewer->createViewPort(0.5, 0.0, 1.0, 1.0, v2);
	//viewer->setBackgroundColor(0, 0, 0, v2);
	//visualization::PointCloudColorHandlerCustom<PointXYZ> singColor2(cloudFiltered, 255, 0, 0);
	//viewer->addPointCloud<PointXYZ>(cloudFiltered, singColor2, "pointCloud2", v2);
	//viewer->setPointCloudRenderingProperties(visualization::PCL_VISUALIZER_POINT_SIZE, 3, "pointCloud2");
	//viewer->addText("After", 10, 10, "text2", v2);


	//显示坐标系统方向
	viewer->addCoordinateSystem(1.0);




	//visualization::CloudViewer viewer("Cloud Viewer");
	//viewer.showCloud(cloudFiltered);
	//viewer.runOnVisualizationThreadOnce(viewerOneOff);

	//system("pause");
	while (!viewer->wasStopped())
	{
		viewer->spinOnce(100);
		boost::this_thread::sleep(boost::posix_time::microseconds(100000));
	}
}