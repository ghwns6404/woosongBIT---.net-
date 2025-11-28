using System;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
	internal class Member
	{
		#region 1. 맴버필드, 프로퍼티(속성)
		public int Number { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Addr { get; set; }
		#endregion
		#region 2. 생성자
		public Member() { }

		public Member(int _number, string _name, string _phone, string _addr)
		{
			Number = _number;
			Name = _name;
			Phone = _phone;
			Addr = _addr;

		}
		#endregion

		public void Print()
		{
			Console.Write(Number + "\t");
			Console.Write(Name + "\t");
			Console.Write(Phone + "\t");
			Console.Write(Addr + "\t");
			Console.WriteLine();
		}
		public void Println()
		{

			Console.WriteLine("[이   름] " + Name);
			Console.WriteLine("[전화번호] " + Phone);
			Console.WriteLine("[주	 소] " + Addr);

		}
	}
}