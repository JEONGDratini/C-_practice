using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            

            square(4);//일반 메소드

            int ref_a = 40;//ref키워드
            ref_ADD(ref ref_a, 60);
            Console.WriteLine("ref_ADD : a={0}\n",ref_a);

            int out_a;//out키워드
            out_ADD(out out_a, 60);
            Console.WriteLine("out_ADD : a={0}\n", ref_a);

            //params키워드
            Console.WriteLine("params : total = {0}", total(30, 34, 23, 12, 64, 23, 11, 1, 2));
            Console.WriteLine("params : total = {0}\n", total(2, 7, 43));

            Console.ReadKey();
        }

        //메소드 
        static int square(int a)
        {
            Console.WriteLine("Method : {0}*{1}={2}\n", a, a, a * a);
            return a * a;
        }

        //ref 키워드 사용 : 미리 변수 초기화 필요함.
        static void ref_ADD(ref int a, int b) 
        {
            a += b;
        }

        //out 키워드 사용 : 미리 변수 초기화 불필요.
        static void out_ADD(out int a, int b)
        {
            a = b;
        }

        //params 키워드 사용 : 형식만 정해주면 동적으로 매개변수를 넘길 수 있음. 배열로 넘길 수 있다.
        static int total(params int[] list)
        {
            int total = 0;
            for (int i = 0; i < list.Length; i++)
                total += list[i];
            return total;
        }
    }

    class Baby
    {

    }
    
}
