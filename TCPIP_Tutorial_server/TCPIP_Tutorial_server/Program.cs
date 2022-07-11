using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPIP_Tutorial_server
{

    class ChatServer

    {

        private Socket ListenSocket = null;//소켓 객체 초기화

        private bool bSocketEnd = false;//소켓 끝나는 여부 불린값 변수


 

        public ChatServer()
        {

            ListenSocket = null;

        }

 

        public void Start_Server()
        {

            ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);//소켓 객체 생성.

            int intPortNum = 3333;//포트넘버 설정

            ListenSocket.Bind(new IPEndPoint(IPAddress.Any, intPortNum));

 

            IPHostEntry host = Dns.GetHostEntry("localhost");//호스트 이름 도메인 확인

            IPAddress ipAddr = Dns.GetHostEntry("localhost").AddressList[0];//로컬 호스트 도메인의 첫번째 ip주소 가져오기.

            Console.WriteLine("[Minyong_SERVER Ver0.01] : Computer Name :  {0} {1}", host.HostName, ipAddr);//호스트 

            Console.WriteLine("[Minyong_SERVER Ver0.01] : 서버가 시작되었습니다. ( Port Number : {0} )", intPortNum);

            

            ListenSocket.Listen(3);

 

            while (bSocketEnd == false)
            {
                Socket ClientSocket = (Socket)ListenSocket.Accept();

                Console.WriteLine("[Minyong_SERVER Ver0.01] : Client 접속 IP Addr : {0} ",ClientSocket.RemoteEndPoint);
                
                ClientSocket.BeginReceive(byteReceiveMsg, 0, 1024, SocketFlags.None, new AsyncCallback(CallBack_ReceiveMsg), ClientSocket);

             }
        }

        private void CallBack_ReceiveMsg(IAsyncResult ar)
        {

            Socket ClientSocket = (Socket)ar.AsyncState;

            int intSize = ClientSocket.EndReceive(ar);

            string strReceiveMsg = Encoding.Default.GetString(byteReceiveMsg, 0, intSize);

            Console.WriteLine("[미뇽서버 Ver0.09] : Receive - {0}", strReceiveMsg);

            ClientSocket.BeginSend(byteSendMsg, 0, byteSendMsg.Length, SocketFlags.None, new AsyncCallback(CallBack_SendMsg), ClientSocket);

        }

        private void CallBack_SendMsg(IAsyncResult ar)
        {

            Socket ClientSocket = (Socket)ar.AsyncState;

            int intSize = ClientSocket.EndSend(ar);

            string strSendMsg = Encoding.Default.GetString(byteSendMsg, 0, intSize);

            ClientSocket.BeginReceive(byteReceiveMsg, 0, 1024, SocketFlags.None, new AsyncCallback(CallBack_ReceiveMsg), ClientSocket);

        }



         
        static void Main(string[] args)
        {
            ChatServer tut_Chatserver = new ChatServer();
            tut_Chatserver.Start_Server();


        }

    }
}
