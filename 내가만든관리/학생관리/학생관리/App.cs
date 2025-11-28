using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 학생관리
{
    class App
    {
        private StudentControl conStudent = StudentControl.Singleton;

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
            conStudent.Init();
            WbLib.Logo();
        }
        public void Run()
        {
            while (true)
            {
                //Console.Clear();
                switch (WbLib.MenuPrint())
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1: conStudent.AddStudent(); break;
                    case ConsoleKey.F2: conStudent.SelectStudent(); break;
                    case ConsoleKey.F3: conStudent.UpdateStudent(); break;
                    case ConsoleKey.F4: conStudent.DeleteStudent(); break;
                    case ConsoleKey.F5: conStudent.SortStudent(); break;
                    
                }
                WbLib.Pause();
            }

            
        }

        public void Exit()
        {
            conStudent.Exit();

            WbLib.Ending();
        }


    }
}
