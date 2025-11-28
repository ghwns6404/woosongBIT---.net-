//AccountControl.cs
using System;
using System.Xml.Linq;
using WoosongBit41.ClientNet;
using WoosongBit41.Packet;

namespace _0410_채팅클라이언트
{
    internal class UserControl
    {
        MyClient client = null;

        #region 0. 싱글톤 패턴
        public static UserControl Singleton { get; } = null;
        static UserControl() { Singleton = new UserControl(); }
        private UserControl()
        {
        }
        #endregion

        #region 1. 전송 메서드
        public void UserInsert(string name)
        {
            try
            {
                string packet = Packet.InsertUser(name);
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex; // 예외 재전송 -> 함수를 호출한 애한테 감
            }
        }
        public void UserLogin(string name)
        {
            try
            {
                string packet = Packet.LoginUser(name);
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex; // 예외 재전송 -> 함수를 호출한 애한테 감
            }
        }
        public void UserFind(string name)
        {
            try
            {
                string packet = Packet.FindUser(name);
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UserCallAck(bool flag , string send_name)
        {
            try
            {
                string packet = Packet.CallUserAck(flag , null , send_name);
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                string packet = Packet.CallUserAck(flag, ex.Message, send_name);
                client.SendData(packet);
            }
        }
        public void UserSendMessage(string message)
        {
            try
            {
                // MyClient.MyLogin -> 본인 이름
                string myname = MyClient.MyUser.Name;
                string packet = Packet.SendMessageUser(myname, message);
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UserExit()
        {
            try
            {
                string packet = Packet.ExitUser();
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UserSendAll(string message)
        {
            try
            {
                string myname = MyClient.MyUser.Name;
                string packet = Packet.SendAllUser(myname, message);
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UserDelete(string name)
        {
            try
            {
                string packet = Packet.DeleteUser(name);
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 2. 시작과 종료 메서드
        public void Init()
        {
            client = MyClient.Singleton;
        }
        public void Exit()
        {
            client.Dispose();
        }
        #endregion
    }
}