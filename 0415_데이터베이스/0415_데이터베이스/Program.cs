using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0415_데이터베이스
{
    internal class Program
    {
        public static void MyDB_TEST()
        {
            MyDB myDB = new MyDB();
            if (myDB.Connect() == false)
                return;
            Console.WriteLine("DB연결");

            //myDB.Insert_Book("C언어", 15000, "C언어의 설명문.....");
            //myDB.Update_Book1(1000, 30000);
            //myDB.update_Book2("C언어", 18000);
            //myDB.Delete_Book1(1000);
            //myDB.Delete_Book2("C언어");
            int total = myDB.Get_TotalPrice();
            int max = myDB.Get_MaxPrice();
            Console.WriteLine(total + ", " + max);

            List<Book> books = myDB.SelectAll();
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            Book book1 = myDB.SelectBook(1010);
            Console.WriteLine(book1?.Name + ", " + book1?.Price);

            if (myDB.Close() == true)
                Console.WriteLine("DB연결종료");
        }
        
        public static void MyDB1_TEST()
        {
            MyDB1 myDB1 = new MyDB1();
            if (myDB1.Connect() == false)
                return;
            Console.WriteLine("DB연결");

            //myDB1.AddProduct("C++언어", 18000, "C++언어교재....");
            myDB1.FindCIDByName("김길동");

            myDB1.Close();
        }
       
        public static void MyMemoryDB_Test()
        {
            MyMemoryDB db = new MyMemoryDB();
            db.Create_AccountTable();           

            db.Account_Insert("홍길동");
            db.Account_Insert("김길동", 1000);
            db.Account_Insert("고길동", 4000, DateTime.Now);

            db.Print_TableSchema(db.Account_Table);
            List<Account> accounts = db.Account_SelectAll();
            foreach(Account account in accounts)
            {
                Console.WriteLine(account);
            }

            Account acc = db.Account_Select(1000);
            if(acc != null)
            {
                Console.WriteLine(acc);
            }
            else
            {
                Console.WriteLine("없는 id");
            }

            Console.WriteLine("\n\n삭제 및 입금 후 상황");
            db.Account_Delete(1000);
            db.Account_Update_InputMoney(1010, 500);
            List<Account> accounts1 = db.Account_SelectAll();
            foreach (Account account in accounts1)
            {
                Console.WriteLine(account);
            }

            db.Account_Write_Xml();
        }

        public static void MyMemoryDB_Test1()
        {
            MyMemoryDB db = new MyMemoryDB();
            db.Account_Read_Xml();
            //db.Create_AccountTable();
            db.Print_TableSchema(db.Account_Table);

            List<Account> accounts1 = db.Account_SelectAll();
            foreach (Account account in accounts1)
            {
                Console.WriteLine(account);
            }

        }
        
        public static void  MyDB2_Test()
        {
            MyDB2 db = new MyDB2();
            List<string> ret = db.Custom_SelectAll();
            foreach(string s in ret)
                Console.WriteLine(s);

            db.Custom_Insert("홍길동", "010-7777-7777", "대전 동구 자양동");
            db.Custom_Update(3, "010-1234-5678", "대전 중구");
            db.Custom_Delete(2);

            db.MemoryToDataBase();
            
        }
        static void Main(string[] args)
        {
            MyDB2_Test();
        }
    }
}
