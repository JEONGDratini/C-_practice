using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaekJoon_7662_Duel_Queue_ver
{
    //얘도 아웃풋은 맞는데 시간이 초과됐다.
    //아무래도 push할 때 각 priority를 비교하는 시간복잡도가O(n)이라서 그런듯하다.

    class Program
    {
//=============================우선순위 큐 구현===================================
        public class Node
        {
            public int priority;//우선순위
            public Node next;//다음 순서원소.
        }

        public static Node node = new Node();

        public static Node newNode(int p)//새 노드 설정해 반환하는 메소드
        {
            Node temp = new Node();
            temp.priority = p;//우선순위
            temp.next = null;
            return temp;
        }

        public static int top(Node head)
        {
            return (head).priority;//가장 위에 있는 원소 가져오기
        }

        public static Node pop(Node head)//head를 갈아치우고 반환한다.
        {
            Node temp = head;
            (head) = (head).next;
            return head;
        }

        public static Node push(Node head, int p)
        {
            Node start = (head);
            Node temp = newNode(p);
            //각 노드들의 우선순위를 비교해서 head를 갈아치우거나 중간에 끼는 양옆 친구들의 next를 바꾼다.
            if ((head).priority > p)
            {
                temp.next = head;
                (head) = temp;
            }
            else
            {//근데 이렇게 되면 선형탐색이니까 어제만들었던 list를 이진탐색하는 답안보다 비효율적일것같은데..?
                while (start.next != null && start.next.priority < p)
                {
                    start = start.next;
                }
                temp.next = start.next;
                start.next = temp;
            }
            return head;
        }

        public static int isEmpty(Node head)
        {
            return ((head) == null) ? 1 : 0;
        }

//======================우선순위 큐 이용해 문제풀기================================
        static int K;//테스트 케이스 숫자       

        static void Main(string[] args)
        {
            K = int.Parse(Console.ReadLine());
            for (int i = 0; i < K; i++)
                Solution();
        }

        static void Solution() {//각 testcase마다 결과를 출력하는 함수
            int N = int.Parse(Console.ReadLine());
            int size = 0;//큐 두개를 사용할 것이므로 size를 사용한다.
            Node MaxQueue = null;//최대값이 head에 올 큐랑, 최솟값이 head에 올 큐 두개를 선언한다.
            Node MinQueue = null;
            for (int i = 0; i < N; i++)
            {
                string[] raw_data = Console.ReadLine().Split(' ');
                int num = int.Parse(raw_data[1]);
                if (raw_data[0].Equals("I"))
                {
                    if (size == 0)//사이즈가 0이면 MaxQueue, MinQueue의head에 새 노드를 집어넣는다.
                    {
                        MaxQueue = newNode(-num);
                        MinQueue = newNode(num);
                        size++;
                    }
                    else//사이즈가 0이 아니면 각 Queue에 Push한다.
                    {
                        MaxQueue = push(MaxQueue, -num);
                        MinQueue = push(MinQueue, num);
                        size++;
                    }
                }
                else {
                    if (size == 0)
                        continue;
                    else if (size == 1)
                    {
                        MinQueue = pop(MinQueue);
                        MaxQueue = pop(MaxQueue);
                        size--;
                    }
                    else {
                        if (num == 1)//최댓값빼는거면 MaxQueuePop시키고 최솟값 빼는거면 MinQueuePop시킨다.
                        {
                            MaxQueue = pop(MaxQueue);
                            size--;
                        }
                        else {
                            MinQueue = pop(MinQueue);
                            size--;
                        }
                    }
                }
            }

            if (size == 0)
                Console.WriteLine("EMPTY");
            else
                Console.WriteLine(-top(MaxQueue) + " " + top(MinQueue));
        }
    }
}
