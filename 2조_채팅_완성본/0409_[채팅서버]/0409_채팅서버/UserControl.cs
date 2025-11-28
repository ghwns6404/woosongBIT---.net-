//AccountControl.cs
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using WoosongBit41.Data;
using WoosongBit41.File;
using WoosongBit41.Packet;
using WoosongBit41.ServerNet;

namespace _0409_채팅서버
{
    internal class UserControl
    {
        MyServer server = null;

        private List<User> users = new List<User>();
        private List<Login> logins = new List<Login>();

        private object add_login = new object();
        private object exit_login = new object();

        #region 0. 싱글톤 패턴
        public static UserControl Singleton { get; } = null;
        static UserControl() { Singleton = new UserControl(); }
        private UserControl()
        {
        }
        #endregion

        #region 1. 기능 메서드
        public void UserInsert(Socket socket , string name)
        {
            try
            {
                User_Insert(socket ,name);
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                Console.WriteLine($"{ ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void UserLogin(Socket socket, string name)
        {
            try
            {
                User_Login(socket, name);
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void UserFind(Socket socket , string recv_name)
        {
            try
            {
                User_Call(socket , recv_name);
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void UserCall(Socket recv_socket , string msg)
        {
            try
            {
                string[] sp        = msg.Split('#');
                bool     flag      = bool.Parse(sp[0]); // T or F
                string   info      = sp[1];             // 오류
                string   send_name = sp[2];             // 상대방 이름

                // 채팅 신청을 보낸 사람
                int send_idx = GetIdx(send_name);
                // 채팅 신청을 받은 사람
                int recv_idx = server[recv_socket];

                User_Find(server[recv_idx], flag , logins[send_idx].Name);       // 채팅 신청 보낸 사람의 소켓 , flag  , 채팅 신청 받은 사람
                User_Find(server[send_idx], flag , logins[recv_idx].Name);       // 채팅 신청 받은 사람 , flag  , 채팅 신청 보낸 사람의 소켓
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)recv_socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void UserSendMessage(Socket socket , string msg)
        {
            try
            {
                string[] sp      = msg.Split('#');
                string   name    = sp[0];
                string   message = sp[1];
                DateTime time = DateTime.Now;

                Socket recv_socket = GetRecvSocket(socket);

                UserSendMessage(socket, recv_socket, name , message , time);
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void UserExit(Socket send_socket)
        {
            try
            {
                Socket recv_socket = GetRecvSocket(send_socket);

                User_Exit(send_socket); // 종료한 사람
                User_Exit(recv_socket); // 종료한 사람과 연결 된 사람
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)send_socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void UserSendAll(Socket socket , string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                string name = sp[0];
                string message = sp[1];

                UserSendAll(socket, name, message);
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void UserDelete(Socket socket , string name)
        {
            try
            {
                User_Delete(socket, name);
            }
            catch (Exception ex)
            {
                IPEndPoint ip = (IPEndPoint)socket.RemoteEndPoint;
                Console.WriteLine($"{ip.Address} 에서  {ex.Message} 오류");
            }
        }
        public void CloseUser(Socket socket)
        {
            #region 1. 연결된 유저가 있을 때 상대방에게 PACKET_EXITUSER_ACK 전송
            // 소켓 값 -> idx 변환
            int idx = server[socket];
            // 로그인을 한 유저인지 안한 유저인지 체킹
            if (idx == -1)
            {
                socket.Close();
                return;
            }
            // idx 값 -> login 객체 반환
            Login login = logins[idx];

            // 연결된 대상이 있을때
            if ( login.Connect != -1)
            {
                // 연결된 상대방에게 Exit 전송
                if (User_Exit(server[login.Connect]) == false)
                    Console.WriteLine("진짜 백만 분의 1 확률로 오류");
            }
            #endregion

            #region 2. List에 저장되어 있는 Socket 값과 Login 값을 제거
            // 종료 할 때에도 인덱스 값이 꼬이지 않게 lock 을 걸어둠
            lock (exit_login)
            {
                // 통신소켓 종료
                int check = server.ClientClose(socket);

                #region !!!!! 리스트 값이 꼬일 때 !!!!!!!!!!!!!!
                if (check != idx)
                {
                    Console.WriteLine(" 인덱스 값 저장이 꼬임 (디버깅 요망 )");
                }
                #endregion

                // idx 값으로 login 유저 비우기
                logins.RemoveAt(idx);
            }
            Thread.Sleep(10);
            #endregion
        }// login 한 유저가 종료 했을 때
        #endregion

        #region 2. 기능 메서드 내부 함수
        private void User_Insert(Socket socket, string name)
        {
            try
            {
                // id pw 중복처리
                User temp = users.Find(acc => (acc.Name == name));
                if (temp != null)
                    throw new Exception("이미 회원가입 된 이름 입니다");

                //회원 정보 저장
                User user = new User(name);
                users.Add(user);

                string packet = Packet.InsertUserAck(true, null ,user.Name);
                server.SendData(socket, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.InsertUserAck(false, ex.Message , null);
                server.SendData(socket, packet);
            }
        }
        private void User_Login(Socket socket, string name)
        {
            try
            {
                // id pw 중복처리
                User user = users.Find(acc => (acc.Name == name));
                if (user == null)
                    throw new Exception("로그인 실패");

                string packet = Packet.LoginUserAck(true, null , user.Name);

                Add(socket, user.Name);
                server.SendData(socket, packet);

            }
            catch (Exception ex)
            {
                string packet = Packet.LoginUserAck(false, ex.Message, null);
                server.SendData(socket, packet);
                throw ex;
            }
        }
        private void User_Call(Socket send_socket ,  string recv_name)
        {
            try
            {
                // 찾고자 하는 상대방이 로그인이 되어 있는지 체크
                int recv_idx = GetIdx(recv_name);
                if (recv_idx == -1)
                    throw new Exception("유저 없음");

                // 찾고자 하는 사람의 이름 값 도출
                string send_name = GetName(send_socket);
                // 상대방 소켓
                Socket recv_socket = server[recv_idx];

                // 서로 연결 되어있는지 확인
                if (CheckConnect(send_socket, recv_socket) == false)
                    throw new Exception("이미 연결중인 유저 입니다.");

                string packet = Packet.CallUser(send_name);
                server.SendData(recv_socket, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.FindUserAck(false , ex.Message , null);
                server.SendData(send_socket, packet);
            }
        }
        private void User_Find(Socket socket, bool flag, string name)
        {
            try
            {
                // id pw 중복처리
                if(flag == false)
                    throw new Exception("상대방 거절");

                string packet = Packet.FindUserAck(true, null , name);
                server.SendData(socket, packet);

                AddConnect(socket , name);
            }
            catch (Exception ex)
            {
                string packet = Packet.FindUserAck(false, ex.Message , null);
                server.SendData(socket, packet);
            }
        }
        private void UserSendMessage(Socket sendsocket,Socket recvsocket, string name , string message , DateTime time)
        {
            try
            {
                string packet = Packet.SendMessageUserAck(true, null ,  name , message, time);

                server.SendData(sendsocket, packet);
                server.SendData(recvsocket, packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.SendMessageUserAck(true, ex.Message, null , null , null);
                server.SendData(sendsocket, packet);
            }
        }
        private bool User_Exit(Socket socket)
        {
            try
            {
                string packet = Packet.ExitUserAck(true, null);

                server.SendData(socket, packet);
                RemoveConnect(socket);
                return true;
            }
            catch (Exception ex)
            {
                string packet = Packet.ExitUserAck(true, ex.Message);
                server.SendData(socket, packet);
                return false;
            }
        }
        private void UserSendAll(Socket socket, string name , string message)
        {
            try
            {
                string packet = Packet.SendAllUserAck(true, null, name, message);
                foreach (Socket sock in server.clients)
                {
                        server.SendData(sock, packet);
                }
            }
            catch (Exception ex)
            {
                string packet = Packet.SendAllUserAck(false, ex.Message ,null , null);
                server.SendData(socket , packet);
            }
        }
        private void User_Delete(Socket socket, string name)
        {
            try
            {
                string packet = Packet.DeleteUserAck(true, null, name);
                server.SendData(socket, packet);
                Delete(socket, name);
            }
            catch (Exception ex)
            {
                string packet = Packet.DeleteUserAck(false, ex.Message, null);
                server.SendData(socket, packet);
            }
        }

        // 추가 기능
        private void Add(Socket socket , string name)
        {
            lock(add_login)
            {
                Login login = logins.Find( lgn =>  lgn.Name == name);
                if (login != null)
                    throw new Exception("이미 로그인이 된 회원입니다.");

                logins.Add(new Login(name));
                server.Add(socket);
                Thread.Sleep(10);
            }
        }
        private void Delete(Socket socket , string name)
        {
            int idx = users.FindIndex(user=> user.Name == name);
            if (idx != -1)
                users.RemoveAt(idx);

            idx = logins.FindIndex(find => find.Name == name);
            if(idx != -1)
                logins.RemoveAt(idx);
        }
        private bool CheckConnect(Socket send_socket, Socket recv_socket)
        {
            int send_idx = server[send_socket];
            int recv_idx = server[recv_socket];

            return (logins[send_idx].Connect == -1) && (logins[recv_idx].Connect == -1);
        }
        private void AddConnect(Socket socket , string other)
        {
            int idx = server[socket];

            logins[idx].Connect = GetIdx(other);
        }
        private void RemoveConnect(Socket socket)
        {
            int idx = server[socket];

            logins[idx].Connect = -1;
        }
        private int GetIdx(string name)
        {
            return logins.FindIndex(lgn => lgn.Name == name);
        }
        private string GetName(Socket socket)
        {
            int idx = server.SocketToIdx(socket);

            return logins[idx].Name;
        }
        private Socket GetRecvSocket(Socket send_socket)
        {
            Socket recv_socket = null;

            int send_idx = server.SocketToIdx(send_socket);

            Login send_login = logins[send_idx];
            recv_socket = server[send_login.Connect];

            return recv_socket;
        }
        #endregion

        #region 3. 시작과 종료 메서드
        public void Init()
        {
            try
            {
                server = MyServer.Singleton;
                WbFile.Read_Users(users);
                Console.WriteLine("파일 로드 완료 ....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" 최초 실행 ....." + ex.Message);
            }
        }
        public void Exit()
        {
            WbFile.Write_Users(users);
            server.Dispose();
        }
        #endregion
    }
}