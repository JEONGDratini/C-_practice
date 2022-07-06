using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Thread_Tutorial
{
    public partial class Form1 : Form
    {
        private Thread th;//스레드 선언
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(run));//delegate 타입으로 전달한다.
            th.Start();

        }

        private void run() 
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                setText();//setText함수를 1초마다 실행한다.
            }
        }

        delegate void StringArgReturningVoidDelegete();//delegate 정의.

        private void setText()
        {
            if (this.textBox1.InvokeRequired)
            {
                //델리게이트 선언 및 인보크
                StringArgReturningVoidDelegete d = new StringArgReturningVoidDelegete(setText);
                this.Invoke(d, new object[] { });
            }
            else 
            {
                //현재시간을 textbox의 newline으로 출력
                this.textBox1.Text += "Now Time is " + DateTime.Now + Environment.NewLine;
            }
        }

        private void setText2()
        {
            if (this.textBox1.InvokeRequired)
            {
                //델리게이트 선언 및 인보크
                StringArgReturningVoidDelegete d = new StringArgReturningVoidDelegete(setText2);
                this.Invoke(d, new object[] { });
            }
            else
            {
                //현재시간을 textbox의 newline으로 출력
                this.textBox1.Text += "Button2_Clicked!!!" + Environment.NewLine;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) 
        {
            th.Abort();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            setText2();
        }
    }
}
