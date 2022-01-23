using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class OrDefault
{
    public static void Demonstrate(IEnumerable<Cyclist> enumerable)
    {
        Console.WriteLine("----FirstOrDefault/LastOrDefault/SingleOrDefault overloads with default----");
        
        OrDefaultReferenceType(enumerable);
        OrDefaultValueType(enumerable);
    }

    private static void OrDefaultReferenceType(IEnumerable<Cyclist> enumerable)
    {
        IEnumerable<Cyclist> emptyCyclists = new List<Cyclist>();
        Cyclist firstOrDefault = emptyCyclists.FirstOrDefault();
        Cyclist overloadedFirstOrDefault = emptyCyclists.FirstOrDefault(Cyclist.Empty);

        Console.WriteLine(
            $"Overloaded FirstOrDefault: {overloadedFirstOrDefault}; Old FirstOrDefault: {firstOrDefault}");
    }

    private static void OrDefaultValueType(IEnumerable<Cyclist> enumerable)
    {
        var firstOrDefault = enumerable.Where(x => x.Age < 10).Select(x => x.Age).FirstOrDefault();
        var overloadedFirstOrDefault = enumerable.Where(x => x.Age < 10).Select(x => x.Age).FirstOrDefault(-1);

        Console.WriteLine(
            $"Overloaded FirstOrDefault: {overloadedFirstOrDefault}; Old FirstOrDefault: {firstOrDefault}");
    }
    
}