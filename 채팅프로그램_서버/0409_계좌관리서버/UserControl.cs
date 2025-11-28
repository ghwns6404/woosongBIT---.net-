//AccountControl.cs
using System;
using System.Collections.Generic;
using WoosongBit41.ServerNet;
using WoosongBit41.Data;
using System.Net.Sockets;
using System.Security.Policy;
using System.Xml.Linq;
using System.Net;

namespace 채팅프로그램_서버
{
    internal class UserControl
    {
        MyServer server = new MyServer();

        private List<User> users = new List<User>();

        private object add_login = new object();
        private object exit_login = new object();
        
        private const int SERVER_PORT = 7000; 

        #region 0. 싱글톤 패턴
        public static UserControl Singleton { get; } = null;
        static UserControl() { Singleton = new UserControl(); }
        private UserControl()
        {
        }
        #endregion

        #region 네트워크 CallBack 메서드 -> 기능 메서드
        public void LogMessage(Socket sock, string message)
        {
            Console.WriteLine($"[log] {message}");
        }
        public void PacketMessage(Socket sock, string message)
        {
            //1. 패킷 수신
            Console.WriteLine($"[packet] {message}");

            //2. 패킷 파싱(분석)
            string[] sp = message.Split('@');

            //3. 분석 분할 처리
            switch (int.Parse(sp[0]))
            {
                case Packet.PACKET_INSERTUSER:          UserInsert(sock, sp[1]); break;
                case Packet.PACKET_LOGINUSER:           UserLogin(sock, sp[1]); break;
                case Packet.PACKET_CALLUSER_ACK:        UserCall(sock, sp[1]); break;
                case Packet.PACKET_FINDUSER:            UserFind(sock, sp[1]); break;
                case Packet.PACKET_SENDMESSAGEUSER:     UserSendMessage(sock, sp[1]); break;
                case Packet.PACKET_EXITUSER:            UserExit(sock, sp[1]); break;
                case Packet.PACKET_SENDALLUSER:         UserSendAll(sock, sp[1]); break;
                case Packet.PACKET_DELETEUSER:          UserDelete(sock, sp[1]); break;
            }
        }
        #endregion 

        #region 1. --------------------기능 메서드--------------------------------------
        public void UserInsert(Socket socket, string message)
        {
            try
            {
                // 1. 데이터 획득 --------------------------------------------
                string[] sp = message.Split('#');
                string name = sp[0];
             
               

                // 올바른 변수 이름 사용
                // id pw 중복처리
                User temp = users.Find(acc => (acc.Name == name));
                if (temp != null)
                    throw new Exception("이미 회원가입 된 아이디 입니다");

                //회원 정보 저장
                User user = new User(name);
                users.Add(user);

                //클라이언트에게 성공 메시지 전송(Ack)
                string packet = Packet.UserInsert(true, null, user.Name);
                server.SendData(socket, packet);
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서 {ex.Message} 오류");
                //클라이언트에게 오류 메시지 전송
                string packet = Packet.UserInsert(false, ex.Message, "");
                server.SendData(socket, packet);
            }
        }
        public void UserLogin(Socket socket, string message)
        {
            try
            {
                string[] sp = message.Split('#');
                string name = sp[0];
                
                User user = users.Find(acc => (acc.Name == name ));
                if (user == null)
                    throw new Exception("이름이 틀립니다");
               
                string packet = Packet.UserLogin(true, null, user);
                server.SendData(socket, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.UserLogin(false, ex.Message, null);
                server.SendData(socket, packet);
            }
        }
        public void UserFind(Socket socket, string message)
        {
            try
            {
                string[] sp = message.Split('#');
                string name = sp[0];

                User user = users.Find(acc => (acc.Name == name));
                if (user == null)
                    throw new Exception("상대방이 존재하지 않습니다");

                string packet = Packet.UserFind(true, null, name);
                server.SendData(socket, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.UserFind(false, ex.Message, null);
                server.SendData(socket, packet);
            }
        }
        public void UserCall(Socket recv_socket, string message)
        {
            try
            {
                string[] sp = message.Split('#');
                string name = sp[0];
                string flag = sp[1];
                string OppName = sp[2]; // 상대방 이름

                // 채팅 신청을 받을 사람의 인덱스를 찾음
                int send_idx = GetIdx(OppName);
                // 채팅 신청을 받을 사람의 MyServer의 Clients의 list의 소켓을 가져오기
                Socket recvClient = server.clients[send_idx];
                // 채팅   신청을 받을 사람에게 메세지 전송
                string packet = Packet.UserCall(true, null, name);
                string packet1 = Packet.UserCall(true, null, name);
                server.SendData(recvClient, packet); //받을사람
                server.SendData(recv_socket, packet1);  //보내는사람
            }
            catch (Exception ex)
            {
                string packet = Packet.UserCall(false, ex.Message, "");
                server.SendData(recv_socket, packet);

            }
        }
        public void UserSendMessage(Socket socket, string message)
        {
            try
            {
                string[] sp = message.Split('#');
                string name = sp[0];
                string msg = sp[1];
                DateTime time = DateTime.Parse(sp[2]);

                //메세지 전송
                int idx = GetIdx(name);
                Socket sendClient = server.clients[idx];
                string packet = Packet.UserSendMessage(true, null,name, msg);
                server.SendData(sendClient, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.UserSendMessage(false, ex.Message, "","");
                server.SendData(socket, packet);
            }
        }
        public void UserExit(Socket socket, string message)
        {
            try
            {
                string[] sp = message.Split('#');
                string name = sp[0];
                
                int idx = GetIdx(name);
                Socket sendClient = server.clients[idx];
                string packet = Packet.UserExit(true, null, name);
                server.SendData(sendClient, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.UserExit(false, ex.Message, "");
                server.SendData(socket, packet);
            }
        }
        public void UserSendAll(Socket socket, string message)
        {
            try
            {
                string[] sp = message.Split('#');
                string name = sp[0];
                string msg = sp[1];
                //메세지 전송
                foreach (Socket client in server.clients)
                {
                    string packet = Packet.UserSendAll(true, null, msg);
                    server.SendData(client, packet);
                }
            }
            catch (Exception ex)
            {
                string packet = Packet.UserSendAll(false, ex.Message, "");
                server.SendData(socket, packet);
            }
        }
        public void UserDelete(Socket socket, string message)
        {
            try
            {
                string[] sp = message.Split('#');
                string name = sp[0];
                string id = sp[1];
                string pw = sp[2];
                
                int idx = GetIdx(name);
                if (idx == -1)
                    throw new Exception("회원 정보가 없습니다");
                users.RemoveAt(idx);
                
                string packet = Packet.UserDelete(true, null, name);
                server.SendData(socket, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.UserDelete(false, ex.Message, "");
                server.SendData(socket, packet);
            }
        }

        #endregion----------------------------------------------------------------------

        #region 2. 시작과 종료 메서드
        public void Init()
        {
            if (server.Start(SERVER_PORT, LogMessage, PacketMessage) == false)
                return;
            Console.WriteLine("서버 실행........");
        }
        public void Exit()
        {
            server.Close();
            Console.WriteLine("서버 종료........");
        }
        #endregion

        #region 3. 유틸리티 메서드
        private int GetIdx(string name)
        {
            return users.FindIndex(acc => acc.Name == name);
        }
        #endregion


    }
}