using System;

namespace _0401
{
    #region 게시자와 구독자가 모두 알고 있는 정보
    //1. EventArg
    internal class CalArgs : EventArgs
    {
        public int Num1  { get; private set; }
        public int Num2  { get; private set; }
        public char Oper {  get; private set; }
        public int Result { get; private set; }

        public CalArgs(int num1, int num2, char oper,  int result)
        {
            this.Num1   = num1;
            this.Num2   = num2;
            this.Oper   = oper;
            this.Result = result;    
        }
    }

    //2. Delegate
    internal delegate void CalDel(object obj, CalArgs e);
    #endregion

    //[이벤트 게시자]
    internal class Sample
    {
        //3.1 이벤트 선언
        public event CalDel DelEvent = null;

        public void Add(int x, int y)
        {
            int result = x + y;

            //이벤트 발생(게시)
            if (DelEvent != null)
            {
                DelEvent(this, new CalArgs(x, y, '+' , result));
            }
        }
        public void Sub(int x, int y)
        {
            int result = x - y;

            //이벤트 발생(게시)
            if (DelEvent != null)
            {
                DelEvent(this, new CalArgs(x, y, '-', result));
            }
        }
    }

    internal class Start
    {
        //이벤트를 수신할 핸들러 함수
        static void ResultHandler(object obj, CalArgs e)
        {
            Console.WriteLine("{0} {1} {2} = {3}", e.Num1, e.Oper, e.Num2, e.Result);
        }
        static void Main(string[] args)
        {
            Sample s1 = new Sample();
            s1.DelEvent += ResultHandler;

            s1.Add(10, 20);
            s1.Sub(10, 20);           
        }
    }
}
