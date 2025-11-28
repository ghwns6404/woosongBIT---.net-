//wbarray.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WoosongBit41.Lib
{
    internal class WbArray
    {
        #region 1. 맴버 필드 및 프로퍼티, 배열의 인덱서

        private List<object> arr;  // 동적 배열의 주소 저장(저장소)
        public List<object> Arr { get { return arr; } }
        public object this[int idx]
        {
            get
            {
                if (idx < 0 || idx >= arr.Count)
                    return null;
                return arr[idx];
            }
        }
        #endregion

        #region 2. 생성자 
        public WbArray()        
        {
            arr  = new List<object>();
        }
        #endregion

        #region 기능 메서드
        public void Add(object value)
        {
            arr.Add(value);
        }
        public void RemoveIdx(int idx)  //Remove
        {
            if (idx < 0 || idx >= arr.Count)
                throw new Exception("잘못된 인덱스 입니다.");

            arr.RemoveAt(idx); // 인덱스로 삭제

        }
        //public void RemoveName(string name)
        //{
        //    arr.Remove(name); // 값으로 삭제
        //}
        #endregion 
    }
}
