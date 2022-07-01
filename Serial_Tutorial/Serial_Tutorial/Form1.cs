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
            serialPort1.PortName = set_Port.Text;//포트 고른거 가져오기
            serialPort1.BaudRate = 9600;//통신속도
            serialPort1.DataBits = 8;//data bit
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;

            //Data받아오는거 핸들링할 객체
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort_data_received);

            serialPort1.Open();//통신 열고
            set_Port.Enabled = false;//포트설정박스 비활성화

            serialPort1.Write("*IDN?\r\n");
        
        }

        //Data수신 받으면 실행됨.
        private void serialPort_data_received(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(SerialReceived));
        }

        private void SerialReceived(object sender, EventArgs e)
        {
            int get_Data = serialPort1.ReadByte();//시리얼 포트에 수신된 데이터를 읽는다.
            richTextBox1.Text = richTextBox1.Text + string.Format("{0:X2}", get_Data);//읽어온걸 형변환 시켜서 볼 수 있게 한다.
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
