using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

//socket >> bind >> listen >>
//accept >>
//recv >> send >>
//closesocket
namespace _0408_패킷프로그래밍
{
    class MyServer1 : IDisposable
    {
        private Socket server       = null; //소켓 객체를 담을 변수 선언
        private Thread work_thread  = null; //스레드 객체를 담을 변수 선언

        #region  1.호출시 AcceptThread() 메서드 실행 (동작)
        public bool Start(int port)
        {
            try
            {
                server = new Socket(AddressFamily.InterNetwork,
                                       SocketType.Stream,           //스트림 방식
                                       ProtocolType.Tcp);           //TCP 방식
                server.Bind(new IPEndPoint(IPAddress.Any, port));
                server.Listen(10); //대기열의 길이 설정

                work_thread = new Thread(AcceptThread); //스레드 객체 생성
                work_thread.Start(); //스레드 시작

                //work_thread.Join();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("서버 시작 실패 : " + ex.Message);
                return false;
            }
        }

        public void AcceptThread()
        {
            while (true)
            {
                try
                {
                    Socket socket = server.Accept();

                    IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                    //LocalEndPoint은 서버의 주소, 내꺼 
                    //RemoteEndPoint는 클라이언트의 주소, 상대방꺼                 
                    Console.WriteLine("클라 접속. {0}:{1}", ip.Address, ip.Port);

                    Thread tr = new Thread(WorkThread);
                    tr.IsBackground = true;
                    tr.Start(socket);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("접속오류" + ex.Message);
                    continue;
                }
            }
        }
        #endregion

        #region 1. Dispose나 Close호출시 메서드 실행,종료
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

        #region 2. 클라이언트 섭속 시 통신 스레드
        private void WorkThread(object obj)
        {
            Socket socket = (Socket)obj;
            byte[] data = new byte[1024];
            while (true)
            {
                try
                {
                    if (RecvData(socket, data) == 0)
                        throw new Exception("recvData 실패");
                    SendData(socket, data, ret);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("recv오류" + ex.Message);
                    break;
                }
            }
            IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
            //LocalEndPoint은 서버의 주소, 내꺼 
            //RemoteEndPoint는 클라이언트의 주소, 상대방꺼                 
            Console.WriteLine("클라 종료. {0}:{1}", ip.Address, ip.Port);
        }
        #endregion

        #region 4 .송수신
        private int RecvData(Socket socket, byte[] data)
        {
            int ret = server.Receive(data);
            if (ret == 0)
                return 0;

            string msg = Encoding.Default.GetString(data, 0, ret);
            Console.WriteLine($"수신 {msg}");
            
            return ret;
        }
        #endregion
    }
}
