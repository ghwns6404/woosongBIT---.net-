//15_LinkedList.cs
using System;
using System.Collections.Generic;

namespace _0401
{
    internal class List_Sample
    {
        private LinkedList<int> datas = new LinkedList<int>();  //****

        #region 1. 저장(**AddLast, AddFirst***, AddBefore)
        public void Add_test()
        {
            for (int i = 1; i <= 5; i++)
            {
                datas.AddLast(i);
                datas.AddFirst(i);
            }
        }
        public void Insert_test()
        {
            try
            {
                LinkedListNode<int> node = datas.First;
                datas.AddBefore(node.Next.Next.Next, 10);
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
            bool ret = datas.Remove(3);     //값 전달

            try
            {
                datas.RemoveFirst();
                datas.RemoveLast();
            }
            catch (Exception ex)
            {
                Console.WriteLine("removeat : " + ex.Message);
            }

            datas.Clear();      //전체 삭제
        }
        #endregion

        #region 3. 수정(인덱서 활용)
        public void Update_test()
        {
            LinkedListNode<int> node = datas.First.Next.Next;
            node.Value = 300;
        }
        #endregion

        #region 4. 데이터 저장 여부 확인(Contains)
        public void DataCheck_test()
        {
            int value = 50;
            bool ret = datas.Contains(value);
            if (ret)
            {
                Console.WriteLine("저장 : O");
            }
            else
            {
                Console.WriteLine("저장 : X");
            }
        }
        #endregion

        #region 5. 검색(find)
        public void Select_test()
        {
            LinkedListNode<int> node = datas.Find(5);
            if (node != null)
                Console.WriteLine("검색결과 : " + node.Value);
            else
                Console.WriteLine("검색결과 : " + "없음");
        }
        #endregion
        
        public void Print_All()
        {
            Console.WriteLine("저장 개수 : " + datas.Count);

            foreach (int i in datas)
            {
                Console.Write(i + " ");
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
            sample.Update_test(); sample.Print_All();
            sample.DataCheck_test();
            sample.Select_test();

            sample.Remove_test(); sample.Print_All();
        }
    }
}
