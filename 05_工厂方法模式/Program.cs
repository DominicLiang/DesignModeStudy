using System;

namespace _05_工厂方法模式
{
    internal class Program
    {
        /// <summary>
        ///     产品基类
        /// </summary>
        public class Operation
        {
            // 基本变量
            public double NumberA { get; set; }
            public double NumberB { get; set; }

            // 虚方法供重写
            public virtual double GetResult()
            {
                double result = 0;
                return result;
            }
        }

        /// <summary>
        ///     产品类 加法
        /// </summary>
        internal class OperationAdd : Operation
        {
            public override double GetResult()
            {
                double result = 0;
                result = NumberA + NumberB;
                return result;
            }
        }

        /// <summary>
        ///     产品类 减法
        /// </summary>
        internal class OperationSub : Operation
        {
            public override double GetResult()
            {
                double result = 0;
                result = NumberA - NumberB;
                return result;
            }
        }

        /// <summary>
        ///     工厂接口
        /// </summary>
        private interface IFactory
        {
            Operation CreateOperation();
        }

        /// <summary>
        ///     加法工厂
        /// </summary>
        private class AddFactory : IFactory
        {
            public Operation CreateOperation()
            {
                return new OperationAdd();
            }
        }

        /// <summary>
        ///     减法工厂
        /// </summary>
        private class SubFactory : IFactory
        {
            public Operation CreateOperation()
            {

                return new OperationSub();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //先决定实例化哪一个工厂
            IFactory operFactory = new AddFactory();
            //然后实例化具体产品
            var oper = operFactory.CreateOperation();
            oper.NumberA = 1;
            oper.NumberB = 2;
            var result = oper.GetResult();

            Console.Write(result);
            Console.ReadKey();
        }
    }
}