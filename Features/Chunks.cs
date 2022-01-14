using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class Chunks
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        Console.WriteLine("----Chunk----");

        Console.WriteLine("Without chunk:");
        int chunkSize = 3;


        IEnumerable<IEnumerable<Person>> clusterOld = source
            .Select((x, i) => new {Index = i, Value = x})
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value));

        foreach (var chunk in clusterOld)
        {
            Console.WriteLine($"Cluster of {string.Join(", ", chunk.Select(person => person.Name))}");
        }

        //todo for/foreach


        IEnumerable<IEnumerable<Person>> cluster = source.Chunk(chunkSize);
        foreach (var chunk in cluster)
        {
            Console.WriteLine($"Cluster of {string.Join(", ", chunk.Select(person => person.Name))}");
        }
    }
}