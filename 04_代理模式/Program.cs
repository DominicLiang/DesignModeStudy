using System;

namespace _04_代理模式
{
    internal class Program
    {
        /// <summary>
        ///     格式接口（不写也是可以的）
        /// </summary>
        private interface ISubject
        {
            void Request();
        }

        /// <summary>
        ///     真实请求类
        /// </summary>
        private class RealSubject : ISubject
        {
            public void Request()
            {
                Console.Write("真实的请求");
            }
        }

        /// <summary>
        ///     代理类
        /// </summary>
        private class Proxy : ISubject
        {
            private RealSubject realSubject;

            /// <summary>
            ///     代理类中创建真实请求类的对象并调用方法，还可以作一些处理
            /// </summary>
            public void Request()
            {
                if (realSubject == null) realSubject = new RealSubject();
                realSubject.Request();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var proxy = new Proxy();
            proxy.Request();

            Console.ReadKey();
        }
    }
}