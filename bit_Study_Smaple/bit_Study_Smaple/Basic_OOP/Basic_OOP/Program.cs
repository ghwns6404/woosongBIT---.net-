using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Basic_OOP
{
	internal class Program
	{
		static void Main(string[] args)
		{
            int water = InputInteger("수분량 입력");

            Human human = new Human(false, water);
			WaterCup watercup = new WaterCup();
            watercup.Drink();

            Console.WriteLine(human);
		}
		public static int InputInteger(string msg)
		{
			Console.Write(msg + " :");
			return int.Parse(Console.ReadLine());
		}
	}
}
