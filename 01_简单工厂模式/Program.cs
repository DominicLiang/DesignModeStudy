using System;

namespace _01_简单工厂模式
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
    ///     产品类 乘法
    /// </summary>
    internal class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }

    /// <summary>
    ///     产品类 除法
    /// </summary>
    internal class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB == 0) throw new Exception("除数不能为0。");
            result = NumberA / NumberB;
            return result;
        }
    }

    /// <summary>
    ///     简单工厂
    /// </summary>
    public class OperationFactory
    {
        // 静态方法，可以使用类名调用（不用创建类的对象）
        public static Operation CreateOperate(string operate)
        {
            if (operate != "+" && operate != "-" && operate != "*" && operate != "/")
                throw new Exception("请输入正确的算术符号。");

            // 基类声明的对象可以使用子类来构造
            Operation oper = null;

            // 通过switch选择不同的子类，来达成生产不同的产品
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;

                case "-":
                    oper = new OperationSub();
                    break;

                case "*":
                    oper = new OperationMul();
                    break;

                case "/":
                    oper = new OperationDiv();
                    break;
            }

            return oper;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Operation oper;
            oper = OperationFactory.CreateOperate("+");
            oper.NumberA = 1;
            oper.NumberB = 2;
            var result = oper.GetResult();
            Console.Write(result);
            Console.ReadKey();
        }
    }
}