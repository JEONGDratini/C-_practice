using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//백준 1041번 주사위 골드5
namespace BaekJoon_1041
{
    class Program
    {
        static long N;
        static int[] dice = new int[6];

        static void Main(string[] args)
        {
            //입력받기
            N = long.Parse(Console.ReadLine());
            string  [] raw_dice = Console.ReadLine().Split(' ');
            int i = 0;
            foreach(string dice_num in raw_dice){
                dice[i] = Convert.ToInt32(dice_num);
                i++;
            }
            //2개면 보이는거 경우의 수 찾아 배열 만듦
            int[] dice_2 = {dice[0]+dice[1], dice[0]+dice[2], dice[0]+dice[3], dice[0]+dice[4],
                           dice[1]+dice[2], dice[1]+dice[3], dice[1]+dice[5], 
                           dice[2]+dice[4], dice[2]+dice[5], dice[3]+dice[4], dice[3]+dice[5], dice[4]+dice[5]};
            //3개면 보이는거 경우의 수 찾아 배열 많듦
            int[] dice_3 = { dice[0] + dice[1] + dice[2], dice[0] + dice[1] + dice[3], dice[0] + dice[2] + dice[4], dice[0] + dice[3] + dice[4], 
                             dice[1]+dice[2]+dice[5], dice[1]+dice[3]+dice[5],
                           dice[2]+dice[4]+dice[5], dice[3]+dice[4]+dice[5]};

            //각 찾은 경우의 수들을 최소값이 맨 앞에 오도록 정렬.
            Array.Sort(dice);
            Array.Sort(dice_2);
            Array.Sort(dice_3);
            long result = 0;
            //N의 경우에 맞춰서 최솟값만 바깥에 나오는 경우의 수 계산.
            if (N >= 3)
                result = (5 * N * N - 16 * N + 12) * dice[0] + (8*N-12) * dice_2[0] + 4 * dice_3[0];
            else if (N == 2)
                result = 4 * dice_2[0] + 4 * dice_3[0];
            else if (N == 1)
                result = dice[0] + dice[1] + dice[2] + dice[3] + dice[4];
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}