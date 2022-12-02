#include <iostream>

#include<pcl/visualization/cloud_viewer.h>

#include<pcl/io/io.h>
#include<pcl/io/pcd_io.h>//pcd 读写类相关的头文件。
#include<pcl/io/ply_io.h>

#include<pcl/point_types.h> //PCL中支持的点类型头文件。
#include<pcl/point_cloud.h>

#include<pcl/kdtree/kdtree_flann.h>
#include<pcl/octree/octree.h>

#include <pcl/filters/passthrough.h>

using namespace pcl;
using namespace std;

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

void viewerOneOff(visualization::PCLVisualizer& viewer)
{
	viewer.setBackgroundColor(0, 0, 0);
}

int main()
{
	PointCloud<PointXYZ>::Ptr cloud(new PointCloud<PointXYZ>);
	char strfilepath[256] = "chef.pcd";
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
	//cloud2.resize(cloud2.width * cloud2.height);
	//for (int i = 0; i < cloud2.width * cloud2.height; i++)
	//{
	//	//[0, 1024)
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



	//可视化展示
	visualization::CloudViewer viewer("Cloud Viewer");
	viewer.showCloud(cloud);
	viewer.runOnVisualizationThreadOnce(viewerOneOff);
	cout << cloud->width << "," << cloud->height << endl;

	system("pause");
}