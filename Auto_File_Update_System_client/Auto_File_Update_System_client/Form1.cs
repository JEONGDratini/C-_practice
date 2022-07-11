using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_File_Update_System_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "test";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("이름 : 홍길동");
            sb.AppendLine("이름 : 응애");
        }
    }
}
