using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_Tutorial
{
    class Program
    {
         static void Main(string[] args)//이 컴퓨터의 c#버전에서는 Main을 비동기로 만들 수 없대요 ㅠㅠ
        {
             /*
            TaskTest1();
            System.Console.WriteLine("MainThread_Running..");
            Console.ReadLine();
             */

            Task t = TaskTest2();
            for (int i = 0; i < 10; i++) {
                System.Console.WriteLine("Do Something before end of your vacation");
            }


            for (int i = 0; i < 10; i++) {
                System.Console.WriteLine("Do Something during your semester");
            }

        }

        private static async void TaskTest1()//async wait사용
        {
            //지정한 시간동안 작업의 흐름이 이 메서드를 호출한 쪽(Main)으로 넘어간다.
            await Task.Delay(4000);
            System.Console.WriteLine("TaskTest Done");
        }

        private static async Task TaskTest2()
        {
            await Task.Delay(5000);
            System.Console.WriteLine("TaskTest2 Activated");
        }


    }
}
