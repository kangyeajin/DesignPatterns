
// 데코레이터 패턴
// 한겹씩 쌓아서 기능을 향상시킨다.
// 대상 객체에 대한 기능 확장이나 변경이 필요할때 객체의 결합을 통해 서브클래스 대신 사용
// 객체 지향 프로그래밍에서 원본 객체에 대해서 무언가를 장식하여 더 멋진 기능을 가지게 만든다는 의미
// 상황에 따라 다양한 기능이 빈번하게 추가/삭제되는 경우 사용
// 대신 순서에 의존해야 함 ex A실행 후 B 실행 
// https://inpa.tistory.com/entry/GOF-%F0%9F%92%A0-%EB%8D%B0%EC%BD%94%EB%A0%88%EC%9D%B4%ED%84%B0Decorator-%ED%8C%A8%ED%84%B4-%EC%A0%9C%EB%8C%80%EB%A1%9C-%EB%B0%B0%EC%9B%8C%EB%B3%B4%EC%9E%90
// https://refactoring.guru/ko/design-patterns/decorator

namespace DesignPatterns.Structural
{
    /*    =========================
        // The base Component interface defines operations that can be altered by decorators.
        public abstract class Component //원본 객체와 장식된 객체 모두를 묶는 역할
        {
            public abstract string Operation ();
        }

        // Concrete Components provide default implementations of the operations.
        // There might be several variations of these classes.
        // Concrete 구성 요소는 작업의 기본 구현을 제공합니다.
        // 이러한 클래스에는 여러 가지 변형이 있을 수 있습니다.
        class ConcreteComponent : Component //원본 객체 (데코레이팅 할 객체)
        {
            public override string Operation ()
            {
                return "ConcreteComponent";
            }
        }

        // The base Decorator class follows the same interface as the other
        // components. The primary purpose of this class is to define the wrapping
        // interface for all concrete decorators. The default implementation of the
        // wrapping code might include a field for storing a wrapped component and
        // the means to initialize it.
        // 기본 Decorator 클래스는 다른 구성 요소와 동일한 인터페이스를 따릅니다.
        // 이 클래스의 주요 목적은 모든 구체적인 데코레이터에 대한 래핑 인터페이스를 정의하는 것입니다.
        // 래핑 코드의 기본 구현에는 래핑된 구성 요소를 저장하기 위한 필드와 이를 초기화하는 방법이 포함될 수 있습니다.
        abstract class Decorator : Component // 추상화된 장식자 클래스
        {
            protected Component _component;

            public Decorator ( Component component )
            {
                this._component = component;
            }

            public void SetComponent ( Component component )
            {
                this._component = component;
            }

            // The Decorator delegates all work to the wrapped component.
            // 데코레이터는 모든 작업을 래핑된 구성 요소에 위임합니다.
            public override string Operation ()
            {
                if ( this._component != null )
                {
                    return this._component.Operation ();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        // Concrete Decorators call the wrapped object and alter its result in some way.
        // 콘크리트 데코레이터는 래핑된 객체를 호출하고 어떤 방식으로든 그 결과를 변경합니다.
        class ConcreteDecoratorA : Decorator //구체적인 장식자 클래스
        {
            public ConcreteDecoratorA ( Component comp ) : base ( comp )
            {
            }

            // Decorators may call parent implementation of the operation, instead
            // of calling the wrapped object directly. This approach simplifies
            // extension of decorator classes.
            // 데코레이터는 래핑된 객체를 직접 호출하는 대신 작업의 상위 구현을 호출할 수 있습니다.
            // 이 접근 방식은 데코레이터 클래스의 확장을 단순화합니다.
            public override string Operation ()
            {
                // 원본 객체를 상위 클래스의 위임을 통해 실행하고
                // 장식 클래스만의 메소드를 실행한다.
                return $"ConcreteDecoratorA({base.Operation ()})";
            }
        }

        // Decorators can execute their behavior either before or after the call to
        // a wrapped object.
        // 데코레이터는 래핑된 객체를 호출하기 전이나 후에 자신의 동작을 실행할 수 있습니다.
        class ConcreteDecoratorB : Decorator
        {
            public ConcreteDecoratorB ( Component comp ) : base ( comp )
            {
            }

            public override string Operation ()
            {
                return $"ConcreteDecoratorB({base.Operation ()})";
            }
        }

        public class Client
        {
            // The client code works with all objects using the Component interface.
            // This way it can stay independent of the concrete classes of
            // components it works with.
            // 클라이언트 코드는 Component 인터페이스를 사용하는 모든 객체와 함께 작동합니다.
            // 이런 방식으로 작업하는 구성 요소의 구체적인 클래스와 독립적으로 유지될 수 있습니다.
            public void ClientCode ( Component component )
            {
                Console.WriteLine ( "RESULT: " + component.Operation () );
            }
        }

        class Program
        {
            static void Main ( string[] args )
            {
                Client client = new Client ();

                // 1. 원본 객체 생성
                var simple = new ConcreteComponent ();
                Console.WriteLine ( "Client: I get a simple component:" );
                client.ClientCode ( simple );
                Console.WriteLine ();

                // ...as well as decorated ones.
                //
                // Note how decorators can wrap not only simple components but the
                // other decorators as well.
                // 데코레이터가 간단한 구성 요소뿐만 아니라 다른 데코레이터도 래핑할 수 있는 방법에 유의하세요.

                // 2. 원본 객체에 장식을 추가한다.
                ConcreteDecoratorA decorator1 = new ConcreteDecoratorA ( simple );
                ConcreteDecoratorB decorator2 = new ConcreteDecoratorB ( decorator1 );
                Console.WriteLine ( "Client: Now I've got a decorated component:" );
                client.ClientCode ( decorator2 );

                var deco3 = new ConcreteDecoratorA ( new ConcreteDecoratorB( simple ) );
                Console.WriteLine ( "same :" );
                client.ClientCode ( deco3 );

            }
        }
    =========================*/

    /*result
    Client: I get a simple component:
    RESULT: ConcreteComponent

    Client: Now I've got a decorated component:
    RESULT: ConcreteDecoratorB(ConcreteDecoratorA(ConcreteComponent))
     */
}