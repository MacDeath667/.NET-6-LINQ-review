using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class MinMax
{
    public static void DemonstrateMinBy(IEnumerable<Cyclist> source)
    {
        Console.WriteLine("----MinBy----");

        //old way
        Cyclist oldWay = source
            .OrderBy(person => person.Age)
            .First();
        Console.WriteLine($"Youngest Person: {oldWay.Name}");
        
        //new way
        Cyclist newWay = source.MinBy(person => person.Age);
        Console.WriteLine($"Youngest Person without using MaxBy: {newWay.Name}");
    }

    public static void DemonstrateMaxBy(IEnumerable<Cyclist> source)
    {
        Console.WriteLine("----MaxBy----");
        
        //old way
        Cyclist oldWay = source
            .OrderByDescending(person => person.Age)
            .First();
        Console.WriteLine($"Oldest Person: {oldWay.Name}");
        
        //new way
        Cyclist newWay = source.MaxBy(person => person.Age);
        Console.WriteLine($"Oldest Person using MaxBy: {newWay.Name}");
    }
}