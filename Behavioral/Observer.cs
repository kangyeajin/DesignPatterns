// 옵저버 패턴
// 객체의 상태 변화를 관찰하는 객체를 만들어, 상태 변화가 있을 때마다 통보받는 방식
namespace DesignPatterns.Behavioral
{/* --------------------
    public interface IObserver
    {
        // Receive update from subject
        void Update ( ISubject subject );
    }

    public interface ISubject
    {
        // Attach an observer to the subject.
        void Attach ( IObserver observer );

        // Detach an observer from the subject.
        void Detach ( IObserver observer );

        // Notify all observers about an event.
        // 알림
        void Notify ();
    }

    // The Subject owns some important state and notifies observers when the state changes.
    // 상태 변하면 알림 보냄
    public class Subject : ISubject
    {
        // For the sake of simplicity, the Subject's state, essential to all
        // subscribers, is stored in this variable.
        public int State { get; set; } = -0;

        // List of subscribers. In real life, the list of subscribers can be
        // stored more comprehensively (categorized by event type, etc.).
        /// 구독자 리스트
        private List<IObserver> _observers = new List<IObserver> ();

        // The subscription management methods.
        /// <summary>
        /// 구독자 추가
        /// </summary>
        public void Attach ( IObserver observer )
        {
            Console.WriteLine ( "Subject: Attached an observer." );
            this._observers.Add ( observer );
        }

        /// <summary>
        /// 구독자 제거
        /// </summary>
        public void Detach ( IObserver observer )
        {
            this._observers.Remove ( observer );
            Console.WriteLine ( "Subject: Detached an observer." );
        }

        // Trigger an update in each subscriber.
        /// <summary>
        /// 알림발송
        /// </summary>
        public void Notify ()
        {
            Console.WriteLine ( "Subject: Notifying observers..." );

            foreach ( var observer in _observers )
            {
                observer.Update ( this );
            }
        }

        // Usually, the subscription logic is only a fraction of what a Subject
        // can really do. Subjects commonly hold some important business logic,
        // that triggers a notification method whenever something important is
        // about to happen (or after it).
        public void SomeBusinessLogic ()
        {
            Console.WriteLine ( "\nSubject: I'm doing something important." );
            this.State = new Random ().Next ( 0, 10 );

            Thread.Sleep ( 15 );

            Console.WriteLine ( "Subject: My state has just changed to: " + this.State );
            this.Notify ();
        }
    }

    // Concrete Observers react to the updates issued by the Subject they had been attached to.
    class ConcreteObserverA : IObserver
    {
        public void Update ( ISubject subject )
        {
            // 상태가 3 미만일 때만 반응
            if ( (subject as Subject).State < 3 )
            {
                Console.WriteLine ( "ConcreteObserverA: Reacted to the event.\n" );
            }
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Update ( ISubject subject )
        {
            // 상태가 0이거나 2 이상일 때만 반응
            if ( (subject as Subject).State == 0 || (subject as Subject).State >= 2 )
            {
                Console.WriteLine ( "ConcreteObserverB: Reacted to the event.\n" );
            }
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            // The client code.
            var subject = new Subject ();
            var observerA = new ConcreteObserverA ();
            subject.Attach ( observerA );

            var observerB = new ConcreteObserverB ();
            subject.Attach ( observerB );

            subject.SomeBusinessLogic ();
            subject.SomeBusinessLogic ();

            subject.Detach ( observerB );

            subject.SomeBusinessLogic ();
        }
    }
-------------------- */

    /*output

     Subject: Attached an observer.
    Subject: Attached an observer.

    Subject: I'm doing something important.
    Subject: My state has just changed to: 2
    Subject: Notifying observers...
    ConcreteObserverA: Reacted to the event.

    ConcreteObserverB: Reacted to the event.


    Subject: I'm doing something important.
    Subject: My state has just changed to: 6
    Subject: Notifying observers...
    ConcreteObserverB: Reacted to the event.

    Subject: Detached an observer.

    Subject: I'm doing something important.
    Subject: My state has just changed to: 1
    Subject: Notifying observers...
    ConcreteObserverA: Reacted to the event.

     */
}