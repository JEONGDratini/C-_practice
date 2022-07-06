using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//구조체 첫 실습
namespace Structure_Tutorial
{
    class Program
    {
        //구조체는 클래스처럼 선언할 수 있지만 상속은 불가능하다. 
        //하지만 인터페이스로 구현하는 것은 가능하다.
        struct ex_Struct
        {
            public int x;
            public int y;

            public ex_Struct(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1})", x, y);
            }
        }
        static void Main(string[] args)
        {
            ex_Struct pt = new ex_Struct(10, 12);
            Console.WriteLine(pt.ToString());
            Console.ReadKey();
        }
    }
}
