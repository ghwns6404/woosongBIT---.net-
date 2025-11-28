using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 학생관리
{
    class Student
    {
        private List<Student> students = new List<Student>();

        #region 1. 멤버필드, 프로퍼티
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int Number { get; private set; }
        #endregion

        #region 2. 생성자
        public Student(string _name, string _major, int _number)
        {
            Name = _name;
            Major = _major;
            Number = _number;
        }
        #endregion

        #region 3. 메서드(기능)
        public void PrintAll()
        {
            Console.WriteLine("----전체출력---- ");
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("전공 : " + Major);
            Console.WriteLine("학번 : " + Number);
        }
        public void UpdateStudent(string _name, string _major, int _number)
        {
            Name = _name;
            Major = _major;
            Number = _number;
        }
        



        #endregion
    }
}
