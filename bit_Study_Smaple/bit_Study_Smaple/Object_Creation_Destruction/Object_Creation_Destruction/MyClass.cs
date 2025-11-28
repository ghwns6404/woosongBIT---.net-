// MyClass.cs
using System;

namespace Object_Creation_Destruction
{
	internal class MyClass
	{
		int id;
		public MyClass()
		{
			Console.WriteLine($"객체{id}가 생성되었습니다.");
		}
		~MyClass()
		{
			Console.WriteLine($"객체{id}가 소멸되었습니다");
		}

		public void Work()
		{
			Console.WriteLine("클래스가 작동 중 입니다");
		}
        public MyClass(int id)
		{
			this.id = id;
		}
    }
}
