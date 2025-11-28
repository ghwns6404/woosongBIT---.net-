//16_List.cs(Member객체 저장)
using System;
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

    internal class List_Sample
    {
        private List<Member> datas = new List<Member>();  //****

        #region 1. 저장(**Add***, Insert)
        public void Add_test()
        {
            datas.Add(new Member("홍길동", "010-1111-1111"));
            datas.Add(new Member("김길동", "010-2222-2222"));
            datas.Add(new Member("이길동", "010-3333-3333"));
        }
        public void Insert_test()
        {
            try
            {
                //가능범위 : 0 ~ Count
                datas.Insert(3, new Member("허길동", "010-4444-4444"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 2. 삭제(Remove, RemoveAt, Clear)
        public void Remove_test()
        {
            string select_phone = "010-2222-2222";
            Member member = datas.Find(n => n.Phone == select_phone);
            bool ret = datas.Remove(member);     //값 전달
            if (ret == true)
                Console.WriteLine("Remove 성공");
        }
        public void RemoveAt_test()
        {
            try
            {
                datas.RemoveAt(1);          //인덱스 전달
            }
            catch (Exception ex)
            {
                Console.WriteLine("removeat : " + ex.Message);
            }
        }
        public void Clear_test()
        {
            datas.Clear();      //전체 삭제
        }
        #endregion

        #region 3. 수정(인덱서 활용)
        public void Update_test()
        {
            string select_phone = "010-3333-3333";
            Member member = datas.Find(n => n.Phone == select_phone);
            member.Phone = "010-7777-7777";
        }
        #endregion

        #region 4. 데이터 저장 여부 확인(Contains), 인덱스 획득(IndexOf)
        public void DataCheck_test()
        {
            Member member = datas[1];
            bool ret = datas.Contains(member);
            if (ret)
            {
                int idx = datas.IndexOf(member);
                Console.WriteLine("저장된 인덱스 : " + idx);
            }
        }
        #endregion

        #region 5. 검색(find)
        public void Select_test()
        {
            //람다식
            /*
             * n : 매개변수
             * => : 구분자
             * n == 5 : 함수 코드 작성부
             */
            string select_phone = "010-3333-3333";
            Member member = datas.Find(n => n.Phone == select_phone);
            if (member == null) //기본값
            {
                Console.WriteLine("없다");
            }
            else
            {
                Console.WriteLine("검색결과 : " + member.ToString());
            }
        }
        #endregion

        public void Print_All()
        {
            Console.WriteLine("저장 개수 : " + datas.Count);
            for (int i = 0; i < datas.Count; i++)
            {
                Member member = datas[i];
                Console.Write(member + " ");
            }
            Console.WriteLine();

            foreach (Member member in datas)
            {
                Console.Write(member + " ");
            }
            Console.WriteLine();
        }
    }
    internal class Start
    {
        static void Main(string[] args)
        {
            List_Sample sample = new List_Sample();
            sample.Add_test();  sample.Print_All();
            sample.Insert_test(); sample.Print_All();

            sample.Select_test();
            sample.Update_test(); sample.Print_All();
            
            sample.DataCheck_test();

            sample.Remove_test();   sample.Print_All();
            sample.RemoveAt_test(); sample.Print_All();
            sample.Clear_test();    sample.Print_All();
        }
    }
}
