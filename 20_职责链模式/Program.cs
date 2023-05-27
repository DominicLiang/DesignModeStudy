using System;

namespace _20_职责链模式
{
    internal class Program
    {
        private class Request
        {
            public string RequestType { get; set; }

            public string RequestContent { get; set; }

            public int Number { get; set; }
        }

        /// <summary>
        ///     管理者基类
        /// </summary>
        abstract class Manager
        {
            protected readonly string name;
            protected Manager superior;

            public Manager(string name)
            {
                this.name = name;
            }

            // 设置上级
            public void SetSuperior(Manager superior)
            {
                this.superior = superior;
            }

            public abstract void RequestApplications(Request request);
        }

        /// <summary>
        ///     具体管理者类 经理
        /// </summary>
        private class CommonManager : Manager
        {
            public CommonManager(string name) : base(name)
            {
            }

            /// <summary>
            ///     处理方法
            /// </summary>
            /// <param name="request"></param>
            public override void RequestApplications(Request request)
            {
                if (request.RequestType == "请假" && request.Number <= 2)
                    // 满足权限执行处理
                    Console.WriteLine("{0}:\n{1} 数量{2} 被批准\n", name, request.RequestContent, request.Number);
                else
                    // 不满足权限调用上级的处理方法
                    superior?.RequestApplications(request);
            }
        }

        private class Majordom : Manager
        {
            public Majordom(string name) : base(name)
            {
            }

            public override void RequestApplications(Request request)
            {
                if (request.RequestType == "请假" && request.Number <= 5)
                    Console.WriteLine("{0}:\n{1} 数量{2} 被批准\n", name, request.RequestContent, request.Number);
                else
                    superior?.RequestApplications(request);
            }
        }

        private class GeneralManager : Manager
        {
            public GeneralManager(string name) : base(name)
            {
            }

            public override void RequestApplications(Request request)
            {
                if (request.RequestType == "请假")
                    Console.WriteLine("{0}:\n{1} 数量{2} 被批准\n", name, request.RequestContent, request.Number);
                else if (request.RequestType == "加薪" && request.Number <= 500)
                    Console.WriteLine("{0}:\n{1} 数量{2} 被批准\n", name, request.RequestContent, request.Number);
                else if (request.RequestType == "加薪" && request.Number > 500)
                    Console.WriteLine("{0}:\n{1} 数量{2} 再说吧\n", name, request.RequestContent, request.Number);
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // 实例化各管理者
            var jingli = new CommonManager("经理");
            var zongjian = new Majordom("总监");
            var zhongjingli = new GeneralManager("总经理");

            // 为管理者设置上级关系
            jingli.SetSuperior(zongjian);
            zongjian.SetSuperior(zhongjingli);

            var request = new Request();
            request.RequestType = "请假";
            request.RequestContent = "小菜请假";
            request.Number = 1;
            jingli.RequestApplications(request);

            var request2 = new Request();
            request2.RequestType = "请假";
            request2.RequestContent = "小菜请长假";
            request2.Number = 4;
            jingli.RequestApplications(request2);

            var request3 = new Request();
            request3.RequestType = "加薪";
            request3.RequestContent = "小菜请求加薪";
            request3.Number = 500;
            jingli.RequestApplications(request3);

            var request4 = new Request();
            request4.RequestType = "加薪";
            request4.RequestContent = "小菜请求大幅加薪";
            request4.Number = 1000;
            jingli.RequestApplications(request4);

            Console.ReadKey();
        }
    }
}