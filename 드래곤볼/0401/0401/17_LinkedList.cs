//15_LinkedList(Member).cs
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
        private LinkedList<Member> datas = new LinkedList<Member>();  //****

        #region 1. 저장(**AddLast, AddFirst***, AddBefore)
        public void Add_test()
        {
            datas.AddLast(new Member("홍길동", "010-1111-1111"));
            datas.AddFirst(new Member("김길동", "010-2222-2222"));
        }
        public void Insert_test()
        {
            try
            {
                LinkedListNode<Member> node = datas.First;
                datas.AddBefore(node.Next, new Member("고길동", "010-3333-3333"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 2. 삭제(***Remove***, RemoveFirst, RemoveLast, Clear)
        public void Remove_test()
        {
            LinkedListNode<Member> node = datas.First;
            bool ret = datas.Remove(node.Next.Value);     //값 전달
            if (ret == true)
                Console.WriteLine("삭제 성공");
        }
        public void RemoveFirst_Last_test()
        {
            try
            {
                datas.RemoveFirst();
                datas.RemoveLast();
                Console.WriteLine("삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("removeat : " + ex.Message);
            }
        }
        public void Clear_test()
        {
            datas.Clear();
        }
        #endregion

        #region 3. 수정(인덱서 활용)
        public void Update_test()
        {
            LinkedListNode<Member> node = datas.First.Next.Next;
            Member member = node.Value;
            member.Phone = "010-7777-7777";
        }
        #endregion

        #region 4. 데이터 저장 여부 확인(Contains)
        public void DataCheck_test()
        {           
        }
        #endregion

        #region 5. 검색(find)

        private Member FindName(string name)
        {
            foreach(Member mem in datas)
            {
                if(mem.Name == name)
                    return mem;
            }
            return null;
        }

        public void Select_test()
        {           
            string name = "홍길동";
            Member member = FindName(name);
            if (member != null)
                Console.WriteLine("검색결과 : " + member.ToString());
            else
                Console.WriteLine("검색결과 : " + "없음");
        }
        #endregion

        public void Print_All()
        {
            Console.WriteLine("저장 개수 : " + datas.Count);

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
            sample.Add_test(); sample.Print_All();
            sample.Insert_test(); sample.Print_All();
            sample.Select_test();
            sample.Update_test(); sample.Print_All();            
            //sample.DataCheck_test();
            
            sample.Remove_test();           sample.Print_All();
            sample.RemoveFirst_Last_test(); sample.Print_All();
            sample.Clear_test();            sample.Print_All();
        }
    }
}
