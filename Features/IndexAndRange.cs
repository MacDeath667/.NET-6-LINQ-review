using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class IndexAndRange
{
    public static void Demonstrate(IEnumerable<Cyclist> source)
    {
        Console.WriteLine("----Index and Range----");

        Cyclist secondLastCyclistOld = source.TakeLast(2).FirstOrDefault();
        Cyclist secondLastCyclist = source.ElementAt(^2);
        Console.WriteLine(secondLastCyclist.Name);
        //Pavel

        IEnumerable<Cyclist> take3PeopleOld = source.Take(3);
        IEnumerable<Cyclist> take3People = source.Take(..3);
        Console.WriteLine(string.Join(", ", take3People.Select(person => person.Name)));
        //Gregor, Roman, Roma

        IEnumerable<Cyclist> skip1PersonOld = source.Skip(1);
        IEnumerable<Cyclist> skip1Person = source.Take(1..);
        Console.WriteLine(string.Join(", ", skip1Person.Select(person => person.Name)));
        //Roman, Roma, Pavel, Ghost
        
        IEnumerable<Cyclist> take3Skip1PeopleOld = source.Take(3).Skip(1);
        IEnumerable<Cyclist> take3Skip1People = source.Take(1..3);
        Console.WriteLine(string.Join(", ", take3Skip1People.Select(person => person.Name)));
        //Roman, Roma

        IEnumerable<Cyclist> takeLast2PeopleOld = source.TakeLast(2);
        IEnumerable<Cyclist> takeLast2People = source.Take(^2..);
        Console.WriteLine(string.Join(", ", takeLast2People.Select(person => person.Name)));
        //Pavel, Ghost

        IEnumerable<Cyclist> skipLast3PeopleOld = source.SkipLast(3);
        IEnumerable<Cyclist> skipLast3People = source.Take(..^3);
        Console.WriteLine(string.Join(", ", skipLast3People.Select(person => person.Name)));
        //Gregor, Roman

        IEnumerable<Cyclist> takeLast3SkipLast2Old = source.TakeLast(3).SkipLast(2);
        IEnumerable<Cyclist> takeLast3SkipLast2 = source.Take(^3..^2);
        Console.WriteLine(string.Join(", ", takeLast3SkipLast2.Select(person => person.Name)));
        //Roma
    }
}