using System;

namespace _07_模版方法模式
{
    internal class Program
    {
        /// <summary>
        ///     模板类
        /// </summary>
        private class TestPaper
        {
            /// <summary>
            ///     定义一个骨架
            /// </summary>
            public void TestQuestion1()
            {
                Console.WriteLine("杨过得到，后来给了郭靖，练成倚天剑、屠龙刀的玄铁可能是（）");
                Console.WriteLine("A.球磨铸铁  B.马口铁  C.高速合金钢  D.碳素纤维\n");
                Console.WriteLine("答案：" + Answer1() + "\n\n");
            }

            /// <summary>
            ///     不同部分设置成虚方法供子类改写
            /// </summary>
            /// <returns></returns>
            protected virtual string Answer1()
            {
                return "";
            }

            public void TestQuestion2()
            {
                Console.WriteLine("杨过、程英、陆无双铲除了情花，造成（）");
                Console.WriteLine("A.是这种植物不再害人  B.是一种珍稀物种灭绝  C.破坏了那个生物圈的生态平衡  D.造成该地区沙漠化\n");
                Console.WriteLine("答案：" + Answer2() + "\n\n\n\n");
            }

            protected virtual string Answer2()
            {
                return "";
            }
        }

        /// <summary>
        ///     子类重写不同部分
        /// </summary>
        private class TestPaperA : TestPaper
        {
            protected override string Answer1()
            {
                return "B";
            }

            protected override string Answer2()
            {
                return "C";
            }
        }

        private class TestPaperB : TestPaper
        {
            protected override string Answer1()
            {
                return "C";
            }

            protected override string Answer2()
            {
                return "A";
            }
        }

        ///// <summary>
        /////     模版类
        ///// </summary>
        //abstract class AbstractClass
        //{
        //    // 供重写的虚方法
        //    public abstract void PrimitiveOperation1();
        //    public abstract void PrimitiveOperation2();

        //    /// <summary>
        //    ///     算法骨架
        //    /// </summary>
        //    public void TemplateMethod()
        //    {
        //        PrimitiveOperation1();
        //        PrimitiveOperation2();
        //        Console.WriteLine("");
        //    }
        //}

        ///// <summary>
        /////     子类
        ///// </summary>
        //private class ConcreteClassA : AbstractClass
        //{
        //    // 重写不同部分
        //    public override void PrimitiveOperation1()
        //    {
        //        Console.WriteLine("具体类A 方法1实现");
        //    }

        //    public override void PrimitiveOperation2()
        //    {
        //        Console.WriteLine("具体类A 方法2实现");
        //    }
        //}

        //private class ConcreteClassB : AbstractClass
        //{
        //    public override void PrimitiveOperation1()
        //    {
        //        Console.WriteLine("具体类B 方法1实现");
        //    }

        //    public override void PrimitiveOperation2()
        //    {
        //        Console.WriteLine("具体类B 方法2实现");
        //    }
        //}


        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //AbstractClass c;
            //// 以父类身份构造子类，并调用方法
            //c = new ConcreteClassA();
            //c.TemplateMethod();

            //c = new ConcreteClassB();
            //c.TemplateMethod();

            //Console.ReadKey();


            Console.WriteLine("学生A抄的试卷：\n");
            // 以父类身份构造子类，并调用方法
            TestPaper studentA = new TestPaperA();
            studentA.TestQuestion1();
            studentA.TestQuestion2();

            Console.WriteLine("学生B抄的试卷：\n");
            TestPaper studentB = new TestPaperB();
            studentB.TestQuestion1();
            studentB.TestQuestion2();

            Console.ReadKey();
        }
    }
}