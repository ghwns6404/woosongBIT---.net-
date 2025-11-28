//User.cs
using System;

namespace WoosongBit41.Data
{
    internal class User
    {
        #region 1. 맴버필드, 프로퍼티(속성)
        public string Name      { get; private set; }
        public DateTime Time      { get; private set; }
        #endregion

        #region 2. 생성자
        public User(string name)
        {
            Name = name;
            Time   = DateTime.Now;
        }
        public User(string name  , DateTime time)
        {
            Name = name;
            Time = time;
        }
        #endregion
    }
}
