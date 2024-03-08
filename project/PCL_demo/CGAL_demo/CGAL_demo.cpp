#include <string>
#include <vector>
#include <cstdlib>
#include <fstream>
#include <iostream>
#include <iterator>
#include <Eigen/Core>
#include <CGAL/Exact_predicates_inexact_constructions_kernel.h>
#include <CGAL/Point_set_3.h>
#include <CGAL/Point_set_3/IO.h>
#include <CGAL/remove_outliers.h>
#include <CGAL/grid_simplify_point_set.h>
#include <CGAL/jet_smooth_point_set.h>
#include <CGAL/jet_estimate_normals.h>
#include <CGAL/mst_orient_normals.h>
#include <CGAL/poisson_surface_reconstruction.h>
#include <CGAL/Advancing_front_surface_reconstruction.h>
#include <CGAL/Scale_space_surface_reconstruction_3.h>
#include <CGAL/Scale_space_reconstruction_3/Jet_smoother.h>
#include <CGAL/Scale_space_reconstruction_3/Advancing_front_mesher.h>
#include <CGAL/Surface_mesh.h>
#include <CGAL/Polygon_mesh_processing/polygon_soup_to_polygon_mesh.h>
#include <boost/iterator/function_output_iterator.hpp>
#include <CGAL/Timer.h>
#include <CGAL/Random.h>
#include <CGAL/Shape_detection/Region_growing/Region_growing.h>
#include <CGAL/Shape_detection/Region_growing/Region_growing_on_point_set.h>


//typedef CGAL::Exact_predicates_inexact_constructions_kernel Kernel;
//typedef Kernel::FT FT;
//typedef Kernel::Point_3 Point_3;
//typedef Kernel::Vector_3 Vector_3;
//typedef Kernel::Sphere_3 Sphere_3;
//typedef CGAL::Point_set_3<Point_3, Vector_3> Point_set;
//#define CGAL_EIGEN3_ENABLED

using Kernel = CGAL::Exact_predicates_inexact_constructions_kernel;
using FT = typename Kernel::FT;
using Point_3 = typename Kernel::Point_3;
using Vector_3 = typename Kernel::Vector_3;
using Input_range = CGAL::Point_set_3<Point_3>;
using Point_map = typename Input_range::Point_map;
using Normal_map = typename Input_range::Vector_map;
using Neighbor_query = CGAL::Shape_detection::Point_set::K_neighbor_query<Kernel, Input_range, Point_map>;
using Region_type = CGAL::Shape_detection::Point_set::Least_squares_plane_fit_region<Kernel, Input_range, Point_map, Normal_map>;
using Region_growing = CGAL::Shape_detection::Region_growing<Input_range, Neighbor_query, Region_type>;
using Indices = std::vector<std::size_t>;
using Output_range = CGAL::Point_set_3<Point_3>;
using Points_3 = std::vector<Point_3>;

// 定义一个迭代器
struct Insert_point_colored_by_region_index {
	using argument_type = Indices;
	using result_type = void;
	using Color_map = typename Output_range:: template Property_map<unsigned char>;


	const Input_range& m_input_range;//输入
	const   Point_map  m_point_map;//point.map
	Output_range& m_output_range;//输出
	std::size_t& m_number_of_regions;//输出种类

	Color_map m_red, m_green, m_blue;
	Insert_point_colored_by_region_index(const Input_range& input_range, const   Point_map  point_map,
		Output_range& output_range, std::size_t& number_of_regions) :
		m_input_range(input_range),
		m_point_map(point_map),
		m_output_range(output_range),
		m_number_of_regions(number_of_regions)
	{
		m_red = m_output_range.template add_property_map<unsigned char>("red", 0).first;
		m_green = m_output_range.template add_property_map<unsigned char>("green", 0).first;
		m_blue = m_output_range.template add_property_map<unsigned char>("blue", 0).first;
	}
	result_type operator()(const argument_type& region)
	{
		CGAL::Random rand(static_cast<unsigned int>(m_number_of_regions));
		const unsigned char r = static_cast<unsigned char>(64 + rand.get_int(0, 192));
		const unsigned char g = static_cast<unsigned char>(64 + rand.get_int(0, 192));
		const unsigned char b = static_cast<unsigned char>(64 + rand.get_int(0, 192));

		for (const std::size_t index : region)
		{
			const auto& key = *(m_input_range.begin() + index);
			const Point_3& point = get(m_point_map, key);
			const auto it = m_output_range.insert(point);
			m_red[*it] = r;
			m_green[*it] = g;
			m_blue[*it] = b;
		}
		++m_number_of_regions;
	}
};

int main(int argc, char* argv[])
{
	//    //通过专用容器来处理具有附加属性(法向量等)的点云
	//    Point_set points;
	//    std::string fname = argc == 1 ? CGAL::data_file_path("./data/140.xyz") : argv[1];
	//    if (argc < 2)
	//    {
	//        std::cerr << "Usage: " << argv[0] << " [input.xyz/off/ply/las]" << std::endl;
	//        std::cerr << "Running " << argv[0] << " data/kitten.xyz -1\n";
	//    }
	//    std::ifstream stream(fname, std::ios_base::binary);
	//    if (!stream)    {
	//        std::cerr << "Error: cannot read file " << fname << std::endl;
	//        return EXIT_FAILURE;
	//    }
	//    stream >> points;
	//    std::cout << "Read " << points.size() << " point(s)" << std::endl;
	//    if (points.empty())
	//        return EXIT_FAILURE;
	//
	//
	//    //异常值过滤
	//    typename Point_set::iterator rout_it = CGAL::remove_outliers<CGAL::Sequential_tag>
	//        (points,
	//            24, // 计算中需要考虑的领域中的点
	//            points.parameters().threshold_percent(5.0)); // 需要过滤的异常值百分比
	//    points.remove(rout_it, points.end());
	//    std::cout << points.number_of_removed_points()
	//        << " point(s) are outliers." << std::endl;
	//    // Applying point set processing algorithm to a CGAL::Point_set_3
	//    // object does not erase the points from memory but place them in
	//    // the garbage of the object: memory can be freeed by the user.
	//    points.collect_garbage();
	//
	//
	//    //简化点云
	//    double spacing = CGAL::compute_average_spacing<CGAL::Sequential_tag>(points, 6);
	//    typename Point_set::iterator gsim_it = CGAL::grid_simplify_point_set(points, 2. * spacing);
	//    points.remove(gsim_it, points.end());
	//    std::cout << points.number_of_removed_points()
	//        << " point(s) removed after simplification." << std::endl;
	//    points.collect_garbage();
	//
	//    //平滑
	//    CGAL::jet_smooth_point_set<CGAL::Sequential_tag>(points, 24);
	//
	//
	//    int reconstruction_choice
	//        = argc == 1 ? -1 : (argc < 3 ? 0 : atoi(argv[2]));
	//    if (reconstruction_choice == 0 || reconstruction_choice == -1) // 泊松算法
	//    {
	//        // 估计法线
	//        CGAL::jet_estimate_normals<CGAL::Sequential_tag>
	//            (points, 24);
	//        // 定位法线
	//        typename Point_set::iterator unoriented_points_begin =
	//            CGAL::mst_orient_normals(points, 24);
	//        points.remove(unoriented_points_begin, points.end());
	//
	//        // 需要法线，并产生闭合平滑曲面
	//        CGAL::Surface_mesh<Point_3> output_mesh;
	//        CGAL::poisson_surface_reconstruction_delaunay
	//        (points.begin(), points.end(),
	//            points.point_map(), points.normal_map(),
	//            output_mesh, spacing);
	//        // 输出重建结果
	//        std::ofstream f("out_poisson.ply", std::ios_base::binary);
	//        CGAL::IO::set_binary_mode(f);
	//        CGAL::IO::write_PLY(f, output_mesh);
	//        f.close();
	//    }
	//    if (reconstruction_choice == 1 || reconstruction_choice == -1) // 前进算法
	//    {
	//        typedef std::array<std::size_t, 3> Facet;
	//        std::vector<Facet> facets;
	//        // 不需法线和封闭， 但对噪声敏感
	//        CGAL::advancing_front_surface_reconstruction(points.points().begin(),
	//            points.points().end(),
	//            std::back_inserter(facets));
	//        std::cout << facets.size()
	//            << " facet(s) generated by reconstruction." << std::endl;
	//        
	//
	//        std::vector<Point_3> vertices;
	//        vertices.reserve(points.size());
	//        std::copy(points.points().begin(), points.points().end(), std::back_inserter(vertices));
	//        CGAL::Surface_mesh<Point_3> output_mesh;
	//        CGAL::Polygon_mesh_processing::polygon_soup_to_polygon_mesh(vertices, facets, output_mesh);
	//        std::ofstream f("out_af.off");
	//        f << output_mesh;
	//        f.close();
	//    }
	//    if (reconstruction_choice == 2 || reconstruction_choice == -1) // 尺度空间
	//    {
	//        // 多次平滑构建尺度空间
	//        CGAL::Scale_space_surface_reconstruction_3<Kernel> reconstruct
	//        (points.points().begin(), points.points().end());
	//        reconstruct.increase_scale(4, CGAL::Scale_space_reconstruction_3::Jet_smoother<Kernel>());
	//        // Mesh with the Advancing Front mesher with a maximum facet length of 0.5
	//
	//        reconstruct.reconstruct_surface(CGAL::Scale_space_reconstruction_3::Advancing_front_mesher<Kernel>(0.5));
	//        std::ofstream f("out_sp.off");
	//        f << "OFF" << std::endl << points.size() << " "
	//            << reconstruct.number_of_facets() << " 0" << std::endl;
	//        for (Point_set::Index idx : points)
	//            f << points.point(idx) << std::endl;
	//        for (const auto& facet : CGAL::make_range(reconstruct.facets_begin(), reconstruct.facets_end()))
	//            f << "3 " << facet.at(0) << std::endl;
	//        f.close();
	//    }
	//    else
	//    {
	//        std::cerr << "Error: invalid reconstruction id: " << reconstruction_choice << std::endl;
	//        return EXIT_FAILURE;
	//    }
	//    return EXIT_SUCCESS;


	//读取点云
	std::ifstream in(argc > 1 ? argv[1] : CGAL::data_file_path("./data/cube.xyz"));
	CGAL::IO::set_ascii_mode(in);
	if (!in) {
		std::cout <<
			"Error: cannot read the file point_set_3.xyz!" << std::endl;
		std::cout <<
			"You can either create a symlink to the data folder or provide this file by hand."
			<< std::endl << std::endl;
		return EXIT_FAILURE;
	}
	//插入法线
	const bool with_normal_map = true;
	Input_range input_range(with_normal_map);
	in >> input_range;
	in.close();
	std::cout << "* loaded " << input_range.size() << " points with normals" << std::endl;


	//默认参数设置
	const std::size_t k = 12;
	const FT          max_distance_to_plane = FT(1);
	const FT          max_accepted_angle = FT(20);
	const std::size_t min_region_size = 200;


	//区域增长
	Neighbor_query neighbor_query(input_range, k, input_range.point_map());
	Region_type region_type(input_range, max_distance_to_plane, max_accepted_angle, min_region_size, input_range.point_map(), input_range.normal_map());
	Region_growing region_growing(input_range, neighbor_query, region_type);
	Output_range output_range;

	std::size_t number_of_regions = 0;
	Insert_point_colored_by_region_index inserter(input_range, input_range.point_map(), output_range, number_of_regions);

	CGAL::Timer timer;
	timer.start();
	region_growing.detect(boost::make_function_output_iterator(inserter));
	timer.stop();
	std::cout << "* " << number_of_regions << " regions have been found in " << timer.time() << " seconds" << std::endl;



	if (argc > 2) {
		const std::string path = argv[2];
		const std::string fullpath = path + "regions_point_set_3.ply";
		std::ofstream out(fullpath);
		out << output_range;
		std::cout << "* found regions are saved in " << fullpath << std::endl;
		out.close();
	}

	return EXIT_SUCCESS;
}