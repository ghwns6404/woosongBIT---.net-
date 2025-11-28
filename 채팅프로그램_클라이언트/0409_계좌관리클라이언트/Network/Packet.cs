//Packet.cs
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.ClientNet
{
    internal static class Packet
    {
        #region FLAG
        public const int PACKET_INSERTUSER = 1;  // 회원 정보 추가 ( string id , string pw , string name )
        public const int PACKET_INSERTUSER_ACK = 11;

        public const int PACKET_LOGINUSER = 2;  // 로그인 ( string id , string pw )
        public const int PACKET_LOGINUSER_ACK = 21;

        public const int PACKET_FINDUSER = 3;  // 상대방에게 통신여부 전송 ( 찾고자 하는 사람 )
        public const int PACKET_FINDUSER_ACK = 31; // 상대방이 승낙했는지 받음

        public const int PACKET_CALLUSER = 4;  // 서버 -> 클라 ( 통신을 원하는 사람의 이름 )
        public const int PACKET_CALLUSER_ACK = 41; // 클라 -> 서버 ( 통신할지 말지 bool flag , 오류 string info , 상대방 이름 )

        public const int PACKET_SENDMESSAGEUSER = 5;  // 상대방에게 메세지 전송 ( 본인 이름 , 메세지 내용 )
        public const int PACKET_SENDMESSAGEUSER_ACK = 51;

        public const int PACKET_EXITUSER = 6;  // 채팅방을 나갈 때 전송
        public const int PACKET_EXITUSER_ACK = 61;

        public const int PACKET_SENDALLUSER = 7;  // 공지사항 ( 본인 이름 , 메세지 )
        public const int PACKET_SENDALLUSER_ACK = 71;

        public const int PACKET_DELETEUSER = 8;  // 회원 탈퇴 (  id , pw )
        public const int PACKET_DELETEUSER_ACK = 81;
        #endregion

        #region 클라에서 서버로

        public static string InsertUserAck(string name)
        {
            string packet = PACKET_INSERTUSER + "@";

            packet += name;

            return packet;
        }// ( 회원가입)
        public static string LoginUserAck(string name)
        {
            string packet = PACKET_LOGINUSER + "@";

            packet += name;



            return packet;
        }// 로그인
        public static string FindUserAck(string name)
        {
            string packet = PACKET_FINDUSER + "@";

            packet += name;

            return packet;
        }//누구랑 연결하고싶은지 이름으로 검색
        public static string CallUser(bool flag ,string info , string name)
        {
            string packet = PACKET_CALLUSER + "@";

            packet += flag + "#";
            packet += info +"#";
            packet += name;

            return packet;
        }//내가 상대방을 호출하면 서버가 상대방에게 CallUser 전송하여 통신여부 묻기 ( 통화를 원하는 사람(상대방)의 이름 
        public static string SendMessageUserAck(string name, string message)
        {
            string packet = PACKET_SENDMESSAGEUSER + "@";

            packet += name + "#";
            packet += message + "#";
            packet += DateTime.Now;

            return packet;
        }//상대방에게 메세지 전송 ( 보낸 사람(본인포함) , 메세지  , 보낸 시간 )
        public static string ExitUserAck()
        {
            string packet = PACKET_EXITUSER + "@";

            return packet;
        }// 상대방이 채팅방을 나감  ( flag , info (시간 되면 나간 이유 , 클라 종료 + recv 오류 등등 )
        public static string SendAllUserAck(string name, string message)
        {
            string packet = PACKET_SENDALLUSER + "@";

            packet += name + "#";
            packet += message;

            return packet;
        }// 모든 사람에게 채팅 전송 ( 공지사항을 보낸 사람 , 받아야 되는 공지사항 메세지 )
        public static string DeleteUserAck(string name)
        {
            string packet = PACKET_DELETEUSER + "@";

            packet += name;

            return packet;
        }// 회원 탈퇴 된 이름 전송
        #endregion
    }
}
