using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Example
{
    class Program
    {

        static List<int> List = new List<int>();

        static void Main(string[] args)
        {
            for (int i = 1; i < 22; i++) {
                List.Add(i*2);
            }
            int find_num = 15;
            int size = 21;
            int index = BinarySearch(List, size, find_num);
            
            Console.WriteLine(find_num + "의 알맞은 자리는 " + index + "입니다.");

            Console.Write(find_num + " 추가 전의 queue : ");
            for (int i = 0; i < size; i++) 
                Console.Write(List[i] + " ");
            Console.WriteLine();

            List.Insert(index, find_num);
            size++;
            Console.Write(find_num + " 추가 뒤의 queue : ");
            for (int i = 0; i < size; i++)
                Console.Write(List[i] + " ");
            Console.WriteLine();

            Console.ReadLine();

        }

        static int BinarySearch(List<int> List, int size, int Find_Num)
        {//이진탐색 구현.
            int low = 0, high = size - 1, mid = -1;
            bool Case = false;//마지막 비교결과를 확인하기 위한 변수. 마지막 비교값보다 Find_Num이 작으면 false, 크면 ture반환

            while (low <= high)//반복해서 이진탐색한다.
            {
                mid = (low + high) / 2;

                if (List[mid] > Find_Num)
                {
                    high = mid - 1;
                    Case = false;
                }
                else if (List[mid] < Find_Num)
                {
                    low = mid + 1;
                    Case = true;
                }
                else
                    return mid;//중앙값과 찾는값이 일치하면 mid값을 반환한다.
            }

            if (Case)
                return mid + 1;
            else
                return mid;
        }
    }
}
