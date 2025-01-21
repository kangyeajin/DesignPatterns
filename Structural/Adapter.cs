// 어댑터 패턴
// 하나의 객체에 대한 호출을 캐치하고 두 번째 객체가 인식할 수 있는 형식과 인터페이스로 변환
namespace DesignPatterns.Structural
{
/*    // The Target defines the domain-specific interface used by the client code.
    public interface ITarget
    {
        string GetRequest ();
    }

    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    // 기존 클라이언트 코드와 호환되지 않는 메서드
    class Adaptee
    {
        public string GetSpecificRequest ()
        {
            return "Specific request.";
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface.
    internal class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter ( Adaptee adaptee )
        {
            this._adaptee = adaptee;
        }

        public string GetRequest ()
        {
            return $"This is '{this._adaptee.GetSpecificRequest ()}'";
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            Adaptee adaptee = new Adaptee ();
            ITarget target = new Adapter ( adaptee );

            Console.WriteLine ( "Adaptee 인터페이스가 클라이언트와 호환되지 않습니다." );
            Console.WriteLine ( "그러나 어댑터 클라이언트를 사용하면 해당 메서드를 호출할 수 있습니다." );

            // 원래는 호출이 불가하지만, 어댑터를 사용함으로써 메서드 호출 가능
            Console.WriteLine ( target.GetRequest () );
        }
    }*/
}
