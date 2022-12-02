// using System;
using System.Collections; //集合、泛型
using System.Data; //数据库
using System.Net;
using System.Text;
using System.Text.RegularExpressions;//正则
using System.Security.Cryptography; //MD5
using System.Reflection;//反射
using System.Diagnostics;
using Common.http;
using log4net.Config;
using log4net;
using log4net.Repository.Hierarchy;
using System.Drawing;
using Microsoft.Extensions.DependencyInjection;
using ConfigServices;
using MailServices;
using Microsoft.Extensions.Configuration;

namespace MyNote
{
    public class MyNote
    {

        static void Main(string[] args)
        {
            #region 23种设计模式
            //六大原则

            //1.单一职责原则SRP
            //  一个类只负责一件事，减少代码修改
            //  成本：增多了类
            //   如果类相对稳定，逻辑简单，扩展变化少，可违背单一
            //   不同的职责总是一起变化，则要分开

            //2.里氏替换原则LSP
            //  任何使用基类的地方，都可以透明地使用子类
            //  安全：使用父类的地方，换成子类后依然可以用
            //  不推荐用new隐藏父类中的普通方法，因为编译时确定的类型调用的不一定是设想的方法

            //3.依赖倒置原则DIP
            //  最常用
            //  高层模块不应该依赖低层模块，应该通过抽象依赖
            //  面向抽象，底层最好都是 抽象类/接口
            //  用于扩展变化

            //4.接口隔离原则ISP
            //  客户端不该依赖不需要的接口
            //  对另一个类的依赖应该建立在最小的接口上
            //  把不同接口隔离开，方便重用、维护

            //5.迪米特原则LOD
            //  (最少知道原则)
            //  一个对象应该保持对其他对象最少的了解，只与最直接的朋友通信

            //6.开闭原则OCP
            //  (原则的原则)
            //  对扩展开发，对修改关闭
            //  扩展功能时增加类而不是修改
            #region 创建型
            //      1.单例模式
            //只能创建同一个对象，不能用来解决线程冲突
            //私有构造函数
            //懒汉式：双判断加锁
            //饿汉式：静态缓存


            //      2.原型模式 
            //解决对象重复创建的问题
            //通过MemberwiseClone()克隆新对象
            //public static Singleton CreateProtoType(){
            //    Singleton instance = (Singleton)_instance.MemberwiseClone();
            //    return instance;}


            //      3.工厂：
            //根据用户的输入创建对象赋值给父类
            //包一层，去细节，根据传入创建不同的对象
            //集中了矛盾
            //工厂方法：再包一层，进一步减少依赖


            //      4.抽象工厂模式
            //约束创建的对象
            //创建多个对象组成一个整体的产品簇

            //      5.建造者模式
            //将一个复杂的构建与其表现分离

            #endregion
            #region 结构型
            //总结：组合优于继承

            //类与类之间关系：
            //纵向关系：继承/实现，关系最紧密
            //横向关系：依赖-关联-组合-聚合 关系依次变强

            //      6.适配器模式
            //

            //      7.装饰器模式

            //      8.代理模式

            //      9.外观(门面)模式
            //增加一层隔离，减少客户端的直接交互
            //将直接朋友变成间接，降低耦合度

            //      10.桥接模式

            //      11.组合模式

            //      12.享元模式 (对象池)
            #endregion
            #region 行为型

            //      13.策略模式

            //      14.模板方法模式

            //      15.观察者模式
            //事件的应用
            //一个对象触发其他对象的动作，且这些动作有可能变化扩展
            //用一个列表存储需要更改或可能扩展的对象，对列表进行操作
            //当需要扩展时，在外部添加对象

            //      16.迭代器模式
            //存在不同的数据模式，需要屏蔽其间的差异使用统一的方式对其访问
            //foreach是一种实现   yield跳转语句(按需获取)

            //      17.责任链模式

            //      18.命令模式

            //      19.备忘录模式

            //      20.状态模式
            //处理一个具有多个状态的对象，可以在这多个状态之间切换    Next()、SetState()

            //      21.访问者模式

            //      22.中介者模式
            //一些实例需要相互交互时，增加一个中介者将直接变间接

            //      23.解释器模式 
            #endregion

            #endregion
            #region WinForm
            //winform应用程序是一种智能客户端技术，可以帮助我们获得信息或传输信息
            //WPF:XAML语言

            //属性
            //事件：
            //注册事件：双击控件注册的都是默认选中的事件
            //触发事件

            //在Main函数中创建的窗体对象，称为主窗体----->将主窗体关闭后，整个应用程序都关闭了
            //在窗体中，左上角为(0,0)点，向右为X轴，向下为Y轴

            //TextBox控件：
            //WordWrap:指示文本框是否换行
            //PasswordChar:
            //ScrollBars:是否显示滚动条
            //事件：
            //TextChanged:当文本框内容发生改变时触发

            //timer:在指定的时间间隔内做指定的事情(数值1000为1秒)

            //WebBrowser控件：uri
            //ComboBox下拉框控件:DropDownStyle:控制下拉框的外观样式
            //combobox对象.DropDownStyle = ComboBoxStyle.DropDownList-------不允许改变选中项的值

            //OpenFileDialog、SaveFileDialog、FontDialog、ColorDialog
            //OpenFileDialog old = new OpenFileDialog();
            //ofd.Multiselect = true;
            //ofd.Filter = "文本文件|*.txt|图片文件|*.jpg|媒体文件|*.wmv|所有文件|*.*";

            //Panel:隐藏控件

            //多线程操作控件：
            //1、取消跨线程访问限制CheckForIllegalCrossThreadCalls = false;
            //2、if(控件.InvokeRequired){
            //  this.Invoke(new Action(() => {
            //      在子线程中执行Action委托
            //  }))
            //}
            #endregion
            #region	WPF
            //容器：
            //1、StackPanel
            //默认垂直排列，通过修改orientation="Horizonal/Vertical"
            //2、WrapPanel
            //可以自动换行
            //3、DockPanel
            //控件设置DockPanel.Dock="Left/Top/Right/Bottom"
            //默认最后一个元素会填充满 LastChildFill="false"
            //4、Grid
            //相当于表格
            //先定义行列数
            //<Gird.RowDefinition>
            //	<RowDefinition Height="Auto"/>
            //	...
            //</Gird.RowDefinition>
            //<Grid.ColumnDefinition>
            //	<ColumnDefinition/>
            //	...
            //</Grid.ColumnDefinition>
            //添加内容时，定义属性Grid.Row/Column="..."
            //自适应宽高是以元素为准
            //5、Canvas
            //通过固定坐标设置元素位置(少用)



            //样式
            //全局样式，表示为所有【类型】的【名称】的控件添加了样式
            //<Window.Resources>
            //	<Style x:Key="名称" TargetType="类型">
            //		<Setter Property="FontSize" Value="20"/>
            //	</Style>
            //</Window.Resources>
            //给元素设置样式：
            //<Button Style="{StaticResource 名称}"/>
            //可以通过BasedOn="{SatticResource ...}"继承样式


            //触发器：
            //<Style.Trigger>
            //	<Trigger Property="事件名" Value="True">
            //		<Setter/>
            //	</Trigger>
            //</Style.Trigger>
            //多条件：
            //<Style.Trigger>
            //	<MultiTrigger>
            //		<MultiTrigger.Conditions>
            //			<Condition Property="事件名1" value="True"/>
            //			<Condition Property="事件名2" value="True"/>
            //		</MultiTrigger.Conditions>
            //		<MultiTrigger.Setters>
            //			<Setter Property="" Value/>
            //		</MultiTrigger.Setters>
            //	</MultiTrigger>
            //</Style.Trigger>
            //事件触发器
            //<EventTrigger RoutedEvent="Mouse.MouseDown">
            //		<EventTrigger.Actions>
            //			<BeginStoryBoard>
            //				<StroyBoard>
            //					<DoubleAnimation Duration="0:0:0.2" Storyboard.TargetProperty="Foreground" To="Red">
            //				</StroyBoard>
            //			</BeginStoryBoard>
            //		<EventTrigger.Actions>
            //</EventTrigger>



            //模板
            //没有在模板中定义的原有属性会失效



            //绑定
            //通过元素名
            // 		<Slider x:Name="Slider"/>
            // 		<TextBox Text="{Binding ElementName=Slider, Path=Value, Mode=Default}"/>
            //绑定到非元素上
            //Source指向一个数据源
            //		<TextBox Text="{Binding Source={StaticResource text1}, Path=Text}"/>
            //使用RelativeSource对象 查找源对象
            //<TextBox Text="{Binding Path=属性名, RelativeSource={RelativeSourceMode=FindAncestor, AncestorType={x:Type 控件名}}}">

            //DataContext

            //DataGrid绑定 => IEnumerable、DataTable.DefaultView
            #endregion
            #region GDI绘图
            //基本流程：
            //using(BitMap map = new BitMap(300, 400))
            //{
            //  using(Graphics g = new Graphics.FromImage(map))
            //  {
            //      //在清除颜色的同时填充背景色
            //      g.Clear(Color.颜色);
            //      map.Save(string fileName)
            //  }
            //}
            //创建GDI对象
            //Graphics pic = this.CreateGraphics();
            //创建画笔对象
            //Pen pen = new Pen(Brushes.Goldenrod);
            //创建两点坐标
            //Point p1 = new Point(30, 50);
            //Point p2 = new Point(100, 120);
            //画直线：
            //pic.DrawLine(pen, p1, p2);
            //画扇型：
            //pic.DrawPie();
            //画文本字符串
            //pic.DrawString("",new font(),Brushes.Black,new point());
            //将画布保存为一张图片
            //
            #endregion
            #region Socket
            //程序之间可以通过Socket来通信
            //电脑与电脑之间进行联系---->协议（Socket、HTTP）
            //协议包括TCP协议以及UDP协议

            //Socket:通常称为“套接字”,用来描述IP地址(Internet Protocol Address)（cmd---->ipconfig /all）和端口号
            //客户端与服务端之间必须有一个负责监听的Socket---->创建一个负责通信的Socket
            //端口----->不同端口对应不同的服务(应用程序)
            //端口号必须在1到65535之间，且最好在1024之后
            //http:80端口
            //ftp:21端口
            //smtp:25端口
            //一般用50000以后的端口

            //流式Socket(Stream)------TCP协议（比较安全稳定，不会发生数据丢失）(但是效率较低)：
            //数据报式Socket(datagram)------要经历“3次握手”(three-way handshake)的过程（“你有空吗”，“我有空”，“我知道你有空了”）----->要求必须有服务器

            //UDP协议：快速效率高，但是不稳定容易发生数据丢失
            //视频传输（影音同传）一般用UDP协议，保证流畅但是画质会有损失


            //Socket通信基本流程：
            //客户端                                               服务端
            //Socket()-->                                             Socket()创建监听接口-->
            //                                                        Bind()绑定监听接口-->
            //                                                        Listen()设置监听队列-->
            //Connect()连接建立                    <--                 while(true)    Accept()    循环等待客户端连接
            //Send()发送数据                       -->                 Receive()接受数据
            //Receive()接受数据                    <--                 Send()
            //Close()                             -->                 捕捉异常-->Close()


            ////创建一个负责监听的Socket
            //Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建IP地址和端口号对象
            //IPAddress ip = IPAddress.Any;
            //IPEndPoint point = new IPEndPoint(ip, 50000);
            ////让负责监听的Socket绑定IP地址和端口号
            //socketWatch.Bind(point);
            ////设置监听队列
            ////如果连接的设备数超出了限制（在下列代码中为10）则需排队进入
            //socketWatch.Listen(10);
            ////接受客户端的连接
            //Socket socketSend = socketWatch.Accept();


            //向用户发送的都是二进制字节数组，应该制定一个  协议  来标识发送的文件类型
            //举例：在字节数组前加0表示文字       加1表示文件
            //枚举类型的SocketFlags
            #endregion
            #region Ado.Net数据库连接
            //三大范式
            //  原子性
            //  一张表只描述一个对象
            //  每一列和主键直接相关

            //无限极分类：
            //表分为两张：分类表和信息表
            //1、父表存储typeId   子表中存储parentId
            //2、增加标头01一级、0101二级、010101三级        查询时，like'01%'一级分类的所有子类

            //负载均衡
            //多个数据库存储的内容一样
            //中间层服务器DBMS
            //  读 => 负载均衡
            //  写 => 基于触发器，写完第一个库之后根据日志写其他的库，全部完成之后返回
            //适合做查询，同步效率不能保证，中间层挂了全部挂

            //读写分离
            //二八原则：二写八读
            //写数据很麻烦，读写分离降低压力
            //主数据库写入之后直接返回，从数据库再完成更新
            //  日志传送：从数据库根据日志完成数据更新(有延迟)
            //  快照复制(定时复制传输)    即时性差、不适合大批量修改、适合做报表
            //  事务复制：发布服务器--主数据库
            //          订阅服务器--从数据库
            //          复制代理

            //分库分表
            //
            //垂直分表：将多余的属性分出去(占空间、更新少、查询少 的数据)
            //水平分表：按时间分表(实时性数据)、地域拆分、类别分表、唯一标识分表
            //表分区：数据库提供，按条件将一张表的数据拆分为不同文件
            //
            //垂直分库：按业务区分、多个服务器分担压力，一个程序同时访问多个数据库(通过服务的形式)，事务=>最终一致性
            //水平分库：多个库结构一样、按时间地域等区分

            #region 数据库连接过程
            /***********************************************************
                //Connnection对象
                //非托管资源
                //应用程序---->数据库
                //地址 连接指定数据库 用户名 密码
                //连接字符串：告诉Connection对象连接的数据库地址、名称、用户名和密码
                //连接本机---->"Data Source=.;"
                //忘了字符串--->
                //1、拼接连接字符串的工具
                //SqlConnectionStringBuilder
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = ".";
                scsb.UserID = "sa";//用户名
                scsb.InitialCatalog = "Student";//数据库名称
                scsb.Password = "12345678";
                string scsbStr = scsb.ToString();
                //使用Windows身份登录
                scsb.IntegratedSecurity = true;
                scsbStr = "Data Source=.;Initial Catalog=CyberCampus";
                //2、服务器资源管理器
                //Data Source =.; Initial Catalog = Student; Persist Security Info = True; User ID = sa; Password = ***********

                //创建Connetion对象
                using (SqlConnection sc = new SqlConnection(scsbStr))
                {
                    //sc.StateChange += sc_StateChange;
                    if (sc.State == ConnectionState.Closed)
                    {
                        sc.Open();//必须open
                    }

                    string sql = "select * from Student";
                    //string sql = string.Format("select * from Spassword where Sno='{0}' and Spassword = '{1}'", textBoxImportAdmin.Text, textBoxImportPsw.Text);

                    //SQL注入漏洞攻击：
                    //构造恶意的Password: 'or'1'='1
                    //防范注入漏洞攻击的方法：不使用SQL语句拼接，通过参数赋值(不使用''单引号)------>用户输入的时候使用
                    //string sql = "select * from [Student] where Sno = @Sname and Spassword = @Password"
                    //在执行查询语句之前，给参数赋值(自动加''单引号)
                    //cmd.Parameters.AddWithValue("@Sno" , textboxAdm.Text);
                    //cmd.Parameters.AddWithValue("@Password" , textboxPwd.Text);
                    //这不是简单的字符串替换，而是由SQLServer（查询分析器）直接用添加的值进行数据比较

                    //创建SqlCommand对象执行sql语句
                    //SqlCommond cmd = con.CreateCommand()
                    using (SqlCommand cmd = new SqlCommand(sql, sc))
                    {
                        //写在构造函数中==  ：
                        //cmd.Connection = sc; ;
                        //cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;

                        //要执行的是非查询语句(ExecuteNonQuery)：
                        int influencedR = cmd.ExecuteNonQuery();
                        if (influencedR > 0)
                        {
                            Console.WriteLine("插入成功！");
                        }

                        //ExecuteScalar方法(返回单个值):
                        object result = cmd.ExecuteScalar();
                        //Console.WriteLine(result);

                        //ExecuteReader方法：
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //SqlReader在过程中必须独享一个Connection（不能断开）
                            while (reader.Read())//如果下一条有数据则继续执行==reader.HasRows
                            {
                                //reader["列名"]
                                //Console.WriteLine(reader.GetString(0));
                                //获取索引的方法：reader.GetOrdinal("列名")------------>最规范
                                //Console.WriteLine(reader.GetString(reader.GetOrdinal("学号")) );
                                string 姓名 = reader.GetString(reader.GetOrdinal("姓名"));
                                string 性别 = reader.GetString(reader.GetOrdinal("性别"));
                                DateTime 出生日期 = reader.GetDateTime(reader.GetOrdinal("出生日期"));
                                string 班级 = reader.GetString(reader.GetOrdinal("班级"));
                                string QQ号 = reader.GetString(reader.GetOrdinal("QQ"));
                                if (reader["职务"] != DBNull.Value)
                                {
                                    string 职务 = reader.GetString(reader.GetOrdinal("职务"));
                                }
                                int 四级成绩 = reader.GetInt32(reader.GetOrdinal("成绩"));
                                string 籍贯 = reader.GetString(reader.GetOrdinal("籍贯"));
                            }
                        }
                    }
                    //Close内部判断，如果之前没有将sc连接关闭，则将其关闭，若关闭了则什么都不做
                    //sc.Close();
                    //sc.Dispose();
                }
                ***********************************************************/
            #endregion
            //ADO.Net连接池
            //在连接字符串pooling = false关闭连接池（默认打开）
            //每次正常连接数据库都会执行：1、登录数据库服务器 2、执行操作 3、注销用户
            //open操作较为耗时

            //Command对象
            //托管资源
            //CommandText属性表示要执行的SQL语句
            //常用的三个方法:
            //1、ExecuteNonQuery()-------->执行非查询语句（增insert、删delete、改update），返回受影响的行数,对其他语句(select)返回-1
            //2、ExecuteScalar()-------->执行查询，返回首行首列
            //3、ExecuteReader()-------->执行查询，返回DataReader对象
            //StatementCompleted事件：-------->每条sql语句执行后触发


            //DataSet
            //临时数据库(内存)---->(一次性全部读取，不需要一直保证数据库连接，用于小型数据的读取)
            //SqlDataAdapter
            //数据适配器---->用来填充DataSet
            //
            #region 手动添加DataSet内容
            //创建DataSet临时数据库，将数据显示在DataGridView中
            //DataSet ds = new DataSet("Student");
            //创建表
            //DataTable dt = new DataTable("Student");
            //把表添加到数据库中
            //ds.Tables.Add(dt);
            //设计列
            //DataColumn dc1 = new DataColumn("sID");
            //dc1.DataType = typeof();//数据类型
            //dc1.AllowDBNull = false;//不许为空
            //dc1.AutoIncrement = true;//自动增长
            //dc1.AutoIncrementSeed = 1;//种子大小
            //dc1.AutoIncrementStep = 1;//增量
            //DataColumn dc2 = new DataColumn("sName");
            //dc2.DataType = typeof(string);
            //把列添加到表中
            //dt.Columns.Add(dt1);
            //dt.Columns.Add(dt2);
            //添加每行数据
            //DataRow dr1 = dt.NewRow();
            //dr1["sName"] = "";
            //dt.Rows.Add(dr1);
            //还可以使用dt.Rows.InsertAt(DataRow, index);----------在表的指定位置插入
            //把DataTable中的数据传给DGV
            //DtaGridView对象.DataSource = dt
            #endregion
            //
            //using(SqlConnection con = new Sqlconnection(conStr))
            //{
            //    DataTable dt = new DataTable();
            //      1、查询
            //    string sql = "select * from Student";
            //    SqlDataAdapter adapter = newSqlDataAdapter(sql, con);
            //    adapter.Fill(dt);
            //      2、增删改
            //    string sql = "";
            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            //    创建关键对象，可以自动生成sql语句(DGV手动修改数据)
            //    SqlCommandBuilder scb = new SqlCommandBuilder(adapter);
            //    adapter.Update(dt);
            //}
            #region 数据库操作封装
            //封装链接字符串：
            //app.config------>Application.Configuration(应用程序配置信息文件)
            //在这个xml文档中标签不能随便写
            //1、添加节点
            //<connectionStrings>
            //  <add name="conStr" connectionString="Data Source=.;Initial Catalog=Student"/>
            //</connectionStrings>
            //2、在指定项目中添加System.Configuration的引用
            //3、添加命名空间using System.Configuration;
            //4、ConfigurationManager.ConnectionStrings["conStr"].ConnnectionString;------返回string连接字符串

            //封装连接数据库的步骤：
            //新建类库
            //删除class1.cs
            //添加System引用，引用命名空间
            //封装连接字符串
            //将class标记为public
            //读取连接字符串string conStr = ConfigurationManager.ConnectionStrings["conStr"].connectionString;
            //
            #region 封装操作方法，直接用
            // 1、静态SqlDataAdapter查询函数:
            //public static DataTable ExecuteDataTable(string sql, CommandType type, params SqlParameter[] param)
            //{
            //    DataTable dt = new DataTable();
            //    using (SqlConnection con = new SqlConnection(conStr))
            //    {
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            //        adapter.SelectCommand.CommandType = type;
            //        adapter.SelectCommand.Parameters.Clear();
            //        adapter.SelectCommand.Parameters.AddRange(param);
            //        adapter.Fill(dt);
            //    }
            //    return dt;
            //}
            //2、静态增删改函数
            //public static int ExecuteNonQuery(string sql, params SqlParameter[] param)
            //{
            //    int n = -1;
            //    using (SqlConnection con = new SqlConnection(conStr))
            //    {
            //        using (SqlCommand cmd = new SqlCommand(sql, con))
            //        {
            //            con.Open();
            //            cmd.Parameters.Clear();
            //            cmd.Parameters.AddRange(param);
            //            n=cmd.ExecuteNonQuery();
            //        }
            //    }
            //    return n;
            //}
            //
            //3、执行查询，返回首行首列
            //public static object ExecuteScalar(string sql, params SqlParameter[] param)
            //{
            //    object o = null;
            //    using (SqlConnection con = new SqlConnection(conStr))
            //    {
            //        using (SqlCommand cmd = new SqlCommand(sql, con))
            //        {
            //            con.Open();
            //            cmd.Parameters.Clear();
            //            cmd.Parameters.AddRange(param);
            //            o = cmd.ExecuteScalar();
            //        }
            //    }
            //    return o;
            //}
            //
            //4、DataReader
            //public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] param)
            //{
            //    SqlDataReader reader;
            //    SqlConnection con = new SqlConnection(conStr);
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        con.Open();
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddRange(param);
            //    //在外部关闭SqlDataReader对象,CommandBehavior.CloseConnection：如果关闭SqlDataReader,则con随之关闭
            //        reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //    }
            //    return reader;
            //}
            #endregion
            #endregion

            //DataGridView控件
            //  读取每一个单元格数据：DataGridView对象.SelectedRows[0].Cells["属性名"].Value.ToString();
            //  CellFormatting事件:对dgv进行格式化处理
            //  CellContentDoubleClick事件:
            //  通过创建DataGridViewRow对象   =   dgv.Rows[(DataGridViewCellEventArgs类型参数)e.RowIndex]
            //  可以拿取到当前点击的行,再根据dgvRow.Cell[index].Value拿到对应的单元格
            //ComboBox控件：
            //  绑定数据------DataSource属性：DataTable---------------数据绑定时，传统的数据添加方式就失效了
            //  设置要显示的内容------DisplayMenber属性："列名/属性名"
            //  ValueMember属性："列名/属性名"
            //  读取ValueMember属性的值：comboBox对象.SelectedValue
            //  多个控件同时操作同一个数据源会出问题，因此在第二个控件使用时需要将数据源进行拷贝-->DataTable对象.Copy()


            #region DB
            //CASE
            //单值判断，相当于C#中的switch-case，原表中的数据并没有改变，替换值的类型必须一致
            //当进行区间判断时，不写列名
            //case 参数
            //  when 值 then 值
            //  when 值 then 值
            //  else 值
            //end
            //(as 列名)

            //if()
            //  begin
            //      语句1
            //  end
            //else
            //  begin
            //      语句2
            //  end

            //while()
            //  begin
            //      语句
            //      break
            //  end


            //索引
            //sql语言创建索引：
            //create (nonclusteres/clustered) index on 表名 列名 asc/desc
            //默认主键含有一个聚簇/非聚簇索引
            //使用索引可以提高查询效率，但索引也要占据空间，增删改的时候也会同步更新索引因此降低速度
            //只在经常使用的字段上创建索引
            //全表扫描：一条条的找，效率最低
            //*********即使创建了索引，当存在like、函数、类型时仍会进行全表扫描


            //分页
            //row_number函数
            //给一个结果集再加一个数据
            //row_number() over (order by 列名)
            //
            //select * from
            //(select *,ROW_NUMBER() over (order by [列名]) as '' from Student) as t
            //where number between (2-1)*3+1 and 2*3
            //(x-1)*y+1             x是页数，y是每一页的行数
            //x*y                   x是页数，y是每一页的行数


            //连接
            //[表名]   join  [表名]
            //交叉连接cross join            行数相乘，列数相加
            //内连接inner join             把不符合条件的数据删除
            //外连接                        使用 ON、USING 或 NATURAL 关键字来表达
            //      left join
            //      right join


            //视图
            //虚拟表，储存的实际上为查询语句
            //能方便查询，不直接对其进行增删改
            //创建数据库(表、约束等)时做检查：
            //if exists(select * from sys.databases/sys.objects where name="名字")
            //  动作
            //go


            //局部变量
            //声明：declare @变量名 数据类型
            //赋值：set @变量名=值
            //      select @变量名=值       (查询并赋值，可以一次给多个变量赋值)
            //没有GC,但也会自动释放内存
            //
            //全局变量
            //在前面加上@@
            //@@ERROR               最后一条T-SQL语句错误的错误号           0:并没有发生错误
            //@@IDENTITY            最后一次插入的标识值
            //@@LANGUAGE            当前使用的语言
            //@@MAX_CONNECTIONS     可以创建的同时连接的最大数目
            //@@ROWCOUNT            受上一条SQL语句影响的行数
            //@@SERVERNAME          本地服务器的名称
            //@@TRANCOUNT           当前连接打开的事务数
            //@@VERSION             SQL Server的版本信息


            //事务
            //多个SQL语句作为一个整体执行
            //开始事务：BEGIN TRANSACTION
            //事务提交：COMMIT TRANSACTION
            //事务回滚：ROLLBACK TRANSACTION
            //一旦事务提交，就不能再回滚
            //没有END，事务最终只能被提交或回滚
            //ACID特性:
            //      原子性：原子工作单元，对于数据修改一起执行(不执行)
            //      一致性：事务在完成时，必须使所有数据都保持一致状态，所有规则都必须应用于事务的修改以保证数据的完整性
            //      隔离性：由并发事务所做的修改必须与其他任何并发事务隔离
            //      持久性：事务完成后对系统的影响是永久的，即使出现故障也一直保持
            //
            //1、自动提交事务：当执行一条SQL语句的时候，数据库自动打开一个事务，执行成功则自动提交事务，否则自动回滚
            //
            //2、隐式事务：
            //set implicit_transaction on/off
            //数据库自动打开一个事务，但是需要手动提交或回滚
            //
            //3、显式事务：
            //begin transaction
            //  declare @sum int = 0
            //  [执行sql语句]
            //  统计错误次数：set @sum = @sum + @@ERROR
            //  if(@sum > 0)
            //      begin
            //          rollback//如果出现错误则回滚
            //      end
            //  else
            //      begin
            //          commit//如果没有发生错误则提交该事务
            //      end

            //高并发系统死锁不可避免
            //解决方案：
            //	1、按照固定顺序操作数据
            //	2、事务尽量简短，耗时越少越好
            //	3、不要在事务执行期间等待


            //触发器
            //特殊类型的存储过程
            //通过事件被触发而执行
            //主要有增、删、改(insert、delete、update)三种类型
            //
            //create trigger tr_Insert_Student
            //on Student
            //  for insert
            //as
            //  declare @sutID int
            //  select @stuID = studentID from inserted


            //备份
            //创建删除触发器，在进行删除操作的时候将数据添加到备份表当中去


            //事务锁
            //  begin trans
            //  update [表1] set = ;
            //  wait delay '0:0:5'
            //  update [表2] set = ;
            //  commit trans
            //在另一个进程：
            //  begin trans
            //  update [表2] set = ;
            //  wait delay '0:0:5'
            //  update [表1] set = ;
            //  commit trans
            //报错：事务(进程ID 54)与另一个进程被死锁在 锁 资源上，并且已被选作死锁牺牲品。请重新运行该事务。

            #region 触发器对表进行备份
            //select * into [备份表名] from [表名]
            //create trigger tr_Delete_[表名]
            //on [表名]
            //for delete
            //as
            //  begin
            //      insert into [备份表名] select *from deleted
            //  end
            #endregion


            //存储过程
            //类似于方法
            //优点：
            //执行速度更快(保存的存储过程都是编译过的)、允许模块化程序设计(类似方法的复用)、提高系统安全性(防止恶意注入)、减少网络流通量(只传输存储过程的名称)
            //缺点：
            //不好维护，难以管理，逻辑分散不好理解
            //1、系统存储过程：由系统定义，存放在master数据库中，名称以sp_或xp_开头
            //sp_databases                          列出服务器上所有的数据库
            //sp_helpdb                             报告指定(所有)数据库的信息
            //sp_renamedb                           改名
            //sp_tables                             返回当前环境下可查询对象的列表
            //sp_columns                            返回某个表的列的信息
            //sp_help(constraint/index)             查看某个表的所有信息(约束/索引)
            //sp_stored_procedures                  列出当前环境中所有存储过程
            //sp_password                           添加或修改登录账户的密码
            //sp_helptext'存储过程名'                显示实际文本
            //
            //2、自定义存储过程：以usp_开头
            //在C#中指定cmd.CommandType = CommandType.StoredProcedure;
            //output输出参数：cmd.Parameters[参数index值].Direction = ParameterDirection.Output;
            //运行时在语句前面加上exec
            //可以将表名作为参数传递
            //exec(@sql)
            //在sql中，''代表一个'
            //创建一个参数对象,即为返回值
            //SqlParameter retVal = cmd.Parameters.AddWithValue("@count", SqlDbType.Int);
            //指定返回值
            //retVal.Direction = ParameterDirection.ReturnValue;
            //
            //(create/drop/alter) (procedure/proc) usp_方法名
            //@参数1 类型 ,
            //@参数2 类型 (output------输出参数,调用时也应加上output)
            //as
            //  begin
            //      语句
            //      (return)
            //  end
            //
            //外部调用存储过程：exec @变量 = usp_方法名 参数列表
            //调用存储过程时，如果有写 变量=值 的赋值语句，那么之后所有的参数都必须用同样的格式
            //使用output 的参数在调用时必须提前声明

            //分页存储过程
            #region 分页存储过程
            //create proc GetPage
            //@pageSize int, --------每页有几行数据
            //@pageIndex int, --------当前页数
            //@pageTotalCount int output --------总页数
            //as
            //  declare @pageCount int --------总行数
            //  select @pageCount = count(*) from [表名]
            //  select @pageTotalCount = ceiling(@pageCount*1.0 / @pageSize) --------通过ceiling函数取整,返回总页数
            //  select * from
            //  (select *,ROW_NUMBER() over (order by [列名]) as '[结果列名]' from [表名]) as t
            //  where [结果列名] between ((@pageSize-1)*@pageIndex+1) and (@pageSize*@pageIndex)
            #endregion

            #endregion

            #endregion
            #region 事件与委托
            //委托
            //delegate
            //委托是C#中类型安全的，可以订阅一个或多个具有相同签名方法的函数指针
            //继承自System.MulticastDelegate，内置了几个方法的一个类
            //将一个方法作为参数传递
            //public delegate 返回值类型 委托名(参数列表);
            //函数可以直接赋值给一个委托对象，其签名必须一致
            //委托可以近似理解为函数的父类
            //委托实例.Invoke();
            //  result = 委托实例.BeginInvoke(回调, obj)
            //  委托实例.EndInvoke(result)
            //1、委托解耦，减少重复代码
            //2、支持异步多线程
            //3、多播委托不能异步

            ////1、
            //Printer prin = SayHello;
            //prin("hello");

            ////2、匿名函数
            //好处：可以访问到局部变量
            //Printer printer = delegate (string s)
            //{
            //    Console.WriteLine(s);
            //};
            //printer("asdf");

            ////3、lambda表达式
            //实际上是一个类中类，里面的一个internal方法，被绑定到静态的委托类型字段
            //多播委托中lambda的注册不能去掉
            //  //匿名函数简写的形式  () => {  }
            //Printer pri = (string name) =>
            //{
            //    Console.WriteLine("knjw");
            //};

            //匿名类
            //dynamic model = new {
            //    Id = 1,
            //    Name = "张三"
            //};
            //编译后存在真实的类
            //只读不写
            //dynamic 避开编译器的检查，使其可以访问到model.Id


            //泛型委托：
            //public delegate int DelCompare<T> (T t1, T t2);
            //多播委托:
            //委托实例 +=(-=) 方法名;
            //形成方法链，执行时按顺序
            //foreach(delegate item in 委托实例.GetInvocationList()){
            //  item.Invoke();
            //}


            //事件：
            //声明事件的语法：public event 委托名 事件名;
            //注册事件：事件名 += new 委托名(方法名);
            //事件的本质就是一个类型安全的委托实例
            //声明事件可以限制变量被外部调用/赋值
            //只有声明者才能使用事件
            //委托可以在任意位置调用(不安全)
            //事件的应用：将一些可变的行为封装，交给第三方指定


            //Action    0-16个参数、没有返回值的泛型委托
            //Func      0-16个参数、有返回值的泛型委托
            //  Func(in X... out X)
            //自定义的无参无返回值泛型委托 与Action不是同一种类型


            //通用的异常处理
            //传入的Action对应任何形式的逻辑
            //public static void SafeInvoke(Action act){
            //      try(){
            //          act.Invoke();
            //      }
            //      catch(Exception e){
            //          throw e;
            //      }
            //}
            #endregion
            #region log4net
            //log4配置文件：
            //  log4net.cfg.xml

            //配置
            //  static Logger()
            //  {
            //      XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.cfg.xml")));
            //      ILog log = LogManager.GetLogger(typeof(Logger));
            //      log.Info("初始化Log4net模块");
            //  }

            //构造函数
            //  public Logger(Type type)
            //  {
            //      logger = LogManager.GetLogger(type);
            //  }


            //实现
            //  public void Error(string msg, Exception ex)
            //  {
            //      Console.WriteLine(msg);
            //      logger.Error(msg, ex);
            //  }

            //外部调用
            //  static Logger logger = new Logger(typeof(类名));
            //  logger.Error();
            #endregion
            #region SQLite
            //SQLite数据库
            //是一种轻量级的数据库完全配置时小于 400k，省略可选功能配置时小于250k，
            //不同于SQlserver的服务型数据库，而是一种文档型，可以在本机离线情况下使用
            //允许从多个进程或线程安全访问

            //注释：
            //      /*   */或    --
            //
            //数据类型
            //INTEGER                                   带符号的整数
            //REAL                                      8字节的浮点数字
            //TEXT                                      文本字符串，使用编码（UTF-8、UTF-16BE 或 UTF-16LE）存储
            //BLOB                                      根据输入储存
            //亲和(Affinity)类型:
            //任何列仍然可以存储任何类型的数据，当数据插入时，该字段的数据将会优先采用亲缘类型作为该值的存储方式
            //TEXT、(NUMERIC、INTEGER、REAL)(基本等同)、NONE(不做任何类型转换)

            //链接字符串：
            //@"Data Sourse = C:\SQLite\DATA\student.db3; Version = 3;"

            //ANALYZE语句
            //  收集有关表和索引的统计信息，并将收集的信息存储在数据库的内部表中，查询优化器可以访问信息并使用它来帮助做出更好的查询计划选择。
            //  如果没有给出参数，则分析所有附加的数据库。如果模式名称作为参数给出，则分析该数据库中的所有表和索引。
            //  如果参数是一个表名，那么只分析该表和与该表相关的索引。如果参数是索引名称，那么只分析那一个索引
            //ATTACH DATABASE
            //  附加数据库
            //ALTER TABLE
            //  给指定表改名
            //EXPLAIN
            //  对指定SQl语句进行解释
            //GLOB
            //  用来匹配通配符指定模式的文本值。如果搜索表达式与模式表达式匹配，GLOB 运算符将返回真（true），也就是 1
            //  星号（*）代表零个、一个或多个数字或字符。问号（?）代表一个单一的数字或字符。这些符号可以被组合使用
            //LIMIT
            //  用于限制由 SELECT 语句返回的数据数量
            //  SELECT * FROM COMPANY LIMIT 6;

            //PRAGMA
            //  用在 SQLite 环境内控制各种环境变量和状态标志
            #endregion
            #region 三层
            // 版本控制器
            //解决多人同时开发项目时的冲突问题
            //调试通过之后再上传
            //Visual SVN
            //项目经理：Visual SVN Server
            //组员：

            //三层架构
            //将原来写在一个方法中的代码，分到三个层中编写：<      展示层UI     >
            //                                          ↓ 调用   ↑ 返回
            //                                          <   业务逻辑层BLL   >
            //                                          ↓ 调用   ↑ 返回
            //                                          <   数据访问层DAL   >
            //模型层Model
            //通用层Common

            //基本架构
            //添加引用时，DAL:(Model、Common)
            //           BLL:(DAL、Model、Common)
            //           UI:(Bll、Model、Common)

            //在一个层不能出现其它层的类
            #endregion
            #region	Git
            //Git
            //工作区	add=>	暂存区	commit=>	本地仓库	push=>	远程仓库
            //	远程仓库	pull(fetch+merge)=>	工作区
            //	远程仓库	fetch/clone	=>	本地仓库
            //		本地仓库	checkout=>	工作区

            //fetch：从远程仓库抓取到本地仓库，不进行合并工作
            //pull：从远程库拉取到本地仓库，自动进行合并放到工作区

            //常用指令
            //git status								查看暂存区、工作区修改状态
            //git add .									从工作区添加到暂存区    .表示通配符
            //git commit -m "记录内容"					 从暂存区提交到本地仓库
            //git-log									查看提交日志

            //
            //git reset --hard commitId					版本切换
            //git reflog								查看已经删除的提交记录

            //分支操作指令
            //git checkout -b 分支名					切换分支，不存在时创建
            //git merge 分支名							合并到当前分支
            //git branch -d 分支名						检查并删除分支，-D不做检查

            //远程命令
            //git remote -v								显示所有远程仓库
            //git remote add [name] [url]				添加远程库
            //git remote rm [name]						删除

            //最常用
            //git push 远程主机 本地分支				  推送并合并本机分支
            //git pull 远程主机 远程分支				  拉取远程分支与当前分支合并
            //git clone [url]							克隆远程库


            //项目分支使用流程
            //  master									最终上线
            //  develop									开发版本分支
            //  feature									新功能实现分支
            //  hotfix									线上修复bug使用

            //自定义：
            //git config --global alias.log-one 'log --pretty=format:"%C(white)%h%Creset %C(white)-%Creset %C(yellow)%cn%Creset %C(white)-%Creset %C(red)%cd%Creset %C(white)-%Creset %C(green)%s%Creset" --date=format:"%Y-%m-%d %H:%m:%S" --graph --decorate --all'

            #endregion
            #region ASP.NET

            //ASP.NET
            //浏览器
            //服务器：（电脑）
            //1、建立一个HTML网页，将其部署到服务器上
            //2、用户可以通过输入地址访问放在服务器上的网站
            //  B/S结构
            //与Winform系统的区别：
            //不需要将每个设备上安装，输入一个地址就可以访问
            //
            //Web.config        网站的配置文件

            //IIS
            //(Internet Information Server)
            //安装微软的服务器软件：控制面板---程序和功能---windows服务---IIS
            //管理：控制面板---管理工具

            //HTTP协议
            //超文本传输协议
            //传输数据的规定协议
            //域名：最终会解释为IP地址，目的是方便用户记忆
            //是一个基于请求与响应模式的、无状态的、应用层的协议
            //基于TCP协议
            //在浏览器向服务器发送请求之前，BS之间会先建立一个连接通道，当整个过程结束之后，连接通道就会关闭
            //服务器同时处理的请求是有限的，如果不及时关闭连接通道，服务器会一直维护处理的请求
            //负载均衡：由多台机器来处理请求
            //浏览器通过url(http://localhost:****/*.ashx)发送请求，服务端通过继承于IHttpHandler的类接收
            //IHttpHandler包括属性:IsReusable(表示是否可以使用)、方法:ProcessRequest(启用HTTP Web请求的处理、参数HttpContext对象)
            //
            //1、请求报文的格式
            //请求头(请求行、实体头、头部结束标志)、请求体
            //请求行--------请求头第一行-------规定请求的方式、页面地址、HTTP协议的版本
            //  Accept                      告诉服务器浏览器可以处理的数据类型
            //  Accept                      告诉服务器浏览器的语言版本
            //  User-Agent                  浏览器的版本，操作系统的版本
            //  Accept-Encoding             数据压缩方式
            //  Connection: Keep-Alive      保持长连接，不会立刻关闭连接通道
            //头部结束标志：回车换行
            //get请求没有请求体
            //
            //2、响应报文
            //响应头(响应行、实体头、头部结束标志)、响应体
            //响应状态码:表示服务器的处理结果，200是处理结果没有任何问题，404 Not Found， 500 服务端代码执行出错
            //302 found重定向， 403 Forbidden 禁止， 503 当前访问人数过多
            //200段是访问成功
            //300段是需要做进一步的处理
            //400段表示客户端请求错误
            //500段是服务器的错误

            //先安装IIS的原因：asp.net_isapi.dll
            //IIS无法识别.ashx扩展名的文件，转而交给.Netframework处理C#代码，然后再将处理结果返还给IIS
            //在asp.net 中对文件或文件夹进行操作使用绝对路径

            //应用程序池：
            //与工作进程相关联，包含一个或多个应用程序，并提供不同应用程序之间的隔离

            //localhost:端口号
            //127.0.0.1:

            //get 和 post
            //  一般情况下使用post，更加安全，发送的数据量更大
            //  搜索时使用get
            //  一般情况下对url的大小限制为2KB
            //如果是method = get方式发送请求，则用户在表单中输入的数据将放在浏览器的地址栏中发送到服务器
            //如果是post方式请求，则表单中的数据全都放在请求报文的请求体中
            //  HttpContext context
            //  context.Response.ContentType = "text/plain"
            //  //获取文件的绝对路径
            //  string filePath = context.Request.MapPath("*.html");
            //  //读取文件的内容
            //  string fileContent = File.ReadAllText(filePath);
            //  //替换参数内容
            //  fileContent = fileContent.Replace("$name", "ZhangSan").Replace("$pwd", "123456");\
            //  //将替换后的内容输出到浏览器
            //  context.Response.Write(fileContent);

            //  HttpContext context
            //  context.Response.ContentType = "text/plain";
            //  //在服务端接受get请求的数据
            //  string userName = context.Request.QueryString["txtName"];
            //  string userPwd = context.Request.QueryString["txtPwd"];
            //  context.Response.Write(userName + userPwd);

            //  //接受post请求的数据
            //  string userName = context.Request.Form["txtName"];
            //  string userPwd = context.Request.Form["txtPwd"];

            //HTTP的无状态性，第二次请求无法获取第一次请求的处理结果

            //抓包：通过其他的技术手段来抓取请求报文，伪造请求报文数据
            //delete 和 put

            //对网站进行调试时，会自动在Wen.config文件中添加<compilation debug="true" targetFramework=""/>
            //在网站正式发布的时候要将其删除，否则很影响性能

            //相当于重新执行了一遍服务端的代码
            //context.Request.Redirect(*.ashx);
            //设置第二个参数为false可以取消对 Response.End 的内部调用

            //Web网站与Web应用程序的区别：
            //  应用程序.ashx文件包含cs文件-----有命名空间
            //  网站每个页面(.ashx)都是一个单独的应用，其中一个出错不会影响到其他的应用，网站中创建cs文件需要放到App_Code文件夹中
            //  总结：大项目适合使用web应用程序，小项目适合web网站

            //Redirect------服务器会在响应报文中加上一个302响应状态码(等待下一步操作)，浏览器接下来进行跳转，重新向服务器提交请求Location
            //css、js、图片等文件可以缓存在浏览器中，等到下次访问的时候就不会重新发送请求了
            //上传域
            //上传文件：使用<input type="file" enctype="multipart/form-data" action="">通过post请求并保存到服务器磁盘中
            //在服务端使用context.Request.Files接受文件数据
            //创建HttpPostedFile对象接受单个文件或HttpFileCollection对象接受全部

            //web窗体文件.aspx
            //.aspx--------html
            //.aspx.cs-----C#
            //aspx继承于aspx.cs类
            //在一些复杂的页面中选用aspx布局
            //不需要给用户展示页面时使用一般处理程序
            //在html中写C#代码----------写在<%  %>之间
            //.aspx文件首行必须是<%%>
            //服务端注释：<%--  --%>
            //  %@ XXX--------代表一个指令
            //  %@ Import Namespace=""                         在<!DOCTYPE>下一行导入命名空间
            //代码后置：C#和html代码分离
            //页面加载完成之后，触发Load事件，执行Page_Load方法
            //在<%%>内 = 的效果等同于Response.Write()

            //服务端控件：form标签runat属性="server"
            //aspx.cs继承的Page类直接封装了Response和Request类，所以可以不创建HttpContext对象直接Requset.Form[""]
            //IsPostBack-------添加隐藏域用于识别是不是post请求
            //状态保持：将查询到的数据暂时保存再hidden隐藏域的value属性中
            //<input type="hidden" name="IsPostBack" value="0">
            //if( !String.IsNullOrEmpty(Request.Form["IsPostOrBack"]) )







            //主要的Razor C#语法规则
            //Razor代码块包括在@{...}之中
            //变量使用var 声明
            //文件扩展名是.cshtml
            #endregion

            #region javascript
            //JS
            //在浏览器中运行，能做出更流畅、优美的页面效果，增强用户体验
            //1、head区域：用于声明变量、函数、类型、为事件绑定处理函数-----<script></script>
            //2、body区域：调用脚本执行
            //3、外部脚本：用于定义函数、类型
            //  将代码封装到一个扩展名为js的文件中，然后在需要的地方引用<script src="xxx.js"></script>
            //  在文件中不需要写标签
            //大小写敏感
            //弱类型语言:不需声明变量类型(var、value)
            //js 封装=> ts(typescript)---------:指定数据类型
            //vscode注释：/**   */
            /**
             * 方法1
             * @param1 (*) param1 参数一，可以是任意类型
             */
            //function fun1(param1){
            //}

            //数据类型：
            //boolean       布尔
            //number        数字       整数（不使用小数点或指数计数法）最多为15位,小数的最大位数是17
            //string        字符串     既可以用双引号，也可以用单引号
            //Undefined     未定义
            //Null          空对象
            //Object        对象类型
            //Undefined和Null类型都只有一个值：undefined和null
            //如果前缀为 0，则 JavaScript 会把数值常量解释为八进制数，如果前缀为 0x，则解释为十六进制数
            //三等号判断===先判断类型是否相同，再判断值是否相等
            //非数字判断 isNaN() 能转成number就是数字
            //无穷大（Infinity）
            //将一段字符串转换成js代码执行   eval()

            //块级作用域
            //ES2015(ES6) 新增加可以使用 let 关键字来实现块级作用域。
            //let 声明的变量只在 let 命令所在的代码块{ }内有效，在{ }之外不能访问。
            //const声明的常量必须初始化       而let声明的变量不用
            //const 定义常量的值不能通过再赋值修改，也不能再次声明     而 let 定义的变量值可以修改

            //弹出对话框------------alert()
            //在浏览器控制台输出-----console.log()
            //开始计时--------------console.time("");
            //停止计时--------------console.endTime("");
            //查看变量类型----------typeof()
            //写入html文件----------document.write("<></>")
            //写入到HTML元素--------innerHTML
            //通过id操作html元素----getElementById()
            //获取世界时间，标出当前时区         date对象.toString()
            //本地时区的时间--------------date对象.toLocaleString()


            //数组：
            //var array = [1,2,3,4,5];
            //var array = new Array();
            //声明空数组：var array = [];
            //js数组不会超出索引，自动进行添加
            //数组中元素的类型可以不一致
            //可以直接使用console.log(数组名)输出

            //键值对：
            //var keyValues = {"key1":"value1","key2":"value2"};
            //声明空的键值对：var keyValues = {};
            //keyValue.key = value
            //加引号：json格式的对象
            //不加引号：js对象

            //对象数组：
            //json格式的对象组成的数组
            //      ison是一种轻量级的数据交换格式，通常用于服务端向网页传递数据
            //      json == javascript object notation(标记)
            //              JSON.parse() 将json字符串转换为js对象:
            //              JSON.stringify() 将javascript值转换为字符串

            //Array对象方法
            //.concat()                 连接两个或更多的数组，并返回结果
            //.join()                   把数组中的所有元素放入一个字符串，通过指定元素分隔
            //.push()                   向数组末尾添加一个或更多元素，并返回新的长度
            //.reverse()
            //.sort()
            //.splice(要删除的元素下标,要删除之后的几个元素(不写删除之后所有，为0则不删除任何元素),要插入的内容)

            //类型转换
            //类型名(变量名)
            //parseInt()
            //parseFloat()

            //方法
            //使用关键字function定义方法
            //方法名使用camel命名法
            //function myFunction(param1, param2)
            //{
            //  return param1 + param2;
            //}
            //不存在方法重载，重载会被覆盖
            //从方法中取参数还可以用arguments关键字，是一个数组             用法类似于params参数
            //可以在定义方法的时候给参数赋值，调用时不写则取其默认值
            //
            //匿名方法
            //1、最常用
            //var fun = function(param1){
            //
            //}
            //fun();
            //
            //使sort为降序排列(return b-a)
            //var array1 = [2,3,1,4,7,5,6]
            //var fun1 = function(a, b){
            //  return b-a;
            //};
            //array1.sort(fun1);
            //2、定义匿名方法时同时传参及调用
            //(function (param1, param2){
            //  return param1+param2;
            //})(1, 2);
            //3、箭头函数
            //ES6新增
            //var a = (x, y) => {x + y};

            //闭包
            //简单理解为子方法可以使用父方法的变量(尽量不使用，变量不易释放)
            //靠作用域链(变量的作用域在当前函数及其内部定义的子函数中，形成的一个链条)实现
            //尽量避免：变量都应该先声明再使用

            //模拟面对对象
            //定义js对象
            //var Person = {
            //  firstName:"三",
            //  lastNme:"张",
            //  age = 21,
            //  gender = "男"
            //}
            //定义一个类
            //class 类名{
            //  constructor(){   }              //-------构造函数
            //  成员
            //}
            //类名称首字母大写
            //获取对象:new 类名称()
            //可以在类中声明static静态函数，通过 类名.方法名 调用
            //访问:对象.成员
            //function Person(name){
            //  this.Name = name;           在类内部声明一个属性Name,初始化值为name值
            //}
            //还可以不用在类中声明成员，直接创建对象，为对象增加成员
            //              关键字this随着执行环境的改变而改变
            //1、在方法中this表示该方法所属的对象
            //2、单独使用，this 表示全局对象
            //3、事件中，this 表示接收事件的元素
            //4、严格模式("use strick")下，this是undefined

            //继承
            //使用关键字extends      相当于:
            //super()               用于调用父类的构造函数
            //可以用 getter 和 setter 来获取和设置值,都需要在严格模式下执行
            //get s_name() {
            //    return this.属性;
            //}
            //set s_name(x)
            //{
            //    this.属性 = x;
            //}
            //let zs = new Person();
            //document.getElementById("demo").innerHTML = zs.s_name;            没有括号

            //原型
            //(对象的类型)
            //类似于继承
            //var zs = new Person("张三");
            //访问原型
            //zs.prototype
            //添加属性：
            //zs._proto_.EducationBackground = "college";
            //等同于Person.prototype.EducationBackGround = "college";


            //BOM:
            //window是DOM的顶级对象，代表当前浏览器窗口
            //方法：
            //alert()
            //confirm()                                返回boolean
            //prompt()                                 显示提示用户输入的对话框，点击确定返回输入值，取消返回null
            //open()                                   打开新窗口
            //close()                                  关闭当前窗口
            //moveTo()                                 移动当前窗口
            //resizeTo()                               调整当前窗口的尺寸
            //setInterval("code", time)                每隔time毫秒执行一次code代码(""),也可以直接写上方法名
            //在一个页面中尽量不要启动多个定时器，返回一个int标识定时器，可以用于清除clearInterval(intervalId)
            //setTimeOut("code", delay)                等待delay毫秒后执行，只执行一次
            //属性：
            //window.innerHeight                       浏览器窗口的内部高度(包括滚动条)
            //window.innerWidth                        浏览器窗口的内部宽度(包括滚动条)
            //1、location  重定向，记录当前浏览器窗口地址栏信息的对象
            //location.href                            设置url
            //location.pathname                        返回当前url路径
            //location.hostname                        返回 web 主机的域名
            //location.pathname                        返回当前页面的路径和文件名
            //location.port                            返回 web 主机的端口 （80 或 443）
            //location.protocol                        返回所使用的 web 协议（http: 或 https:）
            //2、screen    包含有关用户屏幕的信息
            //screen.availHeight                       可用的屏幕高度
            //screen.availWidth                        可用的屏幕宽度
            //3、History    包含浏览器的历史
            //history.back()                           与在浏览器点击后退按钮相同
            //history.forward()                        与在浏览器中点击向前按钮相同
            //history.go(option)                       option：0刷新、1前进、-1后退

            //DOM
            //Document Object Model
            //包括事件、属性、方法
            //用于操作html文档(标签)的内容
            //js中将每一个标签作为对象处理
            //两个方面：Browser对象,即BOM,用于操作窗口的规范            window.
            //         HTML DOM对象,即狭义的DOM,用于操作html中的标签   document.
            //使用document关键字调用操作DOM对象
            //document.getElementById()
            //document.getElementsByClassName()     根据class值获取一组元素节点            返回HTMLCollection对象(不是数组)
            //...ByName根据name属性值         ...ByTagName根据标签名称
            //HTML5中使用document.querySelector("#id值")-----------id为#,class为.
            //document.querySelectorAll();
            //事件注册
            //注册代码必须在文档对象加载完成之后
            //方式1：直接在元素上注册
            //方式2：动态注册，代码分离，更加规范
            //onload事件:当页面中的所有元素加载完成后，触发此事件
            //onload = function(){
            //
            //};
            //常用事件
            //oncontextmenu                     在用户点击鼠标右键打开上下文菜单时触发
            //onchange                          html元素改变
            //onmouseover                       鼠标指针移动到指定的元素上时发生
            //onmouseout                        用户从一个 HTML 元素上移开鼠标时发生
            //onkeydown                         用户按下键盘按键
            //onsubmit                          在转向页面之前，进行数据的有效验证，取消提交的方式：return false
            //模拟表单提交
            //input-button对象.submit();        不会触发onsubmit事件
            //DOM元素.click();                  模拟元素的点击事件
            //属性：event
            //function(e){}

            //动态操作节点
            //document.createElement()          动态创建元素
            //appendChild()                     将新元素追加到末尾
            //insertBefore(新元素对象, 原节点)    将新元素插入到某节点前
            //firstChild()                      获取第一个元素
            //childNodes                        获取所有子节点元素
            //removeChild(子元素对象)            删除元素
            //replaceChild()                    替换元素
            //获取或设置标签对的内容
            //innerText                         直接获取标签内的文本，火狐不支持-------textContent
            //innerHTML                         获取标签信息
            //使用js操作样式
            //元素.style.内容
            //特例：background-color             命名中不允许有-  所以将-后单词首字母大写
            //      float                        标准写法：style.cssFloat
            //设置标签可见性       style.display属性="block"----显示/"none"----隐藏

            //表单
            //required属性        ="required"表单自动验证是否为空
            //数据验证
            //用于确保用户输入的数据是否合法(必须字段是否有输入、是否输入了合法的数据、在数字字段是否输入了文本)
            //服务端数据验证：在数据提交到服务器上后再验证
            //客户端数据验证：在数据发送到服务器之前，在浏览器上完成验证


            //正则表达式
            //构造对象的方法
            //1、var regObj = new RegExp('\content');
            //2、var regObj = /content/;
            //推荐使用第二种，专门用于js，不需要考虑转义字符的影响
            //RegExp对象.test(string)                 检索字符串中的指定值，返回bool，同IsMatch()
            //RegExp对象.exec(string)                 检索字符串中指定值，返回值，没找到返回null，同Match()
            //字符串.match(/正则式/g)
            //                                        全局模式，在正则式末尾加g，结合循环匹配，同Matches()
            //字符串对象.replace(正则对象, string)      用string替换原式的内容，可以用全局的正则式替换多个(比如多个空格)

            //Cookie
            //用于存储 web 页面的用户信息
            //当 web 服务器向浏览器发送 web 页面时，在连接关闭后，服务端不会记录用户的信息
            //在用户下一次访问该页面时，可以在 cookie 中读取用户访问记录
            //Cookie 以名值对形式存储，username = John Doe
            //可以使用 document.cookie 属性来创建、读取、及删除cookie
            //document.cookie="username=John Smith; expires=Thu, 18 Dec 2043 12:00:00 GMT; path=/";
            //修改cookie              类似于创建 cookie
            //删除cookie              设置 expires 参数为以前的时间
            #region cookie实例
            //     < script >
            //      /**
            //      * 设置 cookie 值的函数
            //      */
            //      function setCookie(cname, cvalue, exdays){
            //        var d = new Date();
            //        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));//按天数计算cookie将存在的日期
            //        var expires = "expires=" + d.toGMTString();
            //        document.cookie = cname + "=" + cvalue + "; " + expires;//设置了cookie名、cookie值、过期时间
            //    }
            //    /**
            //     * 获取cookie值的函数
            //    */
            //    function getCookie(cname)
            //    {
            //        var name = cname + "=";
            //        var ca = document.cookie.split(';');
            //        for (var i = 0; i < ca.length; i++)
            //        {
            //            var c = ca[i].trim();
            //            if (c.indexOf(name) == 0) { return c.substring(name.length, c.length); }
            //        }
            //        return "";
            //    }
            //    /**
            //     * 检测 cookie 是否创建的函数
            //     * 如果设置了 cookie，将显示一个问候信息。
            //     * 如果没有设置 cookie，将会显示一个弹窗用于询问访问者的名字，并调用 setCookie 函数将访问者的名字存储 365 天：
            //    */
            //    function checkCookie()
            //    {
            //        var user = getCookie("username");
            //        if (user != "")
            //        {
            //            alert("欢迎 " + user + " 再次访问");
            //        }
            //        else
            //        {
            //            user = prompt("请输入你的名字:", "");
            //            if (user != "" && user != null)
            //            {
            //                setCookie("username", user, 365);
            //            }
            //        }
            //    }
            //</ script >
            #endregion


            //ajax
            //1、使用XHR发起get请求：
            //var vhr = new XMLHttpRequest();
            //xhr.open("get", url);                     指定请求方式与url
            //xhr.send(str);                            发起ajax请求，(str)用于POST请求
            //
            //处理响应回来的数据
            //  0: 请求未初始化
            //  1: 服务器连接已建立
            //  2: 请求已接收
            //  3: 请求处理中
            //  4: 请求已完成，且响应已就绪
            //xhr.onreadystatechange = function(){
            //  监听xhr对象的请求状态readystate和服务器的响应状态status
            //if(xhr.readyState === 4 && xhr.status === 200)
            //  服务器响应回来的数据
            //  console.log(xhr.responseText);
            //}

            //2、发起post请求：
            //在调用open()后
            //xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");


            //url中不允许出现中文字符
            //url编码：
            //使用安全的字符表示不安全的字符(英文字符表示非英文字符)
            //浏览器会自动进行操作
            //编码的函数,返回编码结果str                    encodeURL()
            //解码的函数,返回解码后的文本                   decodeURL()


            //数据交换格式
            //前端领域常用XML(少)和JSON
            //XML格式臃肿，和数据无关的代码多，体积较大，传输效率较低，在JS中解析XML比较麻烦
            //JSON本质为字符串，更加轻量级，更易于解析，不允许单引号表示字符串，属性名必须用双引号包裹，不能在json中写注释，不能使用undefined或函数作为值
            //
            //json转js                              JSON.parse()
            //js转json                              JSON.stringify()

            //xhr.timeout                           设置HTTP的请求时限，超时后自动停止请求，ontimeout事件可以用来指定回调函数
            //var fd = new FormData()               模拟表单操作，也可以获取网页表单的值
            //1、模拟表单
            //  fd.append("name","")
            //  xhr.open("post","./formdata");
            //直接提交FormData对象
            //  xhr.send(fd);

            //2、获取表单数据
            //var form = document.querySelector("#form1");
            //form.addEventListenr("submit", function(e){
            //  e.preventDefault()
            //  var fd = new FormData();
            //  var xhr = new XMLHttpRequest();
            //  xhr.open();
            //  xhr.send(fd);
            //  xhr.onreadystatechange = function(){};
            //})

            //显示文件上传进度
            //xhr.upload.onprogress = function(e){
            //  if(e.lengthComputable){
            //  var percentComplete = Math.ceil((e.uploaded / e.total) * 100);
            //  }
            //}

            //同源：
            //如果两个页面的协议、域名、端口号相同，则其具有相同的源
            //同源策略：限制了从同一个源加载的文档或脚本如何与另一个源的资源进行交互，是隔离潜在恶意文件的重要安全机制
            //无法读取非同源的Cookie、localStorage、indexedDB，DOM、发送ajax请求
            //跨域
            //浏览器允许跨域访问，但请求回来的数据会被同源策略拦截，无法被页面获取
            //实现跨域请求的方案：
            //1、JSONP      只支持get请求
            //2、CORS       W3C标准
            //JSON with Padding
            //是JSON的使用模式
            //实现原理是通过<script>的src属性请求跨域的数据接口，并调用函数，接受响应回来的数据
            //script标签不受同源则略的影响，可以通过src属性请求非同源的js脚本
            //在src中添加?callback=函数名&name=xx&age=xx
            //在ajax中发起JSONP请求必须包含dataType:"jsonp",

            //缓存
            //将用户输入的内容作为键，响应的数据作为值添加到缓存中去
            //防抖(debounce)
            //当事件被触发后，延迟n秒再进行回调，如果这时又被触发则重新计时
            //节流(throttle)
            //减少一段时间内事件的触发频率(只在单位时间内触发一次)
            //  节流阀：为空时可以进行下一步的操作，操作完成后将其重置为空
            #region ES6
            //ES6

            //webpack
            //js应用程序的静态模块打包器
            //当webpack处理应用程序时，会递归地构建一个依赖关系图，包含每个应用程序所需的模块，然后将这些模块打包
            //四个核心概念：
            //  1、入口entry
            //      指示webpack应该使用哪个模块，用来构建其内部依赖图的开始
            //          单个入口的写法：
            //          const config = {
            //              entry: "相对路径"
            //              output: {
            //                  filename: "",
            //                  path: apth.resolve(__dirname, "dist")
            //              }
            //          }
            //          对象语法：
            //          const config = {
            //              app: "",
            //              vendors: ""
            //          }
            //  2、输出
            //      输出属性output，知识在哪里输出创建好的bundles，以及如何命名的方法， 默认值为./dist
            //  3、loader
            //      用于转换某些类型的模块, 处理非js文件
            //  4、插件
            //      打包优化、压缩、定义环境变量等
            //      const webpack = require("webpack")
            //      然后将其添加到plugins数组

            //gulp是一个自动构建工具
            //  全局安装
            //  npm install gulp -g
            //  在项目中引入依赖
            //  npm install gulp --save-dev
            //  创建gulpfile.js的文件
            //      const gulp = require("glup");
            //      const uglify = require("uglify");
            //      gulp.task("default", function(){
            //          gulp.src("相对路径")
            //              .pipe(uglify())
            //              .pipe(gulp.dest("./dist"))
            //      })
            //  运行
            //  $ gulp


            //解构赋值
            //对赋值运算符进行的扩充，针对数组或对象
            //  可嵌套
            //      let [a, [[b], c]] = [1, [[2], 3]];
            //      a=1, b=2, c=3
            //  可忽略
            //      let [a, , b] = [1, 2, 3];
            //      a=1, b=3
            //  不完全解构
            //      let [a = 1, b] = []
            //      a=1, b=undefined
            //  剩余运算符
            //      let [a, ...b] = [1, 2, 3]
            //      a=1, b=[2, 3]
            //  字符串等
            //      let [a, b, c, d, e] = "hello"
            //      a="h"
            //  当解构模式有匹配结果且为undefined时结果为默认值
            //
            //对象模型的解构赋值

            //Symbol
            //表示独一无二的值，可以用来定义对象的唯一属性
            //每一个Symbol的值都是不相等的所以可以用来保证对象属性不重名
            //Symbol作为属性名用方括号[]
            //作为属性名时是公有属性，可以在类的外部访问
            //无法通过for循环读取，可以通过Object.getOwnPropertySymbol()和Reflect.ownKeys()读取
            //  let a = Symbol("A");        //"A"参数作为名称
            //  let obj = {};               //创建对象
            //  obj[a] = "AB";              //属性值为"AB"
            //obj对象展开为： {Symbol(A): "AB"}
            //Symbol.for()                  类似于单例模式，实例化后登记在全局环境中供搜索
            //Symbol.keyFor()               返回一个已登记的Symbol类型的key，用来检测是否已登记

            //Map对象
            //  var newMap = new Map()
            //  newMap.set("keyCanBeAny", "value")
            //  newMap.get("key")
            //Map对象保存键值对，键或值可以是任何值
            //Map对象中的键是有序的，键值对个数可以通过size属性获取
            //Map构造函数可以将一个二维键值对数组转化为Map对象------使用Array.from()函数可以将一个Map对象转换为二维键值对数组
            //for(var [key, value] of newMap.entries()){}-------entries 返回一个新的Iterator对象其按插入顺序包含了Map对象中每个元素的[k, v]数组
            //Set对象
            //用来存储任何类型的唯一值
            //var newSet = new Set();
            //用途：
            //  数组去重                    new Set([])
            //  并集                        new Set([...a, ...b])
            //  交集                        new Set([...a].filter(x => b.has(x)))
            //  差集                        new Set([...a].filter(x => !b.has(x)))

            //Promise
            //顺序地使用异步处理
            //Promise构造函数只有起始函数一个参数
            //起始函数包含resolve(一切正常)和reject(出现异常)参数
            //Promise类包含.then、.catch、.finally
            //resolve()中可以设置参数传递给then
            //reject()可以传参给catch
            //标记async fun为异步函数
            //await后跟Promise对象 



            #endregion

            #endregion
            #region jquery
            //Jquery
            //js类库，使用前要引入jquery.js文件
            //$对象是jquery对象的简写形式
            //.min表示压缩版本
            //链式编程、隐式迭代（自动将数组当中的每个元素都执行一遍操作）
            //功能：对象处理、属性、css、选择器、筛选方法、文档处理、事件(对原有DOM事件封装)、效果、Ajax、工具

            //1、基本选择器：
            //id选择器 #id、      元素选择器 标签、       类选择器 .class
            //使用：
            //1、引入.js文件
            //<script src="scripts/jquery-3.6.0.js"></script>
            //2、前缀：$
            //$("#id")          获取DOM元素         返回juqery对象，其本质为DOM数组
            //DOM对象转换jquery对象                      $(DOM对象名称)
            //jquery对象转换DOM对象                      jq对象.get(index) 或 jq对象[index]
            //注意直接通过索引访问会将jq对象转为DOM对象，因此选择通过jq对象.eq()方法拿到内部的jq对象

            //事件
            //jq对象.事件名(function(){
            //});
            //常见事件：
            //click、dbclick、mouseenter、mouseleave、keypress、keydown、keyup
            //表单事件：
            //submit、change、focus、blur

            //合成事件处理程序
            //hover(fn1, fn2)                           fn1表示mouseover的处理函数，fn2表示mouseout的处理函数
            //toggle(fn1, fn2... fnN)                   当元素被点击后fn1、fn2...依次执行
            //one(type, fn)                             表示type型事件只响应一次，然后失效

            //动态处理文档
            //创建元素
            //$("标签字符串")
            //添加元素
            //append(), appendTo()                      要添加的元素内容的jq对象.appendTo(目标标签的jq 对象)
            //prepend(), prependTo()                    在被选元素的开头插入内容
            //after(), insertAfter()                    在被选元素之后插入内容
            //before(), insertBefore()                  在被选元素之前插入内容
            //动态删除元素
            //empty()                                   清空子元素
            //remove(selector)                          无参表示将自己删除，否则删除符合选择器的内容

            //标签属性操作
            //jquery对象.操作方法名
            //获取属性值                                 attr(属性)
            //设置属性值                                 attr(属性, 值)
            //操作标签的值                               text(), html()
            //操作控件的值                               val()
            //移除属性                                   removeAttr()
            //prop表示元素的原有属性，attr表示扩展属性

            //遍历
            //$.each() 方法为每个匹配元素规定要运行的函数
            //$(selector).each(function(index,element))

            //2、层级选择器
            //空格                     取子元素，都能取到
            //大于号>                  直接子元素
            //加号+                    之后紧邻的一个统同级元素
            //波浪号~                  之后所有的同级元素
            //      方法：
            //next()    nextAll()
            //prev()    prevAll()
            //siblings()               兄弟
            //parent()  children()

            //样式
            //jq对象.css("color", "red");
            //设置多个样式：   css({键1:值1, 键2:值2, 键3:值3})
            //
            //类操作
            //.blue{
            //      font:blue;
            //      }
            //jq对象.addclass("blue");

            //链式编程
            //只查找一次，支持逐个使用方法
            //$().text().css()
            //
            //.end()------恢复最近的一次链破坏

            //3、过滤选择器
            //对于选择结果进行进一步过滤
            //:first    :last   :eq()-----按下标获取   :gt()   :lt()   :not()      :even偶数     :odd奇数
            //以下标判断奇偶，下标从零开始

            //函数调用
            //方法名.call(对象)                    表示由哪个对象来调用此方法,方法中的this 指这个对象,但是无法传递参数
            //方法名.apply()                       调用的时候还可以传递参数
            //意义：在不改变元对象源代码的情况下让函数内部的this 表示当前的对象

            //4、属性选择器
            //选择包含指定属性的jquery对象
            //$("input[name]")                      表示所有含有name属性的input元素
            //$("input[name = ...]")                表示name 属性值为...的元素
            //attribute( !=   ^=  $=  *= )value     ^=($=)表示开头(结尾)为value的元素
            //写多个[]                               表示同时具有多个属性

            //5、表单选择器
            //$(":input")
            //:input    :text   :password   :submit ...
            //选择表单对象属性
            //:enabled  :disabled   :checked    :selected

            //jquery动画效果
            //可以在动画函数中传递一个callback参数，表示动画完成后在每个元素上执行函数
            //基本：
            //show(speed, [easing], [fn])                      点击出现，可以设置出现的速度以及效果
            //hide()                                           点击隐藏
            //toggle()                                         点击出现，再次点击隐藏
            //滑动：
            //slideDown()
            //slideUp()
            //slideToggle()
            //淡入淡出
            //fadeIn()
            //fadeOut()
            //fadeToggle()
            //fadeTo(speed, opacity)                           指定过渡到不透明度为0-1之间
            //自定义动画
            //animate(目标样式, 时间)
            //只能对数字类型的样式设置动画
            //使用链式编程将多个动画拼接起来
            //":animated"选择器可以拿到正在执行的动画元素
            //stop()                                           无参表示停止当前正在进行的动画,true参数表示停止所有动画并且清除动画队列

            //第三方插件
            //基于jquery开发的组件
            //先引入jquery

            //常用jquery组件：
            //1、cookie
            //本质：键值对字符串信息
            //作用：记录请求数据的用户
            //设置cookie                          $.cookie(, )                第一个参数是键，第二个参数是值
            //读取cookie                          $.cookie()                  参数是键，根据键返回值
            //$.cookie('name', 'value', { expires: 7, path: '/' });
            //2、jqueryUI
            //引入css、js文件
            //3、jqzoom
            //图片放大镜
            //引入css、js、zoomcore

            //$.ajax({
            //  method:"get",
            //  url:"",
            //  data:{}
            //}, success:function(){})
            #endregion
            #region Node.js


            //思考题：
            //4.1、因为脚本语言、数据库的加入，让Web不只是简单的HTML文档，越来越多的数据分布在Web的不同地方，通过API和网络联合在一起
            //4.2、Node.js适合应用程序需要在网络上发送和接受数据的时候，其可能是API、联网设备或浏览器与服务器之间的实时通信
            //5.2可以在http头中发送可接受的字符集、特权授权证书、日期、用户代理等
            //6.1express适合处理视图或在Web浏览器中显示数据
            //6.2使用模板引擎可以更快地开发，更容易维护




            //创建一个node服务器
            // var http = require("http");
            // http.createServer(function(req, res){
            //     res.writeHead(200, {"Content-Type":"text/plain"});
            //     res.end("this is the end");
            // }).listen(50789, "127.0.0.1");//第一个参数为端口号
            // console.log("Server running success at http://127.0.0.1:50789");
            //保存为server.js
            //从终端(cmd)运行node server.js启动服务器
            //在终端Ctrl+C终止运行
            //cd ../                            向上一层路径

            //npm:(Node Package Manager)
            //可以重用的代码库
            //示例：(数据库交互、验证数据输入、分析yaml文件)
            //打开服务器等node命令直接在终端中写
            //node.exe可以直接写js代码
            //在使用npm之前必须请求模块          var module = require("module");
            //使用终端安装npm模块                npm install [module名] (-g)
            //                                  加-g 表示全局安装npm
            //                                  本地安装在node_modules文件夹中
            //确保npm安装在正确的位置，在安装之前需要位于指定文件夹当中
            //升级旧版本的npm                   npm install [] -g
            //清空npm本地缓存                   npm cache clear
            //在线搜索官方npm                   npm search []
            //更新npm                           npm update []
            //卸载npm                           npm uninstall [npm名]
            //可以使用package.json指定依赖关系来代替一个一个安装模块
            //{
            // "name":"example",                    包名
            // "version":"0.1",                     版本号
            // "description":"i's 1th pack",        描述
            // "homepage":"www."                    官网url
            // "author":""                          作者
            // "respondencies":""                   存放的类型(svn|git)
            // "main":""                            程序主入口文件,require函数加载的文件,默认index.js
            // "dependencies":{                     依赖包列表，如果没有会自动安装在node_modules目录下
            //     "underscore":"-1.2.1"
            // }
            //}
            //
            //npm镜像
            //淘宝：npm install -g cnpm --registry=http://registry.npmmirror.com
            //镜像之后可以直接使用cnpm install [name] 安装

            //常用工具
            //util.callbackify(func)                将async异步函数转换成遵循回调风格的函数
            //util.inherits(子, 父)                 实现对象间原型继承
            //util.inspect(o, showHidden, depth, color)
            //                                      将任意对象转换为字符串，showHidden(true时输出更多隐藏信息)，depth最大递归层数
            //util.isRegExp                         是否为正则

            //I/O
            //(输入/输出)操作
            //cmd命令echo(                       用于回显提供的文本
            //基于网络的I/O是不可预测的，每次访问相同的网页时获得响应的时间都不相同、
            //事件驱动的编程是处理Web不可预测性的极佳方式，我们不用知道事件什么时候会发生
            //并发
            //指可能在同一时间发生并可能相互交互的事
            //Node的事件化的I/O模型可以不用考虑 互锁 和 并发 的问题
            //Node运行在单一的进程中且要求异步编码风格
            //同步的代码意味着在一个操作完成前，每执行一个操作，代码的执行会被阻塞
            //事件循环可以将回调函数先保存起来，等事件发生时再运行
            //由于事件循环以单一进程为基础，因此为了确保瞬间完成的高性能需要遵守：
            //      1、函数必须快速返回
            //      2、函数不能阻塞
            //      3、长时间运行的操作需要转移到另一个进程当中

            //HTTPHeader
            //增加头：
            //res.writeHead(响应码, 请求头对象)
            //url模块的parse函数可以手动解析传入url参数中的内容
            //第二个参数默认为false即query属性为一个字符串      当为true时query属性为json对象格式
            //1、解析get请求
            //var url = require("url");
            //var util = require("util");
            //返回json对象
            //var pars = url.parse(req.url, true).query;
            //res.write(pars.name);
            //res.write(pars.url);
            //res.end(util.insepct(pars));--------//通过util模块的inspect函数将对象转为字符串
            //2、解析post请求
            //node默认不会解析post的请求体，需要手动实现
            //var queryString = require("queryString");
            //var post = "";
            //  通过req的data事件监听函数，每当接收到请求体的数据就追加到post对象中
            //req.on("data", function(chunk){
            //     post += chunk;
            //});
            //  在end事件触发后，通过queryString.parse将post对象解析为真正的post请求格式
            //req.on("end", function(){
            //     post = queryString.parse(post);
            //     res.end(util.insepct(post));
            //});

            //重定向：
            //res.writeHead(301.{
            //     "Location":"http://www..com"
            // });

            //路由(route)：
            //响应不同的请求

            //使用node的http客户端
            //客户端不只包含浏览器，可以是任何对服务器请求响应的东西(邮件客户端、Web刮取器)
            //需要应用html客户端的场景有：
            //监控服务器的正常工作时间、刮取不能通过API获取的Web内容、创建Web的多个信息来源组合在一起的混搭


            //Express框架
            //使用框架可以减少创建应用程序的时间，如路由、视图层已经在框架中处理，代码稳定性可以保障
            //Express能实现:基于JSON的API、单页面Web应用程序、实时Web应用程序
            //Express示例站点文件夹内容：
            //  app.js                          用来启动应用程序的文件夹包含配置信息
            //  node_modules                    保存在package.json中已经定义的模块
            //  package.json                    提供应用程序信息，包括需安装的依赖模块
            //  public
            //  routes
            //  views                           定义应用程序布局(layout)
            //express提供了内置的中间件express.static 来设置静态文件(路径)如图片、css、js等
            //app.use("/directory", express.static("directory"))

            //var express = require("express");
            //var app = express();
            // app.get("/index.html", function(req, res) {
            //    res.sendFile(__dirname + "/" + "index.html");
            // })
            //  app.post('/', function (req, res) {
            //     console.log("主页 POST 请求");
            //     res.send('Hello POST');
            //  })

            #region jade
            //jade
            //模板引擎(将视图编译为html)      也称为模板处理器或过滤器，如Smarty(PHP)和ERB(Ruby)
            //Jade  使用缩进表示HTML文档的层次结构
            //      无需使用标记，编译的时候会自动生成<>
            //使用模板引擎的例子：
            //      显示一组保存在数据库中的帖子
            //      创建单一的模板用于显示不同的帖子
            //      按变量的值更改页面的<title></title>元素
            //html                              编译后：<html></html>
            //p#first                           <p id="first"></p>
            //div.nav                           <div class="nav"></div>
            //span#first.nav                    <span id="first" class="nav"></span>
            //p.first.second.third              <p class="first second third"></p>
            //p
            //  span                            使用缩进：<p><span></span></p>
            //p This is the Txt                 在标记定义后加入文本<p>This is the Txt</p>
            //p
            //  | Txt
            //  | Over
            //  | Lines                          使用管道描述符|组织长文本
            //form(method="post", action="#")    给标签添加属性值
            //使用Jade输出数据
            //-                 随后的代码应当被执行
            //=                 告诉解释器要对代码进行演算、转义、然后输出
            //#{变量}            将变量替换为字符串
            //
            //循环：
            // -var name = "ZS"
            // -array = {firstName:"San", lastName:"Zhang"}
            // -each val, key in array
            // li #{key}:#{val}
            //
            //在jade模板中内联使用js
            //script
            //  alert()
            //使用include关键字添加包含的模板
            //include 路径/文件名
            //mixin关键字：将重复的代码块封装起来
            //mixin users(users)
            //  ul
            //      each user in users
            //          li= user
            //调用：
            //-users = ["ZS","LS","WW"]
            //mixin users(users)
            #endregion


            //获取参数：
            //req.params["参数名"]或req.params.参数      app.get("/:参数名", fun)
            //req.query[""]                             用在get请求中，app.get("/?参数名", fun)
            //req.body.参数名                           用在post请求，app.post("/body", fun)

            //var routes = require("./routes")
            //res.render(view, [locals], callback)     渲染一个视图，同时向callback传递选然后的字符串
            //render：渲染模板、将本地变量传递给模板、使用布局文件(layout)、发送响应码
            //res.render("index.jade", {title: "WebSite"});默认使用布局文件
            //可以指定不同的或不使用布局文件res.render("page.jade", {layout: false});
            //本地变量：
            //var users = {
            //     "user1":{
            //      first_name: "San",
            //      last_name: "Zhang",
            //      address:"eastStreet:2062"
            //     }
            // };
            // res.render("index.jade", {title:"Users", user:user["user1"]});

            //中间件
            //指业务流程的中间处理环节,本质上是函数
            //请求到达Express的服务器后可以连续调用多个中间件，对这次请求进行预处理
            //中间件函数必须包含next形参(把流转关系转交给下一个中间件或路由)
            //app.get("/", function(req, res, next){
            //  next();//最后写
            //})
            //定义一个全局生效的中间件，任何请求到达后都会触发
            //app.use(中间件函数)
            //当定义多个中间件时，按照定义的顺序依次执行，其共享req和res对象
            //局部生效的中间件：不适用app.use定义
            //要在路由之前注册中间件
            //分类：
            //应用级
            //路由级


            #region 文件系统
            //在Web应用程序中，持久的数据指的是被保存在某个地方将来还可以拿出来用的数据
            //持久的数据可以被储存在：硬盘或闪盘、内存、数据库、cookie或会话
            //
            //写入文件操作
            //  新写入的内容会覆盖之前的内容
            // var data="はしゃいでいた君はどこへ行ったの";
            // fs.writeFile("C:\Users\Attac\Desktop\newHTML\node\newNodeFS.txt", data, function(e) {
            //    if (!e) {
            //       console.log("write success");
            //    }
            //    else{
            //       alert(e);
            //    }
            // })
            //
            /*读取文件操作 */
            // fs.readFile("newNodeFS.txt", "utf8", function(e, data) {
            //    if (!e) {
            //       console.log(data);
            //    }
            //    else{
            //       alert(e);
            //    }
            // });
            //文件上传：
            //  表单enctype属性设置为"multipart.from-data"
            //app.post('/file_upload', function (req, res) {
            //    console.log(req.files[0]);  // 上传的文件信息
            //    var des_file = __dirname + "/" + req.files[0].originalname;
            //    fs.readFile( req.files[0].path, function (err, data) {
            //         fs.writeFile(des_file, data, function (err) {
            //          if( err ){
            //               console.log( err );
            //          }else{
            //                response = {
            //                    message:'File uploaded successfully',
            //                    filename:req.files[0].originalname
            //               };
            //           }
            //           console.log( response );
            //           res.end( JSON.stringify( response ) );
            //        });
            //    });
            // })
            //关闭文件
            //fs.close(fd, callback)
            //截取文件
            //fs.ftruncate(fd, len, callback)
            //  len文件截取的长度
            //删除文件
            //fs.unlink(path, callback)
            //打开文件：
            //fs.open(path, "flags", mode, callback)
            //mode:设置文件模式，默认为0666(可读可写)
            //flags:
            //  r               读取模式，加s表示同步方式
            //  w               写入模式，文件不存在则创建
            //  a               追加模式，文件不存在则创建
            //在后面加 + 表示读写模式
            //文件信息：
            //fs.stat(path, function(e, stats){
            //  console.log(stats.isFile());
            //})
            //stats类的方法：
            //isFile()
            //ifDirectory()

            //如果只是一次性地将数据项目储存起来，以后再读取，则可以储存在环境变量中
            //  应用实例：数据库连接字符串、储存秘密(secret)和键值(key)、为不同的服务器储存用户名
            //在终端中运行set查看环境变量
            //通过js代码process.env.环境变量名 就可以读出

            //__filename()正在执行的脚本的文件名，输出文件所在位置的绝对路径，如果在模块中返回模块文件的路径
            //__dirname(双下划线)是一个路径处理模块，其总是指向被执行的js文件的绝对路径
            //./会返回执行node命令的路径
            //出现路径拼接错误的问题，是因为提供了./或../开头的相对路径
            //指定完整存放路径需要//表示"/" ,这种方式不利于维护

            //path路径模块
            //var path = require("path")
            //path.join(["../"])                         将多个路径片段拼接为完整的路径字符串，../表示返回上一层路径
            //path.basename(path, ext)                   获取路径中的最后一部分，可以用来获取文件名，第二个参数可选：表示文件的扩展名
            //path.extname(path)                         获取路径中的扩展名部分

            //js中没有二进制数据类型
            //支持的编码包括(ascii、utf8、ucs2、base64、Latin1/binary、hex(将每个字节编码为两个十六进制字节))
            //创建对象
            //var buf = Buffer.from("str","ascii")
            //Buffer.alloc(size, fill)                   size指定大小,fill填充
            //写入缓冲区：
            //buf.write()                                返回实际写入的大小
            //从缓冲区读取数据：
            //buf.toString("编码")                       返回字符串
            //将Buffer转换为JSON对象
            //buf.toJSON()                               返回JSON对象
            //缓冲区合并
            //Buffer.concat(list, totalLength)           返回新Buffer对象
            //缓冲区比较
            //buf.compare(other)                         返回数字表示buf在other之前(<0)、相同、之后
            //复制
            //buf.copy(目标buf)
            //裁剪
            //buf.slice(start, (end))
            //缓冲区长度
            //buf.length
            #endregion

            //process
            //描述当前Node.js进程状态的对象
            //process.abort()                           退出并生成一个核心文件
            //process.chdir()                           改变当前工作进程的目录，操作失败则退出并爆出异常
            //process.cwd()                             返回当前进程的工作目录
            //process.exit(code)                        使用指定的code结束进程，默认0
            //process.uptime()                          返回Node已运行的秒数
            //

            #region MongoDB
            //MongoDB:
            //  文档的增删查改用mongoose。
            //  操作mongoDB数据库本身用mongodb(Node.js MongoDB Driver)
            //CRUD(Create、Read、Update、Delete)
            //var mongoose = require("mongoose");
            //无需手动创建数据库
            //mongoose.connect("mongodb://localhost/todo_development", callback)
            //
            //在MongoDB中没有关系数据中表的概念，而是集合(文档)，其具备多种属性
            //通过Mongoose模块中的Schema接口定义任务文档，然后声明属性
            //Mongoose中的数据类型：
            //String、Number、Date、Boolean、Buffer、ObjectID、Mixed、Array
            //             var MongoClient = require("mongodb").MongoClient;
            // var dburl = "mongodb://localhost:27017/school";

            // //连接/创建数据库
            // MongoClient.connect(dburl, function (e, db) {
            //   if (!e) {
            //     console.log("conncet to mongodb");
            //   }
            // });

            // //添加数据
            // app.get("/add", function (req, res) {
            //   MongoClient.connect(dburl, function (e, client) {
            //     if (!e) {
            //       var db = client.db("school");
            //       //连接student集合并插入一条数据
            //       db.collection("student").insertOne({
            //         "name": "zs",
            //         "sex": "m",
            //         "age": 20
            //       }, function (e, result) {
            //         if (!e) {
            //           res.send("插入成功！");
            //         } else {
            //           console.log(e.message);
            //         }
            //       });
            //     } else {
            //       console.log(e.message);
            //     }
            //   });
            // });

            // //修改数据
            // app.get("/edit", function (req, res) {
            //   MongoClient.connect(dburl, function (e, client) {
            //     if (!e) {
            //       var db = client.db("school");
            //       //连接student集合并插入一条数据
            //       db.collection("student").updateOne({
            //         "name": "李四"
            //       }, {
            //         $set: {
            //           "sex": "男"
            //         }
            //       }, function (e, result) {
            //         if (!e) {
            //           res.send("修改成功！");
            //         } else {
            //           console.log(e.message);
            //         }
            //       });
            //     } else {
            //       console.log(e.message);
            //     }
            //   });
            // });

            // //删除数据
            // app.get("/delete", function (req, res) {
            //   var query = url.parse(req.url, true).query;
            //   var name = query.name;
            //   MongoClient.connect(dburl, function (e, client) {
            //     if (!e) {
            //       var db = client.db("school");
            //       //连接student集合并插入一条数据
            //       db.collection("student").deleteOne({
            //         "name": name
            //       }, function (e, result) {
            //         if (!e) {
            //           res.send("删除成功！");
            //         } else {
            //           console.log(e.message);
            //         }
            //       });
            //     } else {
            //       console.log(e.message);
            //     }
            //   });
            // });

            // //查询数据
            // app.get("/query", function (req, res) {
            //   MongoClient.connect(dburl, function (e, client) {
            //     if (!e) {
            //       var db = client.db("school");
            //       //用一个对象接受数据再循环输出
            //       var cursor = db.collection("student").find();
            //       var list = [];
            //       cursor.forEach((e, doc) => {
            //           if (!e) {
            //             if (doc != null) {
            //               list.push(doc);
            //             } else {
            //               res.send(list);
            //             }
            //           }
            //           else {
            //             console.log(e.message);
            //           }
            //         });
            //     } else {
            //       console.log(e.message);
            //     }
            //   });
            // });
            #endregion
            #region MySQL
            //MySQL中的单行注释为#或者--空格
            //         多行注释为/**/

            //连接MySQL的步骤：
            //1、引入mysql模块
            //2、创建连接mysql.createConncetion({
            //     host:"127.0.0.1",
            //     user:"root",
            //     password:"",
            //     database:""
            // })
            //mysql.query(sql, (e, results) => {}))

            //使用sql语句导出将表格导出为csv文件(表格)
            // select * from course INTO OUTFILE 'D:/Program Files (x86)/MySQL/outfiles/table.csv'
            // fields terminated by ',' enclosed by '"'
            // lines terminated by '\r\n'

            //声明全局变量：
            //  会占用，非必要不使用
            //  SET @变量名 = 值;
            //局部变量
            //  在BEGIN、END中局部使用
            //  DECLARE 变量名 类型 [DEFAULT] 值;

            //存储过程( [] 表示可选)：
            //  DROP PROCEDURE IF EXISTS 方法名;
            //  DELIMITER &&                                                      //定义局部换行分隔符
            //  CREATE PROCEDURE 方法名([IN 参数名, ..., OUT 参数名])
            //    BEGIN
            //    END&&
            //  DELIMITER;                                                        //将分隔符恢复为;
            //
            //调用存储过程
            //CALL 方法名()

            //执行预定义语句
            //PREPARE sqlStr FROM @sqlStr;
            //EXECUTE sqlStr;
            //DEALLOCATE PREPARE sqlStr;
            #endregion

            //调试
            //1、安装node-inspector
            //2、终端运行node --inspect-brk ..js
            //3、浏览器打开chrome://inspect/#devices

            //部署


            //RESTful API
            //表述性状态传递，是一组架构约束条件或原则，通常使用JSON数据格式
            //REST基本架构的四个方法:GET PUT DELETE POST


            //Socket.IO
            //实时Web应用程序
            //在服务器和浏览器之间保持一直打开


            //多进程
            //Node以单进程运行，使用事件驱动处理并发
            //每个子进程有三个流对象：child.stdin、child.stdout、child.stderr
            //使用child_process模块创建子进程
            //child.exec()使用子进程执行命令，缓存子进程的输出，并将子进程的输出以回调函数参数的形式返回
            //  .spawn 使用指定的命令行参数创建新进程
            //  .fork 是spawn方法的特殊形式，用于创建进程




            #endregion
            #region Vue3
            //Vue3
            //使用命令安装vue 以及vue cli
            //cnpm install vue@next
            //cnpm install @vue/cli
            //引入script    src="https://unpkg.com/vue@next"
            //插值表达式{{}}用于输出对象属性和函数返回值        支持js表达式，例如三目运算符
            //Vue3直接面向数据
            //Vue的设计模式：MVVM(Model-View-ViewModel)

            //在vue3项目中使用element-plus:
            //  引入npm i element-plus --save
            //  在main.js中import导入ElementPlus和样式文件
            //  .use(ElementPlus)


            //命令创建Vue项目
            //      vue create 项目名
            //命令启动
            //      npm run serve
            //命令打开GUI
            //      vue ui


            //Vue.createApp({}).mount("#app")
            //1、data选项是一个函数，Vue在创建新项目的时候调用，vue通过响应性系统将其包裹起来并以$data的形式保存在组件实例中
            //  var app = Vue.createApp({
            //     data(){
            //         return{
            //          }----Model
            //     },
            //      template:""----View
            //  });
            //  const vm = app.mount("#app")----vm挂在到DOM上
            //  通过app.$data.item或者app.item可以访问到item，同时更新item的值也可以更新$data.item
            //2、可以在组件中添加方法，在createApp函数中添加method:{fun1, fun2}
            //  使用app.方法名来调用函数

            //<template></template>
            //不在页面中显示，用来控制业务逻辑

            //指令：
            //指令是带有v-前缀的特殊属性，用于在表达式的值改变时将某些行为应用到DOM当中
            //可以在指令后加上:来指明参数
            //修饰符.        v-on:submit.prevent="onSubmit"
            //v-once指令                只进行一次插值，当数据改变时，插值处的内容不会更新              <script v-once></script>
            //v-html指令                用于输出html代码                                             <span v-html="变量名"></span>
            //v-bind:属性名=""          如果属性值为null或者undefined，那么该属性不会显示出来           <div v-bind:class="div1"></div>
            //                          v-bind="$attrs" 将所有父组件中的属性复制到自身(子组件)
            //v-if=""                   根据变量的值(true/false)判断是否插入该元素                     <p v-if="view"></p>
            //v-else                    在v-if后使用
            //v-else-if=""
            //v-show="变量名"           是否展示(通过控制样式display=none/block)，效果同if
            //v-for="item in array"     绑定一个数组的元素来渲染一个项目列表
            //      tasks:[{value: "1"},{value: "2"},{value: "3"]
            //      <li v-for="task in tasks">{{task.value}}</li>
            //      <p v-for="(item, index) in array">{{index}}, {{item.字段}}</p>
            //      <p v-for="(value, key, index) in obj">{{key}}{{value}}</p>
            //在v-for标签中添加属性     :key="index+item"    可以在数据量较大时只更新数据而不是重新渲染整个页面
            //v-on                      用于监听DOM事件                                             v-on:click="event1"
            //v-model                   在表单元素控件上创建双向数据绑定(根据表单的值自动更新数据)
            //缩写：
            //v-bind:属性名=""          :属性名=""
            //v-on:click=""             @click=""
            //
            //注册自定义指令
            //  定义一个v-focus指令
            // app.directive("focus", {
            //     mounted(el){
            //         el.focus()
            //     }
            // })
            //  也可以通过directives注册局部指令



            //组件
            //  用标签<组件名/>实现组件内容
            //  降低程序的耦合性
            //1、全局组件
            // app.component("组件名", {
            //     template: ""
            // })
            //2、动态组件
            //  使用<component/>
            //  <component :is="变量名"/>
            //  动态组件中需要保留用户输入的内容        <keep-alive><component/></keep-alive>
            //  在父组件中通过绑定data传递动态值，如果写死的话只能传递string类型
            //  可以给子组件传递箭头函数，在子组件中也可以声明函数
            // app.component("组件名", {
            //     props: ["index", "item"],
            //     methods: 方法(){},
            //     template: `<li>{{index}}--{{item}}</li>`
            // })
            //3、局部组件
            //  只能在这个实例中使用
            //  const component1 = {template: ``};
            //  var app = Vue.createApp({
            //         components: {
            //             "component": component1
            //         }
            // })
            //4、组件验证
            // props:{
            //     prop1: Number,
            //     prop2: [Number, String],
            //     prop3: {
            //         type: String,
            //         require: true
            //     }
            //     prop4: {
            //         type: Number,
            //         default: 100
            //         //default: fun(){}
            //     }
            //     prop5: {
            //         validator: function(value){
            //             return value.search("") !== -1
            //         }
            //     }
            // }
            //5、单项数据流
            //  数据只能单向绑定，子组件内部不能修改由父组件传递的数据
            //  在子组件中通过data(){return{ 变量名}}改变
            //6、Non-props
            //  子组件没有接受父组件传递过来的参数，而完全不变的复制了属性到自己的标签上
            //  不用props接收
            //  inheritAttrs: true
            //7、调用父组件中的方法
            //  给子组件传递事件(@add="func")
            //  在子组件中声明emit: ["add"]
            //  写子组件的函数fun(){  this.$emit("add", [params])  }
            //8、插槽
            //  <slot></slot>
            //  使用组件时可以在标签(成对)内插入文本、html
            //  可以为插槽设置默认值
            //  具名插槽：
            //  <slot name="one"></slot>          需要使用多个插槽时
            //  调用    <template v-slot:one></template>
            //              简写<template #one></template>
            //  作用域插槽:
            //      将子组件中的变量传递给父组件使用
            //      子组件 <slot :item="变量名">
            //      使用时<组件名 v-slot=""/>
            //
            //9、作用域
            //  父模板里调用的是父模板里的元素
            //  子模板里调用的是子模板里的元素
            //10、异步组件
            //promise
            //需要花费时间加载时使用
            // app.component("", Vue.defineAsyncComponent(() => {
            //     return new Promise((resolve, reject) => {
            //         resolve({
            //             template: ``
            //         })
            //     })
            // }))
            //11、多级组件传值
            //provide和inject
            //  在父组件中声明provide
            //  在子组件中可以通过inject: ["变量名"]的方法接受而不需要通过属性传值
            //  中间可以越过多级进行

            //1、使用import引入子组件
            //  import 组件名 from "相对路径"
            //2、在子组件中export default{ 注册组件
            //     name: "",
            //     component: {}
            // }
            //3、通过标签在父组件中使用标签
            //  三个步骤缺一不可


            //生命周期函数(钩子函数)
            //在某时刻会自动执行的函数
            //beforeCreate()                    在实例生成之前自动执行的函数
            //created()                         在实例生成之后自动执行
            //beforeMount()                     在挂载之前(模板渲染完成之前)
            //mounted()                         挂载以后
            //beforeUpdate()                    data数据更改之前
            //updated()                         data更改后
            //beforeUnmount()
            //unmount()                         应用失效，DOM销毁后执行
            //参数有：
            //el                                指el指令绑定到的元素 可以直接操作DOM
            //binding
            //vnode
            //prevnode


            //计算属性computed
            //当计算属性依赖的内容改变时才会重新计算
            //在效果上与methods(重新渲染时执行)是一样的，但computed基于依赖缓存，只有依赖发生改变的时候执行，性能更好

            //监听器watch
            // watch: {
            //     变量名(){
            //     }
            // }
            //vm.$watch("变量名", (curr, prev) => {})-----------第二个参数为回调

            //样式绑定
            //:class="classArray"
            //在data中声明变量：
            //  classStr: "color"
            //  classArray: ["color", "background"]
            //  classObj: {color: true, background: false}

            //绑定事件
            //在@事件中传递默认参数(如event)时，前加$
            //当在一个事件中调用多个函数时，在@事件属性中用逗号隔开函数名，并加括号     @click="fun1(), fun2()"
            //事件修饰符:
            //  @事件名.stop                              阻止冒泡
            //  @事件名.self                              不会触发子元素，只有自己
            //  @事件名.prevent                           阻止元素默认行为
            //  @事件名.capture                           捕获冒泡，反转冒泡模式
            //  @事件名.once                              只能点一次
            //  @事件名.passive                           解决滚动时的性能
            //鼠标、按键修饰符
            //@事件名.13                                enter回车
            //@事件名.left   right   middle

            //表单数据双向绑定
            //在<textarea></textarea>文本区域使用v-model代替插值
            //<input type="checkbox" v-model="name" true-value="T" false-value="F"/>{{name}}
            //修饰符
            //v-model.lazy                                当失焦的时候进行双向绑定
            //v-model.number
            //v-model.trim                                去掉前后空格


            //路由
            //  Vue路由允许通过不同的URL访问不同的内容，可以不写a标签
            //  可以在不重新加载页面的情况下对url进行操作
            //  需要载入vue-router库使用<router-link></router-link>      <script src="https://unpkg.com/vue-router@next"></script>
            //  使用router-link组件
            //      属性:
            //      to                                      指定链接，当被点击后，内部会立刻把值传递到router.push()
            //      replace                                 点击后调用router.replace()，不会留下历史记录        <router-link :to="" replace>
            //      append                                  在当前相对路径前添加路径
            //      tag                                     将router-link渲染为何种标签
            //      active-class                            设置链接激活时使用的CSS类名
            //      event                                   声明可以用来触发的事件，可以为一个数组
            //  使用<router-view></router-view>指定路由渲染的位置
            //  创建路由        VueRouter.createRouter      参数history: VueRouter.createWebHashHistory(), routes对象


            //混入
            //  mixins定义了一部分可以复用的方法或computed
            //  混入对象可以包含任意组件选项
            //  组件使用混入对象时，所有混入对象的选项被混入组件的选项
            //  //定义混入对象
            // const mixin = {
            //     created(){
            //         this.sayHi()
            //     },
            //     methods:{
            //         sayHi(){
            //             console.log("Hi");
            //         }
            //     }
            // }
            // //使用混入
            // const app = Vue.createApp({
            //     mixins: [mixin]
            // }).mount("#app")
            //
            //当组件和混入的对象含有同名选项时，这些相将以恰当的方法结合
            //数据对象会在内部进行浅合并，发生冲突时组件的选项(methods、component、directives)优先
            //同名生命周期函数将会合并为一个数组，因此都会被调用，混入对象的会优先调用
            //可以使用app.mixin()定义全局混入对象，这会影响到之后创建的Vue实例


            //axios
            //  用来完成ajax请求
            //  需要载入    <script src="https://unpkg.com/axios/dist/axios.min.js"></script>
            //  可以用axios.get("", {params: {}})代替在url中添加参数
            //  执行多个并发请求
            //  axios.all([fun1(), fun2()])
            //      .then(axios.spread())






            #endregion
            #region 小程序
            //更改主界面上方颜色：app.json--window--naviBGColor
            //添加页面：app.json--pages--"pages/xx/xx"
            //允许使用爬虫进行全局搜索：project.config.json--setting--"checkSiteMap": true
            //通过this.setData函数给data中的变量赋值
            //使用view代替div
            //scroll-view                   容器页面
            //swiper                        滚动窗口(有indicator)
            //text                          只有text可以长按选择操作，指定selectable="true"
            //rich-text                     通过nodes属性可以将html渲染到页面当中
            //button                        open-type提供的功能 bindtap绑定事件函数 data-*="{{}}"传递参数
            //                                                 在事件处理函数中通过 event.target.dataset.参数名 拿到值
            //block                         包裹性质的容器，不会被渲染到页面当中
            //hidden属性                    可以代替wx:if="{{condition}}"   运行方式为切换样式
            //wx:for="{{array}}"            默认{{index}}   {{item}}    wx:for-item="iName"手动指定变量名{{iName}}  wx:key="id"提高渲染效率

            //rpx   将不同大小的屏幕均分为750等分来实现自动适配     在ip6上1px = 2rpx
            //@import "xx.wxss";样式导入外联样式表
            //在app.wxss中定义全局样式  就近原则局部样式会覆盖全局样式

            //tabBar                        底部、顶部(不显示图标)，用于多页面的快速切换，最少2最多5
            // "tabBar": {
            //     "list": [{
            //         "pagePath": "",
            //         "text": ""
            //     }],
            //     "position": "bottom",
            // }

            //就近原则，页面配置会覆盖全局配置
            //数据接口只能请求https且必须将接口的域名添加到信任列表中
            //跳过request合法域名校验
            //小程序宿主环境不是浏览器，没有跨域问题，没有Ajax

            //navigator
            //导航到tabBar时加属性open-type="switchTab"
            //非tabBar时可以不写ot属性

            //wxs不允许使用箭头函数和let
            //在iOS上性能优于js
            //  函数通过module.exports = {}   导出
            //  在wxml中添加wxs标签并指定module名 src     可以直接通过module名.方法名调用
            //  不能作为事件的回调函数

            //引用组件
            //  在(app/页面).json中usingComponents:{"名": "相对路径"}
            //组件的事件处理函数需要定义到methods中,非事件处理函数名加前缀_
            //全局样式对组件无效(只有class选择器有隔离效果)
            //在options中styleIsolation: "isolated"     启用样式隔离
            //                            apply-shared  不会影响页面
            //                            shared        自定义组件会影响页面样式
            //
            //observes: {
            //     "**": function(新值){
            //     }
            // }
            //  可以使用通配符**代替所有属性名
            //在options中声明pureDataPattern: /^_/
            //凡是复合正则式的均是纯数据字段，可以用来提升页面更新的性能，一般以下划线开头
            //
            //组件的生命周期函数：
            //created、attached、detached
            //在Component构造器中的lifetimes: {attched() {}}
            //在组件进行到attached生命周期时开展初始化工作
            //
            //组件所在页面的生命周期
            //show、hide、resize
            //在Component中定义pageLifeTimes: {show: function(){}}
            //启用多个插槽：options里multipleSlots: true
            //
            //父子组件通信：
            //属性绑定
            //  父向子--只能传递JSON支持的类型，子组件通过properties接收
            //事件绑定
            //  子向父--可以传递任意类型
            //  父组件中使用标签时 bind:传递函数名="函数名"
            //  子组件中this.triggerEvent("函数名", { 参数列表 })
            //  父组件中fun(e){ 变量: e.detail.value接收 }
            //获取组件实例
            //  父组件调用this.selectComponent("选择器")            获取子组件实例，可以直接访问其任意方法和数据，不支持标签选择器
            //
            //behaviors
            //类似mixins
            // module.exports = Behaviors({
            //     porperties: {},
            //     data: {},
            //     methods: {}
            // })
            //require()导入behavior
            //Component中hebaviors: []

            //使用npm包
            //初始化包管理配置文件
            //  npm init -y
            //安装npm包
            //工具-构建npm
            //

            //import {promisify} from "miniprogram-api-promise"
            // const wxp = wx.p = {};
            // promisifyAll(wx, wxp);
            #endregion
            #region WebGIS
            //WebGIS API
            //ArcGIS API for JavaScript
            //Vue项目添加引用
            //npm install esri-loader --save-dev

            //使用ts开发工具
            //1、建立文件夹结构
            //  index.html
            //  package.json
            //  tsconfig.json
            //  src/
            //      mian.ts
            //2、在根目录下命令npm init --yes
            //   命令npm install @types/arcgis-js-api@4.16 --save-exact
            //3、安装dojo-typings   命令npm install dojo-typings
            //4、命令tsc -w实时将ts编译为js

            //elevationInfo属性
            //(on-the-ground / relative-to-ground / absolute height / relative-to-scene)
            //offset属性(偏移量)

            //地图事件:
            //blur                              view失焦
            //focus                             焦点在view时
            //click                             单击地图
            //double-click                      双击地图
            //layerview-create                  layerview创建
            //layerview-destroy                 layerview销毁
            //drag                              鼠标拖拽地图
            //pointer-down                     鼠标按下
            //hold                              按住鼠标一段时间
            //pointer-up                        鼠标按键释放
            //pointer-leave                     鼠标离开view
            //pointer- enter                    鼠标进入view
            //pointer- move                     鼠标移动
            //mouse-wheel                       鼠标滚轮滑动
            //immediate-click                   快速点击
            //key-down                          键盘按下
            //key-up                            键盘释放
            //resize                            view的尺寸改变

            #region Map
            //Map模块:
            //管理底图图层的容器
            //Map中的图层被分为三组：
            //  1、Ground Layers
            //      地形图层    Map.ground
            //  2、Basemap Layers
            //      底图图层    Map.basemap
            //  3、Operational Layers
            //      业务图层    Map.layers

            //设置Map.ground
            //1、默认ground实例
            //var map = new Map({
            //  ground:"world-elevation"
            //});
            //2、自定义实例
            //var customElevation = new ElevationLayer({
            //  url:""
            //});
            //var customGround = new Ground({
            //  layers:[customElevation]
            //});
            //var map = new Map({
            //  ground:customGround
            //});
            //设置背景色：map.ground.surfaceColor = "#004C73";
            //设置透明度：map.ground.opacity = 0.5;

            //设置Basemap
            //1、使用默认Basemap实例
            //var map = new Map({basemap:"topo"})
            //2、自定义实例
            //basemap:{
            //     baseLayers:[
            //         new TileLayer({url: baseurl})
            //     ],
            //     referenceLayers:[
            //         new TileLayer({url: refUrl})
            //     ]
            // }

            //设置Layers
            //  var fl = new FeatureLayer({
            //    "https://sampleserver6.arcgisonline.com/arcgis/rest/services/USA/MapServer/0"
            //});
            //  var gl = new GraphicsLayer();
            //  var map = new Map({
            //     layers:[fl, gl]
            // });
            #endregion
            #region View
            //View模块:
            //视图模块，用于显示地图的图层、显示小部件，处理用户交互的事件
            //2D视图    可以旋转(rotation属性)
            //3D视图    相机位置(camera属性)、viewingMode属性(指定Global(默认)、Local模式)
            //导航：
            //Zoom                              指定视图缩放级别
            //Center                            定义视图中心点
            //Scale                             指定地图显示的比例级别
            //Extent                            定义视图显示范围
            //camera在空间中的角度:
            //  heading         相机相对与地面水平旋转的角度（偏航）
            //  tilt            相对于地面垂直时上下的倾角（俯仰）
            //  camera: {position: {x: , y: , z： }，}
            //限制:
            //MapView.constraints
            //限制lods(缩放级别控制)、scale、zoom、rotation
            //      view.constraints = {
            //          minScale: 500000,//1:500000
            //          maxScale: 0,
            //          rotationEnable: false
            //      };
            //SceneView.constraints
            //限制altitude、camera tilt         单位都是m
            //      view.constraints = {
            //          altitude:{
            //              min: 500,
            //              max: 200000000
            //          }
            //      };

            //View属性:
            //View.environment
            //background                        地图后的背景，地球外星空的颜色

            //View方法:
            //.goto(target, options)             将地图从一个位置导航到另一个位置
            //  target:(经纬度、Geometry[]、Graphic[]、Viewpoint)
            //  options:(animate、duration、easing)
            //.toMap()                           将屏幕坐标转换为地图坐标(经纬度)
            //.toScreen()                        将地图坐标转换为屏幕坐标
            //.hitTest(screenPoint)              返回与指定屏幕相交的每个图层的最顶层要素
            //.when(func)                        加载完成后触发回调函数
            //.on("", func)                      监听事件(点击、拖拽、resize)
            //      var clickEvent = view.on("", func)-------------clickEvent.remove()
            //.watch(event, callback)            监听view属性的变化，用法同on
            #endregion

            //Layers
            //添加Layer                           map.add()
            //添加ElevationLayer                  map.ground.layers.add()
            //用于提供地理背景的图层:
            //  TileLayer                        用来加载缓存服务，直接获取切片，不需动态渲染(请求多张图片)，没有编辑、客户端渲染、弹出模板
            //      var layer = new TileLayer(){url:""};
            //  BaseTileLayer                    可以扩展来创建自定义切片图层
            //  ElevationLayer                   用来加载DEM数据
            //  PointCloudLayer                  加载点云数据
            //
            //用于查询、可视化、分析数据的图层:
            //  MapImageLayer                    加载动态地图服务，根据请求回来的数据在前端进行动态输出(请求一张图)，对应MapServer服务，没有编辑支持
            //      portalItem:当要加载的图层比较多时通过id以包的形式加载
            //  GraphicsLayer                    包含一个或多个客户端要素的图层，没有对应服务，数据源为客户端图形
            //      没有renderer属性，但其中的每一个graphic都有自己的symbol
            //  FeatureLayer                     进行客户端处理、弹出模板、查询、编辑，显示功能数量有限，可能需要大量下载
            //      要素不能被单独符号化，需要使用renderer属性，指定到图层
            //  CSVLayer                         数据源为CSV文件

            #region Graphics
            //Graphics操作
            //  const graphicLayer = new GraphicLayer();
            //  map.add(graphicLayer);
            // //创建Geometry
            // var point = {
            //     type: "point",
            //     longitude: ,
            //     latitude:
            // };
            // //添加样式
            // var simpleMarkerSymbol = {
            //     type: "simple-marker",
            //     color: [0,0,0],
            //     outline: {
            //         color: [255,255,255],
            //         width: 1
            //     }
            // };
            // //添加属性
            // var attributes = {
            //     name: "NewPoint",
            //     description: "This is a new created point"
            // };
            // //添加要素
            // var pointGraphic = new Graphic({
            //     geometry: point,
            //     symbol: simpleMarkerSymbol,
            //     attributes: attributes,
            //     popupTemplate: {
            //         title: attributes.name,
            //         content: attributes.description
            //     }
            // });
            // graphicLayer.add(pointGraphic);
            #endregion
            #region FeatureLayer
            //FeatureLayer
            //  var headLayer = new FeatureLayer({
            //     url:""
            // })
            //一个图层包含geometry和属性
            //给map.add(layer, index)函数指定index为0可以将图层添加到数组的顶层，并优先显示
            //线要素通常显示在点要素之前
            //面要素显示在线要素之前
            //
            //FeatureLayer Style
            // var trailheadsRenderer = {
            //     //定义renderer为"simple"
            //     "type":"simple",
            //     "symbol":{
            //         "type":"picture-marker",
            //         //指定图片的url
            //         "url":"http://static.arcgis.com/images/Symbols/NPS/npsPictograph_0231b.png",
            //         "width":"18px",
            //         "height":"18px"
            //     }
            // }
            //
            //定义字体样式
            // var trailheadsLabels = {
            //     symbol:{
            //         type:"text",
            //         //定义字体颜色
            //         color:"#1e1e1e",
            //         //定义字体轮廓颜色
            //         haloColor:"#5E8D74",
            //         haloSize:"2px",
            //         font:{
            //             size:"12px",
            //             family:"Noto Sans",
            //             style:"blod",
            //             weight:"normal"
            //         }
            //     },
            //     labelPlacement:"above-center",
            //     labelExpressionInfo:{
            //         expression:"$feature.TRL_NAME"
            //     }
            // };
            //为FeatureLayer添加样式：
            // var trailheads = new FeatureLayer({
            //     url:"",
            //     renderer: trailheadsRenderer,
            //     labelingInfo:[trailheadsLabels]
            // })

            //显示弹出窗口
            // var popupTrailheads = {
            //     "title":"Trailhead",
            //     "content":"<b>Trail:</b> {TRL_NAME}<br/><b>City:</b>"
            // }
            //显示图表
            // var popupTrails = {
            //     title:"Chart Info"
            //     content:[{
            //         type:"media",
            //         mediaInfos:[{
            //             type:"column-chart",
            //             caption:"展示最大最小高程",
            //             values:{
            //                 fields:["ELEV_MIN","ELEV_MAX"],
            //                 normalizeField: false,
            //                 tooltipField: "最大最小高程"
            //             }
            //         }]
            //     }]
            // };
            // var trails = new FeatureLayer({
            //     url: "",
            //     outFields:["TRL_NAME","ELEV_GAIN"],
            //     popupTemplate: popupTrails
            // });
            // map.add(trails, 0);
            //显示表格
            // var popupOpenspaces = {
            //     "title":"{PARK_NAME}",
            //     "content":[{
            //         "type":"fields",
            //         "fieldInfos":[
            //             {
            //                 "fieldName":"AGNCY_NAME",//行名
            //                 "label":"Agency",//行表头
            //                 "isEditable":true,
            //                 "tooltip":"",
            //                 "visible":true,
            //                 "format":null,
            //                 "stringFieldOption": "text-box"
            //             }
            //         ]
            //     }]
            // }
            // var openspaces = new FeatureLayer({
            //     url:"",
            //     outFields:[],
            //     popupTemplate:popupOpenspaces
            // });
            // map.add(openspaces, 0);
            #endregion

            //VectorTileLayer矢量切片图层
            //view-----layers: [vtLayer]

            //WebMap
            //包含所有地图的配置设置(底图、数据图层、弹出窗口)
            //map------portalItem:{ id:"" }
            //view-----map:webmap

            #region QueryFeature
            //Query featureLayer
            //步骤：
            //1：map、view
            //2：声明SQL选项、创建下拉框、遍历数组将选项添加到下拉框中
            //3：添加事件监听、调用查询函数
            //4：创建FeatureLayer
            //5：查询函数：通过调用 FL对象.queryFeatures(parcelQuery对象)   then(results)异步回调显示函数
            //6：显示函数：样式     popupTemplate       results.feature.map()将对象分配给FL对象     清空显示

            //添加SQL
            // var SQLqueryArray = [
            // "Choose a SQL where clause...",
            // "UseType = 'Residential'"
            // ];
            // let whereClause = SQLqueryArray[0];
            //显示select微件
            // var select = document.createElement("select", "");
            // select.setAttribute("class", "esri-widget esri-select");
            // select.setAttribute("style", "");
            // SQLqueryArray.forEach(function(query){
            //     let option = document.createElement("option");
            //     option.innerHTML = query;
            //     option.value = query;
            //     select.AppendChild(option);
            // });
            // view.ui.add(select, "位置");
            //监听select变化事件
            // select.addEventListenr("change", (e) => {
            //     whereClause = e.target.value;
            //     queryFeatureLayer(view, extent);
            // })
            //添加一个FeatureLayer用来执行queryFeature方法
            // var parcelLayer = new FeatureLayer({
            //     url:""
            // });
            // function queryFeatureLayer(extent){
            //     const parcelQuery = {
            //         where: whereClause,
            //         spatialRelationship: "intersects",
            //         geometry: extent,
            //         outFields: ["", ],
            //         returnGeometry: true
            //     };
            // parcelLayer.queryFeatures(parcelQuery)
            //     .then((results) => {
            //         console.log(results.features.length)
            //     }).catch((e) => {
            //         console.error(e.message)
            //     })
            // };

            //通过空间数据查询
            //步骤：
            //1：引用GraphicsL和Sketch    map,view
            //2：创建GL对象
            //3：创建Sketch对象
            #endregion
            //对地址进行地理编码
            //view.when(() => {
            //  1、引用地理编码服务
            //      var geocodingServiceUrl = "https://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer"
            //  2、设置地址参数
            //      var address = {
            //          address: {
            //              "address":"地址名"
            //          }
            //      }
            //  3、调用Locator类和showResults函数
            //  locator.addressToLocations(geocodingServiceUrl, params).then(
            //    (results) => {showResults(results)
            //  })
            //  4、创建点图层和弹出窗口
            //  function showResults(){}
            //})


            //1、QueryTask
            //查询一个地图服务中的单个图层，可进行属性查询、几何查询
            //2、FindTask
            //只能进行属性查询
            //3、Identify Task
            //查询一个地图中的多个图层，只能进行空间查询
            //4、LayerViewQuery

            //GeometryServices(通过服务器端完成)/GeometryEngine(在客户端完成)
            //对要素进行缓冲区、裁剪、相交、量测等操作

            #endregion
            #region PostGIS
            //安装插件
            //CREATE EXTENSION postgis;
            //检查版本
            //postgis_full_version();


            //Postgre基本类型转换
            //type::newtype

            //使用Bundle3转换shp时注意不能使用中文路径


            //基本函数:
            //返回几何类型
            //SELECT ST_GeometryType(列名) from 表;
            //维度
            //ST_NDims();
            //空间参照
            //ST_SRID();
            //返回几何的文本字符串
            //（默认查询几何对象返回十六进制的坐标表示）
            //ST_AsText()


            //基本几何对象:
            //1、点Point
            //	ST_X	ST_Y	ST_Z	ST_M
            //2、线串Linestring
            //	是否闭合
            //	ST_IsClosed()
            //	是否简单(不与自身交叉或接触)
            //	ST_IsSimple()
            //	长度
            //	ST_Length()
            //	起始/终止点坐标
            //	ST_StartPoint()	/	ST_EndPoint()
            //	构成坐标数
            //	ST_NPoints()
            //3、多边形Polygon
            //	面积
            //	ST_Area()
            //	环数
            //	ST_NRings()
            //	返回最外部环Linestring
            //	ST_ExteriorRing()
            //	返回指定内环
            //	ST_InteriorRingN(列名, n)
            //	返回所有环周长
            //	ST_Perimeter()
            //4、图形集合Collection
            //	集合中组成部分的数量
            //	ST_NumGeometries()
            //	返回指定几何部分
            //	ST_GeometryN(geom, n)


            //几何类型序列化和反序列化:
            //由于SFSQL定义的WKT和WKB不支持高维，postgis定义了EWKT和EWKB	text示例：LINESTRING (Z/ZM) (0 1 2,3 4 12,3 345 23)
            //1、WKT
            //	ST_GeomFromText(text, srid)
            //	ST_AsEWKT(geom)
            //2、WKB
            //	ST_GeomFromWKB(bytea)
            //	ST_AsBinary(geom)
            //	ST_AsEWKB(geom)
            //3、GML
            //	ST_AsGML()
            //4、KML
            //	ST_AsKML()
            //5、GeoJson
            //	ST_AsGeoJson(geom)		返回text
            //6、SVG
            //	ST_AsSVG()				返回text


            //空间关系:
            //1、相交
            //	根据x、y坐标值判断两个几何对象是否相等
            //	ST_Equals(geom, geom)
            //	判断是否相交
            //	ST_Intersect()			会自动使用空间索引
            //	ST_Disjoint()
            //	ST_Crosses()			相交生成的维度小于源几何对象的最大维度，且交集位于两个源的内部
            //	判断是否叠置
            //	（结果集与两个源都不同但具有相同维度）
            //	ST_Overlaps()
            //2、边界相交
            //	边界接触，但内部不相交
            //	ST_Touches()
            //3、包含
            //	互逆函数
            //	ST_Within()	/	ST_Contains()
            //4、相距
            //	返回浮点距离
            //	ST_Distance()
            //	测试是否在某个范围之内(缓冲)，基于索引加速
            //	ST_DWithin(geom, geom, distance)

            #endregion
            #region AO

            // ITableCollection tables = map as ITableCollection;
            // //封装打开流程
            // ITable table = OpenTable(pathName, tableName);
            // tables.AddTable(table);


            // //创建工作空间对象
            // IWorkspaceName spcName = new WorkspaceNameClass();
            // spcName.PathName = pathName;
            // spcName.WorkspaceFactoryProgID = "esriDataSourcesFile.shapefileworkspacefactory";

            // //创建数据集对象
            // IDatasetName dsName = new TableNameClass();
            // dsName.Name = tableName;
            // dsName.WorkspaceName = spcName;

            // //打开数据
            // IName name = dsName as IName;
            // ITable table = name.Open() as ITable;
            #endregion
            #region CS229py
            //监督学习的三要素：
            //模型(总结数据的内在规律，用数学描述)
            //策略(选取最优模型的评价准则)
            //算法(选择最优模型的具体方法)

            //监督学习实现步骤:
            //  获取一个有限的数据集
            //  确定包含所有学习模型的集合
            //  确定模型选择的准则(学习策略)
            //  实现求解最优模型的算法(学习算法)
            //  通过学习算法选择最优模型
            //  利用得到的最优模型对新数据进行预测或分析

            //损失函数：用来衡量模型预测误差的大小
            //  是系数的函数
            //经验风险
            //  关于训练数据集的平均损失
            //经验风险最小化(ERM)
            //  当样本足够多时有很好的学习效果
            //  样本较小时存在问题
            //训练误差：关于训练集的训练集的平均损失
            //  本质上并不重要
            //测试误差
            //  关于测试集的平均损失
            //  真正反映了模型的预测能力(泛化能力)
            //正则化
            //  结构风险最小化(SRM)：在ERM的基础上防止过拟合的策略，加上了表示模型复杂度的正则化项(惩罚项),模型越复杂正则化值越大
            //奥卡姆剃刀原理：如无必要勿增实体
            //交叉验证：
            //  数据不充分时可以重复利用数据
            //  简单交叉验证
            //      将数据随机分为两部分
            //  S折交叉验证
            //      将数据随机切分为S个互不相交、相同大小的子集，S-1个作为训练集剩下一个为测试集，重复进行选取，有S种可能的选择
            //  留一交叉验证
            //  再划分出验证集用于模型选择


            //评测分类问题
            //精确率
            //  所有 预测 为正类的数据中预测正确的比例
            //召回率
            //  所有 实际 为正类的数据中被正确找出的比例

            //回归问题
            //建立输入变量于输出变量之间的关系
            //  等价于函数曲线的拟合
            //步骤：
            //1、导入依赖和测试数据，提取feature和label数据
            //2、定义损失函数 (yi - w*xi - b) ** 2 求和，取平均使损失函数与样本的数据无关
            //3、定义算法拟合函数求解w和b
            //4、调用损失函数计算cost值

            //多元线性回归
            //用θ0 * x0 (x0=1)代替b, 用θ(1 to d)代替w
            //步骤：
            //1、导入依赖和测试数据
            //2、定义损失函数同一元回归
            //3、定义超参数(初值、学习率、次数)
            //4、定义梯度下降函数

            //使用sklearn库
            //引入import LineaRegression from sklearn.linear_model
            //创建实例lr = LinearRegression()
            //训练模型lr.fit(x, y)                                          传入的x, y必须为二维数组
            //从训练完的模型中返回w和b  lr.coef[0][0]  lr.intercept[0]






            //单行注释#
            //多行注释'''或"""      即多行文本
            //def定义函数
            //没有数组的概念，list列表代替(可为任意类型)  len(列表) 函数返回列表长度
            //将数组(列向量)转化为矩阵  数组.reshape(-1, 1)       -1表示行数不限， 1表示生成一列数据
            //相同缩进的一组语句构成代码组，首行以关键字开始，以冒号结束
            //Print输出默认换行，不换行需要在变量末尾加end=""
            //可以多变量赋值，交换变量a,b = b,a
            //不可变数据：
            //  Number(int、float、bool、complex)、String、Tuple(元组)
            //可变数据：
            //  List、Dictionary、Set(集合)
            //判断类型
            //type()
            //isinstance()      会认为子类是一种父类类型
            //del 变量名        手动删除变量释放内存
            //pow(a, b)     ==      a ** b
            //str = "";
            //str[1:5:2]        取子串，从1开始取， 取到5，步长为2(隔两个取一个)

            //元组用括号声明
            //值可以为任意类型，不能修改，但可以包含可变的对象

            //必须全部定义名称(同时可以定义默认值)，而名称顺序可以不同
            //通过 *参数名, **参数名 传递不定长参数
            //可以返回多个值，并使用多个的参数接收
            //除法除完之后即为浮点型数据    ------ // 除法之后的结果向下取整




            #endregion

			#region Ubuntu
			//Linux
			
			
			//当前绝对路径
			//$ pwd
			//将文件导入环境变量
			//$ export PKF_CONFIG_PATH=路径
			//编译C/C++文件
			//$ g++ *.cpp -o *
			//获取库/模块编译信息
			//$ pkg-config
			//更改文件权限
			//$ sudo chmod 777 *
			//应用程序管理工具
			//$ sudo apt-get install *
			//检查已安装的库、软件
			//$ dpkg -l | grep [关键字]
			
			
			
			//opencv.pc文件内容：
			//
			// prefix=/usr/local
			// exec_prefix=${prefix}
			// includedir=${prefix}/include
			// libdir=${exec_prefix}/lib
			
			// Name: opencv
			// Description: The opencv library
			// Version:4.0.1
			// Cflags: -I${includedir}/opencv4
			// Libs: -L${libdir} -lopencv_shape -lopencv_stitching -lopencv_objdetect -lopencv_superres -lopencv_videostab -lopencv_calib3d -lopencv_features2d -lopencv_highgui -lopencv_videoio -lopencv_imgcodecs -lopencv_video -lopencv_photo -lopencv_ml -lopencv_imgproc -lopencv_flann  -lopencv_core
			// ~              



			//虚拟机共享文件夹消失：
			//$ sudo vmhgfs-fuse  .host:/  /mnt/hgfs/  -o allow_other  -o uid=1000
			
			
			// fatal error: opencv/cv.h: No such file or directory
			// #include <opencv/cv.h>
			// 在opencv4中opencv2的cv.h融合进了imgproc.hpp里，所以把源码中的#include <opencv/cv.h>改成#include <opencv2/imgproc.hpp>即可。

			#endregion

            ServiceCollection services = new ServiceCollection();
            services.AddScoped<ConfigController>();

            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: false);
            IConfigurationRoot configRoot = configBuilder.Build();

            services.AddOptions().Configure<Config>(c => configRoot.Bind(c));
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                while (true)
                {
                    using (var scope = sp.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetRequiredService<ConfigController>();
                        service.TestConfiguration();
                    }
                    Console.ReadKey();
                }
            }

            string name = configRoot["name"];
            string address = configRoot.GetSection("proxy:address").Value;
            //Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();








            Console.ReadKey();
        }
    }

    class Config
    {
        public string Name { get; set; }
    }
}
