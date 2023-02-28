#MyNote

##C#基础

<details>
<summary><b>枚举</b></summary>

将枚举声明到命名空间的下面，类的外面，表示这个命名空间下所有的类都可以使用这个枚举。

> public enum 枚举名
> {
> ,
> ,
> 最后一行可以不写逗号
> }

    public:访问修饰符，公开的，哪都可以访问。
    private：私有的，只能在这个类内部进行访问。默认修饰为private
    enum：声明枚举的关键字。

枚举:规范开发。本质还是变量
枚举的类型默认可以和 int 类型互相转换 == 枚举类型和 int 型是兼容的。

```csharp
    public enum MyEnum
    {
        // x = 5,
        yu = 0,
        asdf = 1,
    }
```

```csharp
    public enum Gender
    {
        male,
        female
    }
```

```csharp
//枚举类型强转为int
MyEnum at = MyEnum.x;
int ad = (int)at;
Console.WriteLine(ad);
Console.WriteLine((int)MyEnum.yu);

//int类型强转为枚举
int c = 13;
MyEnum ap = (MyEnum)c;
Console.WriteLine(ap);

//枚举转string
MyEnum aq = MyEnum.yu;
string e = aq.ToString();
Console.WriteLine(e);

//string转枚举
string f = "5";
MyEnum ae = (MyEnum)Enum.Parse(typeof(MyEnum),f);
Console.WriteLine(ae);
```

</details>

<details>
<summary><b>结构</b></summary>

结构：可以帮助我们一次声明多个不同类型的变量

> [public] struct 结构名
> {
> 成员：字段
> }

```csharp
    public struct Person
    {
        public string _firstname; //字段（下划线）
        public string _lastname;
        public int _age;
        public Gender _gender;
    }
```

```csharp
Person zs;
zs._firstname = "张";
zs._lastname = "三";
zs._age = 19;
zs._gender = Gender.male;
```

</details>

<details>
<summary><b>类</b></summary>

> public class 类名

    {
         字段;
         属性;
         方法;
         构造函数;
         析构函数;
    }

写好一个类之后，需要创建这个类的对象，这个过程称为类的实例化
创建对象：
类名 名 = new 类名();

    this：
    1.表示当前这个类的对象
    2.在类当中显式的调用本类的构造函数-------> :this

</details>
<details>
<summary><b>占位符及控制输出精度</b></summary>

`decimal money = 1000m;`
{:n}---->000,000,000
{:c}---->￥符号
{:e}---->科学计数法
{:f4}---->小数点后四位
{:x}---->十六进制---->x2---->加零对齐
{:p}---->百分号

```csharp
Console.WriteLine("{0:p}",0.3);//------30.00%
Console.WriteLine("{0:}",DateTime.Now);//---->0:控制输出位数
```

{:f}---->不显示秒
{:y}---->年月
{:m}---->月日
{:d}---->2020-1-1
{:t}---->14:34

`var yin_shi_lei_xing = 1.23;`
var:根据等式右边自动推算类型

C# 是一门强类型语言：必须对每一个变量的类型一个明确的定义
js 是弱类型语言：不需要对变量的类型有明确的定义

可空类型：类型关键字? 属 Nullable<T>
在 C#代码中用添加前缀“0x”的方式表示十六进制

`Console.WriteLine("{0:0.00\a}",a);`
\a:产生“嘀”的一声蜂鸣
\f:换行

```csharp
//保留两位小数（四舍五入）
int[] num = { 4,7,9 };
double avg = GetAvg(num);
string s = avg.ToString("0.00");
avg = Convert.ToDouble(s);
Console.WriteLine(avg);
Console.ReadKey();
```

序列化：将对象转换为二进制
反序列化：将二进制转换为对象
作用：传输数据（二进制）

</details>

<details>
<summary><b>try-catch</b></summary>

```csharp
//判断是否为闰年
int year, month, day;
Console.WriteLine("请输入年份：");
try
{
   year = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("请输入月份：");
   try
   {
       month = Convert.ToInt32(Console.ReadLine());
       switch (month)
       {
           case 1:
           case 3:
           case 5:
           case 7:
           case 8:
           case 10:
           case 12:
               Console.WriteLine("这个月有31天");
               break;
           case 2:
               if (year % 400 == 0 || (year % 4 == 0 && year % 100  != 0))
               {
                   Console.WriteLine("这个月有28天");
               }
               else
               {
                   Console.WriteLine("这个月有29天");
               }
               break;
           default:
               Console.WriteLine("这个月有30天");
               break;
       }
   }
   catch
   {
       Console.WriteLine("输入的月份有误");
   }
}
catch
{
   Console.WriteLine("输入的年份有误");
}
```

</details>

<details>
<summary><b>类型转换</b></summary>

```csharp
int year = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(year);
bool tb = int.TryParse(Console.ReadLine(), out a);
Console.WriteLine(a);
```

</details>

<details>
<summary><b>产生随机数</b></summary>

```csharp
Random r = new Random();
int rNub = r.Next(1, 10+1);
Console.WriteLine(rNub);
```

</details>

<details>
<summary><b>数组</b></summary>

```csharp
//初始化方式
int[] nums = new int[10];
int[] nums2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int g = nums2.Max();
Console.WriteLine(g);
for (int i = 0; i < nums2.Length; i++)
{
    Console.WriteLine(nums2[i]);
}
```

```csharp
//冒泡排序：
int[] num = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
int temp;
for (int i = 0; i < num.Length-1; i++)
{
   for (int j = 0; j < num.Length-1-i; j++)
   {
       if (num[j]>num[j+1])//升序排列
       {
           temp = num[j];
           num[j] = num[j + 1];
           num[j + 1] = temp;
       }
   }
}
```

```csharp
Array.Sort(num);//针对数组做一个升序的排列
Array.Reverse(num);//逆转排列数组
for (int i = 0; i < num.Length; i++)
{
   Console.WriteLine(num[i]);
}
```

</details>

<details>
<summary><b>三个高级参数：out、ref、params</b></summary>

out 参数

> 在一个方法中返回多个不同类型的值：
> `public static void 方法名（int ,out int,out double,out string）`

ref 参数

> 能够将一个参数带入一个方法中进行改变，改变完成后再将改变后值带出方法
> `public static void 方法名（ref int,ref int）`

params 参数

> 将实参列表中跟可变参数数组类型一致的元素都当作数组的元素里。
> 必须是参数列表之中的最后一个元素
> `public static void 方法名（int ,params int[] num）`

</details>

<details>
<summary><b>重载</b></summary>

方法的重载

> 方法的名称相同，但传递的参数不同

分为两种情况：

> 1.参数的个数相同，那么参数的类型就不能相同 2.参数的类型相同，那么参数的个数就不能相同

方法的重载和返回值没有关系

</details>

<details>
<summary><b>位运算</b></summary>

1 .&运算符
& 是二元运算符，它以特定的方式的方式组合操作数中对应的位 果对应的位都为 1，那么结果就是 1， 如果任意一个位是 0 则结果就是 0
1 & 3 的结果为 1
来看看它的怎么运行的：
1 的二进制表示为 0 0 0 0 0 0 1
3 的二进制表示为 0 0 0 0 0 1 1
根据 & 的规则 得到的结果为 0 0 0 0 0 0 0 1,十进制表示就是 1
只要任何一位是 0 & 运算的结果就是 0，所以可以用 & 把某个变不必要的位设为 0, 比如某个变量的二进制表示为 0 1 0 0 1 0 01, 我想保留低 4 位，消除高 4 位 用 &0x0F 就可以了（注：0x0F 为 16 制表示法，对应的二进制为 0 0 0 0 1 1 1 1），这个特性在编码使用很广泛。

2 、| 运算符
| 跟 & 的区别在于 如果对应的位中任一个操作数为 1 那么结果是 1
1 | 3 的结果为 3

3、 ^运算符
^ 运算符跟 | 类似，但有一点不同的是 如果两个操作位都为 1 话，结果产生 0
0 1 0 0 0 0 0 1
0 1 0 1 1 0 1 0
产生 0 0 0 1 1 0 1 1

4 、~运算符
~是对位求反 1 变 0， 0 变 1

5 、移位运算符移位运算符把位按指定的值向左或向右移动
<< 向左移动 而 >> 向右移动，超过的位将丢失，而空出的位则补 0
如 0 1 0 0 0 0 1 1(十进制 67) 向左移动两位 67 << 2 将变成
0 0 0 0 1 1 0 0 （十进制 12）当然如果你用 java 代码写，由是 32 位，不会溢，结果是 268
向右移动两位 67 >> 2 则是
0 0 0 1 0 0 0 0(十进制 16)
下面介绍一些具体的应用
前面提到 2 向前移动 1 位变成 4 利用这个特性可以做乘法运算(在不虑溢出和符号位的情况下)
2 << 1 = 4
3 << 1 = 6
4 <<detai 1 = 8
同理 >> 则可以做除法运算
任何小数 把它 >> 0 可以取整
如 3.14159 >> 0 = 3;

int a = 5, b = 9;
Console.WriteLine(a & b);
Console.WriteLine(a | b);
Console.WriteLine(a ^ b);

/_交换变量_/
a = a ^ b;
b = b ^ a;
a = a ^ b;
Console.WriteLine("a=" + a + " b=" + b);
a = a & (~a); //a 清零
Console.WriteLine(a);
a = a | (~a); //a 全为 1
Console.WriteLine(a);

输出结果
1
13
12
a=9 b=5
0
-1

</details>

<details>
<summary><b>方法</b></summary>

方法：

> [public（访问修饰符）]static 返回值类型 方法名（[参数列表]）
> {方法体;
> }

`static`:静态的
返回值类型（如果不需写返回值，写 `void`）
方法名：Pascal 命名法(首字母大写)
参数列表：提供给这个方法的条件（括号不能省略）
`return`：返回要返回的值；立即结束方法；
方法改变数组的顺序，元素的位置和大小不需要返回值

</details>

##面对对象

<details>
<summary><b>面对对象初级</b></summary>

面对过程-------->面对对象
面对过程：强调完成这件事的动作
面对对象：找个对象帮你做事-------->意在写出一个通用的代码，蔽差异
如果要用面对过程的思想，当执行的人不同时，需要为每个不同的人身定做解决事情的方法

面向对象三大特征：**封装、继承、多态**
属性：对象具有的多种特征，每个对象的每个属性都拥有特定值
对象是具体化的事物，不能是抽象概念
把这些具有相同属性和相同方法的对象进行进一步的封装，抽象出<>这个概念
类：是模子，确定对象拥有的特征（属性）和行为（方法）
对象是根据类创建出来的
类不占内存，而对象占用内存

属性：ctrl+r+e 封装字段
属性的作用就是保护字段，对字段的赋值和取值进行限定
属性的本质是两个方法：`get` 和 `set`-------->可读可写属性
字段在类之中必须是私有的
对象的初始化：给属性赋值
自动属性：不需要实现的属性语法，不需要定义字段（如果只对字段单封装，没有附加逻辑，则定义自动属性，可以减少代码量）
`Field`-------->字段
`Method`-------->方法
`properties`-------->属性

静态和非静态的区别 1.在非静态类中，既可以有实例成员，也可以有静态成员//静态类中能有静态成员 2.在调用实例成员的时候，需要使用对象名.实例成员;//在调用静成员时，要用类名.成员; 3.静态函数中只能访问静态成员//实例函数中既可以访问静态成员，可以访问实例成员

使用: 1.静态类可以作为工具类使用 2.静态类在整个项目中资源共享-------------------->人为划分内存：堆、栈、静态存储区域

扩展方法
静态类中的静态方法在参数前加 `this` 可以不用类.方法，而是被扩的实例.方法
在使用时 `using` 类名
同名时优先调用实例方法
扩展的类型最好不要是基类，越细越好

构造函数：帮助我们初始化对象（给对象属性依次赋值） 1.构造函数没有返回值，并且不写 `void` 2.构造函数名必须和类名一样 3.静态构造函数：类第一次被创建时将由 CLR 执行且只有一次，只能始化一些静态成员，每个类只能有一个且可以同时存在公有无参构造数 4.私有构造函数：不能通过 new 实例化，可以通过静态成员、或内部例化再返回给外部
类之中会有一个默认的无参构造函数
经过编译器初次编译后 IL 中为 `.ctor`

> public 构造函数名()
> {
> }

`new` 关键字： 1.在内存中开辟一块空间 2.在开辟的空间中创建一个对象 3.用对象的构造函数进行初始化对象

析构函数：
----->无法继承或重载
当程序结束时由 GC 自动执行------->帮我们释放非托管资源（马上放）

> ~类名()
> {
> }

析构函数隐式地调用对象基类的 `Finalize` 方法，故不应使用空析构数，会导致不必要的性能损失

值类型和引用类型在内存上存储的方式不一样
传递值类型和引用类型时方式不一样-------->值传递||引用传递
值类型：`int`、`double`、`bool`、`char`、`decimal`、`struct`、`um`-------->储存在内存的栈当中
引用类型：`string`、`自定义类`、`数组`、`object 类`、`接口`-------->存储在内存的堆中

拆箱：将引用类型转化为值类型
装箱：将值类型转化为引用类型
尽量避免，会影响时间
是否发生拆箱后装箱----->两种类型是否存在继承关系

</details>

<details>
<summary><b>继承</b></summary>

继承： //子类名:父类名
解决类中的代码冗余 1.继承的单根性：一个子类只能有一个父类 2.继承的传递性：多重继承

把几个子类（派生类）当中重复的类单独拿出来封装成一个类，作为这几个类的父类（基类）
子类继承了父类的属性和方法，但并没有继承父类的私有字段
子类并没有继承父类的构造函数，但子类会默认调用父类的无参构造函数————创建父类对象，让子类可以使用父类成员
所以如果在父类中重新写了一个有参数的构造函数后，默认无参构造函数就没有了，子类就无法调用父类成员而报错
解决办法： 1.在父类中重新写一个无参构造函数 2.在子类中显式地调用父类构造函数，使用关键字:`base`()
可以用 `base` 关键字引用基类的成员 `base`.基类方法名();

创建对象时，系统先调用基类的构造函数，初始化基类的变量，然后调用派生类的构造函数，初始化派生类的变量，是
一个由基类向派生类逐步构建的过程。删除对象时，先调用派生类的析构函数，销毁派生类的变量，然后调用
基类的析构函数，销毁基类的变量，是一个由派生类向基类逐步销毁的过程。

在派生类中不能使用基类的私有成员
让类的成员既保持封装性又可以在派生类中使用，那么可以把它定义为 protected 成员（受保护成员）
`protected int _age;`
此时在子类中可以使用父类的字段

虚方法的重写：
子类调研在基类中的同一个方法，但其在每个类中是不同的，则可以把基类中的方法设计成虚方法，然后在派生类中重写该方法
`public virtual 方法名()`
`virtual` 修饰符不能与 `static`、`abstract`、`private` 一起使用
在派生类中，用关键字 `override` 重写该方法
`public override 方法名()`

我们只能重写基类中的虚方法，不能重写普通方法。要想在派生类中修改基类的普通方法，需要用 `new` 关键字隐藏基类中的方法
关键字 `new`: 1.创建对象 2.隐藏从父类继承过来的同名成员(普通方法)
`public new 方法名()-------->子类调用不到父类的成员 不推荐`

抽象类：不能被实例化，只能作为其它类的基类而存在，其目的是抽象出子类的公共部分以减少代码重复。
`abstract class 类名`
抽象方法：是一种特殊的没有默认实现的虚方法(但不需要 `virtual` 关键字)，它只能定义在抽象类中
抽象方法没有任何执行代码，需要在派生类中用重写的方式具体实现
在派生类中不能用 `base` 直接引用抽象基类的抽象方法
`public abstract 方法名()`
抽象属性：也没有具体实现代码，必须在派生类中重写

```csharp
public abstract int Age
{
   get;
   set;
}
```

同样，如果想防止一个方法被派生类重写，可以把它为声明密封方法
`public sealed override 方法名()`
`Object` 类是所有类的基类-------->在 C#中所有类都简介继承了 `Object` 类
etails>

</details>
<details>
<summary><b>里氏转换</b></summary>

里氏转换： 1.子类可以赋值给父类-------->派生类对象也属于基类，所以基类用符可以指向派生类对象

```csharp
Son s = new Son();
People p = s;
People p = new Son();
```

2.如果父类中是子类对象那么可以强转为子类对象

```csharp
Son ss = (Son)p;
```

表示类型转换
1----->`is`：用来判断对象是否与给定类型兼容（即属于类型或该类型的基类）

```csharp
if (p is Son) { }
```

2----->`as`: 向下转换

```csharp
Son d = p as Son;
```

</details>

<details>
<summary><b>多态</b></summary>

让一个对象能表现出多种的状态（类型）
屏蔽各个对象之间的差异，旨在写出通用的代码
声明父类去指定子类对象
实现多态的三种手段：虚方法、抽象类、接口

**_虚方法_**
首先将父类方法标记为虚方法使用关键字：`virtual`
在子类方法中加入关键字：`override`

**_抽象类_**
当父类中的方法不知道如何实现的时候，可以考虑使用抽象类，将方法写成抽象方法
如果存在个性化方法，就不考虑使用抽象
使用关键字：`abstract`
`absract`没有方法体（没有大括号）
抽象方法必须是公有的
通过子类使用`override`重写调用方法
抽象类不允许创建对象

**_接口_**
接口是一个规范（能力）
I...able

> public interface I 接口名
> {

      方法
      自动属性
      索引器
      事件

}

接口中的成员不允许添加访问修饰符，默认`public`
不允许写有方法体的成员
不能包含字段
自动属性和普通属性
只要一个类继承了一个接口就必须使用它的所有成员
接口与接口之间可以多继承，接口只能继承于接口
语法上基类写在接口之前

> 普通实现：public void 方法名
> 显式实现接口：可以解决方法重名的问题----->void 接口名.方法名

接口和抽象类的选择： 单继承多实现

> 接口注重于单个的约束
> 抽象指通用实现

> 子类都有的 => 父类
> 子类都有但不同 => 父类抽象
> 有的没有 => 接口

> 普通方法由左边决定 => 编译时
> 虚方法和抽象方法由右边决定 => 运行时

其他类类型：

> 分部类：
>
> > partial 关键字：把一个同名的类写在不同地方

> 密封类：
>
> > sealed：不能被继承，但能继承其他类

重写`ToString`方法（`Object`类方法）

</details>

<details>
<summary><b>访问修饰符</b></summary>

C#中的访问修饰符

> `public`:公开的公共的
> `private`:私有的，只能在当前类内部访问
> `protected`:受保护的，只能在当前类及该类的子类中访问
> `internal`:只能在当前程序集（项目）中访问

同一个项目中`internal` = `public` `protected` `internal`:
能够修饰类的访问修饰符只有两个：`public` 和 `internal`
可访问性不一致：子类的访问权限不能高于父类的权限，会暴露父类的成员

</details>

##web 前端

<details>
<summary><b>HTML</b></summary>

**_HTML_**
超文本标记语言：`Hyper Text Markup Language`
在 html 当中存在着大量的标签，我们用 html 提供的标签，将要显示在网页中的内容包含起来，构成了网
网页中有哪些东西由 html 决定，这些东西如何显示就由 css 决定
`css`:控制网页内容显示的效果
`html`+`css`=静态网页
`js`+`Jquery`-------动态网页
html 是一门不区分大小写的语言-------语言规范：属性名小写(XML 要求必须小写)

基本框架：

```html
<!DOCTYPE html>
< html >                              manifest 属性：用于离线浏览
    < head >
        < title ></ title >
    </ head >
    < body >
    </ body >
</ html >
```

| 标签名           | 标签       | 作用                                                                                                                                           |
| ---------------- | ---------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| 段落标签         | `<p> </p>` |                                                                                                                                                |
| 超链接标签       | `<a> </a>` | 属性`href` = "地址",属性`target` (_`blank`,_`self`)实现跳转的页面(外、内),`href`属性实现页内/间跳转 给`<a>`标签命名 `href`="外部名称#内部名称" |
| 分割线           | `<hr/>`    |                                                                                                                                                |
| 换行             | ` <br/>`   | 没有空隙                                                                                                                                       |
| 注释标签         | `<!-- -->` |                                                                                                                                                |
| 空格标签(转义符) | `&nbsp;`   | 如果在文本中写空格则只显示一个                                                                                                                 |
| 双引号           | `&quot;`   |                                                                                                                                                |
| &号              | `&amp;`    |                                                                                                                                                |
| 大于号           | `&gt;`     | great than                                                                                                                                     |
| 小于号           | `&lt;`     | less than                                                                                                                                      |

**_物理字体：_**

| 标签名             | 标签                       | 作用                                                                      |
| ------------------ | -------------------------- | ------------------------------------------------------------------------- |
| 加粗               | `<b> </b>`                 |
| 斜体               | `<i>`                      |
| 定义下划线文本     | `<u>`                      |
| 定义加删除线的文本 | `<s>`                      |
| 定义被删除的部分   | `<del>`                    |
| 定义新插入的部分   | `<ins>`                    |
| 定义上、下标       | `<sup> <sub>`              |
| 高亮显示           | `<mark></mark>`            |
| 注音               | `<ruby>`                   | 由需要解释/发音的字符和提供该信息的`<rt>`元素组成，还包括可选的 <rp> 元素 |
| 时间标签           | `<time></time>` `datetime` | 属性：YYYY-MM-DDThh:mm:ssTZD TZD 时区标识符                               |
| 单词正确换行       | `<wbr></wbr>`              |

**_格式:_**

| 标签名                     | 标签                        | 作用                                                                  |
| -------------------------- | --------------------------- | --------------------------------------------------------------------- |
| 预定义文本格式             | `<pre></pre>`               | 类似 C#中的@符号                                                      |
| 定义强调文本               | `<em>`                      |
| 定义强调文本               | `<strong>`                  |
| 定义计算机代码文本         | `<code>`                    |
| 定义计算机代码样本         | `<samp>`                    |
| 定义键盘文本               | `<kbd>`                     |
| 定义文本的变量部分         | `<var>`                     |
| 定义小号文本               | `<small>`                   |
| 脱离其父元素的文本方向设置 | `<bdi></bdi>`               |
| 引文、引用及定义           |                             |
| 定义缩写                   | `<abbr>缩写</abbr>`         | 属性`title`="[全称]"                                                  |
| 定义地址                   | `<address></address>`       |
| 定义文字方向               | `<bdo></bdo>`               | 指的是 bidi 覆盖(Bi-Directional Override),属性`dir`------`rtl`(`ltr`) |
| 定义摘自另一个源的引用     | `<blockquote></blockquote>` | 属性`cite`=url                                                        |
| 定义短的引用语             | `<q></q>`                   | 属性`cite`=url                                                        |
| 定义引用、引证             | `<cite></cite>`             |
| 定义一个定义项目           | `<dfn></dfn>`               |

**_列表_**

| 标签名     | 标签         | 作用                   |
| ---------- | ------------ | ---------------------- |
| 有序列表   | `<ol> </ol>` | `type`属性改变序列号   |
| 无序列表   | `<ul> </ul>` | `type`属性改变序列符号 |
| 自定义列表 | `<dl> </dl>` |

```html
<dt>大列名</dt>
<dd>小列名</dd>
<dd>小列名</dd>
```

**_表格_**

```html
<table border="1">
  <tr>
    <th>表格标题</th>
    <td>单元格内容</td>
    <td>单元格内容</td>
  </tr>
  <tr></tr>
</table>
```

跨行/列的表格使用`rowspan`(`colspan`)属性="单元格数"实现
标题标签 `<h#>`---------#-------`1~6`
用来显示元素的移动 `<marquee> </marquee>`-------`direction`属性设置方向(`left`,`right`,`down`,`up`)
behavior 属性设置运动模式(`scroll`,`altermate`,`slide`--静止)

**_图片标签_**

`<img src="..."/>`------`alt`属性：当图片因为某种原因无法加载出来时显示的内容，`title`属性：当光标移动到图片上的时候显示的内容
`<map></map>`用于客户端图像映射,指带有可点击区域的一幅图像
`<area></area>`定义图像地图中的可点击区域 `coords`属性
百分比条标签 `<meter></meter> ` `value`(必需，可以只有百分值),`high`、`low`(界定值，超出则为黄色),`max`、`min`(范围最值)
进度条： `<progress></progress>` `max`、`value`
表单
收集用户的数据
`<form></form>`----------`action`属性
`method`属性(默认形式 get 以 url 的方式发送到地址栏、post 通过报文提交)
`target`属性(\_parent 父框架打开、\_top 整个窗口打开)
`accept-charset`属性(提交表单的字符编码)
`autocomplete="on/off"`(是否自动填充)
`name`属性(表单名称)
`novalidate`属性(不对表单数据进行验证)
`<input type=""/>`------------`type`的 text 属性值相对应 winform 中的 textbox 控件
`autofocus`(自动获得焦点)

常用控件：`text`(单行文本框输入)、`password`(密码框)、`radio`(单选按钮)、`checkbox`(复选框)
`hidden`隐藏域，用户无法看见
`<select size="">`(下拉列表)------`size`属性表示默认显示几个值
`<textarea>`(多行文本框输入)

```html
<form action="www.baidu.com" method="get">
  用户名：<input type="text" name="txtName" />
  <br />
  密码：<input type="password" name="txtPwd" />
  <br />
  <fieldset>
    <legend>性别</legend>
    <input type="radio" name="sex" />男 <input type="radio" name="sex" />女
  </fieldset>
  <br />
  <fieldset>
    <legend>婚姻状况</legend>
    <input type="radio" name="married" />已婚
    <input type="radio" name="married" />未婚
  </fieldset>
  <br />
  <input type="submit" value="注册" />
  <input type="reset" value="重置所有" />
  <select>
    <optgroup label="高校">
      <option>四川大学</option>
      <option>电子科技大学</option>
      <option>西南交通大学</option>
      <option>西南财经大学</option>
    </optgroup>
  </select>
  <br />
  <input type="file" />
  <br />
  <textarea cols="20" rows="3">
      示范文本：HTML 指的是超文本标记语言 (Hyper Text Markup Language),不是一编程语言，而是一种标记语言(markup language)标记语言是一套标记标签(markup tag)HTML 用标记标签来描述网页
  </textarea>
</form>
```

div 和 span
`<div> </div>`-----自动换行，不允许有其他标签叠加在上面
`<span> </span>`------不换行，可以用来承载文本信息
`<iframe>`

</details>

<details>
<summary><b>CSS</b></summary>

CSS:
cascading style language 层叠样式表，是对 html 的补充
CSS 实现了内面内容和内面效果的彻底分离(写 CSS 的时候基本不影响 html)
将样式表加入到 HTML 文档中：

- 内联样式表(在标签内部通过 CSS 代码设置元素的样式)
  优点：灵活
  缺点：代码冗余
- 嵌入样式表(在 head 标签里面写)
  优点：方便
  缺点：优先级低

```css
<style type="text/css">
  p{
      background-color:pink;
      font-size:innitial;
  }
</style>
```

- 外部样式表

在 head 之间写
`<link href="*.css" rel="stylesheet" type="text/css"/>`
优先级最低
通常不建议使用内联样式表，会与 html 语言搞混

样式规则的选择器：

- HTML Selector
- Class Selector(需要给设置样式的)

`<p class="类名"> </p>`
在 style 里面 p.类名{}----就拿到了[类名]这个标签------可以进行单独设置

- ID Selector(给 id 属性赋值)-----调用:#id 值{},id 值不能重复
- 关联选择器：p em{}----直接用标签名进行设置
- 组合选择器：h1,h2,h3,h4,h5,h6,td{}----组合多种标签名进行设置
- 伪元素选择器：对同一个 html 元素的各种状态和其所包括的部分内容的一种定义方式------类似事件

常用伪元素:

> A:active 选中超链接时的状态
> A:hover 光标移动到超链接上的状态
> A:link 超链接的正常状态
> A:visited 访问过的超链接状态
> A:first-line 段落中的第一行文本
> A:first-letter 段落中的第一个字母

CSS 样式属性
字体

> font-family
> font-size:(xx-small、x-small、small、medium、large、x-large、xx-large)
> font-style:(normal、italic、oblique)
> font-decoration(下中上划线、闪烁效果)
> font-weight:(normal、bold、bolder、lighter、100-900)

背景

> background-color:
> background-image:
> background-repeat:
> background-attachment:(fixed、scroll)-----（图像是否随内容滚动）
> background-position:

文本

> word-spacing 单词间距
> letter-spacing 字符间距
> text-align 文本水平对齐方式
> text-indent 首行缩进值
> line-height 文本所在行的行高

位置

> position:(absolute 绝对定位------最重要------,relative 相对定位,static 默认值-无特殊定位)
> float: ------最重要------使 div 漂浮不对其它 div 造成遮挡
> z-index:值 高度

布局

> 盒子模型：盒子与盒子之间的距离用 margin,盒子与里面内容之间的距离用 padding
> margin-(top、right、bottom、left)
> border-(top、right、bottom、left)-(width,style,color)
> display:(inline、block)

边缘
列表
蒙版层
设置不透明度 `obacity` 属性，1 为不透明，0 为透明，设置不透明度可以看到层下面的内容，但是无法对其进行操作

</details>


<details>
<summary><b></b></summary>
</details>

<details>
<summary><b>yarn包管理器</b></summary>

yarn包管理器
安装yarn
`npm install -g yarn`
更新本体
`yarn set version latest`

安装所有依赖：
`yarn`或`yarn install`
添加依赖项
`yarn add 包名@版本/标签 --dev/peer`
更新依赖项
`yarn up 包名`
删除依赖
`yarn remove 包名`
</details>

<details>
<summary><b>Vite</b></summary>

搭建第一个vite项目
`npm create vite@latest 项目名 --template vue`

`yarn create vite 项目名 --template vue`

`pnpm create vite 项目名 --template vue`


</details>

##Net 6.0

<details>
<summary><b>集合</b></summary>

四种类型：

> Array
> Linked
> Set
> Key-Value

任何数据集合都实现了 IEnumralue 使得都可以使用 Foreach 来遍历
IEumrable、ICollecion、IList、IQueryable 都可能存在重复的内容，承不同的接口来实现标识

<details>
<summary><i>1.1 ArrayList集合</i></summary>

集合：很多数据的一个集合，长度可以任意改变，类型不固定

```csharp
ArrayList list = new ArrayList();
list.Add(Object);
```

将一个对象输出到控制台，默认打印的是这个对象的命名空间
`Console.WriteLine(对象名.ToString());`

ArrayList 长度的问题

> count---->表示这个集合事实际包含的元素个数
> capacity---->表示这个集合可以包含的元素个数

每次集合中实际包含的元素个数超过了可以包含的数时，集合就会向内存申请多开辟一倍的空间，保证合的长度一直够用

</details>

<details>
<summary><i>1.2 List泛型集合</i></summary>

对元素的类型有了确切的定义

```csharp
List<int> list1 = new List<int>();
int[] nums = list1.ToArray();
List<int> list2 = nums.ToList();
```

</details>

---

<details>
<summary><i>2.1 Hashtable</i></summary>

Hashtable 方法------键值对集合

```csharp
Hashtable hs = new Hashtable();
hs.Add(1, "张三");
hs.Add(2, "b");
hs.Add(false, "c");
//---->冲突
hs.Add(1, "张三");
//---->通过索引替换
hs[1]="zs";
```

根据键找值

```csharp
if (hs.ContainsKey("false"))
{
}
foreach (var item in hs.Keys)
{
   Console.WriteLine(hs[item]);
}
```

在循环次数很多时，foreach 的效率远高于 for

</details>

<details>
<summary><i>2.2 Dictionary字典</i></summary>

Dictionary(键值对集合)

```csharp
Dictionary<int, string> dic1 = newDictionary<int, string>();
dic1.Add(1,"一");
dic1[2] = "二";
foreach (KeyValuePair<int,string>keyValuePair1  in dic1)
{
   Console.WriteLine("{0},{1}",keyValuePair1.Key,keyValuePair1.Value);
}
```

静态字典 可以当作缓存使用 全局唯一不会被释放

</details>
<details>
<summary><i>2.3 SortedDictionary</i></summary>

有排序过程效率并不高

</details>

---

<details>
<summary><i>3.1 HashSet</i></summary>

动态长度
不能通过索引访问

```csharp
HashSet<T> hs1 = new HashSet<T>();
hs1.Add();
```

交差并补

```csharp
HashSet<T> hs2 = new HashSet<T>();
hs1.IntersectWith(hs2);
hs1.ExceptWith(hs2);
hs1.UnionWith(hs2);
hs1.SymmetricExceptWith(hs2);
```

</details>

<details>
<summary><i>3.2 SortedSet</i></summary>

去重+排序

</details>

---

<details>
<summary><i>4.1 LinkedList链表</i></summary>

链表
泛型 LinkedList<T> 数据在内存上不连续分配，每元素记录前后节点的地址
不能通过下标访问，查找只能通过遍历
增删较为方便

```csharp
//从头查找数据
LinkedListNode<T> node1 = linkedList.Fin()；
//在后插入
linkedList.AddAfter(node1,XX);
linkedList.Remove(XX);
```

</details>

<details>
<summary><i>4.2 Queue队列</i></summary>

队列 Queue<T>
先进先出链表

```csharp
Queue<T> queue1 = new Queue<T>();
queue1.Enqueue(t);
//获取第一个元素并移除出队列
queue1.Deque();
queue1.Peek();
```

</details>

<details>
<summary><i>4.3 Stack栈</i></summary>

栈 Stack<T>

```csharp
Stack<T> s = new Stack<T>();
s.Push();
s.Pop();
s.Peek();
```

</details>

---

线程安全：
ConcurrentStack  
ConcurrentQueue
ConcurrentBag  
ConcurrentDictionary

</details>

<details>
<summary><b>文件和流</b></summary>

Directory 类：操作文件夹
File 类：操作文件
Path 类：操作路径
FileStream：操作流

---

Path 类

> string str = @"C:\Users\14345\Desktop\new.txt";
> Path.GetFileName(string));---->返回文件名和扩展名
> Path.GetFileNameWithoutExtension(string);---->返回文件名
> Path.GetExtension(string));---->返回扩展名
> Path.GetDirectoryName(string);---->返回文件所在的文件夹的名称

## Path.GetFullPath(string);---->返回全路径

File 类

> ReadAllBytes:多媒体文件（音乐、图片文件）
> ReadAllLines：返回数组、精确操作
> ReadAllText：返回整个字符串

绝对路径：通过我的电脑能找到这个文件的路径
相对路径：文件相对于应用程序的路径
在开发中应尽量使用相对路径

```csharp
File.Create(@"");
File.Delete(@"");
File.Copy(@"",@"");
File.Move(@"", @"");
byte[] buffer = File.ReadAllBytes(@"D:\File\new.txt");
string s = Encoding.Default.GetString(buffer);
File.WriteAllBytes(@"D:\File\new.txt", buffer);
string[] contents = File.ReadAllLines(@"D:\File\new.txt");
foreach (string item in contents)
{
    Console.WriteLine(item);
}
//---->追加不覆盖之前的内容
File.AppendAllText(@"C:\Users\14345\Desktop\new.txt", "contents");
```

`Directory.Delete(string path,bool)--->默认不会删除非空文件夹`

---

FileStream 类
操作字节

```csharp
StreamWriter和StreamReader---->操作字符
FileStream fileStream1 = new FileStrea(@"C:\Users\14345\Desktop\new.txt",FileMode.OpenOrCreate);
FileStream fileStream2 = new FileStrea(@"C:\Users\14345\Desktop\new.txt",FileMode.OpenOrCreate, FileAccess.Read);
byte[] buffer = new byte[1024 * 1024 *5];//5MB
int EffectiveByteLength = fileStream2Read(buffer, 0, buffer.Length);//----->回实际读到的有效的字节数
```

关闭流
`fileStream1.Close();`
释放所占用的资源
`fileStream1.Dispose();`

将创建文件流对象的过程写在 using 当中，会自动释放流所占用的资源

```csharp
using (FileStream fswrite = new FileStream(@"", FileMode.OpenOrCreate, FileAccess.Write))
{
    //读写的内容
    //using ()
}
```

StreamReader
StreamWriter

```csharp
using (StreamReader sr=new StreamReader(@"",Encoding.Default))
{
    while(!sr.EndOfStream)
    Console.WriteLine(sr.ReadLine());
}
```

| 编码名称 | \*     |
| -------- | ------ |
| ASC      | 128    |
| ASCII    | 256    |
| GB2312   | 简体字 |
| Big5     | 繁体字 |
| unicode  | 解析慢 |
| UTF-8    | web    |

乱码原因：保存文件所用的编码格式和打开的不一样

</details>

<details>
<summary><b>字符串</b></summary>

字符串的不可变性：
当给一个字符串重新赋值时，之前的值并未销毁，而是重新开辟一块间存储新值
当程序结束后，GC 扫描整个内存。如果发现有空间没有被指向，则立把它销毁
可以把字符串看成是 `char` 类型的一个只读数组
`stringBuilder` 和 `string` `的区别：string` 在进行运算时会产生一个的实例，因此在频繁对一个字符串进行操作时最好选择 `stringBuilder`

| 方法名                                | 作用                                                            | 返回值类型 |
| ------------------------------------- | --------------------------------------------------------------- | ---------- |
| .`ToUpper`()                          | 将字符串转换成大写形式                                          | string     |
| .`Tolower`()                          | 将字符串转换成小写形式                                          | string     |
| .`Equals`(,)                          | 比较两个字符串（可以忽略大小写）                                | bool       |
| .`Split`(char[],)                     | 分割字符串返回字符串类型的数组                                  | string[]   |
| .`ToCharArray`()                      | 将字符串转换为一个 char 型数组                                  | char[]     |
| new string(char[])                    | 将一个 char 数组转换为字符串                                    | string     |
| .`Contains`(string)                   | 判断字符串中是否有子串 value                                    | bool       |
| .`Replace`(string,string)             | 将字符串中出现 old value（第个）的地方替换为 new value          | string     |
| .`Substring`(int)                     | 取从位置 int 开始到结束的子字符串(或指定度)                     | string     |
| .`Startswith`(string)                 | 判断字符串是否以 value 开始                                     | bool       |
| .`Endswith`(string)                   | 判断字符串是否以 value 结束                                     | bool       |
| .`IndexOf`(stirng)                    | 取 value 在字符串中第一次出现的位置----返回 int（找不到返回-1） |
| .`Trim`()                             | 移除所有的空字符                                                | string     |
| string.`IsNullOrEmpty`()              | 判断一个字符串是否为空 null                                     | bool       |
| string.`Join`(string,params string[]) | 在字符串数组每个素之间加入指定的分隔符                          | string     |

练习：

```csharp
string s = "abcdefg";
 //不能s[0] = 'b';因为s是只读的
char[] ch = s.ToCharArray();
ch[0] = 'b';
s = new string(ch);
```

```csharp
string _s = "a  bc _d+_e  f,,g ";
char[] chs = { ' ', '_', '+', ',' };
string[] str = _s.Split(chs/*new char[]{ ' ', '_', '+',',' }*/,StringSplitOptions.RemoveEmptyEntries);
```

```csharp
string t = "qwe";
if (t.Contains("qwe"))
{
   t = t.Replace("qwe", "***");
}
```

```csharp
StringBuilder sb = new StringBuilder();
string str = null;
//创建一个计时器
Stopwatch sw = new Stopwatch();
sw.Start();//开始计时
for (int i = 0; i < 100000; i++)
{
   sb.Append(i);//增加字符串长度
}
sw.Stop();//计时结束
Console.WriteLine(sw.Elapsed);
```

```csharp
string path = @"C:\Users\14345\Desktop\0101.txt";
string[] content = File.ReadAllLines(path, EncodingUTF8);
string[] result = new string[8];
for (int i = 0; i < content.Length; i++)
{
   string[] temp = content[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
   if (temp[0].Length >= 10)
   {
       temp[0] = temp[0].Substring(0, 8);
       temp[0] += "...";
   }
   result[i] = string.Join("|", temp);
}
for (int i = 0; i < 4; i++)
{
   Console.WriteLine(result[i]);
}
```

</details>

<details>
<summary><b>垃圾回收</b></summary>

CLR

C#释放资源------->GC--->垃圾回收器
托管资源是 Net framework 之内的
对于非托管资源需要手动调用 Close();
而对于托管资源，可以自行关闭

**_托管资源_**：堆里面由 CLR 创建的对象
**_非托管资源_**

**内存泄露**：内存占用了但没有回收

`new` 在堆栈中开辟一块内存，分配一个地址
实例化的对象在栈中，储存的是对应堆栈的地址
对象里面的属性也储存在堆栈中，但方法中的值类型变量在调用是储存在线程栈中

引用类型任何时候都在堆栈里
除非所在对象在堆中，值类型都在栈里

```csharp
string str1 = "aaa";
string str2 = "bbbb";
str2 = "aaa";
object.ReferenceEquals(str1, str2) 			=>		true
```

享元模式的应用：CLR 分配内存的时候查找相同的值

字符串不可变的原因:

> 由于享元模式，可能有多个变量指向一个字符串
> 程序共享一个堆，堆中的内存是连续分配的，如果改动长度，会造成大量数据的移动

在 `new` 的时候会开辟内存，如果空间不够则 GC 释放
对于访问不到的东西(跳出方法体的变量等)需要手动 GC.`Collect`();
静态成员永远不会被回收

垃圾处理两个优化策略： 1.**分级策略**

| 条件                                                                    | 分级 |
| ----------------------------------------------------------------------- | ---- |
| GC 之前：                                                               | 0 级 |
| 第一次 GC 后保留                                                        | 1 级 |
| 进行回收时首先寻找一级对象，如果空间还是不够，再找 1 级，这个过程后存留 | 2 级 |

2.**大对象策略**
当对象大于 85k 时将会分配在大型对象堆(LOH)上
大于 85k 的对象用 链表 单独管理

`Dispose`()
本身是没有意义的，需要继承 `IDisposable` 接口，主动实现
GC 不会自动执行 `Dispose`

</details>

<details>
<summary><b>Guid、MD5</b></summary>

Guid 类
`Console.WriteLine(Guid.NewGuid().ToString());`

**_MD5 不可逆加密_**
**_Des 对称可逆加密_**：加密速度快。加密解密需要同一个密钥，但密钥的安全无法保证
**_RSA 非对称可逆加密_**：加密的密钥和解密的密钥是一组，但无法推算另一个

---

RSA 的一组密钥是对应的，如果解密密钥能解密，则说明加密的源一定确定

1.  https 请求加载时首先进行安全验证
2.  能用解密证明 CA 证书来自访问的地址
    md5 匹配成功说明消息没有被篡改过
3.  实现浏览器向服务器间的数据传输，浏览器使用公钥加密
    服务器通过解密密钥并返回结果，证明
4.  由客户端产生发给服务器，确定公认对称密钥
5.  开始传输

---

MD5 类

> MD5 加密
> 密码加密（16 进制）
> 字节数组转字符串：

1.  将字节数组中每个元素按指定编码格式解析成字符串 Encoding.GetEncoding("GBK").GetString()
2.  直接将字节数组 ToString()
3.  将字节数组中的每个元素 ToString()

```csharp
MD5 md5 = MD5.Create();
byte[] vs = Encoding.Default.GetBytes("as12e1we");
vs = md5.ComputeHash(vs);
string s = "";
for (int i = 0; i < vs.Length; i++)
{
    s += vs[i].ToString("x2");
}
```

工具类 Md5Helper：

```csharp
public partial class Md5Helper
{
    /// <summary>
    /// 字符串加密
    /// 使用UTF8编码
    /// </summary>
    /// <param name="pwdStr"></param>
    /// <returns></returns>
    public static string EncryptString(string pwdStr)
    {
        MD5 md5 = MD5.Create();
        //使用UTF8编码
        byte[] vs = Encoding.UTF8.GetBytes(pwdStr);
        vs = md5.ComputeHash(vs);
        StringBuilder sb = new StringBuilder();
        //将字节数组转换成16进制的字符串，占两位
        foreach (byte b in vs)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
}

//调用
string pwd = Md5Helper.EncryptString("XXXXXXXXXXXXXXXX");
Console.WriteLine(pwd);
```

</details>

<details>
<summary><b>泛型</b></summary>

1. **_泛型方法_**
   延迟声明
   用一个方法，满足不同的参数类型，做相同的事

```
/// <typeparam name="T"></typeparam>
方法名<T> (T 参数名)
```

调用：
`方法名<类型>(参数)`
可以省略类型参数，根据参数自动推算

为什么用泛型不是`Object`:

> `Object`是引用类型，传入如`int`的值类型时会有装箱拆箱的过程
> 泛型方法 ≈ 普通 > 拆装箱

2. **_泛型类_**
   一个类满足不同类型，做同样的事

```
class 类名<T>{
 	public T _name;
 }
```

`类名<int> obj = new 类名<int>({T = 12});`

3. **_泛型接口_**

```
interface 接口名<T> {
 T 方法名(T t);
 }
```

泛型约束：
约束可以叠加，更加灵活

> 基类约束，强制保证传入的参数一定是该类或其子类(不能是密封类)
> 接口约束：一定要实现接口的方法
> 值类型约束：where T : struct
> 引用类型约束：where T : class
> 无参数构造函数约束：where T : new() T obj = new T()

自动赋予不同类型默认值 T obj = default(T)

```
public static 方法名<T, S> (T parameter)
where T : 类名
where S : 类名 2
{
访问声明类中的成员
}
```

**协变**
<out T>
`People p = new Male();`
List<People> ps = new List<Male>(); （不通过
一般做法(类似于遍历子类集合然后将其逐个强转为父类)：
`List<People> ps = new List<Male>().Select(c => (People)c).ToList()`
在接口或自定义类中加入`<out T>` T 只能用作返回值，不能当作参数使用
`IEnumerable<People> ps = new List<Male>()`

**逆变**
`<in T>`
不能用作返回值
`IEnumerable<Male> ps = new List<People>()`
将子类当作参数传递

**泛型缓存**
实现一个泛型类，通过静态构造函数只在声明类时调用一次这个特性，建立缓存
静态成员在内存中只储存一份
对于每一个不同的 T 都会产生一份不同的副本
适合不同类型，需要一份数据的场景
不能主动释放

</details>

<details>
<summary><b>反射</b></summary>

反射是动态的，依赖的是字符串，不需要引用
一般过程：

1. 加载 dll
2. 获取类型信息
3. 创建实例
4. 类型转换
5. 方法调用

利用工厂封装反射过程

```csharp
// 可配置可扩展：
// .config 中添加<appSettings> <add key="key值" value="类型名, dll名"> <appSettings>
public class Factory
{
    private static string XXConfig = ConfigurationManager.AppSetting["key值"];
    private static string DllName = XXConfig.Split(",")[1];
    private static string TypeName = XXConfig.Split(",")[0];
    public static DBHelper CreateHelper()
    {
    	Assembly asb = Assembly.Load(DllName);
    	Type type = asb.GetType(TypeName);
    	object helperObj = Activator.CreateInstance(type);
    	DBHelper helper = (DBHelper)helperObj;
    	return helper;
    }
}
```

**_程序集_**：
可看作是相关类打包，相当于 java 中的`jar`包
程序集包括资源文件，类型元数据(所有类型)
通过反射可以动态地后的其中的元数据
可以封装一些代码，只提供必要的访问接口
`dll` `exe`文件
`dll`文件无法执行----因为没有 Main 函数
初次编译后，高级语言被编译为`IL`中间语言、`metadata`再由 CLR 二次编译为机器码执行

**_Assembly 类_**
读取 dll 文件：
首先加载程序集文件：

```csharp
//当前目录加载dll
Assembly asb = Assembly.Load("dll名称无后缀");
Assembly.LoadFile(@"完整路径");
// 带dll后缀或写出完整路径
Assembly.LoadFrom("");
// 当前exe文件的Directory路径
AppDomain.CurrentDomain.BaseDirectory
//不论公有的、私有的都能拿到
asb.GetType();
//获取此程序集中定义的公共类型，这些公共类型在程序集外可见
asb.GetExportedTypes();
```

读取反射类型

```csharp
foreach(var item in asb.GetTypes())
{
	item.FullName
}
Type type = asb.GetType("包含 命名空间 类名 的完整名称");
```

创建对象的两种方法：

```csharp
// 调用默认无参的构造函数
Assembly对象.CreateInstance("程序集.类名")
Object inst = Activator.CreateInstance(Type对象,nonPublic, params 属性数组)
//nonPublic为true时可以调用公共/非公共构造函数
// 创建泛型对象
Type type = asb.GetType("...泛型类`X");				//使用占位符
Type newType = type.MakeGenericType(new Type[] {typeof(int), typeo(string)...});
object obj = Activator.CreateInstance(newType);
// 动态获取程序集中的信息
// 返回PropertyInfo[](属性数组)
inst.GetType().GetProperTies("")

```

利用反射复制对象(性能低)

```csharp
People people = new People() {... };

Type typePeople = typeof(People);
Type typePeopleDTO = typeof(PeopleDTO);

object peopleDTO = activator.CreateInstance(typePeopleDTO);
foreach (var prop in typePeopleDTO.GetProPerties())
{
     //匹配两个类相同的属性
     object value = typePeople.GetProperty(prop.Name).GetValue(people);
     prop.SetValue(peopleDTO, value);
}
```

返回`MethodInfo[]`(方法数组)
`inst.GetType().GetMethods("方法名")`
如果要调用的方法存在重载，则添加参数类型数组
`Type对象.GetMethod("方法名", BindingFlags.Instance | BindingFlags.NonPublic, new object[] {typeof(int)})`
可以调用到私有方法
`MethodInfo对象.Invoke(实例对象, new object[])`
调用泛型方法
`MethodInfo method = newType.GetMethod("");`
`Method newMethod = method.MakeGenericMethod(new Type[] {typeof(int)});`
`newMethod.Invoke(Object, new Object[] {111})`

---

Type 类：

> IsAssignableFrom(Type c)-----是否可以从 c 赋值
> IsInstanceOfType(object o)-----判断 o 是否为当前类的实例
> IsSubclassOf(Type c)------判断是否当前类是否是 c 的子类(不含接口)
> IsAbstract 判断是否为抽象的(含接口)

</details>
<details>
<summary><b>特性</b></summary>

中括号声明，一个继承自 Attribute 的类

一般命名以 Attribute 结尾`[CustomAttribute]`，声明时可以省略`[Custom]`
编译后产生 IL，并在 metadata 中有记录

相当于调用特性类的构造函数，因此可以写成`[特性名()]`
一般不能重复声明，在特性类命名空间中允许重复修饰

> `[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]`

作用：在不破坏类封装的前提下，补充额外的信息和行为

特性通过反射应用
任何一个可以生效的特性，都是主动使用过的

```csharp
public class Manager
public static void 方法名(T para)
{
      Type type = typeof(para);
      if(type.IsDefined(typeof(CustomAttribute), true)){      //true搜索成员继承链
          CustomAttribute attr = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute), true);
          Console.WriteLine($"{attr.属性}");
          attr.方法()
      }
}
```

给方法返回值加特性 `[return: Custom()]`
给方法参数加特性`public void 方法名([Custom] T para)`

示例:
`[Obsolete("此版本已不再维护！", true)]` 影响编译器的运行，加 true 直接报错
`[Serializable]` 序列化和反序列化，影响程序运行

</details>

<details>
<summary><b>异步多线程</b></summary>

> 同步：完成计算之后进入下一行，只有一个线程运算效率低
> 异步：不等直接下一行，非阻塞，空间换时间 管理多线程也有资源损耗

异步多线程无序
异步启动线程由 OS 响应，不一定按顺序返回
由于 CPU 分片计算，线程结束的时间也不一样

CPU 时间片轮转

- (上下文切换 加载环境=>计算=>保存环境 )
  从微观看，一个核同一时刻只能执行一个线程
  宏观上是多线程并发

`await`只能放在`Task`前面
`await`相当于将之后的代码包装到委托之中作为回调
一把返回值为`Task`，需要其他返回值时`Task<...>`
`await`/`async`一般成对出现，只用一个`async`没有意义，要么不用要么用到底
两种同步等待方式：

1.  task 实例.Wait();
2.  result = task.Result;

进程
一个程序运行时占用全部资源的总和

---

Process 类

```csharp
Process[] pro = Process.GetProcesses();//当前正在进行的所有进程
foreach (var item in pro)
{
    pro.Kill();//杀掉所有正在进行的进程
    Console.WriteLine(item);
}
```

通过进程打开一些应用程序

```csharp
Process.Start("calc");
Process.Start("mspaint");
Process.Start("notepad");
Process.Start("iexplore", "http://www.bilibili.com");
```

打开指定文件

```csharp
ProcessStartInfo info = new ProcessStartInfo(@"...");
Process pro = new Process();
pro.StartInfo = info;
pro.StartInfo.UseShellExecute = true;
pro.Start();
```

进程和线程的关系

> 一个进程包含多个线程
> 线程：程序执行流的最小单位

单线程的问题：
`容易造成程序假死`
使用多线程的目的：

- 让计算机同时做多件事，节省时间
- 后台进行，提高运行效率，不会使主程序无响应
- 可以获得当前线程和进程
  如果线程执行的方法需要参数，那么必须是 `Object` 类型
  在 Net 下不允许跨线程的访问

Winform 取消跨线程的访问：
` Contorl(所有控件的基类).CheckForIllegalCrossThreadCalls = false;`

`volatile`关键字

- 促进线程安全
- 多线程访问时，由于速度很快，可能出问题

---

Task 类

基于线程池
创建子线程的三种方法

1. `Task.Run(() => {});`
2. `TaskFactory tf = Task.Factory;`
   `tf.StartNew(() => {});`
3. `new Task(() => {}).Start();`

阻塞当前线程，会卡界面，所有任务完成后才继续
`Task.WaitAll`(task, 时间)
等待某个任务完成
`Task.WaitAny`()

可以新开一个子线程调用 wait 方法避免卡主线程

不会阻塞 UI 线程，得到一个未完成的任务对象
`Task.WhenAll`()
`Task.WhenAny`()

等效回调

- `Task.WhenAny().ContinueWith(() => {})`
- `tf.ContinueWhenAny(..., () => {})`

延迟不卡界面
`Task.Delay().ContinueWith()`
标识子线程
`Task task = new Task((t) => { Console.WriteLine($"lambda{t}"); }, "heiheihei");`
`CW(task.AsyncState);`

---

Parallel 类

并行 在`Task`基础上的封装
卡界面 主线程参与计算
Parallel.`Invoke`(params Action);
Parallel.`For`(0, 10, i => {});
Parallel.`Foreach`([], () => {});

```csharp
//设置最大线程数量
ParallelOptions po = new ParallelOptions();
po.MaxDegreeOfParallelism = 8;
Parallel.For(0, 10, op, (i, state) => {});
```

多线程里面的异常信息会被吞掉
主线程继续运行，已经脱离了 trycatch 捕捉的范围

```csharp
catch(AggregateException aex){
  foreach(var item in aex.InnerExceptions){
      CW(item.Message);
  }
}
```

一般线程中不允许出现异常，需要自行处理好

取消线程
`Task`无法从外部停止，只能通过公共访问变量检测
`CancellationTokenSource cts = new CancellationTokenSource();`

线程是否已取消
stc.`IsCancellationRequested`
手动取消线程
stc.`Cancel`()

多线程临时变量
循环创建线程时，遍历的速度快于创建，因此读取时不一定按顺序

```csharp
for (int i = 0; i < 5; i++)
{
    int k = i;
    Task.Run(() => { Console.WriteLine(i); });
}
```

线程安全问题
两个线程同时操作 全局/静态变量 时会出现问题
为了保证静态成员的安全，可以考虑加锁(只针对引用类型)
`lock`关键字通过占用引用链接加锁，但是不能用于`string`类型(享元)

```csharp
//需要加锁的静态变量的标准写法:
private static readonly object _lock = new object();
lock (_lock){
  //可以保证任意时刻只有一个线程可以执行
}


// 等价于：
Monitor.Enter(_lock);
...
Monitor.Exit(_lock);
```

不降低性能，通过一个线程完成操作
安全队列`ConcurrentQueue`

</details>

<details>
<summary><b>LINQ</b></summary>

通过委托封装，泛型+迭代器提供特性，完成数据集合的过滤
`where`过滤 whereIF(true, () => {})
`select`投影
`min`
`max`
`orderby`
`groupby`

LINQ 的两种形式：

- 查询表达式
- lambda

内连接

```csharp
var list = from s in studentList
           join c in courseList on s.Id equals c.Id               //equals不能用=
           select new {
              Name = s.Name,
              Age = s.Age,
              Class = s.Class
           }
```

左连接

```csharp
var list = from s in studentList
           join c in courseList on s.Id equals c.Id
           into scList
           from sc in scList.DefaultIfEmpty()
           select new{
              Name = s.Name,
              Age = s.Age,
              Class = s.Class
           }
```

右连接同理

排序

```csharp
var list = from s in studentList
           where s.Age < 30
           group s by s.Class into sg
           select new {
              Name = sg.Name,
              Age = sg.Age,
              Class = sg.Class
           }
```

</details>

<details>
<summary><b>表达式目录树</b></summary>

表达式目录树
命名空间：`System.Linq.Expressions`;

用 lambda 表达式快速初始化表达式目录树
`Expression<Func<int, int, int>> exp = () => {}` //语法只能有一行，lamb 不能存在大括号
是一种数据结构，可以被二叉树解析

将 lamb 编译为委托后执行
`exp.Compile().Invoke()`

拼接表达式：

```csharp
//构建参数
ParameterExpression pe = ExpressionParameter(type, "");
//参数属性
Expression property = Expression.Property(pe, type.GetProperty(""));
//构建常量
ConstantExpression const = Expression.Constant(value, type);
//运算符
BinaryExpression be = Expression.GreaterThan(pe, const);
//构建lambda表达式
Expression<Func<类, bool>> lamb = Expression.Lambda<Func<类, bool>>(be, new ParameterExpression[] {pe});
//编译
lamb.Compile()()
```

构建`lambda`表达式
`Expression.lambda<>()`

`ExpressionVisitor`用来解析表达式目录树
因为不知道表达式的深度，所以递归解析
只提供一个入口`public Expression Visit(EXpression node)`

二元表达式解析:
重写抽象父类`ExpressionVisitor`的`VisitBinary`方法，将表达式中的加号替换为减号

```csharp
protected override Expression VisitBinary(BinaryExpression node){
      if(node.NodeType == ExpressionType.Add){
          Expression left = base.Visit(node.Left);
          Expression right = base.Visit(node.Right);
          return Expression.Subtract(left, right);
      }
      return base.VisitBinary(node);
}
```

</details>

<details>
<summary><b>XML</b></summary>

XML

- 可扩展标记语言，用途：存储数据，类似一个小型的数据库
- 严格区分大小写
- 标签成对出现
- Node:节点(标签) <--包含<-- element:元素(xml 文档中的所有内容)
- xml 文档有且只能有一个根节点

通过代码创建 XML 文档：

```csharp
//1、引用命名空间
//2、创建XML文档对象
XmlDocument xmlDoc = new XmlDocument();
//3、创建第一行文档信息并添加到doc文档中
XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);//第一行的描述信息
xmlDoc.AppendChild(xmlDec);
//4、创建根节点
XmlElement books = xmlDoc.CreateElement("books");
xmlDoc.AppendChild(books);
//给根节点books创建子节点
XmlElement book1 = xmlDoc.CreateElement("book");
books.AppendChild(book1);
//给book1创建name子节点
XmlElement name = xmlDoc.CreateElement("name");
name.InnerText = "三国演义";
book1.AppendChild(name);
//给book1创建id子节点
XmlElement id = xmlDoc.CreateElement("id");
id.InnerText = "00121";
//添加属性(属性名-属性值)
//添加标签
id.InnerXml = "<p>这是一个标签</p>";
id.SetAttribute("encoding", "utf-8");
books.AppendChild(id);
//保存xml文档
xmlDoc.Save("book.xml");
```

追加 xml 文档

```csharp
XmlDocument xmlDoc = new XmlDocument();
if (File.Exists("....xml"))
{
    //如果xml文件存在，则先加载
    xmlDoc.Load();
    XmlElement books = xmlDoc.DocumentElement;
}
else
{
    //如果文件不存在，则从第一行开始创建
}
```

读取 xml 文档

```csharp
// 获取子节点
XmlNodeList xnl = books.ChildNodes;
foreach (XmlNode item in xnl)
{Console.WriteLine(item.Attribute["content"].Value,item.Attribute["count"].Value); }
// 读取带属性的xml
XmlNodeList xnl = xml.SelextNode("/books/book/page");
```

删除节点

1. 创建`XmlDocument`对象
2. 调用`Load`函数加载 xml 文档
3. 选择单一节点：`XmlNode xn = xmlDoc.SelectSingleNode("/books/book");`
4. 删除选中的节点：xn.`RemoveAll`();

DOM 方式创建 XML 文档对象:
通过创建节点对象，然后将属性值传递给 XML 文档

</details>

<details>
<summary><b>正则表达式</b></summary>

正则表达式(Regular Expression)
_匹配_、_提取_、_替换_

正则表达式是由普通字符以及特殊字符组成的文字模式，元字符包括：（ `^` `$` `*` `+` `?` `{` `[` `\` `|` `(` ）
将元字符作为普通字符使用：在前面加转义符`\`

严格匹配:`^` `$`
`^`插入符号，表示正则式的开始
`$`美元符号表示正则式的结束

`[` 是需要匹配的字符， `{` 内是指定匹配字符的数量， `(` 用来分组
在左括号(之后写?<组名>来设置组名，可以通过 Match/MatchCollection(List<>)对象.Groups[组名]来取得这个组
`Regex obj = new Regex("[a-z]{10}");----匹配10个a-z之间的英文字母`

简化命令：
除换行\n 外任意字符 .
[0-9] \d
[a-z][0-9][_] \w
0 次或多次发生 \*
至少一次发生 +
0 次或 1 次发生，终止贪婪模式 ?

贪婪模式
非贪婪模式:尽可能少匹配

---

Regex 类
判断是否匹配：`Regex.IsMatch`(string ,正则表达式);
字符串提取：`Regex.Match`() 返回 M
`Regex.Matches`() 返回 Ma
字符串替换：`Regex.Replace`(string ,正则 ,替换 string );
`RegexOptions`枚举类型

`string str = "God Good";`
`G.d`匹配"God"
`d$`匹配字符串中最后一个"d"---------`$`匹配结尾

字符类：[]
枚举字符集，匹配括号内的任意字符[xyz] 匹配不在此括号的内的任意字符[^xyz]
指定范围内的字符:[a-z] 指定范围以外的字符:[^a-z]

验证简单的网址 URL 格式

1. 检查是否存在 www:www
2. 域名必须是长度在 1-15 之间的英文字母:[a-z]{1,15}
3. 以 com 或 org 结束:(com|org)$

正则式：`^www[.][a-z]{1,15}[.](com|org)$`
`.` `*` `?`---------表示 0 个或多个任意字符

---

`WebClient`类

- `DownloadString` 默认编码
- `DownloadData` UTF-8 编码
- `DownloadFile` 将具有指定 URL 的资源下载到本地文件

net5 推荐使用`HttpClient`类

```csharp
using(HttpClient hc = new HttpClient()){
 	string html = await hc.GetStringAsync(url)
}
```

简单爬虫案例：

```csharp
WebClient web = new WebClient();
byte[] buffer = web.DownloadData(@"https://www.acfun.cn/");
string html = Encoding.UTF8.GetString(buffer);
      //可以用来爬取.png.lpg.webp格式的图片
MatchCollection mc = Regex.Matches(html, @"<img.+?(?<picSrc>https://(cdn\.aixifan\.com|tx-free).+?\.(?<picFormat>png|gif|webp)).+?>");
int index = 0;
foreach (Match m in mc)
{
    if (m.Success)
    {
        index++;
        string downloadSrc = m.Groups["picSrc"].Value;
        //Console.WriteLine(downloadSrc);
        string target = @"C:\Users\Attac\Desktop\newHTML\Resources" + "\\" + index + ".png";
        web.DownloadFile(downloadSrc, target);
    }
}
Console.WriteLine("爬取完成！");
```

</details>

<details>
<summary><b>Crawler爬虫</b></summary>

Nuget: **_HtmlAgilityPack_**

robots 协定(君子协定)
模拟请求检测 Header

反爬：

- 由于频率高，限制 IP 访问(黑名单、验证码)
- 解决方案：
- 多个 IP(adsl 多次拨号/168 伪装 IP/代理 IP)
- 图像识别验证码

大招：

- ajax 数据动态加载
- 文本数据转图片
- js 收集用户操作，提交
- 用户控件

下载图片时防盗链 => 设置 Referer 请求头

懒(惰性)加载：
url 绑定到其他属性，需要时加载
`data-lazy-img`

深层抓取：
分析分页的规律，自动拼装 url，递归下载
与前一页数据相同时停止

Ajax 请求
JSP
找出 URL 再次请求

</details>

<details>
<summary><b>log日志</b></summary>

**_log4net_**
log4 配置文件：
log4net.cfg.xml
配置

```csharp
  static Logger()
  {
      XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDo
      ILog log = LogManager.GetLogger(typeof(Logger));
      log.Info("初始化Log4net模块");
  }
```

构造函数

```csharp
public Logger(Type type)
{
logger = LogManager.GetLogger(type);
}
```

实现

```csharp
public void Error(string msg, Exception ex)
{
Console.WriteLine(msg);
logger.Error(msg, ex);
}
```

外部调用

```csharp
static Logger logger = new Logger(typeof(类名));
logger.Error();
```

</details>

<details>
<summary><b>依赖注入</b></summary>

DI
控制反转 IOC
将传统的控制倒转，只要声明就可以用
DI 是 IOC 思想的一种实现

IOC 两种实现方式：

1. 服务定位器 (自己拿
2. 依赖注入 (声明了就可以用

组成:

- 服务 service
  通过框架需要使用的对象
- 注册服务
  使用之前需要事先注册服务
- 服务容器
  管理注册的服务
- 查询服务
  创建对象、关联对象
- 对象生命周期
  `Transient`(瞬态) 每次一个新的(慎用)
  `Scoped`(范围) 一定范围(由状态，scope 控制、运行在同一个线程中)
  `Singeton`(单例) 唯一对象(类无状态)
  长周期中不要使用短周期
- 服务类型(sevice type) 最好是接口
- 实现类型(implementation type)

```csharp
ServiceCollection services = new ServiceCollection();
services.AddTransient<TestServiceImpl>();				//AddSingeton()
using(ServiceProvider sp = services.BuildServiceProvider())
{
		ITestSerivceImpl service = ap.GetService<TestServiceImpl>();
		...
}
        //出了这个范围scope失效
		using(IServiceScope scope = sp.CreateScope())
		{
				//在scope中获取相关对象，scope.ServiceProvider
				scope.ServiceProvider.GetService();
		}
```

不用自己创建对象，服务自动创建
注册服务不需要知道具体类

有多个类实现服务接口，尽量用`GetServices`<>()
如果只获取一个则以最后一个注册的为准

依赖注入有“传染性”
容器自动创建所有依赖的对象

> Net 中默认构造函数注入
> Spring 属性注入

可覆盖的配置读取器
存在集群服务器，逐级 override
遍历有序服务集合，逐一覆盖作为新值

```csharp
//发送邮件同时记录日志
ServiceCollection services = new ServiceCollection();
services.AddScoped<IConfigService, EnvVarConfigProvider>();
services.AddScoped(typeof(IConfigService), s => new ConfigService { Path = @"./../../../appsettings.json" });
//services.AddScoped<ILogProvider, ConsoleLogProvider>();
services.AddConsoleLog();
services.AddScoped<IMailService, MailService>();

using (ServiceProvider sp = services.BuildServiceProvider())
{
    var mailServ = sp.GetRequiredService<IMailService>();
    mailServ.Send("hello", "fdsa,rewqfsda.", "41254@gs.fawg");
    using(var scope = sp.CreateScope())
    {
        scope.ServiceProvider.GetRequireService<IMailService>();
    }
}
```
</details>

<details>
<summary><b>配置系统</b></summary>

NuGet引入：
`Microsoft.Extensions.Configuration`
`Microsoft.Extensions.Configuration.Json`
按类读取
`Microsoft.Extensions.Configuration.Binder`

```csharp
ConfigurationBuilder configBuilder= new ConfigurationBuilder();
//1：是否必须
//2：是否重新加载配置
configBuilder.AddJsonFile(@"appsettings.json", optional:false, reloadOnChange:false);
IConfigurationRoot configRoot = configBuilder.Build();
string name = configRoot["name"];
string address = configRoot.GetSection("proxy:address").Value;
Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();
```

`
class Proxy
{
    public string ServerHost { get; set; }
    public int Port { get; set; }
    public string Address { get; set; }
}
`
</details>
