using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer_Tutorial
{
    class Myclass
    {
        private const int MAX = 10;//최대 원소 개수 설정
        private string name;//이름 변수

        //class내부의 정수배열 data
        private int[] data = new int[MAX];

        //인덱서를 정의한다. 인덱스로 int 패러미터를 받아서 사용한다.
        public int this[int index]
        {
            get 
            {
                if (index < 0 || index >= MAX)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    //정수배열로부터 값 리턴한다.
                    return data[index];
                }
            }
            set 
            {
                if (!(index < 0 || index >= MAX))
                {
                    //정수배열 data에 값 저장.
                    data[index] = value;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Myclass cls = new Myclass();

            // 인덱서 set 사용해 값 설정.
            cls[1] = 1000;

            //인덱서 get 사용해 값 리턴받기. 사실 get함수를 좀 간단하게 구현할 수 있게 해주는 것 같다.
            int i = cls[1];
        }
    }
}
