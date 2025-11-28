//App.cs
using System;
using System.Net;
using System.Net.Sockets;
using WoosongBit41.Packet;
using WoosongBit41.ServerNet;

namespace _0409_채팅서버
{
    internal class App
    {
        private const int SERVER_PORT   = 7000;
        private UserControl con = null;

        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        private App() {}
        #endregion

        #region 1. CallBack Message
        public void LogMessage(Socket socket, string message)
        {
            Console.WriteLine($"[log] {message}");

            if(socket != null)
            {
                //recv 오류   1: 상대방이 종료했을 때
                con.CloseUser(socket);
            }
        }
        public void PacketMessage(Socket socket, string message)
        {
            IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;

            string[] sp = message.Split('@');
            // 해당 ip 가 요청한 flag
            Console.WriteLine($"{ip.Address} : FLAG : {sp[0]}");

            #region 1. 데이터 파싱
            switch (int.Parse(sp[0]))
            {
                case Packet.PACKET_INSERTUSER:      con.UserInsert(socket      , sp[1]); break;
                case Packet.PACKET_LOGINUSER:       con.UserLogin(socket       , sp[1]); break;
                case Packet.PACKET_FINDUSER:        con.UserFind(socket        , sp[1]); break;
                case Packet.PACKET_CALLUSER_ACK:    con.UserCall(socket        , sp[1]); break;
                case Packet.PACKET_SENDMESSAGEUSER: con.UserSendMessage(socket , sp[1]); break;
                case Packet.PACKET_EXITUSER:        con.UserExit(socket);                break;
                case Packet.PACKET_SENDALLUSER:     con.UserSendAll(socket     , sp[1]); break;
                case Packet.PACKET_DELETEUSER:      con.UserDelete(socket      , sp[1]); break;
                default:   Console.WriteLine("없는 flag 입니다");                       break;
            }
            #endregion
        }
        #endregion

        #region 2. 시작 , 실행 , 종료
        public void Init()
        {
            con = UserControl.Singleton;

            MyServer.Singleton.Start(SERVER_PORT , LogMessage , PacketMessage);
            UserControl.Singleton.Init();
        }

        public void Exit()
        {
            Console.ReadLine();
            UserControl.Singleton.Exit();
        }
        #endregion
    }
}
