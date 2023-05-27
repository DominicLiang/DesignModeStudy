using System;

namespace _23_解释器模式
{
    internal class Program
    {
        /// <summary>
        ///     解释内容类
        /// </summary>
        private class PlayContext
        {
            public string Playtext { get; set; }
        }

        /// <summary>
        ///     抽象表达式类
        /// </summary>
        abstract class Expression
        {
            public void Interpret(PlayContext context)
            {
                if (context.Playtext.Length == 0)
                {
                }
                else
                {
                    // 解析字符串 “O 3 E 0.5 ......”解释为“playkey为O playValue为3  playkey为E playValue为0.5”
                    var playKey = context.Playtext.Substring(0, 1);
                    context.Playtext = context.Playtext.Substring(2);
                    var playValue = Convert.ToDouble(context.Playtext.Substring(0, context.Playtext.IndexOf(" ")));
                    context.Playtext = context.Playtext.Substring(context.Playtext.IndexOf(" ") + 1);

                    // 再使用不同的子类来二次解释
                    Excute(playKey, playValue);
                }
            }

            // 抽象执行处理 不同子类有不同的处理方法
            public abstract void Excute(string key, double value);
        }

        /// <summary>
        ///     表达式类 音符
        /// </summary>
        private class Note : Expression
        {
            // 解释处理
            public override void Excute(string key, double value)
            {
                var note = "";
                switch (key)
                {
                    case "C":
                        note = "1";
                        break;
                    case "D":
                        note = "2";
                        break;
                    case "E":
                        note = "3";
                        break;
                    case "F":
                        note = "4";
                        break;
                    case "G":
                        note = "5";
                        break;
                    case "A":
                        note = "6";
                        break;
                    case "B":
                        note = "7";
                        break;
                }

                Console.Write("{0}", note);
            }
        }

        /// <summary>
        ///     表达式类 音阶类
        /// </summary>
        private class Scale : Expression
        {
            public override void Excute(string key, double value)
            {
                var scale = "";
                switch (Convert.ToInt32(value))
                {
                    case 1:
                        scale = "低音";
                        break;
                    case 2:
                        scale = "中音";
                        break;
                    case 3:
                        scale = "高音";
                        break;
                }

                Console.Write("{0}", scale);
            }
        }

        /// <summary>
        ///     表达式类 音速类
        /// </summary>
        private class Speed : Expression
        {
            public override void Excute(string key, double value)
            {
                string speed;
                if (value < 500)
                    speed = "快速";
                else if (value >= 1000)
                    speed = "慢速";
                else
                    speed = "中速";
                Console.Write("{0}", speed);
            }
        }

        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var context = new PlayContext();
            Console.WriteLine("上海滩：");
            context.Playtext =
                "T 500 O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 ";
            Expression expression = null;
            try
            {
                // 遍历内容
                while (context.Playtext.Length > 0)
                {
                    var str = context.Playtext.Substring(0, 1);

                    // 一个个的解释
                    switch (str)
                    {
                        case "O":
                            expression = new Scale();
                            break;
                        case "T":
                            expression = new Speed();
                            break;
                        case "C":
                            expression = new Note();
                            break;
                        case "D":
                            expression = new Note();
                            break;
                        case "E":
                            expression = new Note();
                            break;
                        case "F":
                            expression = new Note();
                            break;
                        case "G":
                            expression = new Note();
                            break;
                        case "A":
                            expression = new Note();
                            break;
                        case "B":
                            expression = new Note();
                            break;
                        case "P":
                            expression = new Note();
                            break;
                    }

                    expression.Interpret(context);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadKey();
        }
    }
}