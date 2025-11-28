using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class AnimalControl
    {
        private List<Animal> animals = new List<Animal>();

        #region 1. 싱글톤 패턴 적용
        public static AnimalControl Singleton { get; } = null;
        //전역에서 이거 딱 하나만 접근할 수 있게 만듦 즉, 유일한 인스턴스 생성
        static AnimalControl()
        {
            Singleton = new AnimalControl(); //객체를 딱 한번만 만듦
        }//정적 생성자로 프로그램이 처음 시작할 때 딱 한번만 실행됨
        private AnimalControl() //private로 선언함 즉, 다른곳에서 new로 직접 만들지 마라.
        {
            // 초기화 작업
            //animals.Add(new Animal("코끼리", 10, "포유류"));
            //animals.Add(new Animal("독수리", 5, "조류"));
            //animals.Add(new Animal("상어", 8, "어류"));
        }
        #endregion
        #region 2. CRUD 기능
        //삽입
        public void InsertAnimal()
        {
            Console.WriteLine("\n[동물 저장]\n");

            string name = WbLib.InputString("이름 입력");
            int age = WbLib.InputInteger("나이 입력");
            string kind  = WbLib.InputString("종 입력");

            Animal animal = new Animal(name, age, kind);
            animals.Add(animal);

            Console.Clear();
            Console.Write("----저장된 동물 리스트----\n");
            PrintAll();
        }

        //검색
        public void SelectAnimal()
        {
            try
            {
                Console.WriteLine("\n[동물 검색]\n");

                string name = WbLib.InputString("동물 입력");
                Animal animal = NameToAnimal(name);

                animal.PrintAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[도서명 검색 실패] " + ex.Message);
            }

        }

        //수정
        public void UpdateAnimal()
        {
            Console.WriteLine("\n[동물 수정]\n");

            string name = WbLib.InputString("이름 입력");
            int age = WbLib.InputInteger("나이 입력");
            string kind = WbLib.InputString("종 입력");


            var animal = animals.Find(a => a.Name == name);
            if (animal != null)
            {
                animal.Age = age;
                animal.Kind = kind;
                Console.WriteLine("동물정보 수정완료");
                
            }
            else
            {
                Console.WriteLine("동물정보 수정실패");
            }
        }

        //삭제
        public void DeleteAnimal()
        {
            Console.WriteLine("\n[동물 삭제]\n");

            string name = WbLib.InputString("이름 입력");           

            int idx = NameToIdx(name);
            animals.RemoveAt(idx);
            Console.WriteLine("삭제 완료");
        }

        //정렬
        public void Sort()
        {
            animals.Sort((a, b) => a.Name.CompareTo(b.Name)); //이름으로 정렬
        }
        //전체출력
        public void PrintAll()
        {
            Console.WriteLine("동물정보 전체출력");
            if(animals.Count == 0)
            {
                Console.WriteLine("동물정보가 없습니다.");
                return;
            }
            else
            {
                foreach (var animal in animals) // foreach문을 사용하여 animals 리스트에 있는 모든 동물정보를 출력
                {
                    animal.PrintAll();
                }
            }
               
        }
        #endregion
        #region 3. 내부사용 메서드
        private int NameToIdx(string name)
        {
            for (int i = 0; i < animals.Count;  i++)
            {
                Animal animal = (Animal)animals[i];
                if (animal.Name == name)
                    return i;
            }
            throw new Exception("없는 책 입니다.");
        }
        private Animal NameToAnimal(string name)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = (Animal)animals[i];
                if (animal.Name == name)
                    return animal;
            }
            throw new Exception("없는 책 입니다.");
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }
        #endregion
        #region 4. 시작과 종료 메서드
        public void Init()
        {
            try
            {
                WbFile.Read_Animals(animals);
                Console.WriteLine("파일 로드 성공.................");
            }
            catch (Exception ex)
            {
                Console.WriteLine("파일 로드 실패(최초 실행)..........");
                Console.WriteLine(ex.Message);
            }
            WbLib.Pause();
        }
        public void Exit()
        {
            WbFile.Write_Animals(animals);
        }
        #endregion
        
    }
}
