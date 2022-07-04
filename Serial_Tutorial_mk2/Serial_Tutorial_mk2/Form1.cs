using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Text;


namespace Serial_Tutorial_mk2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            set_Port.DataSource = SerialPort.GetPortNames();

        }

        private void Start_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = set_Port.Text;//포트 고른거 가져오기
            serialPort1.BaudRate = 9600;//통신속도
            serialPort1.DataBits = 8;//data bit
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;

            serialPort1.Open();//통신 열기





        }

        private void Terminate_Click(object sender, EventArgs e)
        {

        }

        bool txOn = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (que.Count > 0)
            {
                while (rxOn)
                {
                    await Task.Delay(1);
                }
                txOn = true;
                serialPort1.Write(que.Dequeue());
                txOn = false;
            }
            timer1.Start();
        }


    }
}
