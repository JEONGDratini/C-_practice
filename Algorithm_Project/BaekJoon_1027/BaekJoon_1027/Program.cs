using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 1027번 고층빌딩 티어 골드4
namespace BaekJoon_1027
{
    class Program
    {
        static void Main(string[] args)
        {
            //입력받기
            int N = int.Parse(Console.ReadLine());

            string[] raw_building = Console.ReadLine().Split(' ');

            double[] building = new double[N];
            for(int i = 0;i<N;i++)
                building[i] = double.Parse(raw_building[i]);

            //building의 인덱스가 x좌표, 해당 배열의 값이 높이라고 보면 된다.

            Solution(building, Combination(N), N);
            Console.ReadLine();

        }

        static List<int []> Combination(int N) {//주어진 수보다 작은 수들 2개씩 조합 뽑기(중복허용 X)
            List<int []> Combinate = new List<int []>();
            for (int i = 0; i < N; i++) { 
                for(int j = i+1;j<N;j++){
                    int [] a = {i, j};//3번째의 1은 이 선분이 시야확보에 유효한 선분인지 확인하기 위한 원소다. 1이면 유효한 시야, 0이면 유효하지 않은 시야다.
                    Combinate.Add(a);
                    //Console.WriteLine(a[0] + ", "+ a[1]);
                }
            }
            return Combinate;
        }

        static void Solution(double[] building, List<int[]> comb, int N)
        {
            int[] count = new int[N];
            count.Initialize();

            for (int i = 0; i < comb.Count; i++) {//각 조합마다 연산한다.
                double vert = (building[comb[i][1]] - building[comb[i][0]]) / (comb[i][1] - comb[i][0]);//선분의 기울기.
                double y_mt = building[comb[i][0]] - comb[i][0] * vert;//선분의 y절편
                bool is_available = true;//해당 선분이 유효한지 체크하는 불린변수

                for (int j = comb[i][0] + 1; j < comb[i][1]; j++) { //두 빌딩 사이에 있는 빌딩들이 선분과 만나는지 비교한다.
                    if (building[j] >= vert * j + y_mt) { //빌딩이 해당 선분과 만난다면 해당 선분은 유효하지 않은 것으로 간주한다.
                        is_available = false;
                        break;
                    }
                }

                if (is_available)//유효한 선분이면
                {
                    count[comb[i][0]]++;//두 빌딩의 볼 수 있는 빌딩 갯수를 1개씩 추가한다.
                    count[comb[i][1]]++;
                }
            }

            Array.Sort(count);//count배열 정렬 후 가장 큰값 출력.
            Console.WriteLine(count[N-1]);
            return;
        }
    }
}
