using System;
using System.Collections.Generic;

namespace _09_建造者模式
{
    internal class Program
    {
        /// <summary>
        ///     产品类
        /// </summary>
        private class Product
        {
            // 保存添加了的产品的列表，根据需要可以改成数组、字典、队列和栈等
            private readonly IList<string> parts = new List<string>();

            // 产品添加列表的方法
            public void Add(string part)
            {
                parts.Add(part);
            }

            // 遍历显示列表中的所有产品，也可以提供显示某些产品的方法
            public void Show()
            {
                Console.WriteLine("\n产品 创建----");
                foreach (var part in parts) Console.WriteLine(part);
            }
        }

        /// <summary>
        ///     建造者基类 提供格式 也可以省略
        /// </summary>
        abstract class Builder
        {
            public abstract void BuildPartA();
            public abstract void BuildPartB();
            public abstract Product GetResult();
        }

        /// <summary>
        ///     具体建造者类
        /// </summary>
        private class ConcreteBuilder1 : Builder
        {
            // 创建产品类的实例 新列表
            private readonly Product product = new Product();

            // 添加部件方法 供指挥者类使用
            public override void BuildPartA()
            {
                product.Add("部件A");
            }

            public override void BuildPartB()
            {
                product.Add("部件B");
            }

            // 返回这个产品类实例 供指挥者类使用
            public override Product GetResult()
            {
                return product;
            }
        }

        private class ConcreteBuilder2 : Builder
        {
            private readonly Product product = new Product();

            public override void BuildPartA()
            {
                product.Add("部件X");
            }

            public override void BuildPartB()
            {
                product.Add("部件Y");
            }

            public override Product GetResult()
            {
                return product;
            }
        }

        /// <summary>
        ///     指挥者类
        /// </summary>
        private class Director
        {
            public void Construct(Builder builder)
            {
                // 使用建造者类的添加部件方法 添加部件
                builder.BuildPartA();
                builder.BuildPartB();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // 创建指挥者类实例
            var director = new Director();

            // 创建建造者类实例
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // 为建造者类添加部件
            director.Construct(b1);

            // 得到添加好部件的产品类
            var p1 = b1.GetResult();

            // 最终显示产品
            p1.Show();

            director.Construct(b2);
            var p2 = b2.GetResult();
            p2.Show();

            Console.ReadKey();
        }
    }
}