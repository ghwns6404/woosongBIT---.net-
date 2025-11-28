// Human.cs
using System;

namespace Basic_OOP
{
	// 1. 프로퍼티 만들기
	// 2. 수분량이 60밑으로 내려가면 목마름을 true로 설정
	// 3. 물컵에 물을 마시는 함수 만들기
	internal class Human
	{
		private bool thirsty;
		private int moisture;
		
		public Human(bool thirsty , int moisture)
		{
			this.thirsty = thirsty;
			this.moisture = moisture;
		}
		//public Human()
		//{

		//}

  //      public bool Thirsty
		//{
		//	get { return thirsty; }
		//	set
		//	{
  //              this.thirsty = thirsty;
  //          }
		//}

		public bool Get_Thirsty()
		{
			return thirsty;
		}
		public int Get_Moisture(int moisture)
		{
			return moisture;
		}
		public void Set_Thirsty(bool thirsty)
		{
			this.thirsty = thirsty;
		}
		public void Set_Moisture(int moisture)
		{
			if (moisture > 0 && moisture <= 100)
				this.moisture = moisture;
			else
				Console.WriteLine("입력값이 정확하지 않습니다");
		}

		public override string ToString()
		{	//true => 목마름
			//false => 목 안마름
			string state = !thirsty ? "현재 목이 마르지 않습니다" : "목이 마릅니다";
			return $"현재 수분량: {moisture} --> {state}";
		}
	}
}
