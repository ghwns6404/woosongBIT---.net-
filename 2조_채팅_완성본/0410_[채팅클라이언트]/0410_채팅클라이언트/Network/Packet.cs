//Packet.cs
using System;
using WoosongBit41.ClientNet;
using WoosongBit41.Lib;

namespace WoosongBit41.Packet
{
    internal static class Packet
    {
        private const int X_POS = 30;
        private const int Y_POS = 3;
        #region FLAG
        public const int PACKET_INSERTUSER          = 1;  // 회원 정보 추가 ( string id , string pw , string name )
        public const int PACKET_INSERTUSER_ACK      = 11;

        public const int PACKET_LOGINUSER           = 2;  // 로그인 ( string id , string pw )
        public const int PACKET_LOGINUSER_ACK       = 21;

        public const int PACKET_FINDUSER            = 3;  // 상대방에게 통신여부 전송 ( 찾고자 하는 사람 )
        public const int PACKET_FINDUSER_ACK        = 31; // 상대방이 승낙했는지 받음

        public const int PACKET_CALLUSER            = 4;  // 서버 -> 클라 ( 통신을 원하는 사람의 이름 )
        public const int PACKET_CALLUSER_ACK        = 41; // 클라 -> 서버 ( 통신할지 말지 bool flag , 오류 string info , 상대방 이름 )

        public const int PACKET_SENDMESSAGEUSER     = 5;  // 상대방에게 메세지 전송 ( 본인 이름 , 메세지 내용 )
        public const int PACKET_SENDMESSAGEUSER_ACK = 51;

        public const int PACKET_EXITUSER            = 6;  // 채팅방을 나갈 때 전송
        public const int PACKET_EXITUSER_ACK        = 61;

        public const int PACKET_SENDALLUSER         = 7;  // 공지사항 ( 본인 이름 , 메세지 )
        public const int PACKET_SENDALLUSER_ACK     = 71;

        public const int PACKET_DELETEUSER          = 8;  // 회원 탈퇴 (  id , pw )
        public const int PACKET_DELETEUSER_ACK      = 81;
        #endregion

        #region Client -> Server
        public static string InsertUser(string name)
        {
            string packet = PACKET_INSERTUSER + "@";

            packet += name;

            return packet;
        }
        public static string LoginUser(string name)
        {
            string packet = PACKET_LOGINUSER + "@";

            packet += name;

            return packet;
        }
        public static string FindUser(string name)
        {
            string packet = PACKET_FINDUSER + "@";

            packet += name;

            return packet;
        }
        public static string CallUserAck(bool flag, string info, string send_name)
        {
            string packet = PACKET_CALLUSER_ACK + "@";

            packet += flag + "#";
            packet += info + "#";
            packet += send_name;

            return packet;
        }
        public static string SendMessageUser(string myname , string message)
        {
            string packet = PACKET_SENDMESSAGEUSER + "@";

            packet += myname + "#";
            packet += message;

            return packet;
        }
        public static string ExitUser()
        {
            string packet = PACKET_EXITUSER + "@";

            return packet;
        }
        public static string SendAllUser(string myname ,string message)
        {
            string packet = PACKET_SENDALLUSER + "@";

            packet += myname  + "#";
            packet += message;

            return packet;
        }
        public static string DeleteUser(string name)
        {
            string packet = PACKET_DELETEUSER + "@";

            packet += name;

            return packet;
        }
        #endregion

        #region Server -> Client
        public static void InsertUserAck(string msg)
        {
            string[] sp = msg.Split('#');

            bool flag = bool.Parse(sp[0]);
            string info = sp[1];
            string name = sp[2];

            if (flag)
            {
                Console.SetCursorPosition(X_POS, Y_POS);
                Console.WriteLine($"{name} : 회원가입이 성공했습니다");
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                Console.SetCursorPosition(X_POS, Y_POS);
                Console.WriteLine($"INSERT ERROR : {info}");
                Console.SetCursorPosition(0, 0);
            }
        }
        public static void LoginUserAck(string msg)
        {
            string[] sp = msg.Split('#');

            bool flag = bool.Parse(sp[0]);
            string info = sp[1];
            string name = sp[2];

            if (flag)
            {
                Console.SetCursorPosition(X_POS, Y_POS);
                Console.WriteLine($"{name} : 로그인에 성공했습니다");
                Console.SetCursorPosition(0, 0);
                MyClient.MyUser.Name = name;
            }
            else
            {
                Console.SetCursorPosition(X_POS, Y_POS);
                Console.WriteLine($"LOGIN ERROR : {info} ");
                Console.SetCursorPosition(0, 0);
            }

        }
        public static void FindUserAck(string msg)
        {
            string[] sp = msg.Split('#');

            bool flag = bool.Parse(sp[0]);
            string info = sp[1];
            string name = sp[2];

            if (flag)
            {
                Console.SetCursorPosition(X_POS, Y_POS -1);
                Console.WriteLine($"{name}과 연결에 성공했습니다");
                Console.SetCursorPosition(0, 0);
                MyClient.MyUser.Connect = true;
            }
            else
            {
                Console.SetCursorPosition(X_POS, Y_POS);
                Console.WriteLine($"FIND ERROR : {info} ");
                Console.SetCursorPosition(0, 0);
            }

            return ;
        }
        public static void SendMessageUserAck(string msg)
        {
            string[] sp = msg.Split('#');

            bool     flag    = bool.Parse(sp[0]);
            string   info    = sp[1];
            string   name    = sp[2];
            string   message = sp[3];
            DateTime time    = DateTime.Parse(sp[4]);

            if (flag)
            {
                WbLib.Msg = string.Format($"{name} : {message} ({time})");
                WbLib.DrowMessage();
            }
            else
            {
                Console.SetCursorPosition(X_POS, Y_POS);
                Console.WriteLine($"SendMessage ERROR : {info} ");
                Console.SetCursorPosition(0, 0);
            }

            return;
        }
        public static void ExitUserAck(string msg)
        {
            string[] sp = msg.Split('#');

            bool flag = bool.Parse(sp[0]);
            string info = sp[1];

            if (flag)
            {
                WbLib.ExitMessage();    // 상대방 나가기 메세지 전송

                MyClient.MyUser.Connect = false;    // 연결여부 -> false
                WbLib.MsgClear();                   // msg 내역 비우기
            }
            else
            {
                Console.SetCursorPosition(X_POS, Y_POS);
                Console.WriteLine($"Exit ERROR : {info} ");
                Console.SetCursorPosition(0, 0);
            }


            return;
        }
        public static void SendAllUserAck(string msg)
        {
            string[] sp = msg.Split('#');

            bool   flag    = bool.Parse(sp[0]);
            string info    = sp[1];
            string name    = sp[2];
            string message = sp[3];

            MyClient.Notice = string.Format($"({name}) : {message}");
            return ;
        }
        public static void DeleteUserAck(string msg)
        {
            string[] sp = msg.Split('#');

            bool flag = bool.Parse(sp[0]);
            string info = sp[1];
            string name = sp[2];

            if (flag)
            {
                Console.WriteLine($"{name} : 회원삭제 성공했습니다");
            }
            else
            {
                Console.WriteLine($"DELETE ERROR : {info}");
            }
        }
        #endregion
    }
}
