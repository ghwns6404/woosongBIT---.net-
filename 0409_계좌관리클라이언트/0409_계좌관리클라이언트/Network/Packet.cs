//Packet.cs
using System;

namespace WoosongBit41.ClientNet
{
    internal static class Packet
    {
        public const int PACKET_INSERT_ACCOUNT          = 1;
        public const int PACKET_INSERT_ACCOUNT_ACK      = 2;
        public const int PACKET_SELECT_ACCOUNT          = 3;
        public const int PACKET_SELECT_ACCOUNT_ACK      = 4;
        public const int PACKET_INPUT_ACCOUNT           = 5;
        public const int PACKET_INPUT_ACCOUNT_ACK       = 6;
        public const int PACKET_OUTPUT_ACCOUNT          = 7;
        public const int PACKET_OUTPUT_ACCOUNT_ACK      = 8;
        public const int PACKET_DELETE_ACCOUNT          = 9;
        public const int PACKET_DELETE_ACCOUNT_ACK      = 10;
        public const int PACKET_PRINTALL_ACCOUNT        = 11;
        public const int PACKET_PRINTALL_ACCOUNT_ACK    = 12;
        public const int PACKET_INPUTOUTPUT_ACCOUNT     = 13;
        public const int PACKET_INPUTOUTPUT_ACCOUNT_ACK = 14;

        #region Clinet -> Server
        public static string InsertAccount(int number, string name, int money)
        {
            string packet = PACKET_INSERT_ACCOUNT + "@";

            packet += number + "#";
            packet += name + "#";
            packet += money + "#";
            packet += DateTime.Now;

            return packet;
        }
        public static string SelectAccount(int number)
        {
            string packet = PACKET_SELECT_ACCOUNT + "@";

            packet += number;

            return packet;
        }
        public static string InputAccount(int number, int money)
        {
            string packet = PACKET_INPUT_ACCOUNT + "@";

            packet += number + "#";
            packet += money;

            return packet;
        }
        public static string OutputAccount(int number, int money)
        {
            string packet = PACKET_OUTPUT_ACCOUNT + "@";

            packet += number + "#";
            packet += money;

            return packet;
        }
        public static string DeleteAccount(int number)
        {
            string packet = PACKET_DELETE_ACCOUNT + "@";

            packet += number;

            return packet;
        }
        public static string PrintAllAccount()
        {
            string packet = PACKET_PRINTALL_ACCOUNT + "@";

            return packet;
        }
        public static string InputOutputAccount(int input_number, int output_number, int money)
        {
            string packet = PACKET_INPUTOUTPUT_ACCOUNT + "@";

            packet += input_number + "#";
            packet += output_number + "#";
            packet += money ;

            return packet;
        }
        #endregion

    }
}
