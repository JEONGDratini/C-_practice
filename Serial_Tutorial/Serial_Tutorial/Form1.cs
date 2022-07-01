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

namespace Serial_Tutorial
{
    public partial class Form1 : Form
    {
        static SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();   
        }

        private void set_Port_SelectedIndexChanged(object sender, EventArgs e)
        {//포트 이름 띄우기
            set_Port.DataSource = SerialPort.GetPortNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort.PortName = set_Port.Text;//포트 고른거 가져오기
            serialPort.BaudRate = 9600;//통신속도
            serialPort.DataBits = 8;//data bit
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;

            //Data받아오는거 핸들링할 객체
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_data_received);

            serialPort.Open();//통신 열고
            set_Port.Enabled = false;//포트설정박스 비활성화

            serialPort.Write("*IDN?\r\n");
        
        }

        //Data수신 받으면 실행됨.
        private void serialPort_data_received(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(SerialReceived));
        }

        private void SerialReceived(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
