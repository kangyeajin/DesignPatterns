
// 복합체 패턴
// 트리형태, 반복 작업
// *virtual 가상함수 :
//  부모 클래스에서 상속받을 클래스에서 재정의할 것으로 기대하고 정의
//  파생 클래스에서 재정의하면 이전에 정의되었던 내용들은 모두 새롭게 정의된 내용들로 교체
namespace DesignPatterns.Structural
{
    /*============
   // The base Component class declares common operations for both simple and complex objects of a composition.
   // 기본 Component 클래스는 컴포지션의 단순 객체와 복합 객체 모두에 대한 공통 작업을 선언합니다.
   abstract class Component
   {

       public Component () { }

       // The base Component may implement some default behavior or leave it to concrete classes (by declaring the method containing the behavior as "abstract").
       // 기본 구성 요소는 일부 기본 동작을 구현하거나 이를 구체적인 클래스에 그대로 둘 수 있습니다(동작이 포함된 메서드를 "추상"으로 선언하여).
       public abstract string Operation ();

       // In some cases, it would be beneficial to define the child-management
       // operations right in the base Component class. This way, you won't
       // need to expose any concrete component classes to the client code,
       // even during the object tree assembly. The downside is that these
       // methods will be empty for the leaf-level components.

       //어떤 경우에는 기본 Component 클래스에서 바로 하위 관리 작업을 정의하는 것이 도움이 될 수 있습니다.
       //이렇게 하면 객체 트리 어셈블리 중에도 구체적인 구성 요소 클래스를 클라이언트 코드에 노출할 필요가 없습니다.
       //단점은 리프 수준(leaf-level) 구성 요소에 대해 이러한 메서드가 비어 있다는 것입니다.
       public virtual void Add ( Component component )
       {
           throw new NotImplementedException ();
       }

       public virtual void Remove ( Component component )
       {
           throw new NotImplementedException ();
       }

       // You can provide a method that lets the client code figure out whether
       // a component can bear children.
       // 클라이언트 코드가 >구성 요소가 자식을 가질 수 있는지< 여부를 파악할 수 있도록 하는 메서드를 제공할 수 있습니다.
       public virtual bool IsComposite () 
       {
           return true;
       }
   }

   // The Leaf class represents the end objects of a composition. A leaf can't have any children.
   // Leaf 클래스는 컴포지션의 최종 개체를 나타냅니다.리프에는 자식이 있을 수 없습니다.
   //
   // Usually, it's the Leaf objects that do the actual work, whereas Composite objects only delegate to their sub-components.
   // 일반적으로 실제 작업을 수행하는 것은 Leaf 개체인 반면 Composite 개체는 해당 하위 구성 요소에만 위임합니다.
   class Leaf : Component
   {
       public override string Operation ()
       {
           return "Leaf";
       }

       public override bool IsComposite ()
       {
           return false;
       }
   }

   // The Composite class represents the complex components that may have children. Usually, the Composite objects delegate the actual work to their children and then "sum-up" the result.
   // Composite 클래스는 자식을 가질 수 있는 복잡한 구성 요소를 나타냅니다.
   // 일반적으로 Composite 객체는 실제 작업을 하위 객체에게 위임한 다음 결과를 "요약"합니다.
   class Composite : Component
   {
       protected List<Component> _children = new List<Component> ();

       public override void Add ( Component component )
       {
           this._children.Add ( component );
       }

       public override void Remove ( Component component )
       {
           this._children.Remove ( component );
       }

       // The Composite executes its primary logic in a particular way. It
       // traverses recursively through all its children, collecting and
       // summing their results. Since the composite's children pass these
       // calls to their children and so forth, the whole object tree is
       // traversed as a result.
       // Composite는 특정 방식으로 기본 논리를 실행합니다.
       // 모든 자식을 재귀적으로 탐색하여 결과를 수집하고 합산합니다.
       // 복합의 하위 항목이 이러한 호출을 하위 항목 등에 전달하므로 결과적으로 전체 개체 트리가 순회됩니다.
       public override string Operation ()
       {
           int i = 0;
           string result = "Branch(";

           foreach ( Component component in this._children )
           {
               result += component.Operation ();
               if ( i != this._children.Count - 1 )
               {
                   result += "+";
               }
               i++;
           }

           return result + ")";
       }
   }

   class Client
   {
       // The client code works with all of the components via the base interface.
       // 클라이언트 코드는 기본 인터페이스를 통해 모든 구성 요소와 함께 작동합니다.
       public void ClientCode ( Component leaf )
       {
           Console.WriteLine ( $"RESULT: {leaf.Operation ()}\n" );
       }

       // Thanks to the fact that the child-management operations are declared
       // in the base Component class, the client code can work with any
       // component, simple or complex, without depending on their concrete
       // classes.
       // 하위 관리 작업이 기본 Component 클래스에 선언되어 있다는 사실 덕분에
       // 클라이언트 코드는 구체적인 클래스에 의존하지 않고 단순하거나 복잡한 모든 구성 요소에 대해 작업할 수 있습니다.
       public void ClientCode2 ( Component component1, Component component2 )
       {
           if ( component1.IsComposite () )
           {
               component1.Add ( component2 );
           }

           Console.WriteLine ( $"RESULT: {component1.Operation ()}" );
       }
   }

   class Program
   {
       static void Main ( string[] args )
       {
           Client client = new Client ();

           // This way the client code can support the simple leaf
           // components...
           Leaf leaf = new Leaf ();
           Console.WriteLine ( "Client: I get a simple component:" );
           client.ClientCode ( leaf );

           // ...as well as the complex composites.
           Composite tree = new Composite ();
           Composite branch1 = new Composite ();
           branch1.Add ( new Leaf () );
           branch1.Add ( new Leaf () );
           Composite branch2 = new Composite ();
           branch2.Add ( new Leaf () );
           tree.Add ( branch1 );
           tree.Add ( branch2 );
           Console.WriteLine ( "Client: Now I've got a composite tree:" );
           client.ClientCode ( tree );

           Console.Write ( "Client: I don't need to check the components classes even when managing the tree:\n" );
           client.ClientCode2 ( tree, leaf );
       }
   }

 ========*/

    /*result 

    Client: I get a simple component:
    RESULT: Leaf

    Client: Now I've got a composite tree:
    RESULT: Branch(Branch(Leaf+Leaf)+Branch(Leaf))

    Client: I don't need to check the components classes even when managing the tree:
    RESULT: Branch(Branch(Leaf+Leaf)+Branch(Leaf)+Leaf)

    */
}