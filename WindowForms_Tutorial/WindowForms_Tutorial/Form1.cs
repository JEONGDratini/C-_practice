using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowForms_Tutorial
{
    

    public partial class Form1 : Form
    {
        private Socket EY_Client = null;
        private TextBox txtSendMsg = null;
        private byte[] byteSendMsg = null;
        private byte[] byteReceiveMsg = null;
        private string strReceiveMsg = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EY_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            IPAddress ipServer = IPAddress.Parse("111.111.0.31");

            EY_Client.Connect(new IPEndPoint(ipServer, 3333));
        }

        private void CallBack_SendMsg(IAsyncResult ar)
        {

            EY_Client = (Socket)ar.AsyncState;

            int intSize = EY_Client.EndSend(ar);

            String strSendMsg = Encoding.Default.GetString(byteSendMsg, 0, intSize);

            EY_Client.BeginReceive(byteSendMsg, 0, byteSendMsg.Length, SocketFlags.None, new AsyncCallback(CallBack_ReceiveMsg), EY_Client);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSendMsg = textBox1;
            byteSendMsg = Encoding.Default.GetBytes(txtSendMsg.Text);

            EY_Client.BeginSend(byteSendMsg, 0, byteSendMsg.Length, SocketFlags.None, new AsyncCallback(CallBack_SendMsg), EY_Client);
        }

        private void CallBack_ReceiveMsg(IAsyncResult ar)
        {

            EY_Client = (Socket)ar.AsyncState;

            int intSize = EY_Client.EndReceive(ar);

            strReceiveMsg = Encoding.Default.GetString(byteReceiveMsg, 0, intSize);

        }


    }
}
