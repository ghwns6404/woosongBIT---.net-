//App.cs
using System;
using System.Net.Sockets;
using System.Threading;
using WoosongBit41.ClientNet;
using WoosongBit41.Lib;
using WoosongBit41.Packet;
using WoosongBit41.UI;


namespace _0410_채팅클라이언트
{
    internal class App
    {
        //private const string SERVER_IP = "192.168.35.88";
        private const string SERVER_IP = "220.90.180.108";
        private const int SERVER_PORT   = 7000;

        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        private App() {}
        #endregion

        #region 1. CallBack Message

        public static void LogMessage(Socket sock, string message)
        {
            Console.WriteLine($"[log] {message}");
        }
        public static void PacketMessage(Socket sock, string message)
        {
            //2. 패킷 파싱(분석)
            string[] sp = message.Split('@');

            //3. 분석 분할 처리
            switch (int.Parse(sp[0]))
            {
                case Packet.PACKET_INSERTUSER_ACK:      Packet.InsertUserAck(sp[1]);      break;
                case Packet.PACKET_LOGINUSER_ACK:       Packet.LoginUserAck(sp[1]);       break;
                case Packet.PACKET_FINDUSER_ACK:        Packet.FindUserAck(sp[1]);        break;
                case Packet.PACKET_CALLUSER:            CallAckUser.Invoke(sp[1]);        break;
                case Packet.PACKET_SENDMESSAGEUSER_ACK: Packet.SendMessageUserAck(sp[1]); break;
                case Packet.PACKET_EXITUSER_ACK:        Packet.ExitUserAck(sp[1]);        break;
                case Packet.PACKET_SENDALLUSER_ACK:     Packet.SendAllUserAck(sp[1]);     break;
                case Packet.PACKET_DELETEUSER_ACK:      Packet.DeleteUserAck(sp[1]);      break;
                default:   Console.WriteLine("없는 flag 입니다");    break;
            }
        }
        #endregion

        #region 2. 시작 , 실행 , 종료
        public void Init()
        {

            MyClient.Singleton.Start(SERVER_IP , SERVER_PORT , LogMessage , PacketMessage);
            UserControl.Singleton.Init();

            WbLib.Logo();
        }
        public void Run()
        {
            try
            {
                First();

                while (true)
                {
                    Second();
                    Third();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        public void First()
        {
            try
            {
                while (MyClient.MyUser.Name == null)
                {
                    Console.Clear();
                    switch (WbLib.First_Screen())
                    {
                        case ConsoleKey.Escape: throw new Exception("프로그램 종료");
                        case ConsoleKey.F1: InsertUser.Invoke(); break; // 회원가입
                        case ConsoleKey.F2: LoginUser.Invoke(); break;  // 로그인
                        case ConsoleKey.F3: DeleteUser.Invoke(); break; // 회원탈퇴
                        default: Console.WriteLine("잘못 입력하셨습니다."); break;
                    }
                    Thread.Sleep(30);
                    WbLib.Pause();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Second()
        {
            try
            {
  
                {
                    Console.Clear();
                    switch (WbLib.Second_Screen())
                    {
                        case ConsoleKey.Escape: throw new Exception("프로그램 종료");
                        case ConsoleKey.F1: FindUser.Invoke(); break; // 통신 대상 찾기
                        case ConsoleKey.F2: return;                   // 메세지 전송 화면
                        case ConsoleKey.F9: break;                    // 수락
                        case ConsoleKey.F10: break;                   // 종료
                        default: Console.WriteLine("잘못 입력하셨습니다."); break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Third()
        {
            try
            {
                while (MyClient.MyUser.Connect)
                {
                    Console.Clear();
                    string message = WbLib.Third_Screen();
                    string[] sp = message.Split(':');
                    switch (sp[0])
                    {
                        case "공지사항": SendAllUser.Invoke(sp[1]);     break;   // 통신 대상 찾기
                        case "나가기":   ExitUser.Invoke();            return;   // Second로 return
                        case "":                                       break;    // 예외 처리
                        default:        SendMessageUser.Invoke(sp[0]); break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Exit()
        {
            UserControl.Singleton.Exit();
            WbLib.Ending();
        }
        #endregion
    }
}
