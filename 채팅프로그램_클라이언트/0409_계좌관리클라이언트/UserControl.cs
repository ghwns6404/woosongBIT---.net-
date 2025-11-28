//AccountControl.cs
using Microsoft.SqlServer.Server;
using System;
using System.Net.Sockets;
using System.Security.Policy;
using WoosongBit41.ClientNet;
using WoosongBit41.Lib;

namespace 채팅프로그램_클라이언트
{
    internal class UserControl
    {
        //network
        private const string SERVER_IP = "127.0.0.1";
        private const int SERVER_PORT = 7000;
        private MyClient _client = new MyClient();  //클라이언트 객체 생성

        #region 0. 싱글톤 패턴
        public static UserControl Singleton { get; } = null;
        static UserControl() { Singleton = new UserControl(); }
        private UserControl()
        {
        }
        #endregion


        #region 0-1 CallBack Message
        public void LogMessage(Socket sock, string message)
        {
            Console.WriteLine($"[log] {message}");
        }
        public void PacketMessage(Socket sock, string message)
        {
            //1. 패킷 수신
            Console.WriteLine($"[packet] {message}");

            //2. 패킷 파싱(분석) 및 분할 처리
            string[] sp = message.Split('@');
            switch (int.Parse(sp[0]))
            //call만 거꾸로
            {
                case Packet.PACKET_INSERTUSER_ACK:      UserInsert_Ack(sp[1]);      break;
                case Packet.PACKET_LOGINUSER_ACK:       LoginUser_Ack(sp[1]);       break;
                case Packet.PACKET_FINDUSER_ACK:        UserFind_Ack(sp[1]);        break;
                case Packet.PACKET_CALLUSER:            UserCall(sp[1]);            break;
                case Packet.PACKET_SENDMESSAGEUSER_ACK: UserSendMessage_Ack(sp[1]); break;
                case Packet.PACKET_EXITUSER_ACK:        UserExit_Ack(sp[1]);        break;
                case Packet.PACKET_SENDALLUSER_ACK:     UserSendAll_Ack(sp[1]);     break;
                case Packet.PACKET_DELETEUSER_ACK:      UserDelete_Ack(sp[1]);      break;
            }
        }

        #endregion

        #region  1. 기능 메서드 시작 -> 응답 처리 메서드

        public void UserInsert(string name)     //Insert
        {
            try
            {
                string packet = Packet.InsertUserAck(name);
                _client.SendData(packet);   //서버로 전송
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserInsert_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];

                string name = sp[2];

                if (isbool == true)
                {
                    Console.WriteLine($"{name} 회원가입 성공");
                }
                else
                {
                    Console.WriteLine("회원가입 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)//파싱중 예외 발생시
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LoginUser(string name) //Login
        {
            try
            {
                string packet = Packet.LoginUserAck(name);
                _client.SendData(packet);   //서버로 전송
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LoginUser_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
                string name = sp[2];


                if (isbool == true)
                {
                    Console.WriteLine($"사용자 :[{name}] 로그인 성공");
                }
                else
                {
                    Console.WriteLine("로그인 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)//파싱중 예외 발생시
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserFind(string name)   //Find
        {
            try
            {
                string packet = Packet.FindUserAck(name);
                _client.SendData(packet);   //서버로 전송
                Console.WriteLine("(서버로는 전송 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserFind_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string name = sp[1];
                string info = sp[2];

                if (isbool == true)
                {
                    Console.WriteLine($"[{name}] 유저찾기 성공");
                }
                else
                {
                    Console.WriteLine("유저찾기 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)//파싱중 예외 발생시
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserCall_Ack(string name)   //Call
        {
            try
            {
                bool flag = WbLib.InputBool($"{name} 이 요청헀습니다(Y / N)");

                string packet = Packet.CallUser(flag , null , name);
                _client.SendData(packet);   //서버로 전송
                Console.WriteLine("상대방과 연결성공");
            }
            catch (Exception ex)
            {
                string packet = Packet.CallUser(false, ex.Message, null);
                _client.SendData(packet);   //서버로 전송
            }
        }
        public void UserCall(string msg)//받는쪽
        {
            try
            {
                
                string[] sp = msg.Split('#');
                string name = (sp[0]);

                Console.WriteLine($"[{name}] 통신 요청");
                bool flag = WbLib.InputBool($"{name} 이 요청헀습니다 .(Y / N)");
            }
            catch (Exception ex)//파싱중 예외 발생시
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UserSendMessage(string name, string message, DateTime? time)    //SendMessage
        {
            try
            {
                string packet = Packet.SendMessageUserAck(name, message);
                _client.SendData(packet);   //서버로 전송
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserSendMessage_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];

                string name = sp[2];
                string message = sp[3];
                

                if (isbool == true)
                {
                    Console.WriteLine("메세지 보내기 성공");
                    Console.WriteLine($"{message}");
                }
                else
                {
                    Console.WriteLine("전송 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)//파싱중 예외 발생시
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UserExit()    //Exit
        {
            try
            {
                string packet = Packet.ExitUserAck();
                _client.SendData(packet);   //서버로 전송
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserExit_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
               

                if (isbool == true)
                {
                    Console.WriteLine($"채팅나가기 성공");
                }
                else
                {
                    Console.WriteLine("채팅나가기 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)//파싱중 예외 발생시
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UserSendAll(string name, string message)    //SendAll
        {
            try
            {
                string packet = Packet.SendAllUserAck(name, message);
                _client.SendData(packet);   //서버로 전송
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserSendAll_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];

                string name = sp[2];
                string message = sp[3];

                if (isbool == true)
                {
                    Console.WriteLine("전체 보내기 성공");
                }
                else
                {
                    Console.WriteLine("전송 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)//파싱중 예외 발생시
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UserDelete(string name)     //Delete
        {
            try
            {
                string packet = Packet.DeleteUserAck(name);
                _client.SendData(packet);   //서버로 전송
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserDelete_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];

                string name = sp[2];

                if (isbool == true)
                {
                    Console.WriteLine($"{name} 유저삭제 성공");
                }
                else
                {
                    Console.WriteLine("유저삭제 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 2. 시작과 종료 메서드
        public void Init()
        {
            //위에서 만든 클라이언트객체를 서버와 연결. (성공시 수신 스레드 실행)   
            if (_client.Start(SERVER_IP, SERVER_PORT, LogMessage, PacketMessage) == false)
            {
                Console.WriteLine("서버 연결 실패");
                return;
            }
            Console.WriteLine("서버 연결 성공........");
        }
        public void Exit()
        {
            _client.Close();
            Console.WriteLine("서버 연결 종료........");
        }
        #endregion


        #region 3. App -> Run 에서 LoginUser 조건검사
        

        #endregion
    }
}
