using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    internal class Program
    {
        static void Main(string[] args)
        {                     
            int num     = 10;            
            object obj  = num;   //박싱 : 참조형타입 = 값타입
                                 //1) 힙 메모리를 생성하고 num의 값을 저장
                                 //2) 그 주소가 반환됨.

            int num1 = (int)obj; //언박싱 : 값타입 = 참조형타입
                                 //1) obj가 참조한 주소로 이동하여 값 획득
                                 //2) 획득한 값을 반환
        }
    }
}
