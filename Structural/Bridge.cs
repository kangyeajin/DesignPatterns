// Bridge 패턴
// 추상화 + 기능 구현을 연결해주는 다리 정도..
// 자원 중 하나를 별도의 클래스 계층구조로 추출하여 원래 클래스들이 한 클래스 내에서 모든 상태와 행동들을 갖는 대신 새 계층구조의 객체를 참조하도록 한다
namespace DesignPatterns.Structural
{

    // The Abstraction defines the interface for the "control" part of the two
    // class hierarchies. It maintains a reference to an object of the
    // Implementation hierarchy and delegates all of the real work to this object.
    // 두 클래스 계층의 "제어" 부분에 대한 인터페이스를 정의합니다.
    // 구현 계층의 개체에 대한 참조를 유지하고 모든 실제 작업을 이 개체에 위임합니다.
    /*     ==== 주석처리
    class Abstraction
    {
        protected IImplementation _implementation; //구현

        public Abstraction ( IImplementation implementation )
        {
            this._implementation = implementation;
        }

        public virtual string Operation ()
        {
            return "Abstract: Base operation with:\n" +
                _implementation.OperationImplementation ();
        }
    }

    // You can extend the Abstraction without changing the Implementation classes.
    // 구현(IImplementation) 클래스를 변경하지 않고도 추상화(Abstraction)를 확장(extend)할 수 있습니다.
    class ExtendedAbstraction : Abstraction
    {
        public ExtendedAbstraction ( IImplementation implementation ) : base ( implementation )
        {
        }

        public override string Operation ()
        {
            return "ExtendedAbstraction: Extended operation with:\n" +
                base._implementation.OperationImplementation ();
        }
    }

    // The Implementation defines the interface for all implementation classes.
    // It doesn't have to match the Abstraction's interface. In fact, the two
    // interfaces can be entirely different. Typically the Implementation
    // interface provides only primitive operations, while the Abstraction
    // defines higher- level operations based on those primitives.
    // 모든 구현 클래스에 대한 인터페이스를 정의합니다.
    // 추상화(Abstraction)의 인터페이스와 일치할 필요는 없습니다.
    // 실제로 두 인터페이스는 완전히 다를 수 있습니다.
    // 일반적으로 구현 인터페이스는 기본 작업만 제공하는 반면 추상화(Abstraction)는 해당 기본 작업을 기반으로 더 높은 수준의 작업을 정의합니다.
    public interface IImplementation
    {
        string OperationImplementation ();
    }

    // Each Concrete Implementation corresponds to a specific platform and
    // implements the Implementation interface using that platform's API.
    // 각 구체적 구현은 특정 플랫폼에 해당하며 해당 플랫폼의 API를 사용하여 구현 인터페이스를 구현합니다.
    class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation ()
        {
            return "ConcreteImplementationA: 플랫폼 A의 결과\n";
        }
    }

    class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation ()
        {
            return "ConcreteImplementationB: 플랫폼 B의 결과\n";
        }
    }

    class Client
    {
        // Except for the initialization phase, where an Abstraction object gets
        // linked with a specific Implementation object, the client code should
        // only depend on the Abstraction class. This way the client code can
        // support any abstraction-implementation combination.
        // 추상화 개체가 특정 구현 개체와 연결되는 초기화 단계를 제외하고
        // 클라이언트 코드는 추상화 클래스에만 의존해야 합니다.
        // 이런 방식으로 클라이언트 코드는 추상화-구현 조합을 지원할 수 있습니다.
        public void ClientCode ( Abstraction abstraction )
        {
            Console.Write ( abstraction.Operation () );
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            Client client = new Client ();
            Abstraction abstraction;

            // The client code should be able to work with any pre-configured
            // abstraction-implementation combination.
            // 클라이언트 코드는 사전 구성된 추상화-구현 조합과 함께 작동할 수 있어야 합니다.
            abstraction = new Abstraction ( new ConcreteImplementationA () ); 
            client.ClientCode ( abstraction );

            Console.WriteLine ();

            abstraction = new ExtendedAbstraction ( new ConcreteImplementationB () );
            client.ClientCode ( abstraction );
        }
    }
    
     
     ==== 주석처리 */

    /*
    Abstract: Base operation with:
    ConcreteImplementationA: The result in platform A.
    
    ExtendedAbstraction: Extended operation with:
    ConcreteImplementationB: The result in platform B.
    */
}