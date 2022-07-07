using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Tutorial
{
    class Program
    {
        static void CopyArray<T>(T[] source, T[] target)//제네릭 타입 배열로 받아온다.
        {
            for (int i = 0; i < source.Length; i++)
                target[i] = source[i];//source를 타겟에 집어넣는다.
        }

        static void Main(string[] args)
        {
            int[] source = { 5, 6, 7, 8, 9 };
            int[] target = new int[source.Length];

            CopyArray<int>(source, target);//int 형으로 매개변수 집어넣어버리기

            foreach (int element in target)//target출력
                Console.WriteLine(element);//넣은대로 잘 출력된다.

            string[] source2 = { "일", "이", "삼", "사" };
            string[] target2 = new string[source2.Length];

            CopyArray<string>(source2, target2);//string 형으로 매개변수 집어넣기

            foreach (string element in target2)
                Console.WriteLine(element);//넣은대로 잘 출력된다.
            Console.ReadLine();

        }

        
    }
}
