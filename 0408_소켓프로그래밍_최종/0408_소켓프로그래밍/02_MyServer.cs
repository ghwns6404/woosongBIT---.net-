//MyServer1.cs
//다중 접속 1대 다통신
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

//[socket -> bind -> listen]
//[accept]
//[recv, send]
//[closesocket]
namespace _0408_소켓프로그래밍1
{
    internal class MyServer1 : IDisposable
    {
        private Socket server = null;
        private Thread work_thread = null;

        private List<Socket> clients = new List<Socket>();       

        #region 1. Start 호출 시 AcceptThread 동작
        public bool Start(int port)
        {
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, port));
                server.Listen(20);

                work_thread = new Thread(AcceptThread);
                work_thread.Start();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private void AcceptThread()
        {
            while (true)
            {
                try
                {
                    Socket socket = server.Accept();

                    //LocalEndPoint , RemoteEndPoint
                    IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                    Console.WriteLine("[클라이언트 접속] {0}:{1}", ip.Address, ip.Port);

                    clients.Add(socket);

                    Thread tr = new Thread(WorkThead);
                    tr.IsBackground = true;
                    tr.Start(socket);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[접속 오류] " + ex.Message);
                }
            }
        }
        #endregion

        #region 2. Dispose 나 Close 호출 시 소켓 및 스레드 종료
        ~MyServer1()
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
            work_thread.Abort();
            server.Close();
        }
        #endregion

        #region 3. 클라이언트 접속 시 통신 스레드
        private void WorkThead(object obj)
        {
            Socket sock = (Socket)obj;

            byte[] data = new byte[1024];
            while (true)
            {
                try
                {
                    int ret = RecvData(sock, data);
                    if (ret == 0)
                        throw new Exception("상대방이 소켓을 닫음");
                    //SendData(sock, data, ret);
                    SendAllData(sock, data, ret);
                }
                catch (Exception e)
                {
                    Console.WriteLine("[recv 오류] " + e.Message);
                    break;
                }
            }

            IPEndPoint ip = (IPEndPoint)sock.RemoteEndPoint;
            Console.WriteLine("[클라이언트 종료] {0}:{1}", ip.Address, ip.Port);

            sock.Close();           //****
            clients.Remove(sock);   //****
        }
        #endregion

        #region 4. 데이터 송 수신 
        private int RecvData(Socket socket, byte[] data)
        {
            int ret = socket.Receive(data);
            if (ret == 0)
                return 0;

            string msg = Encoding.Default.GetString(data, 0, ret);
            Console.WriteLine($"[수신] {msg}");
            return ret;
        }
        public void SendAllData(Socket sock, byte[] data, int size)
        {
            foreach (Socket s in clients)
            {
                //if(s != sock)         //본인에게 전달하지 않을 때 사용
                SendData(s, data, size);
            }
        }
        public void SendData(Socket sock, byte[] data, int size)
        {
            //byte[] data = Encoding.Default.GetBytes(msg);
            int ret = sock.Send(data, size, SocketFlags.None);
            Console.WriteLine($"\t\t보낸 바이트 : {ret}byte");
        }
        #endregion 
    }
}
