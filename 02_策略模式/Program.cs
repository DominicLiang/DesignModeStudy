using System;

namespace _02_策略模式
{
    internal class Program
    {
        /// <summary>
        ///     所有算法的抽象基类
        /// </summary>
        abstract class Operation
        {
            // 提供子类格式的抽象方法
            public abstract void Oper();
        }

        /// <summary>
        ///     具体实现类
        /// </summary>
        private class OperationA : Operation
        {
            // 具体实现基类的方法
            public override void Oper()
            {
                Console.Write("算法A");
            }
        }

        /// <summary>
        ///     具体实现类
        /// </summary>
        private class OperationB : Operation
        {
            // 具体实现基类的方法
            public override void Oper()
            {
                Console.Write("算法B");
            }
        }

        /// <summary>
        ///     策略类
        /// </summary>
        private class Context
        {
            private readonly Operation _operation;

            /// <summary>
            ///     通过构造方法获得要使用的具体实现类
            /// </summary>
            /// <param name="operation">具体实现类</param>
            public Context(string type)
            {
                switch (type)
                {
                    case "A":
                        _operation = new OperationA();
                        break;
                    case "B":
                        _operation = new OperationB();
                        break;
                }
            }

            /// <summary>
            ///     Show方法里调用具体实现类的方法
            /// </summary>
            public void ShowOper()
            {
                _operation.Oper();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Context context;
            context = new Context("A");
            context.ShowOper();
            Console.ReadKey();
        }
    }
}