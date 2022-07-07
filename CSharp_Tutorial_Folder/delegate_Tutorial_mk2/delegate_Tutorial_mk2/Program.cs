//동일한 패러미터와 반환값을 가진 다른 메서드로 교체해 델리게이트를 사용하는 법 예시

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_Tutorial_mk2
{
    class Del
    {
        //델리게이트 선언.
        private delegate void RunningDelegate(int i);

        private void RunThis(int val)
        {
            Console.WriteLine("{0}", val);
            //10진수 출력.
        }
          
        private void RunThat(int value)
        {
            Console.WriteLine("0x{0:X}", value);
            //16진수 출력
        }

        public void Perform()
        {
            //델리게이트 인스턴스 생성.
            RunningDelegate run = new RunningDelegate(RunThis);
            run(1024);//인스턴스 실행.

            run = RunThat;//실행되는 메서드 교체
            run(1024);//인스턴스 실행.
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Del dl = new Del();//클래스 객체 만들기
            dl.Perform();//클래스의 perform 메서드 호출해 델리케이트 인스턴스 생성.
            Console.ReadLine();
        }
    }
}
