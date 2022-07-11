using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPIP_Tutorial_client
{
    class UI : Form
    {
        static void Main(string[] args)
        {
            UI form = new UI();

            UI.Click += new EventHandler((sender, EventArgs) =>
            {
                Console.WriteLine("Closing window...");
                Application.Exit();
            });

            Console.WriteLine("Start Window Application...");
            Application.Run(form);

            Console.WriteLine("Exiting Window Application");
        }
    }
}
