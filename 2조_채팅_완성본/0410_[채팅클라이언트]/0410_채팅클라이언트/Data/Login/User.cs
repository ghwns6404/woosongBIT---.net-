//Login

namespace WoosongBit41.Data
{
    internal class User
    {
        #region 1. 맴버필드, 프로퍼티(속성)
        public string Name { get;  set; }
        public bool Connect { get; set; }
        #endregion

        #region 2. 생성자
        public User(string name)
        {
            Name = name;
            Connect = false;
        }
        #endregion
    }
}
