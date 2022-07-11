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

namespace Serial_Tutorial
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {//포트 이름 띄우기
            set_Port.DataSource = SerialPort.GetPortNames();
            Send.Enabled = false;//연결하기 전에 전송하는 것 방지
        }

        private void button1_Click(object sender, EventArgs e)
        {//시리얼 포트에 텍스트 전송.

            que.Enqueue(textBox1.Text + "\r\n");
        }

        //Data수신 받으면 실행됨.
        bool rxOn = false;
        private async void SerialReceived(object sender, EventArgs e)
        {
            string ascii = "";
            string text = "";
            int count = 1;//while문 폭주 방지용

            while (txOn)
            {
                await Task.Delay(1);
            }
            rxOn = true;
            while (true)// \n개행문자가 감지되면 수신을 종료하도록 설정.
            {
                bool Is_End = false;//개행문자 여부 불린값
                int get_Data = serialPort1.ReadByte();//시리얼 포트에 수신된 데이터를 읽는다.1개 바이트만 읽는다.
                ascii = ascii + string.Format("{0:X2}", get_Data) + " ";//스플릿 할 수 있게 각 바이트마다 띄어쓰기로 구분한다.
                Is_End = ascii.Contains("0A");//\n의 16진수 표현 검색
                if (Is_End)//개행문자 있으면 break;
                    break;
                count++;
            }
            string[] hexValues = ascii.Split(' ');

            foreach (String hex in hexValues)
            {
                if (hex.Length > 0)//확인해보니까 hexvalues 배열의 크기가 실제 존재하는 아스키코드 문자 갯수보다 1개 많아서 오류가 남 -> 해결용 조건문
                {
                    int value = Convert.ToInt32(hex, 16);

                    char charValue = (char)value;
                    text = text + charValue;
                }
                //richTextBox1.Text = richTextBox1.Text + hex+ ".";
            }
            richTextBox1.Text = richTextBox1.Text + text;//읽어온걸 형변환 시켜서 볼 수 있게 한다.
            rxOn = false;
        }


        private void Connect_Click(object sender, EventArgs e)
        {

            serialPort1.PortName = set_Port.Text;//포트 고른거 가져오기
            serialPort1.BaudRate = 9600;//통신속도
            serialPort1.DataBits = 8;//data bit
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;

            serialPort1.Open();//통신 열고
            set_Port.Enabled = false;//포트설정박스 비활성화
            Send.Enabled = true;//연결이 되었으니 전송버튼 활성화
            Connection_State.Text = "연결됨";
            timer1.Start();

        }

        private void Close_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            richTextBox1.Clear();
            set_Port.Enabled = true;//포트설정박스 활성화
            Send.Enabled = false;//연결하기 전에 전송하는 것 방지
            Connection_State.Text = "연결해제됨";
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(SerialReceived));
        }

        Queue<string> que = new Queue<string>();
        bool txOn = false;
        private async void timer1_Tick(object sender, EventArgs e)
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


