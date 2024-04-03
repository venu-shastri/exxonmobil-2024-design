class Program
{
    public delegate bool PredicteCommand<TSource>(TSource item);
    static void Main()
    {
        string[] cities = { "Blr", "Delhi", "Chennai", "Hyderabad","Buvenshwar" };

        List<string> list = Program.Filter(cities, "B");
        
         list = Program.Filter(cities, Program.StartsWithAny("B"));
        list = Program.Filter(cities, Program.StartsWithAny("C")); ;
    }

    static PredicteCommand<string> StartsWithAny(string anyString)
    {
        PredicteCommand<string> predicate = (string item) => { return item.StartsWith(anyString); };
        return predicate;

    }

    
    static List<string> Filter(string[] source,string startsWith)
    {
        List<string> list = new List<string>(); 
        for(int i = 0; i < source.Length; i++)
        {
            if (source[i].StartsWith(startsWith))
            {
                list.Add(source[i]);
            }
        }
        return list;

    }
    static List<TSource> Filter<TSource>(TSource[] source, PredicteCommand<TSource> predicateFn )
    {
        List<TSource> list = new List<TSource>();
        for (int i = 0; i < source.Length; i++)
        {
            if (predicateFn.Invoke(source[i]))
            {
                list.Add(source[i]);
            }
        }
        return list;

    }

    
}



