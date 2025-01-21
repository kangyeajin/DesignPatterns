using Newtonsoft.Json;

// 플라이웨이트 패턴 
namespace DesignPatterns.Structural
{/* ------------------
    // The Flyweight stores a common portion of the state (also called intrinsic
    // state) that belongs to multiple real business entities. The Flyweight
    // accepts the rest of the state (extrinsic state, unique for each entity)
    // via its method parameters.
    public class Flyweight
    {
        private Car _sharedState;

        public Flyweight ( Car car )
        {
            this._sharedState = car;
        }

        public void Operation ( Car uniqueState )
        {
            string s = JsonConvert.SerializeObject ( this._sharedState );
            string u = JsonConvert.SerializeObject ( uniqueState );
            Console.WriteLine ( $"Flyweight: Displaying shared {s} and unique {u} state." );
        }
    }

    // The Flyweight Factory creates and manages the Flyweight objects. It
    // ensures that flyweights are shared correctly. When the client requests a
    // flyweight, the factory either returns an existing instance or creates a
    // new one, if it doesn't exist yet.
    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>> ();

        public FlyweightFactory ( params Car[] args )
        {
            foreach ( var elem in args )
            {
                flyweights.Add ( new Tuple<Flyweight, string> ( new Flyweight ( elem ), this.getKey ( elem ) ) );
            }
        }

        // Returns a Flyweight's string hash for a given state.
        public string getKey ( Car key )
        {
            List<string> elements = new List<string> ();

            elements.Add ( key.Model );
            elements.Add ( key.Color );
            elements.Add ( key.Company );

            if ( key.Owner != null && key.Number != null )
            {
                elements.Add ( key.Number );
                elements.Add ( key.Owner );
            }

            elements.Sort ();

            return string.Join ( "_", elements );
        }

        // Returns an existing Flyweight with a given state or creates a new one.
        public Flyweight GetFlyweight ( Car sharedState )
        {
            string key = this.getKey ( sharedState );

            if ( flyweights.Where ( t => t.Item2 == key ).Count () == 0 )
            {
                Console.WriteLine ( "FlyweightFactory: Can't find a flyweight, creating new one." );
                this.flyweights.Add ( new Tuple<Flyweight, string> ( new Flyweight ( sharedState ), key ) );
            }
            else
            {
                Console.WriteLine ( "FlyweightFactory: Reusing existing flyweight." ); //이미 존재하는 데이터
            }
            return this.flyweights.Where ( t => t.Item2 == key ).FirstOrDefault ().Item1;
        }

        public void listFlyweights ()
        {
            var count = flyweights.Count;
            Console.WriteLine ( $"\nFlyweightFactory: I have {count} flyweights:" );
            foreach ( var flyweight in flyweights )
            {
                Console.WriteLine ( flyweight.Item2 );
            }
        }
    }

    public class Car
    {
        public string Owner { get; set; }

        public string Number { get; set; }

        public string Company { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            // The client code usually creates a bunch of pre-populated
            // flyweights in the initialization stage of the application.
            var factory = new FlyweightFactory (
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );
            factory.listFlyweights ();

            addCarToPoliceDatabase ( factory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            } );

            addCarToPoliceDatabase ( factory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            } );

            factory.listFlyweights ();
        }

        public static void addCarToPoliceDatabase ( FlyweightFactory factory, Car car )
        {
            Console.WriteLine ( "\nClient: Adding a car to database." );

            var flyweight = factory.GetFlyweight ( new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            } );

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation ( car );
        }
    }
    --------------------- */

    /*result

    FlyweightFactory: I have 5 flyweights:
    Camaro2018_Chevrolet_pink
    black_C300_Mercedes Benz
    C500_Mercedes Benz_red
    BMW_M5_red
    BMW_white_X6

    Client: Adding a car to database.
    FlyweightFactory: Reusing existing flyweight.
    Flyweight: Displaying shared {"Owner":null,"Number":null,"Company":"BMW","Model":"M5","Color":"red"} and unique {"Owner":"James Doe","Number":"CL234IR","Company":"BMW","Model":"M5","Color":"red"} state.

    Client: Adding a car to database.
    FlyweightFactory: Can't find a flyweight, creating new one.
    Flyweight: Displaying shared {"Owner":null,"Number":null,"Company":"BMW","Model":"X1","Color":"red"} and unique {"Owner":"James Doe","Number":"CL234IR","Company":"BMW","Model":"X1","Color":"red"} state.

    FlyweightFactory: I have 6 flyweights:
    Camaro2018_Chevrolet_pink
    black_C300_Mercedes Benz
    C500_Mercedes Benz_red
    BMW_M5_red
    BMW_white_X6
    BMW_red_X1

     */
}