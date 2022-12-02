using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsForm11._11
{
    public partial class Socket : Form
    {

        /*****************************************************
        由于未知原因 Socket类的方法无法在窗体应用程序中调用 
         排除没有using引用的情况
         
         
         
        */
        
        Socket socketSend;
        public Socket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个负责监听的Socket
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //创建IP地址和端口号对象
            IPAddress ip = IPAddress.Any;
            IPEndPoint point = new IPEndPoint(ip, 50000);
            //让负责监听的Socket绑定IP地址和端口号
            socketWatch.Bind(point);
            //设置监听队列
            socketWatch.Listen(10);
            //接受客户端的连接

            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketWatch);


            textBox3.Text = socketSend.RemoteEndPoint.Tostring();//获取连接终端的ip地址
        }

        private void Socket_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 
        /// </summary>
        void Listen(object socket)
        {
            Socket socketWatch = socket as Socket;
            while (true)
            {
                Socket socketSend = socketWatch.Accept();
                byte[] buffer = new byte[1024 * 1024 * 2];
                //(int r)返回实际接受到的有效字节数
                int r = socketSend.Receive(buffer);
                string str = Encoding.UTF8.GetString(buffer, 0, r);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //创建负责通信的Socket
            socketSend = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPAddress ip=IPAddress.Parse(textBox1.Text);
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(textBox2.Text));
            //获得要远程连接的服务器应用程序的IP地址和端口号
            socketSend.Connect(point);
            textBox3.Text = "连接成功！";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = textBox4.Text;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message);
            socketSend.Send(buffer);
     
        }
    }
}
