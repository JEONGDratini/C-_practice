using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 5525번 티어 실버1 IOI문제 
namespace BaekJoon_5525
{
    class Program
    {
        static int N;
        static int len;
        static string input_str;
        static int count = 0;

        //입력받기
        static void input() {
            N = int.Parse(Console.ReadLine());
            len = int.Parse(Console.ReadLine());
            input_str = Console.ReadLine();
        }

        static void Find_IOI() {

            //문자열 비교하기
            int IOI_num = 0;//발견된 IOI 패턴 갯수
            for (int i = 1; i < len-1; i++) {
                if (input_str[i - 1] == 'I' && input_str[i] == 'O' && input_str[i + 1] == 'I')
                {
                    IOI_num++;//IOI패턴이 연속적으로 발견되는 순간 IOI_num을 1씩 증가시킨다.
                    if (IOI_num == N)//IOI연속패턴 갯수가 N개만큼 발견되면 IOI_num을 1빼고 count를 1 더한다.
                    {
                        IOI_num--;
                        count++;
                    }
                    i++;//패턴이 꼬이지 않도록 i를 1 더해준다.
                }
                else
                    IOI_num=0;//중간에 패턴이 끊기면 IOI_num을 초기화시켜준다.
            }
        }

        static void Main(string[] args)
        {
            input();
            Find_IOI();
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}