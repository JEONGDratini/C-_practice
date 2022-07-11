using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n_h = 6;
            int h = 3 * n_h * (n_h - 1) - (n_h - 1) * (n_h - 2) - (n_h - 2);
            Console.WriteLine(h);
            Console.ReadLine();
        }
    }
}
