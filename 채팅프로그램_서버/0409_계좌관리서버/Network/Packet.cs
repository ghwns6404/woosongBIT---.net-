//Packet.cs
using System;
using System.Collections.Generic;
using WoosongBit41.Data;

namespace WoosongBit41.ServerNet
{
    internal static class Packet
    {
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



        //여기 수정해야함
        #region Server -> Client
        public static string UserInsert(bool ischeck, string info, string name)
        {
            string packet = PACKET_INSERTUSER_ACK + "@";

            packet += ischeck + "#";
            packet += info + "#";
            packet += name;

            return packet;
        }
        public static string UserLogin(bool ischeck, string info, User acc)
        {
            string packet = PACKET_LOGINUSER_ACK + "@";

            packet += ischeck + "#";
            packet += info + "#";
            packet += acc.Name + "#";
            packet += acc.Id + "#";
            packet += acc.Pw;

            return packet;
        }
        public static string UserFind(bool ischeck, string info, string name)
        {
            string packet = PACKET_FINDUSER_ACK + "@";
            packet += ischeck + "#";
            packet += info + "#";
            packet += name;
            return packet;
        }
        public static string UserCall(bool ischeck, string info, string name)
        {
            string packet = PACKET_CALLUSER_ACK + "@";
            packet += ischeck + "#";
            packet += info + "#";
            packet += name;
            return packet;
        }
        public static string UserSendMessage(bool ischeck, string info, string name, string message)
        {
            string packet = PACKET_SENDMESSAGEUSER_ACK + "@";
            packet += ischeck + "#";
            packet += info + "#";
            packet += name + "#";
            packet += message;
            


            return packet;
        }
        public static string UserExit(bool ischeck, string info, string name)
        {
            string packet = PACKET_EXITUSER_ACK + "@";
            packet += ischeck + "#";
            packet += info + "#";
            packet += name;

            return packet;
        }
        public static string UserSendAll(bool ischeck, string info, string name)
        {
            string packet = PACKET_SENDALLUSER_ACK + "@";
            packet += ischeck + "#";
            packet += info + "#";
            packet += name;
            return packet;
        }
        public static string UserDelete(bool ischeck, string info, string name)
        {
            string packet = PACKET_DELETEUSER_ACK + "@";
            packet += ischeck + "#";
            packet += info + "#";
            packet += name;

            return packet;
        }

        #endregion
    }
}
