using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _0408_패킷프로그래밍
{
    class MyClient1 : IDisposable
    {
        private Socket socket = null;
        public bool Start(string ip, int port)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork,
                               SocketType.Stream,
                               ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #region 1. Dispose나 Close호출시 메서드 실행,종료
        ~MyClient1()
        {
            Dispose();
        }
        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }
        public void Close()
        {
            socket.Close();
        }
        #endregion

        
        #region  3.송수신
        public void SendData(Socket socket, byte[] data, int size)
        {
            //byte[] data = System.Text.Encoding.Default.GetBytes(msg);
            int ret = socket.Send(data, data.Length, SocketFlags.None); //변경
            Console.WriteLine($"\t\t보낸 바이트 : {ret}byte");
        }
        #endregion

    }

}
