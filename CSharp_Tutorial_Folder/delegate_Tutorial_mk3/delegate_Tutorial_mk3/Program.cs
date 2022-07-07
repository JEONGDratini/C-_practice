using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_Tutorial_mk3
{
    class Sorting
    {
        //인수 2개를 받는 delegate 선언.
        public delegate int CompareDelegate(int i1, int i2);

        //위에서 선언한 형식의 메서드를 인수로 갖는 Sort 메서드 선언
        public static void Sort(int[] arr, CompareDelegate comd)
        {
            if (arr.Length < 2) return;

            //델리게이트로 가져온 메서드의 정보(반환값, 패러미터, 이름)을 출력한다.
            Console.WriteLine("함수 Prototype: " + comd.Method);

            int ret;
            for (int i = 0; i < arr.Length - 1; i++)//정렬 실행하는 2중 for문
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    ret = comd(arr[i], arr[j]);//가져온 함수에 비교할 두 int값을 집어넣는다.
                    if (ret == -1)//ret가 -1이면 각 비교값 사이의 교체가 필요하다는 뜻이다.
                    {
                        int tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }
            Display(arr);//정렬 끝난 뒤의 배열 출력함수 호출.
        }

        static void Display(int[] arr)//배열 출력함수 호출.
        {
            foreach (var i in arr) Console.Write(i + " ");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
            Console.ReadLine();
        }

        void run() //배열을 만들어서 각각 다른 메서드를 delegate로 넘겨서 다른 방식으로 정렬한다.
        {
            int[] a = { 5, 53, 2, 7, 1 };

            //오름차순 정렬 함수로 delegate 설정.
            Sorting.CompareDelegate compDelegate = AscendingCompare;
            Sorting.Sort(a, compDelegate);

            //내림차순 정렬 함수로 delegate 설정.
            compDelegate = DescendingCompare;
            Sorting.Sort(a, compDelegate);
        }

        //CompareDelegate와 같은 형식으로 선언한다.
        int AscendingCompare(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i2 - i1) > 0 ? 1 : -1;
        }

        //CompareDelegate와 같은 형식으로 선언한다.
        int DescendingCompare(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i1 - i2) > 0 ? 1 : -1;
        }
    }
}