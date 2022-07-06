using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread_Tutorial_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread myThread = new Thread(Func);
            myThread.Start(7);//7을 매개변수값 object로 넘긴다.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i + 1);
                Thread.Sleep(3000);
            }
            Console.WriteLine("메인쓰레드 종료"); 
        }
        private static void Func(object obj)
        {
            int num = (int)obj;//object값 받아온걸 
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(i + 1);
                Thread.Sleep(4000);
            }
        } 
    }
}
