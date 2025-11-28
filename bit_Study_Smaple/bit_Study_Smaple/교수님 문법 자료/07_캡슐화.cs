using System;

namespace _0401
{
    //C++ : 맴버필드 > 생성자 & 소멸자 > **get &set메서드 > 기능메서드
    //C#  : 맴버필드 >> **속성(프로퍼티) >> 생성자 >> 기능메서드 
    internal class Member
    {
        #region 1. 맴버필드 및 속성
        private string name;
        public string Name
        {
            get { return name;  }
            private set { name = value; }
        }

        private int age;
        public int Age
        {
            get { return age;  }
            set 
            {
                if (value < 0)
                    return;
                age = value; 
            }
        }

        private char gender;
        public char Gender
        {
            get { return gender;  }
            set 
            { 
                if(value == '남' || value == '여')
                    gender = value; 
            }
        }
        #endregion

        #region 2. 생성자(맴버메서드에서 속성(프로퍼티)을 사용 권장)
        public Member(string _name, int _age, char _gender)
        {
            Name   = _name;
            Age    = _age;
            Gender = _gender;
        }
        #endregion

        #region 3. 기능 메서드
        public void Print()
        {
            Console.WriteLine(Name + " " + Age + " " + Gender);
        }
        #endregion 
    }


    internal class _07_캡슐화
    {
        static void Main(string[] args)
        {
            Member m = new Member("홍길동", 20, '남');
            //m.Name      = "홍길동";
            m.Age       = -10;
            m.Gender    = '남';
            

            Console.WriteLine(m.Name);
            Console.WriteLine(m.Age);
            Console.WriteLine(m.Gender);

        }
    }
}
