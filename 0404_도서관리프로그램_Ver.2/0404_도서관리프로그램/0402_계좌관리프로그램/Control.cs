//AccountControl.cs
using _0402_계좌관리프로그램;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Xml.Linq;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0404_도서관리프로그램_V2
{
    internal class BookControl
    {
        MyDB myDB = MyDB.Singleton;
        #region BookControl 의 싱글톤
        public static BookControl Singleton { get; } = null;
        static BookControl()
        {
            Singleton = new BookControl();
        }
        #endregion

        #region Product 의 기능메서드
        public void BookInsert() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 저장]\n");

                string name = WbLib.InputString("도서명 입력");
                int price = WbLib.InputInteger("가격 입력");
                string description = WbLib.InputString("저자 입력");

                string sql = string.Format($"INSERT INTO s_product VALUES('{name}', {price}, '{description}')");
                MyDB.Singleton.ExSqlCommand(sql);

                Console.WriteLine("도서 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[도서 저장 실패] " + ex.Message);
            }
        }
        public void BookSelect()//ㅇㅋ
        {
            try
            {

                Console.WriteLine("\n[도서 검색]\n");

                string name = WbLib.InputString("도서명 입력");

                Book b1 = myDB.SelectBook(name);

                Console.WriteLine("-------------------------------");
                Console.WriteLine("책번호 : " + b1.Number);
                Console.WriteLine("도서명 : " + b1.Name);
                Console.WriteLine("가 격 : " + b1.Price);
                Console.WriteLine("저 자 : " + b1.Description);
                Console.WriteLine("-------------------------------");

                Console.WriteLine("[도서 검색 성공] ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[도서 검색 실패] " + ex.Message);
            }
        }
        public void BookUpdate() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 수정]\n");

                string name = WbLib.InputString("도서명 입력");
                int price = WbLib.InputInteger("수정금액 입력");

                string sql = string.Format($"update s_product set price = '{price}' where pname = '{name}';");
                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("수정 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[수정 실패] " + ex.Message);
            }
        }
        public void BookDelete() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 삭제]\n");

                string name = WbLib.InputString("삭제할 도서명 입력");
                string sql = string.Format($"delete from s_product where pname='{name}';");
                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("도서 삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[삭제 실패] " + ex.Message);
            }
        }
        public void SelectNameAll()//ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 전체출력]\n");

                List<Book> books = new List<Book>();
                string sql = string.Format($"select * from s_Product, s_custom, s_sale;");

                List<Book> printall = myDB.SelectAll_pro();

                foreach (Book book in printall)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("책번호 : " + book.Number);
                    Console.WriteLine("도서명 : " + book.Name);
                    Console.WriteLine("가  격 : " + book.Price);
                    Console.WriteLine("저  자 : " + book.Description);
                    Console.WriteLine("-------------------------------------------------");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("[전체출력 실패] " + ex.Message);
            }
        }
        #endregion
    }
    internal class CustControl
    {
        MyDB myDB = MyDB.Singleton;
        #region 0. 싱글톤 패턴
        public static CustControl Singleton { get; } = null;
        static CustControl()
        {
            Singleton = new CustControl();
        }
        #endregion

        #region Customer 의 기능 메서드
        public void CustomerInsert() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[고객 저장]\n");

                string cname = WbLib.InputString("고객명 입력");
                string phone = WbLib.InputString("고객 전화번호 입력");
                string addr = WbLib.InputString("주소 입력");

                string sql = string.Format($"INSERT INTO s_custom VALUES('{cname}', {phone}, '{addr}')");
                MyDB.Singleton.ExSqlCommand(sql);

                Console.WriteLine("고객 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[고객 저장 실패] " + ex.Message);
            }
        }
        public void CustomerSelect() //ㅇㅋ
        {
            try
            {

                Console.WriteLine("\n[고객 검색]\n");

                string cname = WbLib.InputString("고객명 입력");

                Customer b1 = myDB.SelectCustomer(cname);

                Console.WriteLine("-------------------------------");
                Console.WriteLine("고객고유번호 : " + b1.CNumber);
                Console.WriteLine("고객이름 : " + b1.Cname);
                Console.WriteLine("고객폰번호: " + b1.CPhone);
                Console.WriteLine("고객주소: " + b1.CAddr);
                Console.WriteLine("-------------------------------");

                Console.WriteLine("[고객 검색 성공] ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[고객 검색 실패] " + ex.Message);
            }
        }
        public void CustomerUpdate() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[고객 수정]\n");

                string cname = WbLib.InputString("고객 입력");
                string phone = WbLib.InputString("수정할 고객 번호 입력");

                string sql = string.Format($"update S_Custom set phone = {phone} where cname = '{cname}';");
                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("수정 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[수정 실패] " + ex.Message);
            }
        }
        public void CustomerDelete() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[고객 삭제]\n");

                string cname = WbLib.InputString("삭제할 고객명 입력");
                string sql = string.Format($"delete from s_custom where cname='{cname}';");
                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("고객 삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[삭제 실패] " + ex.Message);
            }
        }
        public void SelectCustomerAll()//ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[고객 전체출력]\n");

                List<Customer> cust = new List<Customer>();
                string sql = string.Format($"select * from S_Custom;");

                List<Customer> printall = myDB.SelectAll_cust();

                foreach (Customer custs in printall)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("고객번호 : " + custs.CNumber);
                    Console.WriteLine("고객명 : " + custs.Cname);
                    Console.WriteLine("고객번호 : " + custs.CPhone);
                    Console.WriteLine("고객주소: " + custs.CAddr);
                    Console.WriteLine("-------------------------------------------------");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("[전체출력 실패] " + ex.Message);
            }
        }
        #endregion

        #region CustControl 의 Init / Exit
        public void Init()
        {
            try
            {
                if (myDB.Connect() == false)
                    return;
                Console.WriteLine("---DB연결됨---");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB연결 실패] " + ex.Message);
            }
            WbLib.Pause();
        }
        public void Exit()
        {
            if (myDB.Close() == true)
                Console.WriteLine("DB연결종료");
        }
        #endregion
    }
    internal class SaleControl
    {
        #region 0. 싱글톤 패턴
        public static SaleControl Singleton { get; } = null;
        static SaleControl()
        {
            Singleton = new SaleControl();
        }
        #endregion
        MyDB myDB = MyDB.Singleton;

        public void SaleInsert_Temp() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[임시데이터 저장]\n");

                int cid = WbLib.InputInteger("Customer ID 입력");
                int pid = WbLib.InputInteger("Product ID 입력");
                int count = WbLib.InputInteger("제품 수량 입력");
                string saledate = DateTime.Now.ToString("yyyy-MM-dd");


                string sql = string.Format($"INSERT INTO s_sale VALUES('{cid}', {pid}, '{count}', '{saledate}')");
                MyDB.Singleton.ExSqlCommand(sql);

                Console.WriteLine("S_SALE의 임시데이터 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("임시 저장 실패!! " + ex.Message);
            }
        }
        public void SaleUpdateCount()//수정
        {
            try
            {
                Console.WriteLine("누가, 어떤책을 몇개 구매했다 -> 몇개 수정");

                string cname = WbLib.InputString("누가(고객명)");
                string pname = WbLib.InputString("어떤 책을(책이름)");
                int count = WbLib.InputInteger("몇개 구매로 변경(변경할 갯수)");

                string sql = string.Format($"update s set s.count = '{count}' from s_sale s join s_custom c on s.cid = c.cid join s_prod    uct p on s.pid = p.pid where c.cname = '{cname}' and p.pname = '{pname}';");


                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("수정 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[수정 실패] " + ex.Message);
            }
        }
        public void SaleDeleteCount()//삭제
        {
            try
            {
                Console.WriteLine("누가, 어떤책을 몇개 구매했다가 환불 -> 삭제");

                string cname = WbLib.InputString("누가(고객명)");
                string pname = WbLib.InputString("어떤 책을(책이름)");
                int count = WbLib.InputInteger("몇개 환불(삭제할 갯수)");

                string sql = string.Format($"update s set s.count = count - '{count}' from s_sale s join s_custom c on s.cid = c.cid join s_product p on s.pid = p.pid where c.cname = '{cname}' and p.pname = '{pname}';");


                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[삭제 실패] " + ex.Message);
            }
        }
        public void SaleSelectMax()//삭제
        {
            try
            {
                Console.WriteLine("\n[제일 많이 팔린 책 출력]\n");

                List<Sale> sales = new List<Sale>();
                string sql = string.Format($"SELECT TOP 1 p.pname, SUM(s.count) AS total_count FROM s_sale s JOIN s_product p ON s.PID = p.PID GROUP BY p.pname ORDER BY total_count DESC;");

                List<Sale> printallMax = myDB.SelectMax();

                foreach (Sale sale in printallMax)
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("젤 많이 팔린거 : " + sale.Total_count);
                    Console.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[검색 실패] " + ex.Message);
            }
        }
        public void SaleSelectLog()
        {
            try
            {
                Console.WriteLine("\n[도서 전체출력]\n");
                string cname = WbLib.InputString(" 검색할 이름 ");

                string sql = string.Format($"select * from s_Product;");

                List<SubSale> subsales = myDB.SelectLog(cname);

                foreach (SubSale subsale in subsales)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("도서명 : " + subsale.Pname);
                    Console.WriteLine("갯  수 : " + subsale.Count);
                    Console.WriteLine("구매날짜 : " + subsale.Saledate);
                    Console.WriteLine("-------------------------------------------------");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("[전체출력 실패] " + ex.Message);
            }
        }
    }

}