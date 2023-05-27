using System;
using System.Collections.Generic;

namespace _19_命令模式
{
    internal class Program
    {
        /// <summary>
        ///     执行者类
        /// </summary>
        public class Barbecuer
        {
            public void BakeMutton()
            {
                Console.WriteLine("烤羊肉串！");
            }

            public void BakeChickenWing()
            {
                Console.WriteLine("烤鸡翅！");
            }
        }

        /// <summary>
        ///     命令基类
        /// </summary>
        public abstract class Command
        {
            // 需要通知的执行者 可多个
            protected Barbecuer receiver;

            public Command(Barbecuer receiver)
            {
                this.receiver = receiver;
            }

            public abstract void ExcuteCommand();
        }

        /// <summary>
        ///     具体命令类
        /// </summary>
        private class BakeMuttonCommand : Command
        {
            public BakeMuttonCommand(Barbecuer receiver) : base(receiver)
            {
            }

            // 通知执行者执行对应操作
            public override void ExcuteCommand()
            {
                receiver.BakeMutton();
            }
        }

        private class BakeChickenWingCommand : Command
        {
            public BakeChickenWingCommand(Barbecuer receiver) : base(receiver)
            {
            }

            public override void ExcuteCommand()
            {
                receiver.BakeChickenWing();
            }
        }

        /// <summary>
        ///     接待类
        /// </summary>
        public class Waiter
        {
            // 用于保存订单的列表
            private readonly IList<Command> orders = new List<Command>();

            /// <summary>
            ///     添加订单
            /// </summary>
            /// <param name="command">需要对应的具体命令</param>
            public void SetOrder(Command command)
            {
                if (command.ToString() == "_19_命令模式.Program+BakeChickenWingCommand") // 可否决无法实现的订单
                {
                    Console.WriteLine("服务员：鸡翅没有了，请点别的烧烤。");
                }
                else
                {
                    // 在列表添加订单
                    orders.Add(command);
                    // 日志
                    Console.WriteLine("增加订单：" + command + " 时间：" + DateTime.Now);
                }
            }

            /// <summary>
            ///     撤销订单
            /// </summary>
            /// <param name="command">需要对应的具体命令</param>
            public void CancelOrder(Command command)
            {
                // 在列表移除订单
                orders.Remove(command);
                // 日志
                Console.WriteLine("取消订单：" + command + " 时间：" + DateTime.Now);
            }

            /// <summary>
            ///     通知执行列表内所有订单
            /// </summary>
            public void Notify()
            {
                foreach (var command in orders) command.ExcuteCommand();
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // 实例化执行者 可多个不同类型
            var boy = new Barbecuer();

            // 注册具体命令 可以是不同的执行者
            Command bakeMuttonCommand1 = new BakeMuttonCommand(boy);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(boy);
            Command bakeChickenWingCommand = new BakeChickenWingCommand(boy);

            // 实例化接待
            var girl = new Waiter();

            // 加入订单
            girl.SetOrder(bakeMuttonCommand1);
            girl.SetOrder(bakeMuttonCommand2);
            girl.SetOrder(bakeChickenWingCommand);

            // 通知执行
            girl.Notify();

            Console.ReadKey();
        }
    }
}