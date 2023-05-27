using System;
using System.Collections;

namespace _22_享元模式
{
    internal class Program
    {
        public class User
        {
            public readonly string name;

            public User(string name)
            {
                this.name = name;
            }
        }

        /// <summary>
        ///     享元基类 包含一个写入不相同信息的方法
        /// </summary>
        abstract class WebSite
        {
            public abstract void Use(User user);
        }

        /// <summary>
        ///     具体享元类
        /// </summary>
        private class ConcreteWebSite : WebSite
        {
            private readonly string name = "";

            public ConcreteWebSite(string name)
            {
                this.name = name;
            }

            /// <summary>
            ///     写入不相同的信息
            /// </summary>
            /// <param name="user">不相同的信息</param>
            public override void Use(User user)
            {
                Console.WriteLine("网站分类：" + name + "\n用户：" + user.name + "\n");
            }
        }

        /// <summary>
        ///     享元工厂类
        /// </summary>
        private class WebSiteFactory
        {
            // 哈希表保存分类
            private readonly Hashtable flyweights = new Hashtable();

            /// <summary>
            ///     按分类加入哈希表 相同的分类为一个
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public WebSite GetWebSiteCategory(string key)
            {
                if (!flyweights.ContainsKey(key)) flyweights.Add(key, new ConcreteWebSite(key));

                return (WebSite) flyweights[key];
            }

            /// <summary>
            ///     返回分类个数
            /// </summary>
            /// <returns></returns>
            public int GetWebSiteCount()
            {
                return flyweights.Count;
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var f = new WebSiteFactory();

            // 这三个分类一样 相同部分合并保存 另外用方法写入不同部分
            var fx = f.GetWebSiteCategory("产品展示");
            fx.Use(new User("小菜"));
            var fy = f.GetWebSiteCategory("产品展示");
            fy.Use(new User("大鸟"));
            var fz = f.GetWebSiteCategory("产品展示");
            fz.Use(new User("娇娇"));

            // 这三个分类一样 相同部分合并保存 另外用方法写入不同部分
            var fl = f.GetWebSiteCategory("博客");
            fl.Use(new User("老顽童"));
            var fm = f.GetWebSiteCategory("博客");
            fm.Use(new User("桃谷六仙"));
            var fn = f.GetWebSiteCategory("博客");
            fn.Use(new User("南海鳄神"));

            // 虽然有六个网站 但是分类只有两个 相同部分合并保存
            Console.WriteLine("得到网站分类总数为{0}", f.GetWebSiteCount());

            Console.ReadKey();
        }
    }
}