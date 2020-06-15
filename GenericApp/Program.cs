using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GenericApp
{
    public class SimpleGeneric<T>
    {
        private T[] valuse;
        private int index;

        public SimpleGeneric(int len)
        {
            valuse = new T[len];
            index = 0;
        }

        public void Add(params T[] args)
        {
            foreach (T item in args)
            {
                valuse[index++] = item;
            }
        }

        public void Print()
        {
            foreach (T item in valuse)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
    // 주석
    class Program
    {
        static void Main(string[] args)
        {
            SimpleGeneric<Int32> gIntergers = new SimpleGeneric<int>(10);
            SimpleGeneric<double> gDoubles = new SimpleGeneric<double>(10);

            gIntergers.Add(1, 2);
            gIntergers.Add(1, 2, 3, 4, 5, 6, 7);
            gIntergers.Add(10);

            gDoubles.Add(10.0, 12.4, 37.5);
            gIntergers.Print();
            gDoubles.Print();
        }
    }
}
