//상태패턴
//객체의 상태에 따라 행위를 변경할 수 있도록 하는 패턴
//ex) 같은 버튼이지만 상태에 따라 다르게 동작
//일반적으로 객체의 상태에 따라 적절한 행동들을 선택하는 많은 조건문​(if 또는 switch)​으로 구현
//>>비효율적이고 유지보수가 어려움
//상태 패턴은 상태를 클래스로 표현하고, 각 상태에서 할 수 있는 행동을 메소드로 구현
namespace DesignPatterns.Behavioral
{/* --------------------
    // The Context defines the interface of interest to clients. It also
    // maintains a reference to an instance of a State subclass, which
    // represents the current state of the Context.
    class Context
    {
        // A reference to the current state of the Context.
        private State _state = null;

        public Context ( State state )
        {
            this.TransitionTo ( state );
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo ( State state )
        {
            Console.WriteLine ( $"Context: Transition to {state.GetType ().Name}." );
            this._state = state;
            this._state.SetContext ( this );
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public void Request1 ()
        {
            this._state.Handle1 ();
        }

        public void Request2 ()
        {
            this._state.Handle2 ();
        }
    }

    // The base State class declares methods that all Concrete State should
    // implement and also provides a backreference to the Context object,
    // associated with the State. This backreference can be used by States to
    // transition the Context to another State.
    abstract class State
    {
        protected Context _context;

        public void SetContext ( Context context )
        {
            this._context = context;
        }

        public abstract void Handle1 ();

        public abstract void Handle2 ();
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    // 상태별 동작 구분
    class ConcreteStateA : State
    {
        public override void Handle1 ()
        {
            Console.WriteLine ( "ConcreteStateA handles request1." );
            Console.WriteLine ( "ConcreteStateA wants to change the state of the context." );
            // B로 상태를 변경
            this._context.TransitionTo ( new ConcreteStateB () );
        }

        public override void Handle2 ()
        {
            Console.WriteLine ( "ConcreteStateA handles request2." );
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle1 ()
        {
            Console.Write ( "ConcreteStateB handles request1." );
        }

        public override void Handle2 ()
        {
            Console.WriteLine ( "ConcreteStateB handles request2." );
            Console.WriteLine ( "ConcreteStateB wants to change the state of the context." );
            this._context.TransitionTo ( new ConcreteStateA () );
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            // The client code.
            var context = new Context ( new ConcreteStateA () );
            context.Request1 ();
            context.Request2 ();
        }
    }
-------------------- */

    /*output

    Context: Transition to ConcreteStateA.
    ConcreteStateA handles request1.
    ConcreteStateA wants to change the state of the context.
    Context: Transition to ConcreteStateB. << 상태 변경
    ConcreteStateB handles request2.
    ConcreteStateB wants to change the state of the context.
    Context: Transition to ConcreteStateA.

     */
}