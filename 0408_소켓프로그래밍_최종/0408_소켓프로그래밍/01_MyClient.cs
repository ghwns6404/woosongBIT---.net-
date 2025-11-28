//01_MyClient
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace _0408_소켓프로그래밍
{
    internal class MyClient1 : IDisposable
    {
        private Socket socket = null;

        #region 1. Start 호출 시 소켓 생성 및 서버 연결, 수신thread 실행
        public bool Start(string ip, int port)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                Thread tr = new Thread(WorkThread);
                tr.IsBackground = true;
                tr.Start();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private void WorkThread()
        {
            byte[] data = new byte[1024];
            while (true)
            {
                try
                {
                    int ret = RecvData(data) ;
                    if(ret == 0)
                        throw new Exception("상대방이 소켓을 닫음");

                    //수신 정보 출력
		   string msg = Encoding.Default.GetString(data, 0, ret);
                   Console.WriteLine($"[수신] {msg}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("[recv 오류] " + e.Message);
                    break;
                }
            }            
        }


        #endregion 

        #region 2. Dispose 나 Close 호출 시 소켓 및 스레드 종료
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

        #region 3. 송수신
        public void SendData(string msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            int ret = socket.Send(data, data.Length, SocketFlags.None);
            Console.WriteLine($"\t\t보낸 바이트 : {ret}byte");
        }

        private int RecvData(byte[] data)
        {
            int ret = socket.Receive(data);
            return ret;
        }

        #endregion
    }
}
