using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode_Value_Reference
{
	// 클래스 정의
	public class MyClass
	{
		private int _i;

		public void Func1(int i)
		{
			_i = i; //5
		}
		public int Func2()
		{
			return _i;
		}
		public static MyClass Func3()
		{
			return new MyClass();	
		}
		public MyClass(int i = 10)
		{
			_i = i;
		}
		public override string ToString()
		{
			return $"MyClass: {_i}";
		}
	}

	// 구조체 정의
	public struct MyStruct
	{
		private int _i;

		public void Func1(int i)
		{
			_i = i;
		}
		public int Func2()
		{
			return _i;
		}
		public static MyStruct Func3()
		{
			return new MyStruct();
		}
		public MyStruct(int i)
		{
			_i = i;
		}
		public override string ToString()
		{
			return $"MyStruct: {_i}";
		}
    }

	internal class Program
	{
		static void Main(string[] args)
		{
			Sample1();
		}

		// 클래스 멤버 출력
		private static void Sample1()
		{
			MyClass func1 = new MyClass(30);	//30
			MyClass func2 = MyClass.Func3();   //10

			int i = func2.Func2();   //10

			func1.Func1(5); //*********************5

			func1.Func1(15);  //F1-10, F2-5
            Console.WriteLine(func1);	
			Console.WriteLine(func2);//***********************
		}


		// 구조체 멤버 출력
		private static void Sample2()
		{
			MyStruct func1 = new MyStruct();  //10
			MyStruct func2 = MyStruct.Func3();   //10
            int i = func2.Func2();   //10
			func1.Func1(5);	//5
			func2 = func1; //5
			func1.Func1(10); //10


            func2 = func1; 
            Console.WriteLine(func1); 
			Console.WriteLine(func2); 
        }
    }
}
