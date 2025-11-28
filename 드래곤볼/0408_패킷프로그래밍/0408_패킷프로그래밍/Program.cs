using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace _0408_패킷프로그래밍
{
    
    public class Program // public으로 변경
    {
        private const string SERVER_IP = "220.90.180.111";
        public const int SERVER_PORT = 7000; // public으로 변경

        static void ServerTest()
        {
            MyServer1 server1 = new MyServer1();
            if (server1.Start(SERVER_PORT) == false)
                return;
            Console.WriteLine("서버 성공");
                
            Console.WriteLine();
            server1.Close();
            Console.WriteLine("서버종료");
        }
        static void ClientTest()
        {
            MyClient1 client1 = new MyClient1();
            if (client1.Start(SERVER_IP, SERVER_PORT) == false)
            {
                Console.WriteLine("서버 실패");
                return;
            }
            Console.WriteLine("서버 실행");

            while(true)
            {
                Console.Write("메세지 >>  ");
                string msg = Console.ReadLine();

                if (msg == string.Empty)
                    break;

                client1.SendData(msg);
                //byte[] data = Encoding.Default.GetBytes(msg);

            }

            client1.Close();
        }

        static void Main(string[] args)
        {
            ClientTest();            
        }
    }
}
