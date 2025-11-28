//WbFile.cs
using System;
using WoosongBit41.Data;
using System.IO;
using System.Collections.Generic;

namespace WoosongBit41.File
{
    internal static class WbFile
    {
        private const string USER_FILENAME      = "user.txt";

        // 회원 정보 저장
        public static void Write_Users(List<User> users)
        {
            StreamWriter writer = new StreamWriter(USER_FILENAME);
            writer.WriteLine(users.Count);
            for (int i = 0; i < users.Count; i++)
            {
                User user = (User)users[i];
                string temp = string.Empty;
                temp += user.Name + "@";
                temp += user.Time;

                writer.WriteLine(temp);
            }
            writer.Dispose();
        }
        public static void Read_Users(List<User> users)
        {
            try
            {
                StreamReader reader = new StreamReader(USER_FILENAME);
                int size = int.Parse(reader.ReadLine());
                for (int i = 0; i < size; i++)
                {
                    string temp = reader.ReadLine();     // name @ time
                    string[] sp = temp.Split('@');
                    string name = sp[0];
                    DateTime time = DateTime.Parse(sp[1]);

                    users.Add(new User(name, time));
                }
                reader.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
