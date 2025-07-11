﻿// 커맨드 패턴
// 요청에 대한 모든 정보가 포함된 독립실행형 객체로 변환
// 다양한 요청들이 있는 메서드들을 인수화 할 수 있도록 하며,
// 요청의 실행을 지연 또는 대기열에 넣을 수 있도록 하고, 또 실행 취소할 수 있는 작업을 지원
namespace DesignPatterns.Behavioral
{/*-------------------- 
    // The Command interface declares a method for executing a command.
    public interface ICommand
    {
        void Execute ();
    }

    // Some commands can implement simple operations on their own.
    class SimpleCommand : ICommand
    {
        private string _payload = string.Empty;

        public SimpleCommand ( string payload )
        {
            this._payload = payload;
        }

        public void Execute ()
        {
            Console.WriteLine ( $"SimpleCommand: See, I can do simple things like printing ({this._payload})" );
        }
    }

    // However, some commands can delegate more complex operations to other objects, called "receivers."
    class ComplexCommand : ICommand
    {
        private Receiver _receiver;

        // Context data, required for launching the receiver's methods.
        private string _a;

        private string _b;

        // Complex commands can accept one or several receiver objects along
        // with any context data via the constructor.
        public ComplexCommand ( Receiver receiver, string a, string b )
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }

        // Commands can delegate to any methods of a receiver.
        public void Execute ()
        {
            Console.WriteLine ( "ComplexCommand: Complex stuff should be done by a receiver object." );
            this._receiver.DoSomething ( this._a );
            this._receiver.DoSomethingElse ( this._b );
        }
    }

    // The Receiver classes contain some important business logic. They know how
    // to perform all kinds of operations, associated with carrying out a
    // request. In fact, any class may serve as a Receiver.
    class Receiver
    {
        public void DoSomething ( string a )
        {
            Console.WriteLine ( $"Receiver: Working on ({a}.)" );
        }

        public void DoSomethingElse ( string b )
        {
            Console.WriteLine ( $"Receiver: Also working on ({b}.)" );
        }
    }

    // The Invoker is associated with one or several commands. It sends a
    // request to the command.
    class Invoker
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        // Initialize commands.
        public void SetOnStart ( ICommand command )
        {
            this._onStart = command;
        }

        public void SetOnFinish ( ICommand command )
        {
            this._onFinish = command;
        }

        // The Invoker does not depend on concrete command or receiver classes.
        // The Invoker passes a request to a receiver indirectly, by executing a
        // command.
        public void DoSomethingImportant ()
        {
            Console.WriteLine ( "Invoker: Does anybody want something done before I begin?" );
            if ( this._onStart is ICommand )
            {
                this._onStart.Execute ();
            }

            Console.WriteLine ( "Invoker: ...doing something really important..." );

            Console.WriteLine ( "Invoker: Does anybody want something done after I finish?" );
            if ( this._onFinish is ICommand )
            {
                this._onFinish.Execute ();
            }
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            // The client code can parameterize an invoker with any commands.
            Invoker invoker = new Invoker ();
            invoker.SetOnStart ( new SimpleCommand ( "Say Hi!" ) );
            Receiver receiver = new Receiver ();
            invoker.SetOnFinish ( new ComplexCommand ( receiver, "Send email", "Save report" ) );

            // 요청들을 주문서에 담은 뒤 요청
            // 주문서 = 커맨드 역할
            // 요리할 준비가 될 때까지 대기열에 남아 있음
            invoker.DoSomethingImportant ();
        }
    }
-------------------- */
    /*output

    Invoker: Does anybody want something done before I begin?
    SimpleCommand: See, I can do simple things like printing (Say Hi!)
    Invoker: ...doing something really important...
    Invoker: Does anybody want something done after I finish?
    ComplexCommand: Complex stuff should be done by a receiver object.
    Receiver: Working on (Send email.)
    Receiver: Also working on (Save report.)

     */
}