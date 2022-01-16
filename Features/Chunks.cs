using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class Chunks
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        Console.WriteLine("----Chunk----");

        int chunkSize = 3;
        var chunkOld = ChunkOld(source, chunkSize);
        var chunkNew = ChunkNew(source, chunkSize);
    }

    private static IEnumerable<IEnumerable<Person>> ChunkNew(IEnumerable<Person> source, int chunkSize)
    {
        IEnumerable<IEnumerable<Person>> cluster = source.Chunk(chunkSize);
        foreach (var chunk in cluster)
        {
            Console.WriteLine($"Cluster of {string.Join(", ", chunk.Select(person => person.Name))}");
        }

        return cluster;
    }

    private static IEnumerable<IEnumerable<Person>> ChunkOld(IEnumerable<Person> source, int chunkSize)
    {
        Console.WriteLine("Without chunk:");

        var cluster1 = Chunk1(source, chunkSize);
        var cluster2 = Chunk2(source, chunkSize);

        foreach (var chunk in cluster1)
        {
            Console.WriteLine($"Cluster of {string.Join(", ", chunk.Select(person => person.Name))}");
        }

        return cluster1;
    }

    private static IEnumerable<IEnumerable<Person>> Chunk1(IEnumerable<Person> source, int chunkSize)
    {
        IEnumerable<IEnumerable<Person>> cluster = source
            .Select((x, i) => new {Index = i, Value = x})
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value));
        return cluster;
    }

    private static IEnumerable<IEnumerable<Person>> Chunk2(IEnumerable<Person> source, int chunkSize)
    {
        List<List<Person>> altCluster = new List<List<Person>>();
        int count = source.Count();
        for (int i = 0; i < count; i++)
        {
            int chunkIndex = i / chunkSize;
            if (altCluster.Skip(chunkIndex).FirstOrDefault() is null)
                altCluster.Add(new List<Person>());
            altCluster[chunkIndex].Add(source.Skip(i).FirstOrDefault());
        }

        return altCluster;
    }
}