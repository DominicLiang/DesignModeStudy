using System;

namespace _18_桥接模式
{
    internal class Program
    {
        /// <summary>
        ///     功能基类
        /// </summary>
        abstract class Implementor
        {
            public abstract void Operation();
        }

        /// <summary>
        ///     具体功能类
        /// </summary>
        private class ConcreteImplementorA : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("具体实现A的方法执行");
            }
        }

        private class ConcreteImplementorB : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("具体实现B的方法执行");
            }
        }

        /// <summary>
        ///     调用基类
        /// </summary>
        abstract class Abstraction
        {
            protected Implementor implementor;

            public void SetImplementor(Implementor implementor)
            {
                this.implementor = implementor;
            }

            public abstract void Operation();
        }

        /// <summary>
        ///     调用者类
        /// </summary>
        private class RefinedAbstractionA : Abstraction
        {
            public override void Operation()
            {
                implementor.Operation();
            }
        }

        private class RefinedAbstractionB : Abstraction
        {
            public override void Operation()
            {
                implementor.Operation();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Abstraction a = new RefinedAbstractionA();

            a.SetImplementor(new ConcreteImplementorA());
            a.Operation();

            a.SetImplementor(new ConcreteImplementorB());
            a.Operation();


            Abstraction b = new RefinedAbstractionB();

            b.SetImplementor(new ConcreteImplementorA());
            b.Operation();

            b.SetImplementor(new ConcreteImplementorB());
            b.Operation();

            Console.ReadKey();
        }
    }
}