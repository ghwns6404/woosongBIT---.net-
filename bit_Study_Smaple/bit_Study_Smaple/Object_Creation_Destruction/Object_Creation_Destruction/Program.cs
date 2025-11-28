// Program.cs
using System;

namespace Object_Creation_Destruction
{
	internal class Program
	{
		private static MyClass _myclass = null;
		static void Main(string[] args)
		{
			Sample1();
		}

		private static void Sample1()
		{
			MyClass myClass = new MyClass(0); // 객체 생성
			myClass.Work();
            //Console.ReadLine();
            MyClass myClass1 = new MyClass(1);
            myClass.Work();
            MyClass myClass2 = new MyClass(2);
            myClass.Work();
            MyClass myClass3 = new MyClass(3);
            MyClass myClass4 = new MyClass(4);
            MyClass myClass6 = new MyClass(6);
            MyClass myClass7 = new MyClass(7);
        }
		private static void Sample2()
		{
			// 생성되지 않은 객체를 참조함
			_myclass.Work();
			_myclass = new MyClass();

        }
	}
}
