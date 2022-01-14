using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class TryGetNonEnumeratedCount
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        Console.WriteLine("----TryGetNonEnumeratedCount----");
        bool doneWithoutEnumerating = source.TryGetNonEnumeratedCount(out var sourceCount);
        var actionCount = source.Count();
        Console.WriteLine($"Was enumerated: {!doneWithoutEnumerating}, SourceCount: {sourceCount}, ActionCount: {actionCount}");
    }
}