using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

public class Zip
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        Console.WriteLine("----Zip with 3 parameters----");

        const string Separator = "-";
        IEnumerable<int> ids = source.Select(x=>x.Id).SkipLast(1);
        IEnumerable<string> allNames = source.Select(x=>x.Name);
        IEnumerable<int> allAges = source.Select(person => person.Age);
        
        //old way to zip three collections
        IEnumerable<(int Id, string Name, int Age)> zippedOld = ids.Zip(allNames).Zip(allAges).Select(x=>(x.First.First, x.First.Second, x.Second));
        
        //new way to zip three collections
        IEnumerable<(int Id, string Name, int Age)> zipped = ids.Zip(allNames, allAges);
        Console.WriteLine(string.Join(", ", zipped.Select(x => x.Id + Separator+ x.Name + Separator + x.Age)));
    }
}