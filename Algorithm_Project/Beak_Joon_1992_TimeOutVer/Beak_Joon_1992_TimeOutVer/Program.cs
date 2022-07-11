using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beak_Joon_1992_TimeOutVer
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int y = 1;
            while (true)
            {//받아온 N이 2의 몇번째 제곱수인지를 판별한다.
                if (N / Math.Pow(2, y) == 1)
                    break;
                y++;
            }
            int[,] Quad_Tree = new int[N, N];//숫자 받아올 배열 선언하고 숫자입력받기
            for (int i = 0; i < N; i++)
            {
                string raw = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    Quad_Tree[i, j] = int.Parse(raw[j] + "");
                    //Console.Write(Quad_Tree[i, j]);
                }
                //Console.WriteLine();
            }
            string output = Quad_Tree_Calc(Quad_Tree, y);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        //4등분한거에 4등분은 쪼개고 쪼개야하는 
        //알고리즘 특성상 재귀함수로 구현하는게 가장 좋을 것 같다.
        static string Quad_Tree_Calc(int[,] Quad_Tree, int y)
        {
            int N_div_two = (int)Math.Pow(2, y) / 2;
            string result = "(";
            for (int i = 0; i < 4; i++)
            {//i가 0, 1, 2, 3으로 나눠 각 나눈 면을 계산할 수 있도록 한다.
                int[,] Div_Quad_Tree = new int[N_div_two, N_div_two];
                switch (i)
                {
                    case 0://왼쪽 위 사분면 비교계산
                        for (int j = 0; j < N_div_two; j++)
                        {
                            for (int k = 0; k < N_div_two; k++)
                            {
                                Div_Quad_Tree[j, k] = Quad_Tree[j, k];
                                //다른게 있으면 나뉜 쿼드트리가지고 다시 호출.
                                if (Quad_Tree[0, 0] != Quad_Tree[j, k])
                                {
                                    result = result + Quad_Tree_Calc(Div_Quad_Tree, y - 1);
                                    break;
                                }
                            }
                        }
                        result = result + Quad_Tree[0, 0];
                        break;
                    case 1://오른쪽 위 사분면 비교계산
                        for (int j = 0; j < N_div_two; j++)
                        {
                            for (int k = N_div_two; k < N_div_two * 2; k++)
                            {
                                Div_Quad_Tree[j, k - N_div_two] = Quad_Tree[j, k];
                                //다른게 있으면 나뉜 쿼드트리가지고 다시 호출.
                                if (Quad_Tree[0, N_div_two] != Quad_Tree[j, k])
                                {
                                    result = result + Quad_Tree_Calc(Div_Quad_Tree, y - 1);
                                    break;
                                }
                            }
                        }
                        result = result + Quad_Tree[0, N_div_two];
                        break;
                    case 2://왼쪽아래 사분면 비교계산
                        for (int j = N_div_two; j < N_div_two * 2; j++)
                        {
                            for (int k = 0; k < N_div_two; k++)
                            {
                                Div_Quad_Tree[j - N_div_two, k] = Quad_Tree[j, k];
                                //다른게 있으면 나뉜 쿼드트리가지고 다시 호출.
                                if (Quad_Tree[0, N_div_two] != Quad_Tree[j, k])
                                {
                                    result = result + Quad_Tree_Calc(Div_Quad_Tree, y - 1);
                                    break;
                                }
                            }
                        }
                        result = result + Quad_Tree[N_div_two, 0];
                        break;
                    case 3://오른쪽아래 사분면 비교계산
                        for (int j = N_div_two; j < N_div_two * 2; j++)
                        {
                            for (int k = N_div_two; k < N_div_two * 2; k++)
                            {
                                Div_Quad_Tree[j - N_div_two, k - N_div_two] = Quad_Tree[j, k];
                                //다른게 있으면 나뉜 쿼드트리가지고 다시 호출.
                                if (Quad_Tree[0, N_div_two] != Quad_Tree[j, k])
                                {
                                    result = result + Quad_Tree_Calc(Div_Quad_Tree, y - 1);
                                    break;
                                }
                            }
                        }
                        result = result + Quad_Tree[N_div_two, N_div_two];
                        break;
                }
            }
            return result + ")";
        }
    }
}
