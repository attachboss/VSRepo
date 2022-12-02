using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common
{
    //懒汉式单例
    public class Singleton
    {
        //全局唯一静态
        private static volatile Singleton _instance = null;
        private static readonly object _lock = new object();

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private Singleton()
        {

        }

        public static Singleton CreateInstance()
        {
            //已经创建好之后就不用进锁
            if (_instance == null)
            {
                lock (_lock)
                {
                    //保证第一次创建时只有一个线程
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }



    //饿汉式单例
    public class Singleton2
    {

        private static volatile Singleton2 _instance = null;

        static Singleton2()
        {
            _instance = new Singleton2();
        }

        public static Singleton2 CreateInstance()
        {
            return _instance;
        }

    }
}
