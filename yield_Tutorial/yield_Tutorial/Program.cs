using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yield_Tutorial
{


    public class List
    {
        private int[] data = { 1, 2, 3, 4, 5 };

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (i < data.Length)
            {
                yield return data[i];
                i++;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            IEnumerator it = list.GetEnumerator();//이 IEnumerator로 list를 수동으로 조작한다.
            it.MoveNext();
            Console.WriteLine(it.Current);
            it.MoveNext();
            Console.WriteLine(it.Current);

            Console.ReadKey();
        }
    }
}
