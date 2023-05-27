using System;

namespace _17_单例模式
{
    /// <summary>
    ///     普通单例 多线程不安全 懒汉 被动实例化
    /// </summary>
    internal class Singleton1
    {
        public int i = 12;

        // 私有静态字段
        private static Singleton1 instance;

        /// <summary>
        ///     私有构造方法 使外界不能用new来创建实例
        /// </summary>
        private Singleton1()
        {
        }

        /// <summary>
        ///     获得此类实例的唯一方法 也可以用属性来写
        /// </summary>
        /// <returns></returns>
        public static Singleton1 GetInstance()
        {
            // 如果实例为空 new一个新实例 否则返回已有实例
            if (instance == null) instance = new Singleton1();

            return instance;
        }
    }

    /// <summary>
    ///     双重锁定单例 多线程使用 懒汉 被动实例化
    /// </summary>
    internal class Singleton2
    {
        private static Singleton2 instance;
        private static readonly object syncRoot = new object();

        private Singleton2()
        {
        }

        public static Singleton2 GetInstance()
        {
            if (instance == null)
                lock (syncRoot)
                {
                    if (instance == null) instance = new Singleton2();
                }

            return instance;
        }
    }

    /// <summary>
    ///     饿汉单例 主动实例化
    /// </summary>
    public sealed class Singleton3 // 公有密封类 sealed不能继承、不能重写
    {
        // 私有静态只读字段 类被加载就实例化
        private static readonly Singleton3 instance = new Singleton3();

        private Singleton3()
        {
        }

        public static Singleton3 GetInstance()
        {
            return instance;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Singleton3 s1 = Singleton3.GetInstance();
            Singleton3 s2 = Singleton3.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("两个对象时相同实例");
            }

            Console.ReadKey();
        }
    }
}