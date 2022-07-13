using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Algorithm_Example
{
    class Program
    {
        static int num = 6;
        static int inf = 1000000;

        static int [,] a = {//각 점과 간선간의 거리.
            {0, 2, 5, 1, inf, inf},
            {2, 0, 3, 2, inf, inf},
            {5, 3, 0, 3, 1, 5},
            {1, 2, 3, 0, 1, inf},
            {inf, inf, 1, 1, 0, 2},
            {inf, inf, 5, inf, 2, 0},
            };
        static bool [] v = new bool[6]; //방문한 노드
        static int [] d = new int[6]; //거리

        //거리가 최소인 정점을 반환한다.
        static int getshortestIndex()
        {
            int min = inf;
            int index = 0;
            for (int i = 0; i < num; i++) {
                if (d[i] < min && !v[i]) {
                    min = d[i];
                    index = i;
                }
            }
                return index;
        }

        static void dijkstra(int start) {
            for (int i = 0; i < num; i++) {
                d[i] = a[start,i];
            }
            v[start] = true;
            for (int i = 0; i < num - 2; i++) {
                int current = getshortestIndex();
                v[current] = true;
                for (int j = 0; j < 6; j++) {
                    if (!v[j]) {
                        if (d[current] + a[current,j] < d[j]) {
                            d[j] = d[current] + a[current, j];
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            dijkstra(0);
            for (int i = 0; i < num; i++) {
                Console.Write(d[i] + " ");
            }
            Console.ReadLine();


        }
    }
}
