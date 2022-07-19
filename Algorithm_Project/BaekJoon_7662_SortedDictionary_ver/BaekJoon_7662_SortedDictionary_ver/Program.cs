using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaekJoon_7662_SortedDictionary_ver
{
    //이것도 시간초과래..ㅠㅠ
    class Program
    {

        static int K;//테스트 케이스 숫자

        static void Main(string[] args)
        {
            K = int.Parse(Console.ReadLine());
            for (int i = 0; i < K; i++)
                Solution();
            Console.ReadLine();
        }

        static void Solution() {
            int N = int.Parse(Console.ReadLine());
            SortedDictionary<int, int> SortedMap = new SortedDictionary<int, int>();

            for (int i = 0; i < N; i++) {
                string[] raw_data = Console.ReadLine().Split(' ');
                int num = int.Parse(raw_data[1]);
                if (raw_data[0].Equals("I"))
                {//삽입. 
                    if (SortedMap.ContainsKey(num))//맵에 이미 키값이 존재한다면 만들어진 원소의 value(존재하는 갯수)에 1을 더한다.
                        SortedMap[num]++;
                    else//원소가 없다면 원소를 만든다.
                        SortedMap.Add(num, 1);
                }
                else if (raw_data[0].Equals("D"))
                {//삭제연산. 
                    if (SortedMap.Count == 0)//아무것도 없으면 무시.
                        continue;
                    if (num == 1) {//최댓값 삭제
                        if (SortedMap[SortedMap.Keys.Last()] == 1)//값이 1개 남아있다면 마지막 원소를 삭제.
                            SortedMap.Remove(SortedMap.Keys.Last());
                        else
                            SortedMap[SortedMap.Keys.Last()]--;//값이 1개 이상 남아있다면 마지막 원소의 value값을 1뺀다.
                    }
                    else if (num == -1) {//최솟값 삭제
                        if (SortedMap[SortedMap.Keys.First()] == 1)//값이 1개 남아있다면 첫 원소를 삭제.
                            SortedMap.Remove(SortedMap.Keys.First());
                        else
                            SortedMap[SortedMap.Keys.First()]--;//값이 1개 이상 남아있다면 첫 원소의 value값을 1뺀다.
                    }
                }
            }
            //연산들 끝난 뒤
            if (SortedMap.Count == 0)
                Console.WriteLine("EMPTY");
            else
                Console.WriteLine(SortedMap.Keys.Last() + " " + SortedMap.Keys.First());
        }
    }
}
