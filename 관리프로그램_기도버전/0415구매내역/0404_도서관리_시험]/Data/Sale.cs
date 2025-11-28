using System;

namespace WoosongBit41.Data
{
	internal class Sale
	{
		#region 1. 맴버필드, 프로퍼티(속성)
		public int Sid { get; set; }
        public int Cid { get; set; }
		public int Pid { get; set; }
		public int Count { get; set; }
		public DateTime Date { get; set; }
		#endregion
		#region 2. 생성자
		
		public Sale() { }
		public Sale(int _sid,int _cid, int _pid, int _count, DateTime _date)
		{
			Sid = _sid;
            Cid = _cid;
			Pid = _pid;
			Count = _count;
			Date = _date;

		}
		#endregion

		public void Print()
		{
			Console.Write(Sid + "\t");
            Console.Write(Cid + "\t");
			Console.Write(Pid + "\t");
			Console.Write(Count + "\t");
			Console.Write(Date + "\t");
			Console.WriteLine();
		}
		public void Println()
		{
			Console.WriteLine("[거래내역-SID] " + Sid);
            Console.WriteLine("[이름번호-CID] " + Cid);
			Console.WriteLine("[책 번호-PID] " + Pid);
			Console.WriteLine("[구매갯수] " + Count);
			Console.WriteLine("[날짜/시간] " + Date);


		}
	}
}
