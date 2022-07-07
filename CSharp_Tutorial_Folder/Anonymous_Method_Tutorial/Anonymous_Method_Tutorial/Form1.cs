using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anonymous_Method_Tutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //메서드 명을 따로 지정한다.
            this.button1.Click += new System.EventHandler(this.button1_Click);

            //그 자리에서 무명메서드를 지정한다.
            this.button2.Click += delegate(object s, EventArgs e)//반환값과 매개변수 지정.
            {//메서드 내용
                MessageBox.Show("button2 Clicked");
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1 Clicked");
        }
    }
}
