using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding_Tutorial
{
    class Parent
    {
        public virtual void Method()//virtual를 붙여서 override로 재정의 될 수 있게 해준다.
        {
            Console.WriteLine("Parent Method");
        }
    }
    class Child : Parent //상속 
    {
        public override void Method()//override로 parent의 method()를 재정의한다.
        {
            Console.WriteLine("Child Method");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            child.Method();//child만 Method호출.
            ((Parent)child).Method();//child를 parent로 형변환한 뒤 Method호출.
            Console.ReadLine();
        }
    }
}
