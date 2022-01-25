using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class Chunks
{
    public static void Demonstrate(IEnumerable<Cyclist> source)
    {
        Console.WriteLine("----Chunk----");

        int chunkSize = 3;
        var chunkOld = ChunkOld(source, chunkSize);
        var chunkNew = ChunkNew(source, chunkSize);
    }

    private static IEnumerable<IEnumerable<Cyclist>> ChunkNew(IEnumerable<Cyclist> source, int chunkSize)
    {
        IEnumerable<IEnumerable<Cyclist>> cluster = source.Chunk(chunkSize);
        foreach (var chunk in cluster)
        {
            Console.WriteLine($"Cluster of {string.Join(", ", chunk.Select(person => person.Name))}");
        }

        return cluster;
    }

    private static IEnumerable<IEnumerable<Cyclist>> ChunkOld(IEnumerable<Cyclist> source, int chunkSize)
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

    private static IEnumerable<IEnumerable<Cyclist>> Chunk1(IEnumerable<Cyclist> source, int chunkSize)
    {
        IEnumerable<IEnumerable<Cyclist>> cluster = source
            .Select((x, i) => new {Index = i, Value = x})
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value));
        return cluster;
    }

    private static IEnumerable<IEnumerable<Cyclist>> Chunk2(IEnumerable<Cyclist> source, int chunkSize)
    {
        List<List<Cyclist>> altCluster = new List<List<Cyclist>>();
        int i = 0;
        foreach (var cyclist in source)
        {
            int chunkIndex = i / chunkSize;
            if (altCluster.Count <= chunkIndex)
                altCluster.Add(new List<Cyclist>());
            altCluster[chunkIndex].Add(cyclist);
            ++i;
        }


        return altCluster;
    }
}