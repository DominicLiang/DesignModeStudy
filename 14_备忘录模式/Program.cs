using System;

namespace _14_备忘录模式
{
    internal class Program
    {
        /// <summary>
        ///     需要保存信息的类
        /// </summary>
        private class Originator
        {
            // 需要保存的字段
            public string State { get; set; }

            /// <summary>
            ///     保存方法
            /// </summary>
            /// <returns></returns>
            public Memento CreateMemento()
            {
                // 新建备忘录 写入数据 并返回
                return new Memento(State);
            }

            /// <summary>
            ///     恢复方法
            /// </summary>
            /// <param name="memento"></param>
            public void SetMemento(Memento memento)
            {
                State = memento.State;
            }

            public void Show()
            {
                Console.WriteLine("State=" + State);
            }
        }

        /// <summary>
        ///     备忘录类 可以考虑用结构体
        /// </summary>
        private class Memento
        {
            public string State { get; }

            /// <summary>
            ///     构造方法写入要保存的字段
            /// </summary>
            /// <param name="state"></param>
            public Memento(string state)
            {
                State = state;
            }
        }


        /// <summary>
        ///     备忘录管理类
        /// </summary>
        private class Caretaker
        {
            // 扩展 使用列表保存备忘录 可以有多个备忘录
            public Memento Memento { get; set; }
        }

        private static void Main(string[] args)
        {
            var org = new Originator();
            org.State = "On";
            org.Show();

            // 创建备忘录管理类
            var c = new Caretaker();
            // 把要保存信息的类返回的备忘录写入管理类
            c.Memento = org.CreateMemento();

            org.State = "Off";
            org.Show();

            // 要保存信息的类调用恢复方法重写写入之前保存的信息
            org.SetMemento(c.Memento);
            org.Show();

            Console.ReadKey();
        }
    }
}