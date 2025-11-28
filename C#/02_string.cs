using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    internal class Sample1
    {
        //string 값 형식 처럼 사용(일반적 사용법)
        public static void Example1()
        {
            string s = string.Empty;
            Console.WriteLine(s);

            s = "Hello";
            Console.WriteLine(s);

            string s1 = s;  //동일한 문자열 주소를 저장하게 됨
            Console.WriteLine(s1);

            //"Hello 문자열 수정" 이 임시로 저장되고
            //저장된 주소가 s에 대입된다.
            s = "Hello 문자열 수정";
            Console.WriteLine(s);
            Console.WriteLine(s1);
        }
        
        //string 참조 형식 처럼 사용
        public static void Example2()
        {
            char[] temp = { 'a', 'b', 'c', '\0' };
            string str1 = new string(temp); //str1 100번지 저장 가정           

            string str2 = str1;             //str2 100번지 저장
            string str3 = new string(temp); //str3 200번지 저장 가정
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);
        }
    
        //string의 연산
        public static void Example3()
        {
            string str1 = "abc";    //어딘가 "abc"저장 주소 반환
            str1 = "abc" + "ABC";   //새로운 어딘가 "abcABC"저장 주소 반환
            Console.WriteLine(str1);

            string str2 = "abc";
            string str3 = "abc";

            //값 형식일 때는 동일
            //참조 형식 == (주소비교) Equals(값비교)
            if(str2 == str3)
                Console.WriteLine("동일");

            if(str2.Equals(str3) == true)
                Console.WriteLine("동일");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sample1.Example2();
        }
    }
}
