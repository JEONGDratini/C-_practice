using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//시간초과도 아니고 질문게에 있는 테스트케이스 출력도 다 맞는데 왜 오답이죠..?
//아웃풋은 맞는데 오답인거 3번째다 3번째 이히힣히 이번엔 시간초과도 메모리 초과도 아니래 걍 아웃풋이 틀렸대
//근데 어딜 뒤져봐도 반례가 안보이네? 이히ㅣ히힣히히히힣히
//정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 
//정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 
//정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 정신 나갈 것 같아 

namespace BaekJoon_7662_HeapTree_ver
{
    public class BinaryHeap//이미 만들어놓은 이진힙 클래스 가지고와서 코드 우려먹기
    {
        private List<int> A = new List<int>();

        public void Add(int value)
        {
            // add at the end
            A.Add(value);

            // bubble up
            int i = A.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (A[parent] < A[i]) // MinHeap에선 반대
                {
                    Swap(parent, i);
                    i = parent;
                }
                else
                {
                    break;
                }
            }
        }

        public int RemoveOne()
        {
            if (A.Count == 0)
                throw new InvalidOperationException();

            int root = A[0];

            // move last to first 
            // and remove last one
            A[0] = A[A.Count - 1];
            A.RemoveAt(A.Count - 1);

            // bubble down
            int i = 0;
            int last = A.Count - 1;
            while (i < last)
            {
                // get left child index
                int child = i * 2 + 1;

                // use right child if it is bigger                
                if (child < last &&
                    A[child] < A[child + 1]) // MinHeap에선 반대
                    child = child + 1;

                // if parent is bigger or equal, stop
                if (child > last ||
                   A[i] >= A[child]) // MinHeap에선 반대
                    break;

                // swap parent/child
                Swap(i, child);
                i = child;
            }

            return root;
        }

        public int Heap_Size() {
            return A.Count;
        }

        private void Swap(int i, int j)
        {
            int t = A[i];
            A[i] = A[j];
            A[j] = t;
        }
    }

    class Program
    {
        static int K;//테스트 케이스 숫자

        static void Main(string[] args)
        {
            K = int.Parse(Console.ReadLine());
            for (int i = 0; i < K; i++)
                Solution();
        }

        static void Solution() {
            int N = int.Parse(Console.ReadLine());
            int size = 0;//최대힙, 최소힙 1개씩 사용할 것이므로 size를 사용한다.
            BinaryHeap MaxHeap = new BinaryHeap();//최대힙
            BinaryHeap MinHeap = new BinaryHeap();//최소힙

            for (int i = 0; i < N; i++) { 
                string[] raw_data = Console.ReadLine().Split(' ');
                int num = int.Parse(raw_data[1]);
                if (raw_data[0].Equals("I"))
                {//삽입. 
                    MaxHeap.Add(num);
                    MinHeap.Add(-num);
                    size++;
                }
                else {
                    if (size == 0)
                        continue;
                    else if (size == 1) {
                        MinHeap.RemoveOne();
                        MaxHeap.RemoveOne();
                        size--;
                    }
                    else
                    {
                        if (num == 1)//큐에서 힙으로 바뀐 것 빼면 듀얼큐버전과 다른건 없다.
                        {
                            if (MaxHeap.Heap_Size() == 0)
                                continue;
                            MaxHeap.RemoveOne();
                            size--;
                        }
                        else
                        {
                            MinHeap.RemoveOne();
                            size--;
                        }
                    }
                }
            }

            if (size == 0)
                Console.WriteLine("EMPTY");
            else
                Console.WriteLine(MaxHeap.RemoveOne() + " " + -MinHeap.RemoveOne());

        }
    }
}
