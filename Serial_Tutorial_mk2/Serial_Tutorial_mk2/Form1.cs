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


namespace Serial_Tutorial_mk2
{
    public partial class Form1 : Form
    {
        int count = 1;//DataGrid에 들어갈 번호값
        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            set_Port.DataSource = SerialPort.GetPortNames();
            measurement_result.Columns.Add("colNum", "번호");
            measurement_result.Columns.Add("colRes", "저항값");


        }

        private void Start_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = set_Port.Text;//포트 고른거 가져오기
            serialPort1.BaudRate = 9600;//통신속도
            serialPort1.DataBits = 8;//data bit
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;

            serialPort1.Open();//통신 열기
            timer1.Start();
 //           while()//종료버튼을 누르지 않는 한 계속 실행
 //           {
            que.Enqueue("MEAS:RES?\r\n");


//            }

        }

        bool rxOn = false;
        private async void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string ascii = "";
            string result = "";


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

                    string StrValue = Char.ConvertFromUtf32(value);
                    char charValue = (char)value;
                    result = result + charValue;
                }
            }
            rxOn = false;

            measurement_result.Rows.Add(count, result);//데이터그리드에 값집어넣기
        }

        private void Terminate_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
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
