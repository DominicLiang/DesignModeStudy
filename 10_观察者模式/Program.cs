using System;

namespace _10_观察者模式
{
    internal class Program
    {
        /// <summary>
        ///     被观察者接口
        /// </summary>
        private interface Subject
        {
            // 接口所定义的字段和方法可以通过接口实例来调用
            // 非接口定义的字段和方法不能通过接口实例来调用
            string SubjectState { get; set; }
            void Notify();
        }

        /// <summary>
        ///     观察者类
        /// </summary>
        private class StockObserver
        {
            private readonly string name;
            private readonly Subject sub;

            /// <summary>
            ///     构造方法获得观察者的接口实例
            /// </summary>
            /// <param name="name"></param>
            /// <param name="sub">这里参数写接口类型 可以传实现了该接口的类的实例</param>
            public StockObserver(string name, Subject sub)
            {
                this.name = name;
                this.sub = sub;
            }




            public void CloseStockMarket()
            {
                Console.WriteLine("{0} {1}关闭股票行情，继续工作！", sub.SubjectState, name);
            }
        }

        private class NBAObserver
        {
            private readonly string name;
            private readonly Subject sub;

            public NBAObserver(string name, Subject sub)
            {
                this.name = name;
                this.sub = sub;
            }

            public void CloseNBADirectSeeding()
            {
                Console.WriteLine("{0} {1}关闭NBA直播，继续工作！", sub.SubjectState, name);
            }
        }

        /// <summary>
        ///     被观察者类
        /// </summary>
        public class Boss : Subject
        {
            // 定义委托类型 这里是一个无返回值、无参数的委托 类型名自定
            // 委托其实是一个类
            public delegate void NotifyDelegate();

            // 声明委托 就是说创建这个委托类的实例
            // 声明和定义的访问修饰符需一致
            // 声明event使这个实例不能在本类外部调用
            // 如没声明event，可以在外部通过Boss boss=new Boss(); bossl.Show();来调用
            public event NotifyDelegate Show;

            public string SubjectState { get; set; }

            /// <summary>
            ///     供外部调用的方法
            /// </summary>
            public void Notify()
            {
                // 如果Show不等于空，调用委托
                Show?.Invoke();
                // Show();   <=另一种调用委托的方法
            }
        }


        private static void Main(string[] args)
        {
            var huhansan = new Boss();

            var tongshi1 = new StockObserver("看股票的同事", huhansan);
            var tongshi2 = new NBAObserver("看NBA的同事", huhansan);

            // 为委托添加要调用的方法
            huhansan.Show += tongshi1.CloseStockMarket;
            huhansan.Show += tongshi2.CloseNBADirectSeeding;
            huhansan.SubjectState = "我胡汉三回来了！";
            // 通过调用方法来调用委托
            huhansan.Notify();

            Console.ReadKey();
        }
    }
}