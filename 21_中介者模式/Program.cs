using System;

namespace _21_中介者模式
{
    internal class Program
    {
        /// <summary>
        ///     中介基类
        /// </summary>
        abstract class Mediator
        {
            public abstract void Send(string message, Colleague colleague);
        }

        /// <summary>
        ///     具体中介类
        /// </summary>
        private class ConcreteMediator : Mediator
        {
            private ConcreteColleague1 colleague1;
            private ConcreteColleague2 colleague2;

            // 获得所有同事类
            public ConcreteColleague1 Colleague1
            {
                set => colleague1 = value;
            }

            public ConcreteColleague2 Colleague2
            {
                set => colleague2 = value;
            }

            /// <summary>
            ///     处理同事类收发逻辑
            /// </summary>
            /// <param name="message">信息</param>
            /// <param name="colleague">发送者</param>
            public override void Send(string message, Colleague colleague)
            {
                // 如发送者是同事1 调用同事2的对应方法，反之调用同事1的对应方法
                if (colleague == colleague1)
                    colleague2.Notify(message);
                else
                    colleague1.Notify(message);
            }
        }

        /// <summary>
        ///     同事基类
        /// </summary>
        abstract class Colleague
        {
            protected readonly Mediator mediator;

            // 获得中介
            public Colleague(Mediator mediator)
            {
                this.mediator = mediator;
            }
        }

        /// <summary>
        ///     具体同事类
        /// </summary>
        private class ConcreteColleague1 : Colleague
        {
            public ConcreteColleague1(Mediator mediator) : base(mediator)
            {
            }

            /// <summary>
            ///     发送方法
            /// </summary>
            /// <param name="message"></param>
            public void Send(string message)
            {
                // 使用中介的发送方法 传信息和自己
                mediator.Send(message, this);
            }

            /// <summary>
            ///     对应方法 这里是显示信息
            /// </summary>
            /// <param name="message"></param>
            public void Notify(string message)
            {
                Console.WriteLine("同事1 得到信息：" + message);
            }
        }

        private class ConcreteColleague2 : Colleague
        {
            public ConcreteColleague2(Mediator mediator) : base(mediator)
            {
            }

            public void Send(string message)
            {
                mediator.Send(message, this);
            }

            public void Notify(string message)
            {
                Console.WriteLine("同事2 得到信息：" + message);
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // 创建中介对象
            var m = new ConcreteMediator();

            // 创建所有同事
            var c1 = new ConcreteColleague1(m);
            var c2 = new ConcreteColleague2(m);

            // 为中介类加入同事
            m.Colleague1 = c1;
            m.Colleague2 = c2;

            // 发送消息
            c1.Send("吃过饭了吗？");
            c2.Send("没有呢，你打算请客？");

            Console.ReadKey();
        }
    }
}