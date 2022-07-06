using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Project
{
    class Program
    {
        static void Ship()//백준 문제 1092번 배 풀이
        {
            int crane_num = 0;
            int bx_num = 0;

            //입력받기
            string input_cr_num = Console.ReadLine();
            crane_num = Convert.ToInt32(input_cr_num);

            int[] cr_weight = new int[crane_num];
            int[] cr_weight_possible = new int[crane_num];

            string input_cr_weight = Console.ReadLine();
            string[] input_weights = input_cr_weight.Split(' ');

            int i = 0;
            foreach (string weights in input_weights)
            {
                cr_weight[i] = Convert.ToInt32(weights);
                Console.WriteLine(cr_weight[i]);
            }

            string input_bx_num = Console.ReadLine();
            bx_num = Convert.ToInt32(input_bx_num);

            int[] bx_weight = new int[bx_num];

            string input_bx_weight = Console.ReadLine();
            string[] input_bx_weights = input_bx_weight.Split(' ');

            i = 0;
            foreach (string weights in input_weights)
            {
                bx_weight[i] = Convert.ToInt32(weights);
                Console.WriteLine(bx_weight[i]);
            }

            //각 배열 내림차순으로 정렬하기
            Array.Reverse(cr_weight);
            Array.Reverse(bx_weight);

            //내림차순으로 정렬한 배열들 비교해서 각 크레인이 어느박스까지 들 수 있는지 확인.
            if (bx_weight[0] > cr_weight[0])
            {
                Console.WriteLine("-1");//가장 무거운 박스를 들 수있는 크레인이 없을 때 -1출력.
                return;
            }
            else//가장 무거운 박스를 들 수 있는 크레인이 있을 때
            {
                for (int j = 0; j < cr_weight.Length; j++)//중량 빵빵한 크레인부터 박스무게 비교.
                {
                    for (int u = 0; u < bx_weight.Length; u++)
                    {
                        if (cr_weight[j] >= bx_weight[u])
                        {
                            cr_weight_possible[j] = u;//인덱스 j에 해당하는 크레인이 어느박스까지 들 수 있는지를 배열에 넣는다.
                            break;
                        }
                    }
                }

                for (int j = 0; j < cr_weight_possible.Length; j++)
                { 
                
                }
            }

        }

        static void Main(string[] args)
        {
            Ship();
        }

        

    }
}
