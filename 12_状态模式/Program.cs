using System;

namespace _12_状态模式
{
    internal class Program
    {
        /// <summary>
        ///     状态基类或接口
        /// </summary>
        abstract class State
        {
            // 提供切换状态方法的格式
            public abstract void Handle(Context context);
        }

        /// <summary>
        ///     状态A
        /// </summary>
        private class ConcreteStateA : State
        {
            public ConcreteStateA()
            {
                Console.WriteLine("当前是状态A");
            }

            /// <summary>
            ///     切换状态B
            /// </summary>
            /// <param name="context"></param>
            public override void Handle(Context context)
            {
                // 更改状态控制类的状态
                // 可以加条件 比如按了什么键才切换
                context.State = new ConcreteStateB();
            }
        }

        private class ConcreteStateB : State
        {
            public ConcreteStateB()
            {
                Console.WriteLine("当前是状态B");
            }

            public override void Handle(Context context)
            {
                context.State = new ConcreteStateA();
            }
        }

        /// <summary>
        ///     状态控制类
        /// </summary>
        private class Context
        {
            public State State { get; set; }

            /// <summary>
            ///     设置初始状态
            /// </summary>
            /// <param name="state"></param>
            public Context(State state)
            {
                State = state;
            }

            /// <summary>
            ///     切换状态方法
            /// </summary>
            public void Request()
            {
                // 运行当前状态的切换方法
                // 参数为自身 供更改本类状态用
                State.Handle(this);
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var c = new Context(new ConcreteStateA());

            c.Request();
            c.Request();
            c.Request();
            c.Request();

            Console.ReadKey();
        }
    }
}