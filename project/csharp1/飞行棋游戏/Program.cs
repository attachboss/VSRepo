using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//步骤：
//1.画游戏头
//2.初始化地图（加载地图所需要的资源）-> int数组中的数字变成控制台中显示的特殊字符串的过程
//3.画地图
//4.玩游戏（逻辑过程）





//游戏规则：
//如果玩家A踩到了玩家B，玩家B退6格
//踩到了地雷，退6格
//踩到了时空隧道，进十格
//踩到了幸运方块，选择：{1.交换位置        2.轰炸对方 使对方退6格}
//踩到了暂停     暂停一回合
//踩到了方块     无事发生





//初始化地图：
//Map[i]==0 ->  画方块□
//Map[i]==1 ->  画幸运方块☆
//Map[i]==2 ->  画地雷※
//Map[i]==3 ->  画暂停▲
//Map[i]==4 ->  画时空隧道⊕





//固定方块数组：
//int[] luckyBlock={6,23,44,55,69,83};//幸运方块
//int[] landMine={5,13,17,33,38,50,64,80,94}//地雷
//int[] pauseBlock={9,27,60,93};//暂停
//int[] timeTunnel={20,25,45,63,72,88,90};//时空隧道





namespace 飞行棋游戏
{
    class Program
    {
        //使用静态字段来模拟数组
        public static int[] _Map = new int[100 + 6];

        //声明一个静态数组储存玩家的坐标
        public static int[] _playerPosition = new int[2];

        //储存玩家姓名
        public static string[] _playerName = new string[2];

        //监测暂停情况
        public static bool Flag = true;

        //监测结束情况
        public static bool end = false;




        static void Main(string[] args)
        {
            GameStartShow();
            #region 输入玩家姓名
            //系统字体使用Cyan（青色）
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("请输入玩家1的姓名：");
            _playerName[0] = Console.ReadLine();
            while (_playerName[0] == "")
            {
                Console.WriteLine("姓名不能为空，请重新输入！");
                _playerName[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家2的姓名：");
            _playerName[1] = Console.ReadLine();
            while (_playerName[1] == "" || _playerName[1] == _playerName[0])
            {
                if (_playerName[1] == "")
                {
                    Console.WriteLine("姓名不能为空，请重新输入！");
                    _playerName[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家1的姓名不能玩家2的姓名相同，请重新输入：");
                    _playerName[1] = Console.ReadLine();
                }

            }
            #endregion
            Console.Clear();//清屏
            GameStartShow();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}的角色用A表示", _playerName[0]);
            Console.WriteLine("{0}的角色用B表示", _playerName[1]);
            InitialMap();
            DrawMap();

            //开始游戏
            int i = 0, j = 1;
            while (_playerPosition[i] < 99 && _playerPosition[j] < 99)
            {
                PlayGame(i, j);
                if (end == true)
                {
                    break;
                }
                i = i ^ j;
                j = j ^ i;
                i = i ^ j;
                if (Flag == false)
                {
                    PlayGame(i, j);
                    Flag = true;
                }
            }



            Console.ReadKey();
        }

        /// <summary>
        /// 玩游戏
        /// </summary>
        /// <param name="i">调用此时进行游戏的玩家</param>
        /// <param name="j">下个回合该进行游戏的玩家</param>
        private static void PlayGame(int i, int j)
        {
            Random r = new Random();
            int rNum = r.Next(1, 1 + 6);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}按任意键开始掷骰子", _playerName[i]);
            Console.ReadKey(true);
            Console.WriteLine("{0}掷出了{1}", _playerName[i], rNum);
            Console.ReadKey(true);
            Console.WriteLine("按任意键开始移动");
            Console.ReadKey(true);
            //玩家1移动后有6种情况：
            //1.玩家1踩到了玩家2
            //2.踩到方块
            //3.踩到幸运方块
            //4.踩到了地雷
            //5.踩到暂停
            //6.踩到时空隧道
            if (_playerPosition[i] + rNum == _playerPosition[j])
            {
                _playerPosition[i] += rNum;
                RemakePosition(i);
                Console.WriteLine("{0}踩到了{1}，{2}退6格", _playerName[i], _playerName[j], _playerName[j]);
                _playerPosition[j] -= 6;
                RemakePosition(j);

                Console.ReadKey(true);
            }
            else if (_playerPosition[i] + rNum >= 99 || _playerPosition[j] + rNum >= 99)
            {
                Winner(i, j, rNum);
                end = true;
                return;
            }
            else //关卡
            {
                switch (_Map[_playerPosition[i] + rNum])
                {
                    case 0:
                        Console.WriteLine("{0}前进了{1}格", _playerName[i], rNum);
                        _playerPosition[i] += rNum;
                        RemakePosition(i);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        _playerPosition[i] += rNum;
                        RemakePosition(i);
                        Console.WriteLine("{0}踩到了幸运方块，请选择\n1--交换位置\n2--轰炸对方", _playerName[i]);
                        while (true)
                        {
                            string input = Console.ReadLine();
                            if (input == "1")
                            {
                                Console.WriteLine("{0}选择与{1}交换位置", _playerName[i], _playerName[j]);
                                Console.ReadKey(true);
                                int temp = _playerPosition[i];
                                _playerPosition[i] = _playerPosition[j];
                                _playerPosition[j] = temp;
                                Console.WriteLine("交换完成，按任意键继续");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("{0}选择轰炸{1}", _playerName[i], _playerName[j]);
                                Console.WriteLine("{0}后退6格，按任意键继续", _playerName[j]);
                                _playerPosition[j] -= 6;
                                RemakePosition(j);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("输入有误，请重新输入！");
                                Console.ReadKey(true);
                            }
                        }//循环结束
                        break;
                    case 2:
                        Console.WriteLine("{0}踩到了地雷，后退6格", _playerName[i]);
                        _playerPosition[i] -= 6;
                        RemakePosition(i);
                        Console.WriteLine("按任意键继续");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("{0}暂停一回合", _playerName[i]);
                        Flag = false;
                        Console.WriteLine("按任意键继续");
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("{0}遇到了时空隧道，前进10格", _playerName[i]);
                        _playerPosition[i] += 10;
                        RemakePosition(i);
                        Console.WriteLine("按任意键继续");
                        Console.ReadKey(true);
                        break;
                }//switch结尾
            }//else结尾
            Console.Clear();
            DrawMap();
        }//PlayGame结束

        /// <summary>
        /// 画游戏头
        /// </summary>
        public static void GameStartShow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***0804飞行棋游戏v0.1***");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("************************");
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitialMap()
        {
            int[] luckyBlock = { 6, 23, 44, 55, 69, 83 };//幸运方块
            for (int i = 0; i < luckyBlock.Length; i++)
            {
                int index = luckyBlock[i];
                _Map[index] = 1;
            }

            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷
            for (int i = 0; i < landMine.Length; i++)
            {
                int index = landMine[i];
                _Map[index] = 2;
            }

            int[] pauseBlock = { 9, 27, 60, 93 };//暂停
            for (int i = 0; i < pauseBlock.Length; i++)
            {
                int index = pauseBlock[i];
                _Map[index] = 3;
            }

            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                int index = timeTunnel[i];
                _Map[index] = 4;
            }
        }

        /// <summary>
        /// 画地图结构
        /// </summary>
        public static void DrawMap()
        {
            Console.WriteLine("图例： 幸运方块:☆  地雷:※  暂停:▲  时空隧道:⊕");
            #region 第一行
            //第一行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            #endregion
            #region 第一列
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }
            #endregion
            #region 第二行
            for (int i = 64; i > 34; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            #endregion
            #region 第二列
            for (int i = 65; i < 70; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion
            #region 第三行
            for (int i = 70; i < 100; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            #endregion

        }//DrawMap结尾

        /// <summary>
        /// 画地图中抽象出的一个方法
        /// </summary>
        /// <param name="i"></param>
        public static string DrawStringMap(int i)
        {
            string pathStr = "";
            if (_playerPosition[0] == _playerPosition[1] && _playerPosition[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                pathStr = "∥";
            }
            else if (_playerPosition[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                pathStr = "A";
            }
            else if (_playerPosition[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                pathStr = "B";
            }
            else
            {
                switch (_Map[i])
                {
                    case 0:
                        Console.ResetColor();
                        pathStr = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        pathStr = "☆";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        pathStr = "※";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        pathStr = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        pathStr = "⊕";
                        break;
                }
            }
            return pathStr;
        }//DrawStringMap结尾

        /// <summary>
        /// 当玩家位置改变时调用
        /// </summary>
        /// <param name="num">玩家[]</param>
        public static void RemakePosition(int num)
        {
            if (_playerPosition[num] < 0)
            {
                Console.WriteLine("{0}回到起点", _playerName[num]);
                _playerPosition[num] = 0;
            }
            if (_playerPosition[num] > 99)
            {
                _playerPosition[num] = 99;
            }
        }//RemakePosition结束

        /// <summary>
        /// 胜利
        /// </summary>
        /// <param name="i">玩家i</param>
        /// <param name="j">玩家j</param>
        public static void Winner(int i, int j, int rNum)
        {
            if (_playerPosition[i] + rNum >= 99)
            {
                Console.Clear();
                Console.WriteLine("\a{0}无耻地赢了", _playerName[i]);
            }
            else if (_playerPosition[j] + rNum >= 99)
            {
                Console.Clear();
                Console.WriteLine("\a{0}无耻地赢了", _playerName[j]);
            }
        }

    }//类结尾
}
