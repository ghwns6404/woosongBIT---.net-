using System;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
	internal class Book
	{
		public int Number { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Description { get; set; }

		public Book(int _number, string _name, int _price, string _description)
		{
			Number = _number;
			Name = _name;
			Price = _price;
			Description = _description;
		}
		public Book() { }

		public void Print()
		{
			Console.Write(Number + "\t");
			Console.Write(Name + "\t");
			Console.Write(Price + "\t");
			Console.Write(Description + "\t");
			Console.WriteLine();
		}
		public void Println()
		{
			Console.WriteLine("[도서번호] " + Number);
			Console.WriteLine("[제	목] " + Name);
			Console.WriteLine("[가격] " + Price);
			Console.WriteLine("[설명] " + Description);
		}

		public override string ToString()
		{
			return Number + "," + Name + "," + Price + "," + Description;
		}
	}
}
