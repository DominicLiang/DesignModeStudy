using System;

namespace _06_原型模式
{
    internal class Program
    {
        /// <summary>
        ///     工作经历类 浅复制
        /// </summary>
        private class WorkExperience : ICloneable //实现ICloneable接口
        {
            public string WorkDate { get; set; }

            public string Company { get; set; }

            // 浅复制
            public object Clone()
            {
                return MemberwiseClone();
            }
        }

        /// <summary>
        ///     简历类 深复制
        /// </summary>
        private class Resume : ICloneable //实现ICloneable接口
        {
            private string name;
            private string sex;
            private string age;
            private readonly WorkExperience work;

            public Resume(string name)
            {
                this.name = name;
                work = new WorkExperience();
            }

            /// <summary>
            ///     私有构造方法 供Clone方法调用
            /// </summary>
            /// <param name="work"></param>
            private Resume(WorkExperience work)
            {
                this.work = (WorkExperience) work.Clone();
            }

            public void SetPersonalInfo(string sex, string age)
            {
                this.sex = sex;
                this.age = age;
            }

            public void SetWorkExperience(string workDate, string company)
            {
                work.WorkDate = workDate;
                work.Company = company;
            }

            public void Display()
            {
                Console.WriteLine("{0}\n{1}\n{2}", name, sex, age);
                Console.WriteLine("工作经历：{0}  {1}\n", work.WorkDate, work.Company);
            }

            /// <summary>
            ///     深复制
            /// </summary>
            /// <returns></returns>
            public object Clone()
            {
                // 创建一个新简历，先用私有构造方法复制好工作经历类
                var obj = new Resume(work);
                // 再给这新简历重新赋值
                obj.name = name;
                obj.sex = sex;
                obj.age = age;
                // 返回这个深复制的新简历
                return obj;
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var a = new Resume("大鸟");
            a.SetPersonalInfo("男", "29");
            a.SetWorkExperience("1998-2000", "XX公司");

            var b = (Resume) a.Clone();
            b.SetWorkExperience("1998-2006", "YY企业");

            var c = (Resume) a.Clone();
            c.SetPersonalInfo("男", "24");

            a.Display();
            b.Display();
            c.Display();

            Console.ReadKey();
        }
    }
}