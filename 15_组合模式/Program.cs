using System;
using System.Collections.Generic;

namespace _15_组合模式
{
    internal class Program
    {
        /// <summary>
        ///     基类格式
        /// </summary>
        abstract class Company
        {
            protected readonly string name;

            public Company(string name)
            {
                this.name = name;
            }

            public abstract void Add(Company c);
            public abstract void Remove(Company c);
            public abstract void Display(int depth);
            public abstract void LineOfDuty();
        }

        /// <summary>
        ///     节点类 可多种类
        /// </summary>
        private class ConcreteCompany : Company
        {
            // 列表保存下属节点
            private readonly List<Company> Children = new List<Company>();

            public ConcreteCompany(string name) : base(name)
            {
            }

            // 加入列表
            public override void Add(Company c)
            {
                Children.Add(c);
            }

            // 列表里移除
            public override void Remove(Company c)
            {
                Children.Remove(c);
            }

            /// <summary>
            ///     功能方法
            /// </summary>
            /// <param name="depth"></param>
            public override void Display(int depth)
            {
                // 遍历使用下属所有节点的功能方法
                Console.WriteLine(new string('-', depth) + name);
                foreach (var company in Children) company.Display(depth + 2);
            }

            public override void LineOfDuty()
            {
                foreach (var company in Children) company.LineOfDuty();
            }
        }

        /// <summary>
        ///     末节点类 可多种类
        /// </summary>
        private class HRDepartment : Company
        {
            public HRDepartment(string name) : base(name)
            {
            }

            public override void Add(Company c)
            {
            }

            public override void Remove(Company c)
            {
            }

            /// <summary>
            ///     具体功能
            /// </summary>
            /// <param name="depth"></param>
            public override void Display(int depth)
            {
                Console.WriteLine(new string('-', depth) + name);
            }

            public override void LineOfDuty()
            {
                Console.WriteLine("{0} 员工招聘培训管理", name);
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var root = new ConcreteCompany("北京总公司");
            root.Add(new HRDepartment("总公司人力资源部"));

            var comp = new ConcreteCompany("上海华东分公司");
            comp.Add(new HRDepartment("华东分公司人力资源部"));
            root.Add(comp);

            var comp1 = new ConcreteCompany("南京办事处");
            comp1.Add(new HRDepartment("南京办事处人力资源部"));
            comp.Add(comp1);

            var comp2 = new ConcreteCompany("杭州办事处");
            comp2.Add(new HRDepartment("杭州办事处人力资源部"));
            comp.Add(comp2);

            root.Display(0);
            root.LineOfDuty();

            Console.ReadKey();
        }
    }
}