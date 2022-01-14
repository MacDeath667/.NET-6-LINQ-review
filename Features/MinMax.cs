using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class MinMax
{
    public static void DemonstrateMinBy(IEnumerable<Person> source)
    {
        Console.WriteLine("----MinBy----");

        //Without using MaxBy and MinBy

        Person oldWay = source
            .OrderBy(person => person.Age)
            .First();

        Person newWay = source.MinBy(person => person.Age);
        Console.WriteLine($"Youngest Person using MaxBy: {newWay.Name}");

        Console.WriteLine($"Youngest Person without using MaxBy: {newWay.Name}");
    }

    public static void DemonstrateMaxBy(IEnumerable<Person> source)
    {
        Console.WriteLine("----MaxBy----");
        //Without using MaxBy and MinBy
        Person oldWay = source
            .OrderByDescending(person => person.Age)
            .First();
        Console.WriteLine($"Oldest Person without using MaxBy: {oldWay.Name}");
        
        Person newWay = source.MaxBy(person => person.Age);
        Console.WriteLine($"Oldest Person using MaxBy: {oldWay.Name}");

       
    }
}