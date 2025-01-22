//템플릿 메소드 패턴
// 템플릿 메소드 패턴은 상위 클래스에서 처리의 뼈대를 결정하고, 하위 클래스에서 그 구체적인 내용을 결정하는 디자인 패턴이다.
namespace DesignPatterns.Behavioral
{/* --------------------
    // The Abstract Class defines a template method that contains a skeleton of
    // some algorithm, composed of calls to (usually) abstract primitive
    // operations.
    //
    // Concrete subclasses should implement these operations, but leave the
    // template method itself intact.
    abstract class AbstractClass
    {
        // The template method defines the skeleton of an algorithm.
        // 템플릿 메소드는 알고리즘의 뼈대를 정의합니다.
        // 동작은 하위 클래스별로 다르게 구현된다.
        public void TemplateMethod ()
        {
            this.BaseOperation1 ();
            this.RequiredOperations1 ();
            this.BaseOperation2 ();
            this.Hook1 ();
            this.RequiredOperation2 ();
            this.BaseOperation3 ();
            this.Hook2 ();
        }

        // These operations already have implementations.
        protected void BaseOperation1 ()
        {
            Console.WriteLine ( "AbstractClass says: I am doing the bulk of the work" );
        }

        protected void BaseOperation2 ()
        {
            Console.WriteLine ( "AbstractClass says: But I let subclasses override some operations" );
        }

        protected void BaseOperation3 ()
        {
            Console.WriteLine ( "AbstractClass says: But I am doing the bulk of the work anyway" );
        }

        // These operations have to be implemented in subclasses.
        protected abstract void RequiredOperations1 ();

        protected abstract void RequiredOperation2 ();

        // These are "hooks." Subclasses may override them, but it's not
        // mandatory since the hooks already have default (but empty)
        // implementation. Hooks provide additional extension points in some
        // crucial places of the algorithm.
        //템플릿 메서드는 훅이 오버라이드 되지 않아도 작동합니다.
        //일반적으로 훅들은 알고리즘의 중요한 단계들의 전 또는 후에 배치되어 자식 클래스들에 알고리즘에 대한 추가 확장 지점들을 제공합니다.
        protected virtual void Hook1 () { }

        protected virtual void Hook2 () { }
    }

    // Concrete classes have to implement all abstract operations of the base
    // class. They can also override some operations with a default
    // implementation.
    class ConcreteClass1 : AbstractClass
    {
        protected override void RequiredOperations1 ()
        {
            Console.WriteLine ( "ConcreteClass1 says: Implemented Operation1" );
        }

        protected override void RequiredOperation2 ()
        {
            Console.WriteLine ( "ConcreteClass1 says: Implemented Operation2" );
        }
    }

    // Usually, concrete classes override only a fraction of base class'
    // operations.
    class ConcreteClass2 : AbstractClass
    {
        protected override void RequiredOperations1 ()
        {
            Console.WriteLine ( "ConcreteClass2 says: Implemented Operation1" );
        }

        protected override void RequiredOperation2 ()
        {
            Console.WriteLine ( "ConcreteClass2 says: Implemented Operation2" );
        }

        protected override void Hook1 ()
        {
            Console.WriteLine ( "ConcreteClass2 says: Overridden Hook1" );
        }
    }

    class Client
    {
        // The client code calls the template method to execute the algorithm.
        // Client code does not have to know the concrete class of an object it
        // works with, as long as it works with objects through the interface of
        // their base class.
        public static void ClientCode ( AbstractClass abstractClass )
        {
            // ...
            abstractClass.TemplateMethod ();
            // ...
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            Console.WriteLine ( "Same client code can work with different subclasses:" );

            Client.ClientCode ( new ConcreteClass1 () );

            Console.Write ( "\n" );

            Console.WriteLine ( "Same client code can work with different subclasses:" );
            Client.ClientCode ( new ConcreteClass2 () );
        }
    }
--------------------*/

    /*output

    Same client code can work with different subclasses:
    AbstractClass says: I am doing the bulk of the work
    ConcreteClass1 says: Implemented Operation1
    AbstractClass says: But I let subclasses override some operations
    ConcreteClass1 says: Implemented Operation2
    AbstractClass says: But I am doing the bulk of the work anyway

    Same client code can work with different subclasses:
    AbstractClass says: I am doing the bulk of the work
    ConcreteClass2 says: Implemented Operation1
    AbstractClass says: But I let subclasses override some operations
    ConcreteClass2 says: Overridden Hook1
    ConcreteClass2 says: Implemented Operation2
    AbstractClass says: But I am doing the bulk of the work anyway

     */

}