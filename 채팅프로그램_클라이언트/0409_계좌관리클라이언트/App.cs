//App.cs
using _0409_계좌관리클라이언트;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WoosongBit41.ClientNet;
using WoosongBit41.Lib;

namespace 채팅프로그램_클라이언트
{
    internal class App
    {
        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        private App() { }
        #endregion

        public void Init()
        {
            UserControl.Singleton.Init();
            WbLib.Logo();
        }
        public void Run()
        {
            while (true)
            {
                Screen1();
                try
                {
                    Screen2();
                    Screen3();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void Screen1()
        {
            while (MyClient.MyUser.Name == null)
            {
                try
                {
                    Console.Clear();
                    switch (WbLib.MenuPrint1())
                    {
                        case ConsoleKey.Escape: throw new Exception("나가기"); // 잘못된 키 입력 예외 처리
                        case ConsoleKey.F1: InsertUser.Invoke(); break; // 회원가입
                        case ConsoleKey.F2: LoginUser.Invoke(); return;  // 로그인
                        case ConsoleKey.F3: DeleteUser.Invoke(); break; // 삭제
                        case ConsoleKey.F4: return; //돌아가기
                        default: Console.WriteLine("잘못 입력하셨습니다."); break;
                    }

                    Thread.Sleep(30); // 서버로부터 데이터 수신 -> 출력
                    WbLib.Pause();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void Screen2()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    switch (WbLib.MenuPrint2())
                    {
                        case ConsoleKey.F4: return; //돌아가기
                        case ConsoleKey.F1: FindUser.Invoke(); break; // 유저 선택
                        case ConsoleKey.F2: break; // Y
                        case ConsoleKey.F3: break; // N
                        default: Console.WriteLine("잘못 입력하셨습니다."); break;
                    }
                    Thread.Sleep(1000); // 서버로부터 데이터 수신 -> 출력
                    WbLib.Pause();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void Screen3()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    switch (WbLib.MenuPrint3())
                    {
                        case ConsoleKey.F4: return; //돌아가기
                        case ConsoleKey.F1: SendMessageUser.Invoke(); break; // 메시지 보내기
                        case ConsoleKey.F2: SendAllUser.Invoke(); break; // 전체 메시지 보내기
                        case ConsoleKey.F3: ExitUser.Invoke(); break; // 대화 중단
                        default: Console.WriteLine("잘못 입력하셨습니다."); break;
                    }

                    Thread.Sleep(1000); // 서버로부터 데이터 수신 -> 출력
                    WbLib.Pause();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public void Exit()
        {
            UserControl.Singleton.Exit();
            WbLib.Ending();
        }
    }
}
