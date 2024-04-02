class Program
{
    static void Main()
    {
        string[] cities = { "Blr", "Delhi", "Chennai", "Hyderabad","Buvenshwar" };

        //Aggregator
        List<string> list = new List<string>();
        //iterate
        for(int i=0;i<cities.Length;i++)
        {
            //predicate
            if (cities[i].StartsWith("B"))
            {
                list.Add(cities[i]);

            }
        }

        //Dump Result
        for(int i=0;i<list.Count;i++)
        {
            Console.WriteLine(list[i]);
        }



    }
}
