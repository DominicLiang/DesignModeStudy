using System;

namespace _13_适配器模式
{
    internal class Program
    {
        /// <summary>
        ///     接口基类
        /// </summary>
        private class Target
        {
            public virtual void Request()
            {
                Console.WriteLine("普通请求！");
            }
        }

        /// <summary>
        ///     需要使用接口的类
        /// </summary>
        private class Adaptee
        {
            // 由于没继承基类接口，而且方法名也不同，所以不能通过基类来调用
            public void SpecificRequest()
            {
                Console.WriteLine("特殊请求！");
            }
        }

        /// <summary>
        ///     适配器类
        /// </summary>
        private class Adapter : Target
        {
            private readonly Adaptee adaptee = new Adaptee();

            /// <summary>
            ///     在适配器重写基类的请求方法
            ///     调用要使用的类的方法
            ///     这样就能通过基类来调用不同接口的类的方法
            /// </summary>
            public override void Request()
            {
                adaptee.SpecificRequest();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Target target = new Adapter();
            target.Request();

            Console.ReadKey();
        }
    }
}