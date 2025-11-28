// WaterCup.cs
using System;
namespace Basic_OOP
{
	// 1. 프로퍼티 만들기
	public class WaterCup
	{
		private int water; 

		public WaterCup()
		{
			water = 0;
		}

        public int Water
        {
            get { return water; }
            set
            {
                if (value > 0 && value <= 100)
                    water = value;
                else
                    Console.WriteLine("입력값이 정확하지 않습니다");
            }
        }
        #region water의 get, set 원본
        //      public void Set_Water(int water)
        //{
        //	if (water > 0 && water <= 100)
        //		this.water = water;
        //	else
        //		Console.WriteLine("입력값이 정확하지 않습니다");
        //}
        //      public int Get_Water()
        //      {
        //          return water;
        //      }
        #endregion

        public bool Drink()
		{
            if (water < 60)
                return false;
            else
                return true;
        }
	}
}
