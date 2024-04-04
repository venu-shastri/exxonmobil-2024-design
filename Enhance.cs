 public class Component
    {
        public void Operation()
        {
            Console.WriteLine("Default Operation");
        }
    }
    public class Startup
    {
        static void Main()
        {
            Component obj1 = new Component();
            Component obj2 = new Component();
            Component obj3 = new Component();
            obj1.Operation();//Default Operation 
            obj2.Operation(); // Default + Enhanced Version
            obj3.Operation();//Default +Enhanced + Modified Version
        }

    }
}
