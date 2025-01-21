// 책임 연쇄 패턴
// 요청이 처리가 될때까지 계속해서 다음 핸들러로 넘긴다.
namespace DesignPatterns.Behavioral
{/* --------------------
    // The Handler interface declares a method for building the chain of
    // handlers. It also declares a method for executing a request.
    public interface IHandler
    {
        IHandler SetNext ( IHandler handler );

        object Handle ( object request );
    }

    // The default chaining behavior can be implemented inside a base handler class.
    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext ( IHandler handler )
        {
            this._nextHandler = handler;

            // Returning a handler from here will let us link handlers in a
            // convenient way like this:
            // monkey.SetNext(squirrel).SetNext(dog);
            return handler;
        }

        public virtual object Handle ( object request )
        {
            if ( this._nextHandler != null )
            {
                return this._nextHandler.Handle ( request );
            }
            else
            {
                return null;
            }
        }
    }

    class MonkeyHandler : AbstractHandler
    {
        public override object Handle ( object request )
        {
            //Console.WriteLine ( "monkey" );
            if ( (request as string) == "Banana" )
            {
                return $"Monkey: I'll eat the {request.ToString ()}.\n";
            }
            else
            {
                return base.Handle ( request );
            }
        }
    }

    class SquirrelHandler : AbstractHandler
    {
        public override object Handle ( object request )
        {
            //Console.WriteLine ( "Squirrel" );
            if ( request.ToString () == "Nut" )
            {
                return $"Squirrel: I'll eat the {request.ToString ()}.\n";
            }
            else
            {
                return base.Handle ( request );
            }
        }
    }

    class DogHandler : AbstractHandler
    {
        public override object Handle ( object request )
        {
            //Console.WriteLine ( "Dog" );
            if ( request.ToString () == "MeatBall" )
            {
                return $"Dog: I'll eat the {request.ToString ()}.\n";
            }
            else
            {
                return base.Handle ( request );
            }
        }
    }

    class Client
    {
        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode ( AbstractHandler handler )
        {
            foreach ( var food in new List<string> { "Cup of coffee", "MeatBall", "Nut", "Banana", "Cup of coffee", } )
            {
                Console.WriteLine ( $"Client: Who wants a {food}?" );

                var result = handler.Handle ( food );

                if ( result != null )
                {
                    Console.Write ( $"   {result}" );
                }
                else
                {
                    Console.WriteLine ( $"   {food} was left untouched." );
                }
            }
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            // The other part of the client code constructs the actual chain.
            // 1번만 동작
            var monkey = new MonkeyHandler ();
            var squirrel = new SquirrelHandler ();
            var dog = new DogHandler ();
            var dog2 = new DogHandler ();

            monkey.SetNext ( squirrel ).SetNext ( dog ).SetNext ( dog2 );

            // The client should be able to send a request to any handler, not
            // just the first one in the chain.            
            Console.WriteLine ( "Chain: Monkey > Squirrel > Dog > Dog2\n" );
            Client.ClientCode ( monkey );
            Console.WriteLine ();

            Console.WriteLine ( "Subchain: Squirrel > Dog > Dog2\n" );
            Client.ClientCode ( squirrel );
        }
    }
    --------------------*/

    /*output 

     Chain: Monkey > Squirrel > Dog > Dog2

    Client: Who wants a Cup of coffee?
       Cup of coffee was left untouched.
    Client: Who wants a MeatBall?
       Dog: I'll eat the MeatBall.
    Client: Who wants a Nut?
       Squirrel: I'll eat the Nut.
    Client: Who wants a Banana?
       Monkey: I'll eat the Banana.
    Client: Who wants a Cup of coffee?
       Cup of coffee was left untouched.

    Subchain: Squirrel > Dog > Dog2

    Client: Who wants a Cup of coffee?
       Cup of coffee was left untouched.
    Client: Who wants a MeatBall?
       Dog: I'll eat the MeatBall.
    Client: Who wants a Nut?
       Squirrel: I'll eat the Nut.
    Client: Who wants a Banana?
       Banana was left untouched.
    Client: Who wants a Cup of coffee?
       Cup of coffee was left untouched.

     */
}