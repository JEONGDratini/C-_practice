using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MooChin_humans_Server
{
    public partial class MuchinServer : Form
    {
        public MuchinServer()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Member_Information.Columns.Add("colNum", "번호");
            Member_Information.Columns.Add("authority", "회원권한");
            Member_Information.Columns.Add("userID", "회원아이디");
            Member_Information.Columns.Add("userName", "회원이름");
            Member_Information.Columns.Add("userNickName", "닉네임");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }



    }
}
