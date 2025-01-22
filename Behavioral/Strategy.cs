// 전략패턴
// 전략패턴은 객체의 행위를 클래스로 캡슐화하여 동적으로 행위를 자유롭게 바꿀 수 있게 해주는 패턴이다.
// ex) A까지의 경로 이동 방법을 찾는 알고리즘을 구현할 때, 1.도보, 2.자전거, 3.자동차 등 다양한 전략을 사용
// 작업에 적합한 전략(알고리즘)을 자유롭게 변경할 수 있도록 함.
namespace DesignPatterns.Behavioral
{/* --------------------
    // The Context defines the interface of interest to clients.
    class Context
    {
        // The Context maintains a reference to one of the Strategy objects. The
        // Context does not know the concrete class of a strategy. It should
        // work with all strategies via the Strategy interface.
        private IStrategy _strategy;

        public Context ()
        { }

        // Usually, the Context accepts a strategy through the constructor, but
        // also provides a setter to change it at runtime.
        public Context ( IStrategy strategy )
        {
            this._strategy = strategy;
        }

        // Usually, the Context allows replacing a Strategy object at runtime.
        public void SetStrategy ( IStrategy strategy )
        {
            this._strategy = strategy;
        }

        // The Context delegates some work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public void DoSomeBusinessLogic ()
        {
            Console.WriteLine ( "Context: Sorting data using the strategy (not sure how it'll do it)" );
            var result = this._strategy.DoAlgorithm ( new List<string> { "a", "b", "c", "d", "e" } );

            string resultStr = string.Empty;
            foreach ( var element in result as List<string> )
            {
                resultStr += element + ",";
            }

            Console.WriteLine ( resultStr );
        }
    }

    // The Strategy interface declares operations common to all supported
    // versions of some algorithm.
    //
    // The Context uses this interface to call the algorithm defined by Concrete
    // Strategies.
    public interface IStrategy
    {
        object DoAlgorithm ( object data );
    }

    // Concrete Strategies implement the algorithm while following the base
    // Strategy interface. The interface makes them interchangeable in the
    // Context.
    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm ( object data )
        {
            var list = data as List<string>;
            list.Sort ();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm ( object data )
        {
            var list = data as List<string>;
            list.Sort ();
            list.Reverse ();

            return list;
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var context = new Context ();

            Console.WriteLine ( "Client: Strategy is set to normal sorting." );
            context.SetStrategy ( new ConcreteStrategyA () );
            context.DoSomeBusinessLogic ();

            Console.WriteLine ();

            Console.WriteLine ( "Client: Strategy is set to reverse sorting." );
            context.SetStrategy ( new ConcreteStrategyB () );
            context.DoSomeBusinessLogic ();
        }
    }
--------------------*/

    /*output

    Client: Strategy is set to normal sorting.
    Context: Sorting data using the strategy (not sure how it'll do it)
    a,b,c,d,e,

    Client: Strategy is set to reverse sorting.
    Context: Sorting data using the strategy (not sure how it'll do it)
    e,d,c,b,a,

     */
}