﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_迭代器模式
{
    class Program
    {
        abstract class Iterator
        {
            public abstract object First();
            public abstract object Next();
            public abstract bool IsDone();
            public abstract object CurrentItem();
        }

        abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        class ConcreteAggregate:Aggregate
        {
            private IList<object> items = new List<object>();
            
            public override Iterator CreateIterator()
            {
                throw new NotImplementedException();
            }

            public int Count
            {
                get { return items.Count; }
            }

            public object this[int index]
            {
                get { return items[index];}
                set { items.Insert(index,value);}
            }
        }

        class ConcreteIterator:Iterator
        {
            private ConcreteAggregate aggregate;
            private int current = 0;

            public ConcreteIterator(ConcreteAggregate aggregate)
            {
                this.aggregate = aggregate;
            }
            public override object First()
            {
                return aggregate[0];
            }

            public override object Next()
            {
                object ret = null;
                current++;
                if (current<aggregate.Count)
                {
                    ret = aggregate[current];
                }

                return ret;
            }

            public override bool IsDone()
            {
                return current >= aggregate.Count ? true : false;
            }

            public override object CurrentItem()
            {
                return aggregate[current];
            }
        }

        static void Main(string[] args)
        {
            ConcreteAggregate a=new ConcreteAggregate();

            a[0] = "大鸟";
            a[1] = "小菜";
            a[2] = "行李";
            a[3] = "老外";
            a[4] = "公交内部员工";
            a[5] = "小偷";

            Iterator i=new ConcreteIterator(a);
            object item = i.First();
            while (!i.IsDone())
            {
                Console.WriteLine("{0} 请买票！",i.CurrentItem());
                i.Next();
            }

            Console.ReadKey();
        }
    }
}
