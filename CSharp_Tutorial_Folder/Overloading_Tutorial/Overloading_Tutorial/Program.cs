using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading_Tutorial
{
    class Overload_Practice
    {
        //int 형 패러미터로 받음. 반환값 없음.
        public static void Method(int val)
        {
            Console.WriteLine("int val Method: return void");
        }

        //string 형 패러미터로 받음. 반환값 없음.
        public static void Method(string val)
        {
            Console.WriteLine("string val Method: return void");
        }

        //double형과 float형 패러미터로 받음. 반환값 없음.
        public static void Method(double val1, float val2)
        {
            Console.WriteLine("double val1, float val2 Method: return void");
        }

        //int형 패러미터로 받음. 반환값 int. 생성 중 오류생김.
        //overload는 오직 패러미터만으로 method를 구별하기 때문에 
        //패러미터가 같다면 중복method로 인식해 오류가 생긴다.
       /*
        public static int Method(int val)
        { 
            Console.WriteLine("int val Method: return int");            
            return val + 10;
        }
        */
    }

    class Program
    {
        static void Main(string[] args)
        {
            Overload_Practice.Method(12);
            Overload_Practice.Method("I hate TOEIC");
            Overload_Practice.Method(12, 63);
            Console.ReadKey();
        }
    }
}
