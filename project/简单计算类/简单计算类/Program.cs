using System;

namespace 简单计算类
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("简单计算类的封装和使用\n");
            Console.WriteLine("请选择功能：\n1.计算两点间距离 \n2.计算方位角 \n3.度分秒转化为弧度制\n");
            string option = Console.ReadLine();
            #region distance
            if (option == "1")
            {
                Console.WriteLine("请输入xA:");
                double x1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入yA:");
                double y1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入xB:");
                double x2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入yB:");
                double y2 = Convert.ToDouble(Console.ReadLine());
                Location l = new Location(x1, y1, x1, y2);
                double distance = l.CalculateDistance();//调用Location类的CalculateDistance方法计算两点间的距离
                Console.WriteLine("A与B间的距离为：{0:0.0000}", distance);//输出格式为小数点后四位
            }
            #endregion
            #region azimuth
            else if (option == "2")
            {
                Console.WriteLine("请输入xA:");
                double x1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入yA:");
                double y1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入xB:");
                double x2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入yB:");
                double y2 = Convert.ToDouble(Console.ReadLine());
                Location l = new Location(x1, y1, x2, y2);
                double angle = l.CalculateAzimuth();
                if (angle > 0)//直线AB的斜率为正
                {
                    angle = Math.PI / 2 - angle;
                }
                else if (angle < 0)//直线AB的斜率为负
                {
                    angle = angle * -1 + Math.PI / 2;
                }
                Console.WriteLine("直线AB的坐标方位角(弧度制)为：{0:0.000}", angle);

            }
            #endregion
            #region radian
            else if (option == "3")
            {
                Console.WriteLine("请输入要转化的角度：");
                string angle = Console.ReadLine();
                if (angle.Contains("."))//判断角度中是否含有小数
                {
                    double radian = Convert.ToDouble(angle);
                    radian = radian * Math.PI / 180.0;
                    Console.WriteLine("转化为弧度制为：{0:0.000}", radian);
                }
                else
                {
                    int t = Convert.ToInt32(angle);
                    double radian = t;
                    radian = radian * Math.PI / 180.0;
                    Console.WriteLine("转化为弧度制为：{0:0.000}", radian);
                }
            }
            #endregion

            else//功能选择错误的情况
            {
                Console.WriteLine("\a请正确输入数字！");
            }
            Console.ReadKey();
        }
    }
}