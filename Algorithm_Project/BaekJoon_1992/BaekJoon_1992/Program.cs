using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 문제 1992번 쿼드트리 문제
namespace BaekJoon_1992
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int y = 1;
            while (true) {//받아온 N이 2의 몇번째 제곱수인지를 판별한다.
                if (N / Math.Pow(2, y) == 1)
                    break;
                y++;
            }

            int [,] Quad_Tree = new int [N,N];//숫자 받아올 배열 선언하고 숫자입력받기
            receive_input(ref Quad_Tree, N);

            //입력받은 숫자로 비교연산, 출력하기
            Quad_Tree_Calc(Quad_Tree, 0, 0, N);
            Console.WriteLine();
            Console.ReadLine();
        }

        //배열입력받는 함수.
        static void receive_input(ref int[,] Quad_Tree, int N) {
            for (int i = 0; i < N; i++)
            {
                string raw = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    Quad_Tree[i, j] = int.Parse(raw[j] + "");
                }
            }
        }

        //4등분한거에 4등분은 쪼개고 쪼개야하는 
        //알고리즘 특성상 재귀함수로 구현하는게 가장 좋을 것 같다.

        //배열 가지고가서 문자열로 압축변환하는 함수.
        static void Quad_Tree_Calc(int[,] par_Quad_Tree, int x, int y, int N)//배열, 시작x, 시작y, 계산할 배열 한면 길이.
        {
            if (N == 1) { //배열크기가 1이면 해당 배열값 출력.
                Console.Write(par_Quad_Tree[y, x]);
                return;
            }
            bool is_1 = true;//해당 배열 전체가 1인지 아닌지 판별
            bool is_0 = true;//해당 배열 전체가 0인지 아닌지 판별

            for (int i = y; i < y + N; i++) {//계산할 배열구간 전체비교.
                for (int j = x; j < x + N; j++) {
                    if (par_Quad_Tree[i, j] == 0)
                        is_1 = false;
                    else if (par_Quad_Tree[i, j] == 1)
                        is_0 = false;
                }
            }

            if (is_1)//전체가 다 1이면 1출력
                Console.Write(1);
            else if (is_0)//전체가 다 0이면 0출력
                Console.Write(0);
            else {//전체가 다 통일되어있지 않았다면 각 사분면에 대해 비교연산함수 재귀로 호출하기.
                Console.Write("(");
                Quad_Tree_Calc(par_Quad_Tree, x, y, N / 2);
                Quad_Tree_Calc(par_Quad_Tree, x + N / 2, y, N / 2);
                Quad_Tree_Calc(par_Quad_Tree, x, y + N / 2, N / 2);
                Quad_Tree_Calc(par_Quad_Tree, x+N/2, y+N/2, N / 2);
                Console.Write(")");
            }

            return;
        }
    }
}
