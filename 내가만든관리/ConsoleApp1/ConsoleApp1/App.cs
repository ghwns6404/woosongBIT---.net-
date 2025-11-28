using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class App
    {
        private AnimalControl conAnimal = AnimalControl.Singleton;
        #region 1. 싱글톤 패턴 적용
        public static App Singleton { get; } = null;


        //전역에서 이거 딱 하나만 접근할 수 있게 만듦 즉, 유일한 인스턴스 생성
        static App()
        {
            Singleton = new App(); //객체를 딱 한번만 만듦
        }//정적 생성자로 프로그램이 처음 시작할 때 딱 한번만 실행됨


        private App() //private로 선언함 즉, 다른곳에서 new로 직접 만들지 마라.
        {
            
        }
        #endregion

        public void Init()
        {
            conAnimal.Init();
            WbLib.Logo();
           
        }
        public void Run()
        {
            while(true)
            {
                //Console.Clear();
                switch (WbLib.MenuPrint())
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1:conAnimal.InsertAnimal();      break;
                    case ConsoleKey.F2:conAnimal.SelectAnimal();      break;
                    case ConsoleKey.F3:conAnimal.UpdateAnimal();      break;
                    case ConsoleKey.F4:conAnimal.DeleteAnimal();      break;
                    case ConsoleKey.F5: conAnimal.Sort();             break;
                    case ConsoleKey.F6:conAnimal.PrintAll();          break;
                }
                WbLib.Pause();
            }

        }
        public void Exit()
        {
            conAnimal.Exit();
            WbLib.Ending();

        }
    }
}
