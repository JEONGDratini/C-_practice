using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaekJoon_1753
{
    class Program
    {
        static int inf = 900000000;//갈 수 없음 표기
        static int V;

        static void Main(string[] args)
        {
            int start = -1;
            int [,] a = input(ref V,ref start); //입력받고 각 점과 간선간의 거리배열 구하기

            bool[] visited = new bool[V]; //방문한 노드
            int[] dist = new int[V]; //거리

            Solution(start, ref a, ref dist, ref visited);
            foreach (int distance in dist)
            {
                if(distance == inf)
                    Console.WriteLine("INF");
                else
                    Console.WriteLine(distance);
            }
            Console.ReadLine();
        }

        //입력받기
        static int[,] input(ref int V, ref int start) {
            string [] raw_V_E = Console.ReadLine().Split(' ');
            V = int.Parse(raw_V_E[0]);

            int[,] a = new int[V, V];//배열 inf로 초기화
            for (int i = 0; i < V; i++) {
                for (int j = 0; j < V; j++) {
                    if(i == j)
                        a[i, j] = 0;
                    else
                        a[i, j] = inf;
                }
            }

            int E = int.Parse(raw_V_E[1]);

            start = int.Parse(Console.ReadLine());

            for (int i = 0; i < E; i++) {
                string[] raw_start_end_w = Console.ReadLine().Split(' ');
                int stt = int.Parse(raw_start_end_w[0])-1;
                int end = int.Parse(raw_start_end_w[1])-1;
                int w = int.Parse(raw_start_end_w[2]);

                if (a[stt, end] > w)//정점과 정점을 잇는 간선이 1개가 아닐 수도 있으므로 비교한다.
                    a[stt, end] = w;    
            }

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }

            return a;
        }

        //연산하기
        static void Solution(int start, ref int [,] a, ref int [] dist, ref bool [] visited) {
            
            for (int i = 0; i < V; i++)//맨처음 시작정점과 직접 닿아있는 점들의 거리를 dist에 집어넣는다.
                dist[i] = a[start-1, i];
            visited[start-1] = true;//시작점 방문 체크하고 방문시작

            for (int i = 0; i < V-2; i++) {//방문
                int current = getshortestIndex(V, dist, visited);//원래 있던 곳에서 가장 가까운 곳으로 위치이동.
                visited[current] = true;
                for (int j = 0; j < V; j++) {
                    if (!visited[j]) {
                        if (dist[current] + a[current, j] < dist[j])
                            dist[j] = dist[current] + a[current, j];
                    }
                }
            }
        }

        static int getshortestIndex(int V, int [] dist, bool [] visited) {
            int min = inf;//일단 최솟값 inf로 설정.
            int index = 0;//가장 가까운 곳 인덱스
            for (int i = 0; i < V; i++) {
                if (dist[i] < min && !visited[i]) {
                    min = dist[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
