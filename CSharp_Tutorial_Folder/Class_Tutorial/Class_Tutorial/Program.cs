using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Tutorial
{
    public class Customer
    {
        private string name;//필드 선언
        private int age;

        public event EventHandler NameChanged;//이벤트 생성

        public Customer()//생성자
        {
            name = string.Empty;
            age = -1;
        }

        //속성
        public string Name
        {
            get { return this.name; }
            set 
            {
                if (this.name != value)
                {
                    this.name = value;
                    if (NameChanged != null)
                    {
                        NameChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        //메서드
        public string GetCustomerData()
        {
            string data = string.Format("Name: {0} (Age: {1})",
                this.Name, this, Age);
            return data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer cus1 = new Customer();
            
        }
    }
}
