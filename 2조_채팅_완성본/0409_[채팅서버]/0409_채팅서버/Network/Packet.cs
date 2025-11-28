//Packet.cs
using System;
using System.Net.Sockets;

namespace WoosongBit41.Packet
{
    internal static class Packet
    {
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

        #region Server -> Client

        public static string InsertUserAck(bool flag, string info, string name)
        {
            string packet = PACKET_INSERTUSER_ACK + "@";

            packet += flag + "#";
            packet += info + "#";
            packet += name;

            return packet;
        }// ( 회원가입 성공한 이름 반환 )
        public static string LoginUserAck(bool flag, string info, string name)
        {
            string packet = PACKET_LOGINUSER_ACK + "@";

            packet += flag + "#";
            packet += info + "#";
            packet += name;

            return packet;
        }// ( 로그인 된 이름 반환 )
        public static string CallUser(string name)
        {
            string packet = PACKET_CALLUSER + "@";

            packet += name;

            return packet;
        }// A -> 서버 -> B ( 상대방 )   서버가 B(상대방)에게 CallUser 전송하여 통신여부 묻기 ( 통화를 원하는 사람(A)의 이름 )
        public static string FindUserAck(bool flag, string info, string name)
        {
            string packet = PACKET_FINDUSER_ACK + "@";

            packet += flag + "#";
            packet += info + "#";
            packet += name;

            return packet;
        }// A와 B에게 전송 ( 채팅 할지 말지 결과 값 , 상대방 이름 )
        public static string SendMessageUserAck(bool flag, string info, string name, string message, DateTime? time)
        {
            string packet = PACKET_SENDMESSAGEUSER_ACK + "@";

            packet += flag + "#";
            packet += info + "#";
            packet += name + "#";
            packet += message + "#";
            packet += time;

            return packet;
        }// 상대방에게 메세지 전송 ( 보낸 사람(본인포함) , 메세지  , 보낸 시간 )
        public static string ExitUserAck(bool flag, string info)
        {
            string packet = PACKET_EXITUSER_ACK + "@";

            packet += flag + "#";
            packet += info;

            return packet;
        }// 상대방이 채팅방을 나감  ( flag , info (시간 되면 나간 이유 , 클라 종료 + recv 오류 등등 )
        public static string SendAllUserAck(bool flag, string info, string name ,string msg)
        {
            string packet = PACKET_SENDALLUSER_ACK + "@";

            packet += flag + "#";
            packet += info + "#";
            packet += name  + "#";
            packet += msg;

            return packet;
        }// 모든 사람에게 채팅 전송 ( 공지사항을 보낸 사람 , 받아야 되는 공지사항 메세지 )
        public static string DeleteUserAck(bool flag, string info, string name)
        {
            string packet = PACKET_DELETEUSER_ACK + "@";

            packet += flag + "#";
            packet += info + "#";
            packet += name;

            return packet;
        }// 회원 탈퇴 된 이름 전송
        #endregion
    }
}
