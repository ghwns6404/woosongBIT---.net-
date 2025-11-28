//Login

namespace WoosongBit41.Data
{
    internal class Login
    {
        #region 1. 맴버필드, 프로퍼티(속성)
        public string Name { get; private set; }
        public int Connect { get; set; }
        #endregion

        #region 2. 생성자
        public Login(string name)
        {
            Name = name;
            Connect = -1;
        }
        #endregion
    }
}
