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
            set_Port.DataSource = SerialPort.GetPortNames();//포트이름 가져오기
            measurement_result.Columns.Add("colNum", "번호");//datagrid에 컬럼 집어넣기
            measurement_result.Columns.Add("colRes", "저항값");


        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (set_Port.Enabled)//연결이 안돼있으면 연결하고 이미 연결 돼있으면 타이머만 다시 시작한다.
            {
                serialPort1.PortName = set_Port.Text;//포트 고른거 가져오기
                serialPort1.BaudRate = 9600;//통신속도
                serialPort1.DataBits = 8;//data bit
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                serialPort1.Open();//통신 열기

                label1.Text = "현재상태 : 연결됨";
                set_Port.Enabled = false;
            }
            timer1.Start();

        }


        private void DataReceived(object sender, SerialDataReceivedEventArgs e)//시리얼 Data받았을 때 실행
        {
            this.Invoke(new EventHandler(serialReceived));//this -> form이다. invoke를 사용해서 스레드 충돌이 일어나지 않도록 해준다.
        }

        private void serialReceived(object sender, EventArgs e)//DataReceived에서 invoke로 호출한다.
        {
            string ascii = "";
            string result = "";

            while (true)// \n개행문자가 감지되면 수신을 종료하도록 설정.
            {
                bool Is_End = false;//개행문자 여부 불린값
                int get_Data = serialPort1.ReadByte();//시리얼 포트에 수신된 데이터를 읽는다.1개 바이트만 읽는다.
                ascii = ascii + string.Format("{0:X2}", get_Data) + " ";//스플릿 할 수 있게 각 바이트마다 띄어쓰기로 구분한다.
                Is_End = ascii.Contains("0A");//\n의 16진수 표현 검색
                if (Is_End)//개행문자 있으면 break;
                    break;
            }

            string[] hexValues = ascii.Split(' ');

            foreach (String hex in hexValues)
            {
                if (hex.Length > 0)//확인해보니까 hexvalues 배열의 크기가 실제 존재하는 아스키코드 문자 갯수보다 1개 많아서 오류가 남 -> 해결용 조건문
                {
                    int value = Convert.ToInt32(hex, 16);//16진수 hex값을 10진수로 바꾼다. 

                    char charValue = (char)value;//10진수값을 아스키코드 변환을 한다.
                    result = result + charValue;
                }
            }

            measurement_result.Rows.Add(count, result + " Ω");//데이터그리드에 값집어넣기
            count++;
        }

        private void Stop_Click(object sender, EventArgs e)//정지버튼 눌렀을 때
        {      
            timer1.Stop();
        }

        private async void timer1_Tick(object sender, EventArgs e)//타이머 지정시간 경과때 마다 실행
        {
            serialPort1.Write("MEAS:RES?\r\n");
        }

        private void terminate_Click(object sender, EventArgs e)//리셋버튼 눌렀을 때
        {
            serialPort1.Close();
            timer1.Stop();
            label1.Text = "현재상태 : 연결안됨";
            set_Port.Enabled = true;
            measurement_result.Rows.Clear();
            count = 1;
        }

    }
}
