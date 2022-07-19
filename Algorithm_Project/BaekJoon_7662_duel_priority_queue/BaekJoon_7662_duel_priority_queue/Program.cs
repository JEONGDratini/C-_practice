using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 7662번 이중우선순위 큐 골드4

//이미 만들어놨던 우선순위 큐를 조금 손보면 될듯함. 뭐 안되면 로직 새로짜야징..ㅠ
//그래서 새로짜는 중;;ㅎㅎ!!
//아웃풋은 맞는데 이진탐색을 써도 시간이 너무 오래걸린대요..ㅠ
//자료구조가 비효율적인 것 같아 다른 방식을 사용해보겠습니다.
//근데 탐색시간이 O(logN)인데 이게 시간초과가 뜨네..ㄷ
//왜냐하면 List의 RemoveAt 함수가 O(N)이기 때문이지



namespace BaekJoon_7662_List_BinarySearch_ver
{
    class Program
    {
        static int K;//테스트 케이스 숫자       
        static List<string> Result = new List<string>();//결과 문자열들 담을 리스트

        static void Main(string[] args)
        {
            K = int.Parse(Console.ReadLine());
            for (int i = 0; i < K; i++)
                Solution();
            for (int i = 0; i < K; i++)
                Console.WriteLine(Result[i]);
        }
        
//Priority queue를 List로 선언하고 원소를 추가, 삭제하면서 새로 집어넣을 원소 위치는 이진탐색알고리즘으로 찾는다.
        static void Solution() {
            int N = int.Parse(Console.ReadLine());
            List<int> Priority_Queue = new List<int>();

            for (int i = 0; i < N; i++)
            {
                string[] raw_data = Console.ReadLine().Split(' ');
                int num = int.Parse(raw_data[1]);
                if (raw_data[0].Equals("I"))
                {//삽입명령이면
                    if (Priority_Queue.Count() == 0)//큐에 원소가 아무것도 없을 때는 그냥 원소 바로추가
                        Priority_Queue.Add(num);
                    else if (Priority_Queue.Count() >= 1)
                    {// 큐에 원소가 존재할 때는 이진탐색으로 적절한 위치를 찾아 삽입한다.
                        int index = BinarySearch(Priority_Queue, Priority_Queue.Count(), num);//이진탐색으로 인덱스 찾기
                        Priority_Queue.Insert(index, num);//찾은 인덱스에 값 집어넣기
                    }
                }
                else if (raw_data[0].Equals("D"))
                { //원소 추출명령이면
                    if (Priority_Queue.Count != 0)
                    {//다 끝나고 출력시킬 EMPTY갯수를 1개 추가한다.
                        if (num == 1)//최댓값 삭제 연산
                            Priority_Queue.RemoveAt(Priority_Queue.Count - 1);
                        else if (num == -1)//최솟값 삭제 연산
                            Priority_Queue.RemoveAt(0);
                    }
                }
            }
            //연산하고 나서 최대, 최소값 출력하기
            if (Priority_Queue.Count() == 0)
                Result.Add("EMPTY");
            else
                Result.Add(Priority_Queue[Priority_Queue.Count()-1] + " " + Priority_Queue[0]); 
        }

//원소 삽입에 적당한 index를 찾는 이진탐색 알고리즘
        static int BinarySearch(List<int> List, int size, int Find_Num) {//이진탐색 구현.
            int low = 0, high = size - 1, mid = -1;
            bool Case = false;//마지막 비교결과를 확인하기 위한 변수. 마지막 비교값보다 Find_Num이 작으면 false, 크면 ture반환
           
            while (low <= high) {
                mid = (low + high) / 2;

                if (List[mid] > Find_Num){
                    high = mid - 1;
                    Case = false;
                }
                else if (List[mid] < Find_Num){
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

