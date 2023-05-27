using System;

namespace _08_外观模式
{
    internal class Program
    {
        /// <summary>
        ///     子系统
        /// </summary>
        private class SubSystemOne
        {
            public void MethodOne()
            {
                Console.WriteLine("子系统方法一");
            }
        }

        private class SubSystemTwo
        {
            public void MethodTwo()
            {
                Console.WriteLine("子系统方法二");
            }
        }

        /// <summary>
        ///     外观类
        /// </summary>
        private class Facade
        {
            // 生成子系统实例
            private readonly SubSystemOne one;
            private readonly SubSystemTwo two;

            public Facade()
            {
                one = new SubSystemOne();
                two = new SubSystemTwo();
            }

            // 提供给使用者的一致接口
            public void MethodA()
            {
                Console.WriteLine("\n方法组 A（）----");
                one.MethodOne();
                two.MethodTwo();
                two.MethodTwo();
                two.MethodTwo();
            }

            public void MethodB()
            {
                Console.WriteLine("\n方法组 B（）----");
                two.MethodTwo();
                one.MethodOne();
                two.MethodTwo();
                one.MethodOne();
                one.MethodOne();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            Console.ReadKey();
        }
    }
}