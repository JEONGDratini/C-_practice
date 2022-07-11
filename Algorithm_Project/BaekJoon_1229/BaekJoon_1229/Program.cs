using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//백준 1229번 육각수 티어 골드4
 namespace BaekJoon_1229
{
    class Program
    {
        static void Main(string[] args)
        {
            //입력받기
            int[] hint = { 0, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6, 2 };
            int N = int.Parse(Console.ReadLine());
            if (N < 13)
                Console.WriteLine(hint[N]);
            List<int> Hex_num_list = new List<int>();

            Hex_num_list = Calc_H(N);
            foreach(int a in Hex_num_list)
                Console.WriteLine(a);
            Console.ReadLine();
        }

        static List<int> Calc_H(int N)//N보다 작은 육각수들을 찾아서 리스트에 박아넣는다.
        {
            int n_h = 2;
            List<int> Hex_num_list = new List<int>();
            Hex_num_list.Add(1);
            while(true)
            {
                int h = 3 * n_h * (n_h - 1) - (n_h - 1) * (n_h - 2) - (n_h - 2);
                if(h>N)
                    break;
                else
                {
                    Hex_num_list.Add(h);
                }
                n_h++;
            }
            return Hex_num_list;
        }

    }
}
