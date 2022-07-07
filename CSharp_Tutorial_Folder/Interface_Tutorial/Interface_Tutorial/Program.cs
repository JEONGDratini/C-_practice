using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Tutorial
{
    //인터페이스 정의하기
    interface Interface_Tutorial_1 
    {
        void print();
    }

    interface Interface_Tutorial_2
    {
        void print();
    }

    //인터페이스 2개를 상속받는다.
    class Program : Interface_Tutorial_1, Interface_Tutorial_2
    {
        static void Main(string[] args)
        {
            Program pr = new Program();

            Interface_Tutorial_1 itt1 = pr;
            itt1.print();
            
            Interface_Tutorial_2 itt2 = pr;
            itt2.print();

            Console.ReadLine();
        }

        //각각의 인터페이스 메소드 구현
        void Interface_Tutorial_1.print()
        {
            Console.WriteLine("Interface_Tutorial_1.print() 호출");
        }

        void Interface_Tutorial_2.print()
        {
            Console.WriteLine("Interface_Tutorial_2.print() 호출");
        }
    }
}
