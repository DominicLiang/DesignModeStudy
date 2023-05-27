using System;

namespace _03_装饰模式
{
    internal class Program
    {
        /// <summary>
        ///     抽象基类统一格式
        /// </summary>
        abstract class Component
        {
            public abstract void Operation();
        }

        /// <summary>
        ///     具体实现主类
        /// </summary>
        private class ConcreteComponent : Component
        {
            public override void Operation()
            {
                Console.Write("基类具体操作\n");
            }
        }

        /// <summary>
        ///     装饰类
        /// </summary>
        abstract class Decorator : Component
        {
            protected Component component;

            /// <summary>
            ///     提供给功能子类的加入方法
            /// </summary>
            /// <param name="component"></param>
            public void SetComponent(Component component)
            {
                this.component = component;
            }

            /// <summary>
            ///     调用方法
            /// </summary>
            public override void Operation()
            {
                if (component != null) component.Operation();
            }
        }

        /// <summary>
        ///     功能子类
        /// </summary>
        private class ConcreteDecoratorA : Decorator
        {
            /// <summary>
            ///     重写调用方法
            /// </summary>
            public override void Operation()
            {
                // 先调用上层的调用方法
                base.Operation();
                // 再调用本类的附加方法
                AddedBehavior();
            }

            /// <summary>
            ///     附加功能内容
            /// </summary>
            private void AddedBehavior()
            {
                Console.Write("具体装饰对象A的操作\n");
            }
        }

        /// <summary>
        ///     功能子类
        /// </summary>
        private class ConcreteDecoratorB : Decorator
        {
            /// <summary>
            ///     重写调用方法
            /// </summary>
            public override void Operation()
            {
                // 先调用上层的调用方法
                base.Operation();
                // 再调用本类的附加方法
                AddedBehavior();
            }

            /// <summary>
            ///     附加功能内容
            /// </summary>
            private void AddedBehavior()
            {
                Console.Write("具体装饰对象B的操作\n");
            }
        }

        private static void Main(string[] args)
        {
            var a = new ConcreteDecoratorA();
            var b = new ConcreteDecoratorB();

            // 把功能子类A添加进具体实现主类
            a.SetComponent(new ConcreteComponent());
            // 把功能子类B添加进功能子类A
            b.SetComponent(a);
            // 调用子类B的方法
            // 那么他会先调用A的方法
            // 而A的调用方法会先调用主类的方法
            // 最后显示： 基类具体操作 具体装饰对象A的操作 具体装饰对象B的操作
            b.Operation();

            Console.ReadKey();
        }
    }
}