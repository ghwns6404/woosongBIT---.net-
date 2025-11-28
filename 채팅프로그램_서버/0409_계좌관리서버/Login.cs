using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0409_계좌관리서버
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

