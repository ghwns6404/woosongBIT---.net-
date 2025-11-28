//AccountControl.cs
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Policy;
using System.Threading;
using WoosongBit41.ClientNet;
using WoosongBit41.Data;

namespace _0409_계좌관리클라이언트
{
    internal class AccountControl
    {
        //network
        private const string SERVER_IP  = "220.90.180.111"; //"127.0.0.1";
        private const int SERVER_PORT   = 7000;
        private MyClient _client = new MyClient();  

        #region 0. 싱글톤 패턴
        public static AccountControl Singleton { get; } = null;
        static AccountControl() { Singleton = new AccountControl(); }
        private AccountControl()
        {
        }
        #endregion

        #region 1. 기능 메서드 시작 -> 응답 처리 메서드
        public void AccountInsert(int number, string name, int money)
        {
            try
            { 
                string packet = Packet.InsertAccount(number, name, money);
                _client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;   //예외 재 전송!!!!
            }
        }
        public void AccountInsert_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
                int number  = int.Parse(sp[2]);

                if (isbool == true)
                {
                    Console.WriteLine($"{number} 계좌번호 저장 성공");
                }
                else
                {
                    Console.WriteLine("계좌번호 저장 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void AccountSelect(int number)
        {
            try
            {
                string packet = Packet.SelectAccount(number);
                _client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;   //예외 재 전송!!!!
            }
        }
        public void AccountSelect_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
                int number  = int.Parse(sp[2]);
                string name = sp[3];
                int balance = int.Parse(sp[4]);
                DateTime dt = DateTime.Parse(sp[5]);

                if (isbool == true)
                {
                    Console.WriteLine($"  계좌번호 -> {number}");
                    Console.WriteLine($"  이    름 -> {name}");
                    Console.WriteLine($"  잔    액 -> {balance}원");
                    Console.WriteLine($"  개설일시 -> {dt}");
                }
                else
                {
                    Console.WriteLine("계좌번호 검색 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void AccountInput(int number, int money)
        {
            try
            {
                string packet = Packet.InputAccount(number, money);
                _client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AccountInput_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
                int money   = int.Parse(sp[2]);

                if (isbool == true)
                {
                    Console.WriteLine($"{money}원 입금 성공");
                }
                else
                {
                    Console.WriteLine("계좌 입금 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AccountOutput(int number, int money)
        {
            try
            {
                string packet = Packet.OutputAccount(number, money);
                _client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AccountOutput_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
                int money   = int.Parse(sp[2]);

                if (isbool == true)
                {
                    Console.WriteLine($"{money}원 출금 성공");
                }
                else
                {
                    Console.WriteLine("계좌 출금 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AccountDelete(int number)
        {
            try
            {
                string packet = Packet.DeleteAccount(number);
                _client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AccountDelete_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
                int number  = int.Parse(sp[2]);

                if (isbool == true)
                {
                    Console.WriteLine($"{number} 계좌 삭제 성공");
                }
                else
                {
                    Console.WriteLine("계좌 삭제 실패");
                    Console.WriteLine($"- {info}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void AccountPrintAll()
        {
            try
            {
                string packet = Packet.PrintAllAccount();
                _client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AccountPrintAll_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('$');
                Console.WriteLine($"저장된 회원 수 : {sp.Length}원\n");
                foreach (string sp1 in sp)
                {
                    string[] sp2 = sp1.Split('#');
                    int number   = int.Parse(sp2[0]);
                    string name  = sp2[1];
                    int balance  = int.Parse(sp2[2]);
                    DateTime dt  = DateTime.Parse(sp2[3]);

                    Console.WriteLine($"{number} \t {name} \t {balance}원 \t{dt}");
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AccountInputOutput(int input_number, int output_number, int money)
        {
            try
            {
                string packet = Packet.InputOutputAccount(input_number, output_number, money);
                _client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AccountInputOutput_Ack(string msg)
        {
            try
            {
                string[] sp = msg.Split('#');
                bool isbool = bool.Parse(sp[0]);
                string info = sp[1];
                int money   = int.Parse(sp[2]);

                if (isbool == true)
                {
                    Console.WriteLine($"{money}원 계좌 이체 성공");
                }
                else
                {
                    Console.WriteLine("계좌 이체 실패");
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

        #region CallBack Message
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
            {
                case Packet.PACKET_INSERT_ACCOUNT_ACK:      AccountInsert_Ack(sp[1]);       break;
                case Packet.PACKET_SELECT_ACCOUNT_ACK:      AccountSelect_Ack(sp[1]);       break;
                case Packet.PACKET_INPUT_ACCOUNT_ACK:       AccountInput_Ack(sp[1]);        break;
                case Packet.PACKET_OUTPUT_ACCOUNT_ACK:      AccountOutput_Ack(sp[1]);       break;
                case Packet.PACKET_DELETE_ACCOUNT_ACK:      AccountDelete_Ack(sp[1]);       break;
                case Packet.PACKET_INPUTOUTPUT_ACCOUNT_ACK: AccountInputOutput_Ack(sp[1]);  break;
                case Packet.PACKET_PRINTALL_ACCOUNT_ACK:    AccountPrintAll_Ack(sp[1]);     break;
            }
        }
    }
        #endregion
    
}