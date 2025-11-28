//wbarray.cs
using System;

namespace WoosongBit41.Lib
{
    internal class WbArray
    {
        #region 1. 맴버 필드 및 프로퍼티, 배열의 인덱서
        private object[] arr;  // 동적 배열의 주소 저장(저장소)	
        public object[] Arr { get { return arr; } }
        public object this[int idx] 
        {
            get 
            {
                if (idx < 0 || idx >= Size)
                    throw new Exception("범위를 벗어 났습니다.");                
                return arr[idx]; 
            } 
        }
	    public int Max  { get; private set; }   // 최대 저장개수
        public int Size { get; private set; }   // 현재 저장된 데이터 개수(저장 위치)
        #endregion

        #region 2. 생성자 
        public WbArray(int _max = 10)
        {
            Max  = _max;
            Size = 0;
            arr  = new object[Max];
        }
        #endregion

        #region 기능 메서드
        public void Add(object value)
        {
            if (Max <= Size)
                throw new Exception("Overflow - 저장 공간 부족");
            arr[Size] = value;
            Size++;
        }
        public void Remove(int idx)
        {
            if (idx < 0 || idx >= Size)
                throw new Exception("잘못된 인덱스 입니다.");  

            for (int i = idx; i < (Size - 1); i++)
            {
                arr[i] = arr[i + 1];
            }
            Size--;
        }
        #endregion 
    }
}
