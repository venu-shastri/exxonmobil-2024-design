public class Originator
    {
        string state;
        public string State { get { return state; } set { state = value; } }    

    }
    public class CareTaker
    {
        static void Main() {
            Originator originator = new Originator();
            originator.State = "State1";

            originator.State = "State2";
            originator.Reset();
            Console.WriteLine(originator.State);
            originator.State = "State3";
            originator.Reset();
            Console.WriteLine(originator.State);
            originator.State = "State4";
            originator.Reset();
            Console.WriteLine(originator.State);
        }

    }




    
    
