using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;//MD5
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


//namespace（命名空间）：用于解决类重名问题，类似于类的文件夹
//如果代码和所使用的类在一个命名空间，那么则不需要using
//在一个项目中引用另一个项目的类



namespace csharp1
{
    #region 枚举
    //将枚举声明到命名空间的下面，类的外面，表示这个命名空间下所有的类都可以使用这个枚举。
    //public enum 枚举名
    //{
    //  ,
    //  ,   
    //  最后一行可以不写逗号
    //}
    //public:访问修饰符，公开的，哪都可以访问。
    //private：私有的，只能在这个类内部进行访问。默认修饰符为private
    //enum：声明枚举的关键字。
    //枚举:规范开发。本质还是变量
    //枚举的类型默认可以和int类型互相转换==枚举类型和int类型是兼容的。
    public enum MyEnum
    {
        彧 = 5,
        yu
    }
    public enum Gender
    {
        male,
        female
    }
    #endregion
    #region 结构
    //结构：可以帮助我们一次声明多个不同类型的变量
    //[public] struct 结构名
    //{
    //      成员：字段
    //}
    public struct Person
    {
        public string _firstname;//字段（下划线）
        public string _lastname;
        public int _age;
        public Gender _gender;
    }
    #endregion
    #region 类
    //类
    //public class 类名
    //{
    //      字段;
    //      属性;
    //      方法;
    //      构造函数;
    //      析构函数;
    //}
    //写好一个类之后，需要创建这个类的对象，这个过程称为类的实例化


    //创建对象：
    //类名 名 = new 类名();

    //this：
    //1.表示当前这个类的对象
    //2.在类当中显示的调用本类的构造函数-------> :this 
    #endregion
    class MyNote
    {
        public static int _num = 20;//属于类的字段---->静态字段（用来模拟全局变量）
        const int con = 90;


        static void Main(string[] args)
        {

            #region 占位符及控制输出精度
            //decimal money = 1000m;

            //{:n}---->000,000,000
            //{:c}---->￥符号
            //{:e}---->科学计数法
            //{:f4}---->小数点后四位
            //{:x}---->十六进制---->x2---->加零对齐
            //{:p}---->百分号

            //Console.WriteLine("{0:}",DateTime.Now);
            //{:f}---->不显示秒
            //{:y}---->年月
            //{:m}---->月日
            //{:d}---->2020-1-1
            //{:t}---->14:34


            //var yin_shi_lei_xing = 1.23;

            //var:
            //C#是一门强类型语言：必须对每一个变量的类型有一个明确的定义
            //js是弱类型语言：不需要对变量的类型有明确的定义

            //在 C#代码中用添加前缀“0x”的方式表示十六进制
            //Console.WriteLine("{0:0.00\a}",a);
            //      \a:产生“嘀”的一声蜂鸣
            //      \f:换行


            //保留两位小数（四舍五入）
            //int[] num = { 4,7,9 };
            //double avg = GetAvg(num);
            //string s = avg.ToString("0.00");
            //avg = Convert.ToDouble(s);
            //Console.WriteLine(avg);
            //Console.ReadKey();


            //序列化：将对象转换为二进制
            //反序列化：将二进制转换为对象
            //作用：传输数据（二进制）
            #endregion
            #region 写入、读取txt
            //写入
            //System.IO.File.WriteAllText(@"C:\Users\14345\Desktop\0718.txt", str);
            //Console.WriteLine("写入成功！");

            //读取
            //string path = @"C:\Users\14345\Desktop\0101.txt";
            //string[] content = File.ReadAllLines(path, Encoding.UTF8);
            #endregion
            #region Console.Read()
            //Console.WriteLine("Please input a character");
            //int ch = Console.Read();
            //Console.WriteLine("The ASCII code is " + ch); 
            #endregion
            #region try-catch使用
            //int year, month, day;
            //Console.WriteLine("请输入年份：");
            //try
            //{
            //    year = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("请输入月份：");
            //    try
            //    {
            //        month = Convert.ToInt32(Console.ReadLine());
            //        switch (month)
            //        {
            //            case 1:
            //            case 3:
            //            case 5:
            //            case 7:
            //            case 8:
            //            case 10:
            //            case 12:
            //                Console.WriteLine("这个月有31天");
            //                break;
            //            case 2:
            //                if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            //                {
            //                    Console.WriteLine("这个月有28天");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("这个月有29天");
            //                }
            //                break;
            //            default:
            //                Console.WriteLine("这个月有30天");
            //                break;
            //        }
            //    }
            //    catch
            //    {
            //        Console.WriteLine("输入的月份有误");
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("输入的年份有误");
            //}
            #endregion
            #region 类型转换
            //int year = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(year);
            //bool tb = int.TryParse(Console.ReadLine(),out a);
            //Console.WriteLine(a);
            #endregion
            #region 产生随机数
            //Random r = new Random();
            //int rNub = r.Next(1, 10+1);
            //Console.WriteLine(rNub);
            #endregion
            #region 调用枚举；将枚举类型与int类型互相转换;转换为string类型
            //枚举类型强转为int
            //MyEnum at = MyEnum.彧;
            //int ad = (int)at;
            //Console.WriteLine(ad);
            //Console.WriteLine((int)MyEnum.yu);


            //int类型强转为枚举
            //int c = 13;
            //MyEnum ap = (MyEnum)c;
            //Console.WriteLine(ap);


            //枚举转string
            //MyEnum aq = MyEnum.yu;
            //string e = aq.ToString();
            //Console.WriteLine(e);


            //string转枚举                                 
            //string f = "5";
            //MyEnum ae = (MyEnum)Enum.Parse(typeof(MyEnum), f);                   //将string转换为枚举的类型
            //Console.WriteLine(ae);
            #endregion
            #region 结构示范
            Person zs;
            zs._firstname = "张";
            zs._lastname = "三";
            zs._age = 19;
            zs._gender = Gender.male;
            #endregion
            #region 数组
            //int[] nums = new int[10];
            //int[] nums2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int g = nums2.Max();
            //Console.WriteLine(g);
            //for (int i = 0; i < nums2.Length; i++)
            //{
            //    Console.WriteLine(nums2[i]);
            //}



            //int[] num = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            //int temp;
            //for (int i = 0; i < num.Length-1; i++)
            //{
            //    for (int j = 0; j < num.Length-1-i; j++)
            //    {
            //        if (num[j]>num[j+1])//升序排列
            //        {
            //            temp = num[j];
            //            num[j] = num[j + 1];
            //            num[j + 1] = temp;
            //        }
            //    }
            //}


            //Array.Sort(num);//针对数组做一个升序的排列
            //Array.Reverse(num);//逆转排列数组
            //for (int i = 0; i < num.Length; i++)
            //{
            //    Console.WriteLine(num[i]);
            //}

            #endregion
            #region 三个高级参数：out、ref、params
            //out参数
            //  >>    在一个方法中返回多个不同类型的值：
            //public static void 方法名（int ,out int,out double,out string）


            //ref参数
            //能够将一个参数带入一个方法中进行改变，改变完成后再将改变后的值带出方法
            // public static void 方法名（ref int,ref int）


            //params参数->必须是参数列表之中的最后一个元素
            //将实参列表中跟可变参数数组类型一致的元素都当作数组的元素处理。
            //// public static void 方法名（int ,params int[] num）

            #endregion
            #region 重载
            //方法的重载
            //方法的名称相同，但传递的参数不同
            //分为两种情况：
            //1、参数的个数相同，那么参数的类型就不能相同
            //2、参数的类型相同，那么参数的个数就不能相同
            //方法的重载和返回值没有关系 
            #endregion
            #region 位运算
            //Program.GetMax(1, 2);
            //int a = 5, b = 9;
            //Console.WriteLine(a & b);
            //Console.WriteLine(a | b);
            //Console.WriteLine(a ^ b);


            //  /*交换变量*/
            //a = a ^ b;
            //b = b ^ a;
            //a = a ^ b;
            //Console.WriteLine("a=" + a + " b=" + b);


            //a = a & (~a); //a清零
            //Console.WriteLine(a);


            //a = a | (~a); //a全为1
            //Console.WriteLine(a);


            //输出结果
            //1
            //13
            //12
            //a=9 b=5
            //0
            //-1

            #endregion
            #region 面对对象初级
            //面对过程-------->面对对象
            //面对过程：强调完成这件事的动作
            //面对对象：找个对象帮你做事-------->意在写出一个通用的代码，屏蔽差异
            //如果要用面对过程的思想，当执行的人不同时，需要为每个不同的人量身定做解决事情的方法

            //面向对象三大特征：封装、继承、多态
            //属性：对象具有的多种特征，每个对象的每个属性都拥有特定值
            //对象是具体化的事物，不能是抽象概念
            //把这些具有相同属性和相同方法的对象进行进一步的封装，抽象出<类>这个概念
            //类：是模子，确定对象拥有的特征（属性）和行为（方法）
            //对象是根据类创建出来的
            //类不占内存，而对象占用内存

            //属性：ctrl+r+e封装字段
            //属性的作用就是保护字段，对字段的赋值和取值进行限定
            //属性的本质是两个方法：get和set-------->可读可写属性
            //字段在类之中必须是私有的
            //对象的初始化：给属性赋值
            //自动属性：不需要实现的属性语法，不需要定义字段（如果只对字段简单封装，没有附加逻辑，则定义自动属性，可以减少代码量）
            //Field-------->字段
            //Method-------->方法
            //properties-------->属性

            //静态和非静态的区别
            //1.在非静态类中，既可以有实例成员，也可以有静态成员//静态类中只能有静态成员
            //2.在调用实例成员的时候，需要使用对象名.实例成员;//在调用静态成员时，要用类名.成员;
            //3.静态函数中只能访问静态成员//实例函数中既可以访问静态成员，也可以访问实例成员

            //使用:
            //1.静态类可以作为工具类使用
            //2.静态类在整个项目中资源共享-------------------->人为划分的内存：堆、栈、静态存储区域

            //构造函数：帮助我们初始化对象（给对象属性依次赋值）
            //1.构造函数没有返回值，并且不写void
            //2.构造函数名必须和类名一样
            //类之中会有一个默认的无参构造函数
            //public 构造函数名()
            //{
            //
            //}

            //new关键字：
            //1.在内存中开辟一块空间  
            //2.在开辟的空间中创建一个对象
            //3.用对象的构造函数进行初始化对象

            //析构函数：----->无法继承或重载
            //当程序结束时执行------->帮我们释放资源（马上释放）
            //~类名()
            //{
            //      
            //}
            //析构函数隐式地调用对象基类的Finalize方法，故不应使用空析构函数，会导致不必要的性能损失


            //   然而在大型的程序中，有时有些对象虽然不再使用了，
            // 但离作用域结束还有相当长的时间，在这期间，对象仍然占
            // 用内存，浪费资源。
            //   在 C++中，程序员需要显式的用 delete 语句删除垃圾对
            // 象，如果程序员忘记了及时删除，这些垃圾对象有可能占用
            // 大量的内存空间，造成“内存泄露”。
            //   为了解决这个痼疾，C#专门设计了一套回收资源的机制——垃圾回收器。当垃圾回收
            // 器确定某个对象已经无用时，就会自动删除该对象，释放内存空间。在这套机制下，内存
            // 自动回收，无需人工干预，解决了常常困扰 C++程序员的“内存泄露”问题。总之在 C#
            // 中删除对象的工作是由垃圾回收器负责完成，析构函数通常用来释放对象使用的非托管资
            // 源。
            //   需要指出的是垃圾回收器的运行时间具有不确定性，我们无法预计垃圾回收器什么时
            // 候运行，因此也无法预测什么时候会删除无用对象，有可能立即删除，也可能要过一段时
            // 间才删除。我们可以通过调用 System.GC.Collect()方法强迫垃圾回收器运行（会对性能产
            // 生一定影响），但即使调用了该方法，我们也无法预知垃圾回收器具体在何时运行。

            People zhangSan = new People("张三", '男', 19);
            //zhangSan.intro(); 

            //值类型和引用类型在内存上存储的方式不一样
            //传递值类型和引用类型时方式不一样-------->值传递||引用传递
            //值类型：int、double、bool、char、decimal、struct、enum-------->储存在内存的栈当中
            //引用类型：string、自定义类、数组、object类、接口-------->存储在内存的堆中
            #endregion
            #region 字符串
            //字符串的不可变性：
            //当给一个字符串重新赋值时，之前的值并未销毁，而是重新开辟一块空间存储新值
            //当程序结束后，GC扫描整个内存。如果发现有空间没有被指向，则立即把它销毁
            //可以把字符串看成是char类型的一个只读数组
            //stringBuilder和string的区别：string在进行运算时会产生一个新的实例，因此在频繁对一个字符串进行操作时最好选择stringBuilder

            //.ToUpper()---->将字符串转换成大写形式---->返回string----------------------------//s = s.ToUpper();
            //.Tolower()---->将字符串转换成小写形式---->返回string
            //.Equals(,)---->比较两个字符串（可以忽略大小写）---->返回bool
            //.Split(char[],)---->分割字符串返回字符串类型的数组---->返回string[]
            //.ToCharArray()---->将字符串转换为一个char型数组---->返回char[]
            //new string(char[])---->将一个char数组转换为字符串---->返回string
            //.Contains(string)---->判断字符串中是否有子串value---->返回bool
            //.Replace(string,string)---->将字符串中出现old value（第一个）的地方替换为new value---->返回string
            //.Substring(int)---->取从位置int开始到结束的子字符串(或指定长度)---->返回string
            //.Startswith(string)---->判断字符串是否以value开始---->返回bool
            //.Endswith(string)---->判断字符串是否以value结束---->返回bool
            //.IndexOf(stirng)---->取value在字符串中第一次出现的位置---->返回int（找不到返回-1）
            //.Trim()---->移除所有的空字符---->返回string
            //string.IsNullOrEmpty()---->判断一个字符串是否为空或null---->返回bool
            //string.join(string,params string[])---->在字符串数组每个元素之间加入指定的分隔符---->返回string



            //练习：


            //string s = "abcdefg";
            //  //不能s[0] = 'b';因为s是只读的
            //char[] ch = s.ToCharArray();
            //ch[0] = 'b';
            //s = new string(ch);d


            //string _s = "a  bc _d+_e  f,,g ";
            //char[] chs = { ' ', '_', '+', ',' };
            //string[] str = _s.Split(chs/*new char[]{ ' ', '_', '+', ',' }*/, StringSplitOptions.RemoveEmptyEntries);


            //string t = "qwe";
            //if (t.Contains("qwe"))
            //{
            //    t = t.Replace("qwe", "***");
            //}


            //StringBuilder sb = new StringBuilder();
            //string str = null;
            ////创建一个计时器
            //Stopwatch sw = new Stopwatch();
            //sw.Start();//开始计时
            //for (int i = 0; i < 100000; i++)
            //{
            //    sb.Append(i);//增加字符串长度
            //}
            //sw.Stop();//计时结束
            //Console.WriteLine(sw.Elapsed);


            //string path = @"C:\Users\14345\Desktop\0101.txt";
            //string[] content = File.ReadAllLines(path, Encoding.UTF8);
            //string[] result = new string[8];
            //for (int i = 0; i < content.Length; i++)
            //{
            //    string[] temp = content[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (temp[0].Length >= 10)
            //    {
            //        temp[0] = temp[0].Substring(0, 8);
            //        temp[0] += "...";
            //    }
            //    result[i] = string.Join("|", temp);
            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine(result[i]);
            //} 
            #endregion
            #region 继承
            //继承：   //子类名:父类名
            //解决类中的代码冗余
            //1.继承的单根性：一个子类只能有一个父类
            //2.继承的传递性：多重继承

            //把几个子类（派生类）当中重复的类单独拿出来封装成一个类，作为这几个类的父类（基类）
            //子类继承了父类的属性和方法，但并没有继承父类的私有字段
            //子类并没有继承父类的构造函数，但子类会默认调用父类的无参构造函数————创建父类对象，让子类可以使用父类成员
            //所以如果在父类中重新写了一个有参数的构造函数后，默认无参构造函数就没有了，子类就无法调用父类成员而报错
            //解决办法：
            //1.在父类中重新写一个无参构造函数
            //2.在子类中显式地调用父类构造函数，使用关键字:base()
            //可以用 base 关键字引用基类的成员       base.基类方法名();


            //创建对象时，系统先调用基类的构造函数，初始化基类的变量，然后调用派生类的构造函数，初始化派生类的变量，是
            //一个由基类向派生类逐步构建的过程。删除对象时，先调用派生类的析构函数，销毁派生类的变量，然后调用
            //基类的析构函数，销毁基类的变量，是一个由派生类向基类逐步销毁的过程。


            //在派生类中不能使用基类的私有成员
            //让类的成员既保持封装性又可以在派生类中使用，那么可以把它定义为 protected 成员（受保护成员）
            // protected int _age;
            //此时在子类中可以使用父类的字段


            //虚方法的重写：
            //子类调研在基类中的同一个方法，但其在每个类中是不同的，则可以把基类中的方法设计成虚方法，然后在派生类中重写该方法
            //public virtual 方法名()
            //virtual修饰符不能与static、abstract、private一起使用
            //在派生类中，用关键字override重写该方法
            //public override 方法名()


            //我们只能重写基类中的虚方法，不能重写普通方法。要想在派生类中修改基类的普通方法，需要用 new 关键字隐藏基类中的方法
            //关键字new:
            //1.创建对象
            //2.隐藏从父类继承过来的同名成员(普通方法)
            //public new 方法名()-------->子类调用不到父类的成员



            //抽象类：不能被实例化，只能作为其它类的基类而存在，其目的是抽象出子类的公共部分以减少代码重复。
            //abstract class 类名
            //抽象方法：是一种特殊的虚方法(但不需要virtual关键字)，它只能定义在抽象类中
            //抽象方法没有任何执行代码，需要在派生类中用重写的方式具体实现
            //在派生类中不能用base直接引用抽象基类的抽象方法
            //public abstract 方法名()
            //抽象属性：也没有具体实现代码，必须在派生类中重写
            //public abstract int Age
            //{
            //    get;
            //    set;
            //}


            //密封类:是一种不能被继承的类
            //sealed class 类名
            //同样，如果想防止一个方法被派生类重写，可以把它为声明密封方法
            //public sealed override 方法名() 


            //object类是所有类的基类-------->在C#中所有类都简介继承了object类 
            #endregion
            #region 里氏转换

            //里氏转换：
            //1.子类可以赋值给父类-------->派生类对象也属于基类，所以基类引用符可以指向派生类对象

            //Son s = new Son();
            //People p = s;

            People p = new Son();

            //2.如果父类中是子类对象那么可以强转为子类对象

            Son ss = (Son)p;


            //表示类型转换
            //1----->is：is 运算符用来判断对象是否与给定类型兼容（即属于该类型或该类型的基类）
            if (p is Son)
            {
            }
            //2----->as: 向下转换
            Son d = p as Son;

            #endregion
            #region 集合
            //1、
            //ArrayList集合
            //集合：很多数据的一个集合，长度可以任意改变，类型不固定
            ArrayList list = new ArrayList();
            //list.Add(Object);

            //将一个对象输出到控制台，默认打印的是这个对象的命名空间
            //Console.WriteLine(对象名.ToString());
            #region 添加单个元素
            //没jb用
            //for (int i = 0; i < List.Count; i++)
            //{
            //      if (list[i] is 类名)
            //      {
            //           ( (类名)list[i] ).方法名();
            //      }
            //      else if (list[i] is int[])
            //      {
            //         for(int j = 0; j<( (int[]) list[i] ).Length ; j++)
            //      }
            //} 
            #endregion
            //添加集合元素
            //list.AddRange(new int[] { 1, 2, 3, 4 });
            //list.AddRange(list);
            //list.Clear();---->清空所有元素
            //list.Remove(object)---->删除指定单个元素
            //list.RemoveAt()---->删除下标元素
            //list.RemoveRange(,)---->根据下标范围删除元素
            //list.Reverse();---->逆转list
            //list.Insert(1,"插入的元素")
            //list.InsertRange
            //list.Contains()---->判断是否包含
            //ArrayList长度的问题
            //count---->表示这个集合事实际包含的元素个数
            //capacity---->表示这个集合可以包含的元素个数
            //每次集合中实际包含的元素个数超过了可以包含的个数时，集合就会向内存申请多开辟一倍的空间，保证集合的长度一直够用

            //拆箱：将引用类型转化为值类型
            //装箱：将值类型转化为引用类型
            //尽量避免，会影响时间
            //是否发生拆箱后装箱----->两种类型是否存在继承关系

            //2.1
            //Hashtable方法------键值对集合
            //Hashtable hs = new Hashtable();
            //hs.Add(1, "张三");
            //hs.Add(2, "b");
            //hs.Add(false, "c");
            //hs.Add(1, "张三");---->冲突
            //hs[1]="zs";---->通过索引替换
            //根据键找值
            //if (hs.ContainsKey("false"))
            //{
            //}
            //foreach (var item in hs.Keys)
            //{
            //    Console.WriteLine(hs[item]);
            //}
            //在循环次数很多时，foreach的效率远高于for

            //2.2
            //Dictionary(键值对集合)
            //Dictionary<int, string> dic1 = new Dictionary<int, string>();
            //dic1.Add(1,"一");
            //dic1[2] = "二";
            //foreach (KeyValuePair<int,string> keyValuePair1  in dic1)
            //{
            //    Console.WriteLine("{0},{1}",keyValuePair1.Key,keyValuePair1.Value);
            //}


            //3、
            //泛型
            //对元素的类型有了确切的定义
            //List<int> list1 = new List<int>();
            //int[] nums = list1.ToArray();
            //List<int> list2 = nums.ToList();


            //4、
            //Path类
            //string str = @"C:\Users\14345\Desktop\new.txt";
            //Path.GetFileName(string));---->返回文件名和扩展名
            //Path.GetFileNameWithoutExtension(string);---->返回文件名
            //Path.GetExtension(string));---->返回扩展名
            //Path.GetDirectoryName(string);---->返回文件所在的文件夹的名称
            //Path.GetFullPath(string);---->返回全路径


            //5、
            //File类
            //ReadAllBytes:多媒体文件（音乐、图片文件）
            //ReadAllLines：返回数组、精确操作
            //ReadAllText：返回整个字符串
            //绝对路径：通过我的电脑能找到这个文件的路径
            //相对路径：文件相对于应用程序的路径
            //在开发中应尽量使用相对路径
            //.Create(@"");
            //.Delete(@"");
            //.Copy(@"",@"");
            //File.Move(@"", @"");
            //byte[] buffer = File.ReadAllBytes(@"D:\File\new.txt");
            //string s = Encoding.Default.GetString(buffer);
            //File.WriteAllBytes(@"D:\File\new.txt", buffer);
            //string[] contents = File.ReadAllLines(@"D:\File\new.txt");
            //foreach (string item in contents)
            //{
            //    Console.WriteLine(item);
            //}
            //File.AppendAllText(@"C:\Users\14345\Desktop\new.txt", "contents");//---->追加不覆盖之前的内容


            //6、
            //FileStream
            //操作字节
            //StreamWriter和StreamReader---->操作字符 
            //FileStream fileStream1 = new FileStream(@"C:\Users\14345\Desktop\new.txt", FileMode.OpenOrCreate);
            //FileStream fileStream2 = new FileStream(@"C:\Users\14345\Desktop\new.txt", FileMode.OpenOrCreate, FileAccess.Read);
            //byte[] buffer = new byte[1024 * 1024 * 5];//5MB
            //int EffectiveByteLength = fileStream2.Read(buffer, 0, buffer.Length);//----->返回实际读到的有效的字节数
            ////关闭流
            //fileStream1.Close();
            ////释放所占用的资源
            //fileStream1.Dispose();
            //
            //将创建文件流对象的过程写在using当中，会自动释放流所占用的资源
            //using (FileStream fswrite = new FileStream(@"C:\Users\14345\Desktop\new.txt", FileMode.OpenOrCreate, FileAccess.Write))//创建的过程
            {
                //读写的内容
                //using ()
            }

            //6.1
            //StreamReader
            //StreamWriter
            //using (StreamReader sr=new StreamReader(@"C:\Users\14345\Desktop\new.txt",Encoding.Default))
            //{
            //    while(!sr.EndOfStream)
            //    Console.WriteLine(sr.ReadLine());
            //}


            //ASC       128
            //ASCII     256
            //GB2312    简体字
            //Big5      繁体字
            //unicode   解析慢
            //UTF-8     web
            //乱码：保存文件所用的编码格式和打开的不一样
            #endregion
            #region 多态

            //多态
            //让一个对象能表现出多种的状态（类型）
            //屏蔽哥哥对象之间的差异，旨在写出通用的代码
            //声明父类去指定子类对象
            //实现多态的三种手段：

            //1、虚方法
            //首先将父类方法标记为虚方法使用关键字：virtual
            //在子类方法中加入关键字：override

            //2、抽象类
            //当父类中的方法不知道如何实现的时候，可以考虑使用抽象类，将方法写成抽象方法
            //使用关键字：abstract
            //absract没有方法体（没有大括号）
            //抽象方法必须是公有的
            //有大括号没有内容---->空实现
            //通过子类使用override重写调用方法
            //抽象类不允许创建对象 

            //3、接口
            //接口是一个规范（能力）
            //I...able
            //[public] interface 接口名
            //{
            //      方法
            //      自动属性
            //      索引器
            //      事件
            //}
            //接口中的成员不允许添加访问修饰符，默认public
            //不允许写有方法体的成员
            //不能包含字段
            //自动属性和普通属性
            //只要一个类继承了一个接口就必须使用它的所有成员
            //接口与接口之间可以多继承，接口只能继承于接口
            //语法上基类写在接口之前
            //普通实现：public void 方法名
            //显式实现接口：可以解决方法重名的问题----->void 接口名.方法名




            //分部类：
            //partial关键字：把一个同名的类写在不同地方
            //密封类：
            //sealed：不能被继承，但能继承其他类

            //重写ToString方法（object类方法）
            #endregion
            #region 访问修饰符
            //C#中的访问修饰符
            //public:公开的公共的
            //private:私有的，只能在当前类内部访问
            //protected:受保护的，只能在当前类及该类的子类中访问
            //internal:只能在当前程序集（项目）中访问，同一个项目中internal = public
            //protected internal:

            //能够修饰类的访问修饰符只有两个：public 和 internal
            //可访问性不一致：子类的访问权限不能高于父类的权限，会暴露父类的成员 
            #endregion
            #region 23种设计模式
            //23种设计模式
            //1、简单工厂设计模式：
            //根据用户的输入创建随想赋值给父类
            //1.单例模式

            //2.抽象工厂模式

            //3.工厂方法模式

            //4.建造者模式

            //5.原型模式

            //6.适配器模式

            //7.装饰器模式

            //8.代理模式

            //9.外观模式

            //10.桥接模式

            //11.组合模式

            //12.享元模式

            //13.策略模式

            //14.模板方法模式

            //15.观察者模式

            //16.迭代器模式

            //17.责任链模式

            //18.命令模式

            //19.备忘录模式

            //20.状态模式

            //21.访问者模式

            //22.中介者模式

            //23.解释器模式
            #region 已停用
            //People px = new People("理解", '男', 21);
            //using (FileStream fswrite = new FileStream(@"C:\Users\14345\Desktop\new.txt", FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    //开始序列化对象
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(fswrite, px);
            //} 
            #endregion
            #endregion
            #region Guid和MD5
            //Guid类
            //Console.WriteLine(Guid.NewGuid().ToString());

            //MD5类
            //MD5加密
            //密码加密（16进制）
            //字节数组转字符串：
            //1、将字节数组中每个元素按指定编码格式解析成字符串Encoding.GetEncoding("GBK").GetString()
            //2、直接将字节数组ToString()
            //3、将字节数组中的每个元素ToString()

            //MD5 md5 = MD5.Create();
            //byte[] vs = Encoding.Default.GetBytes("as12e1we");
            //vs = md5.ComputeHash(vs);
            //string s = "";
            //for (int i = 0; i < vs.Length; i++)
            //{
            //    s += vs[i].ToString("x2");
            //} 
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

            //Directory类：操作文件夹
            //File类：操作文件
            //Path类：操作路径
            //FileStream：操作流
            //Directory.Delete(string path,bool)--->默认不会删除非空文件夹

            //WebBrowser控件：uri
            //ComboBox下拉框控件:DropDownStyle:控制下拉框的外观样式

            //OpenFileDialog、SaveFileDialog、FOntDialog、ColorDialog
            //OpenFileDialog old = new OpenFileDialog(); 
            //ofd.Multiselect = true;
            //ofd.Filter = "文本文件|*.txt|图片文件|*.jpg|媒体文件|*.wmv|所有文件|*.*";

            //Panel:隐藏控件 
            #endregion
            #region 多线程

            //进程
            //Process类
            //Process[] pro = Process.GetProcesses();//当前正在进行的所有进程
            //foreach (var item in pro)
            //{
            //    pro.Kill();//杀掉所有正在进行的进程
            //    Console.WriteLine(item);
            //}

            //通过进程打开一些应用程序
            //Process.Start("calc");
            //Process.Start("mspaint");
            //Process.Start("notepad");
            //Process.Start("iexplore", "http://www.bilibili.com");

            //打开指定文件
            //ProcessStartInfo info = new ProcessStartInfo(@"C:\Users\14345\Desktop\花に亡霊.wav");
            //Process pro = new Process();
            //pro.StartInfo = info;
            //pro.Start();

            //单线程的问题：
            //创建一个线程执行Using System.Threading;
            //Thread th = new Thread(方法名);
            //标记这个线程准备就绪了，可以随时被执行th.Start();---->具体什么时候实行取决于cpu
            //将线程设置为后台线程
            //th.IsBackground = true;

            //使用多线程的目的：
            //让计算机同时做多件事，节省时间
            //后台进行，提高运行效率，不会使主程序无响应
            //可以获得当前线程和进程

            //在.Net下不允许跨线程的访问
            //可以取消跨线程的访问
            //Contorl(所有控件的基类)
            //Control.CheckForIllegalCrossThreadCalls = false;
            //Thread.Sleep(时间);---->可以使程序暂停一段时间运行（毫秒为单位）
            //Thread.CurrentThread获得当前线程引用
            //如果线程执行的方法需要参数，那么必须是object类型 
            #endregion
            #region Ado.Net数据库连接
            //Connnection对象
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
            scsbStr = "Data Source = ,; Initial Catalog = Student ; IntegratedSecurity = true";
            //2、服务器资源管理器
            //Data Source =.; Initial Catalog = Student; Persist Security Info = True; User ID = sa; Password = ***********

            //创建Connetion对象
            using (SqlConnection sc = new SqlConnection(scsbStr))
            {
                sc.StateChange += sc_StateChange;
                if (sc.State == ConnectionState.Closed)
                {
                    sc.Open();//必须open
                }
                //Close内部判断，如果之前没有将sc连接关闭，则将其关闭，若关闭了则什么都不做
                //sc.Close();
                //sc.Dispose();
            }

            //ADO.Net连接池
            //在连接字符串pooling = false关闭连接池（默认打开）
            //每次正常连接数据库都会执行：1、登录数据库服务器 2、执行操作 3、注销用户
            //open操作较为耗时

            //Command对象
            //CommandText属性表示要执行的SQL语句
            //ExecuteNonQuery()-------->执行非查询语句（增insert、删delete、改update），返回受影响的行数,对其他语句(select)返回-1
            //ExecuteScalar()-------->执行查询，返回首行首列
            //ExecuteReader()-------->执行查询，返回DataReader对象
            //StatementCompleted事件：-------->每条sql语句执行后触发















            #endregion







            //C#释放资源------->GC--->垃圾回收器
            Console.ReadKey();
        }

        private static void sc_StateChange(object sender, StateChangeEventArgs e)
        {
            Console.WriteLine(e.CurrentState);//当前连接状态
            Console.WriteLine(e.OriginalState);//之前的连接状态
        }

        #region 方法
        //方法：
        //[public（访问修饰符）]static 返回值类型 方法名（[参数列表]）
        //{
        //     方法体;
        //}
        //static:静态的
        //返回值类型（如果不需写返回值，写void）
        //方法名：Pascal命名法(首字母大写)
        //参数列表：提供给这个方法的条件（括号不能省略）
        //return：返回要返回的值；立即结束方法；
        //方法改变数组的顺序，元素的位置和大小不需要返回值



        /// <summary>
        /// 计算两个整数之间的最大值并将最大值返回
        /// </summary>
        /// <param name="n1">第一个整数</param>
        /// <param name="n2">第二个整数</param>
        /// <returns>将最大值返回</returns>
        public static int GetMax(int n1, int n2)
        {
            return n1 > n2 ? n1 : n2;
        }


        /// <summary>
        /// 求一个数组的平均值
        /// </summary>
        /// <param name="num">传入一个int类型的数组</param>
        /// <returns>返回数组平均值</returns>
        public static double GetAvg(int[] num)
        {
            double sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }
            return sum / num.Length;
        }


        #endregion
    }
}
