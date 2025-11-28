using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 학생관리
{
    class StudentControl
    {
        private List<Student> students = new List<Student>();

        #region 1. 싱글톤 패턴 적용
        public static StudentControl Singleton { get; } = null; //전역에서 이거 딱 하나만 접근할 수 있게 만듦 즉, 유일한 인스턴스 생성
        static StudentControl()
        {
            Singleton = new StudentControl(); //객체를 딱 한번만 만듦
        }                                     //정적 생성자로 프로그램이 처음 시작할 때 딱 한번만 실행됨
        private StudentControl() //private로 선언함 즉, 다른곳에서 new로 직접 만들지 마라.
        {
        }
        #endregion

        #region 2. 기능 (CRUD)
        public void AddStudent()
        {
            Console.WriteLine("학생정보 입력 :");

            string name = WbLib.InputString("이름");
            string major = WbLib.InputString("전공");
            int number = WbLib.InputInteger("학번");

            Student student = new Student(name, major, number);
            students.Add(student);

            if (students == null)
                Console.WriteLine("학생정보가 없습니다.");
            else
                Console.WriteLine("학생정보가 추가되었습니다.");

            Console.Clear();
            Console.WriteLine();
            student.PrintAll();

        }   //dz
        public void SelectStudent()
        {
            Console.WriteLine("검색할 학생이름 입력 :");

            string name = WbLib.InputString("이름");
            try
            {
                Student student = students.Find(s => s.Name == name);
                student.PrintAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("학생정보가 없습니다." + ex.Message);
            }

        }   //dz
        public void UpdateStudent()
        {
            Console.WriteLine("수정할 학생이름 입력 :");

            string name = WbLib.InputString("이름");
            string major = WbLib.InputString("전공");
            int number = WbLib.InputInteger("학번");

            var student = students.Find(s => s.Name == name);

            if (student != null)
            {   
                student.UpdateStudent(name, major, number);
            }
            else
            {
                Console.WriteLine("학생정보가 없습니다.");
            }
        }   //dz
        public void DeleteStudent()
        {
            Console.WriteLine("삭제할 학생이름 입력 :");
            string name = WbLib.InputString("이름");
            var student = students.Find(s => s.Name == name);
            if (student == null)
            {
                Console.WriteLine("학생정보가 없습니다.");
                return;
            }
            else
                students.Remove(student);
        }   //dz
        public void SortStudent()
        {
            students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
            Console.WriteLine("학생정보가 정렬되었습니다.");
        }   //dz

        #endregion

        public void Init()
        {
            //try
            //{
            //    //WbFile.Read_Animals(animals);
            //    Console.WriteLine("파일 로드 성공.................");
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine("파일 로드 실패(최초 실행)..........");
            //    Console.WriteLine(ex.Message);
            //}
            WbLib.Pause();
        }
        public void Exit()
        {
            WbLib.Ending();
        }

    }
        
}
