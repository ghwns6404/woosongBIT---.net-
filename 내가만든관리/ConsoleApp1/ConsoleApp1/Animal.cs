using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Animal 
    {
        private List<Animal> animals = new List<Animal>();  

        #region 멤버필드, 프로퍼티
        public string Name { get;  set; }
        public int Age { get;  set; }
        public string Kind { get;  set; }
        #endregion

        #region 생성자
        public Animal(string _name, int _age, string _kind)
        {
            Name = _name;
            Age = _age;
            Kind = _kind;
        }
        #endregion

        #region 기능
        public void Print()
        {
            Console.Write("이름:" + Name + "\t");
            Console.Write("나이:" + Age + "\t");
            Console.Write("종:" + Kind + "\n\n");
        }
        public void PrintAll()
        {
            Console.Write("이름:" + Name + "\t");
            Console.Write("나이:"+ Age + "\t");
            Console.Write("종:"+ Kind + "\n\n");
        }
        //정렬
        //public int CompareTo(object obj)
        //{
        //    Animal animal = (Animal)obj;
        //    return Name.CompareTo(animal.Name);
        //}

        #endregion
    }
}
