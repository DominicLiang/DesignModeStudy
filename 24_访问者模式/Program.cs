using System;
using System.Collections.Generic;

namespace _24_访问者模式
{
    internal class Program
    {
        /// <summary>
        ///     访问者基类
        /// </summary>
        abstract class Action
        {
            public abstract void GetManConclusion(Man concreteElementA);
            public abstract void GetWomanConclusion(Woman concreteElementB);
        }

        /// <summary>
        ///     具体访问者  可创造多种处理方法，但元素类型必须固定
        /// </summary>
        private class Success : Action
        {
            // 具体处理方法 所有类型同时处理
            public override void GetManConclusion(Man concreteElementA)
            {
                Console.WriteLine("{0}{1}时，背后多半有一个伟大的女人。", concreteElementA.GetType().Name, GetType().Name);
            }

            public override void GetWomanConclusion(Woman concreteElementB)
            {
                Console.WriteLine("{0}{1}时，背后大多有一个不成功的男人。", concreteElementB.GetType().Name, GetType().Name);
            }
        }

        private class Failing : Action
        {
            public override void GetManConclusion(Man concreteElementA)
            {
                Console.WriteLine("{0}{1}时，闷头喝酒，谁也不用劝。", concreteElementA.GetType().Name, GetType().Name);
            }

            public override void GetWomanConclusion(Woman concreteElementB)
            {
                Console.WriteLine("{0}{1}时，眼泪汪汪，谁也劝不了。", concreteElementB.GetType().Name, GetType().Name);
            }
        }

        private class Amativeness : Action
        {
            public override void GetManConclusion(Man concreteElementA)
            {
                Console.WriteLine("{0}{1}时，凡事不懂也要装懂。", concreteElementA.GetType().Name, GetType().Name);
            }

            public override void GetWomanConclusion(Woman concreteElementB)
            {
                Console.WriteLine("{0}{1}时，遇事懂也装作不懂。", concreteElementB.GetType().Name, GetType().Name);
            }
        }

        /// <summary>
        ///     元素基类
        /// </summary>
        abstract class Person
        {
            public abstract void Accept(Action visitor);
        }

        /// <summary>
        ///     具体元素
        /// </summary>
        private class Man : Person
        {
            // 使用访问者来处理 由对象结构类调用并提供访问者
            public override void Accept(Action visitor)
            {
                visitor.GetManConclusion(this);
            }
        }

        private class Woman : Person
        {
            public override void Accept(Action visitor)
            {
                visitor.GetWomanConclusion(this);
            }
        }

        /// <summary>
        ///     对象结构类
        /// </summary>
        private class ObjectStructure
        {
            // 保存所有子类元素 供一次性调用
            private readonly IList<Person> elements = new List<Person>();

            // 加入元素 可同类型多个 但类型固定
            public void Attach(Person element)
            {
                elements.Add(element);
            }

            // 移除元素
            public void Detach(Person element)
            {
                elements.Remove(element);
            }

            // 执行所有元素的访问者操作
            public void Display(Action visitor)
            {
                foreach (var element in elements) element.Accept(visitor);
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // 创建对象结构类实例并加入元素
            var o = new ObjectStructure();
            o.Attach(new Man());
            o.Attach(new Woman());

            // 为对象结构类实例设置访问者并执行
            var v1 = new Success();
            o.Display(v1);

            var v2 = new Failing();
            o.Display(v2);

            var v3 = new Amativeness();
            o.Display(v3);

            Console.ReadKey();
        }
    }
}