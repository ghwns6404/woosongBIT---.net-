using System;
using System.Collections;
using System.Collections.Generic;

namespace _0401
{
    internal class Member
    {
        public string Name { get; private set; }
        public string Phone { get; set; }

        public Member(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public override string ToString()
        {
            return Name + "\t" + Phone;
        }
    }

    internal class Sample
    {
        //검색에 최적화(사용자 입장에서 검색이 필요없다.)
        private Dictionary<string, Member> datas = new Dictionary<string, Member>();

        #region  저장
        public void Add_Test()
        {
            //key 충돌 X
            try
            {
                datas.Add("홍길동", new Member("홍길동", "010-1111-1111"));
                datas.Add("김길동", new Member("김길동", "010-2222-2222"));
                datas.Add("이길동", new Member("이길동", "010-3333-3333"));
                datas.Add("이길동", new Member("이길동", "010-3333-3333")); //X
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Add_Test1()
        {
            datas["허길동"] = new Member("허길동", "010-4444-4444");
            datas["고길동"] = new Member("고길동", "010-5555-5555");

            //동일한 키 존재 -> 수정
            datas["고길동"] = new Member("고길동", "010-1234-5678");
        }
        #endregion

        #region 검색(KEY)
        public void Select_Test()
        {
            try
            {
                Member member = datas["홍길동"];
                Console.WriteLine(member);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region 삭제
        public void Remove_Test()
        {
            if (datas.Remove("홍길동1") == true)
                Console.WriteLine("삭제 성공");
            else
                Console.WriteLine("삭제 실패");
        }
        #endregion

        #region 수정
        public void Update_Test()
        {
            //동일한 키 존재 -> 수정
            datas["고길동"] = new Member("고길동", "010-1234-5678");

            //일반적인 수정 작업
            Member member = datas["홍길동"];
            member.Phone = "010-9999-9999";
        }
        #endregion

        #region 키값 확인
        public void KeyCheck()
        {
            bool b = datas.ContainsKey("홍길동");
            if (b == true)
                Console.WriteLine("있다 -> 사용할 수 없는 키");
            else
            {
                Console.WriteLine("저장 기능 수행");
            }
        }
        #endregion

        public void Print_Test()
        {
            foreach (KeyValuePair<string, Member> m in datas)
            {
                Console.Write("[{0}] {1} \t", m.Key, m.Value);
            }
            Console.WriteLine();

            foreach (string m in datas.Keys)
            {
                Console.Write("{0}\t", m);
            }
            Console.WriteLine();

            foreach (Member m in datas.Values)
            {
                Console.Write("{0}\t", m);
            }
            Console.WriteLine();
        }
    }

    internal class Start
    {
        static void Main(string[] args)
        {
            Sample s = new Sample();
            s.Add_Test();               s.Print_Test();
            Console.WriteLine("\n");
            s.Add_Test1();              s.Print_Test();
            Console.WriteLine("\n");
            s.Select_Test();
            s.Remove_Test(); s.Print_Test();

            s.KeyCheck();
        }
    }
}
