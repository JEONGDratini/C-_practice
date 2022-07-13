using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//아웃풋은 정상인데 메모리를 너무잡아먹음. 로직 기본 뼈대는 그대로 두고 자료구조 써먹는걸 손봐야할듯.
namespace BaekJoon_1753
{
    class Program
    {
        static int inf = 900000000;//갈 수 없음 표기
        static int V; //총 정점 갯수
        static bool[] visited;//방문한 정점
        static int[] dist;//각 정점로 가는 거리

        static void Main(string[] args)
        {
            int start = -1;
            int [,] a = input(ref V,ref start); //입력받고 각 점과 간선간의 거리배열 구하기

            visited = new bool[V]; //방문한 정점
            dist = new int[V]; //거리

            Solution(start, ref a);
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

            int[,] a = new int[V, V];//V*V크기의 a배열 전부 초기화
            for (int i = 0; i < V; i++) {
                for (int j = 0; j < V; j++) {
                    if(i == j)
                        a[i, j] = 0;//자기자신과의 거리는 0으로,
                    else
                        a[i, j] = inf;//그 외 다른 점들과의 거리는 inf(무한대)로 설정한다.
                }
            }

            start = int.Parse(Console.ReadLine());//시작 노드의 번호를 입력.

            for (int i = 0; i < int.Parse(raw_V_E[1]); i++) {//몇개의 간선을 받을 건지 받아온 만큼 반복.
                string[] raw_start_end_w = Console.ReadLine().Split(' ');//받아온 값들을 스플릿 -> 배열화한다.

                //정점과 정점을 잇는 간선이 1개가 아닐 수도 있으므로 비교한다.
                //int.Parse(raw_start_end_w[0])-1 -> 간선 시작 정점 인덱스
                //int.Parse(raw_start_end_w[1])-1 -> 간선 도착 정점 인덱스
                //int.Parse(raw_start_end_w[2]) -> 해당 간선의 가중치(거리)
                if (a[int.Parse(raw_start_end_w[0])-1, int.Parse(raw_start_end_w[1])-1] > int.Parse(raw_start_end_w[2]))
                    a[int.Parse(raw_start_end_w[0])-1, int.Parse(raw_start_end_w[1])-1] = int.Parse(raw_start_end_w[2]);    
            }


            //그렇게 완성시킨 배열 a출력.
            /*
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
            */
            return a;
        }

        //연산하기
        static void Solution(int start, ref int [,] a) {
            
            for (int i = 0; i < V; i++)//맨처음 시작정점과 직접 닿아있는 점들의 거리를 dist에 집어넣는다.
                dist[i] = a[start-1, i];

            visited[start-1] = true;//시작점 방문 체크하고 방문시작

            for (int i = 0; i < V-2; i++) {//방문
                //원래 있던 곳에서 가장 가까운 곳으로 현재위치 설정
                int current = getshortestIndex(dist, visited);
                visited[current] = true;//현재 위치 방문 확인.
                for (int j = 0; j < V; j++) {//각 정점마다 확인한다.
                    if (!visited[j]) {//아직 방문하지 않은 정점이라면
                        if (dist[current] + a[current, j] < dist[j])//기존거리와 새로 구한 거리를 비교해서 더 짧은 쪽 선택
                            dist[j] = dist[current] + a[current, j];
                    }
                }
            }
        }

        static int getshortestIndex(int [] dist, bool [] visited) {
            int min = inf;//일단 최솟값 inf로 설정.
            int index = 0;//가장 가까운 곳 인덱스

            for (int i = 0; i < V; i++) {//각 정점마다 비교한다.
                if (dist[i] < min && !visited[i]) {//아직 방문하지 않았고, min보다 거리가 짧다면
                    min = dist[i];//min을 갈아치우고
                    index = i;//가장 가까운 곳 인덱스를 i로 설정한다.
                }
            }
            return index;
        }
    }
}
