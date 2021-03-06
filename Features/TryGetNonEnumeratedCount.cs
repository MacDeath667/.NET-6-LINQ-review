using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class TryGetNonEnumeratedCount
{
    public static void Demonstrate(IEnumerable<Cyclist> source)
    {
        Console.WriteLine("----TryGetNonEnumeratedCount----");
        bool doneWithoutEnumerating = source.TryGetNonEnumeratedCount(out var sourceCount);
        var actionCount = source.Count();
        Console.WriteLine($"Was enumerated: {!doneWithoutEnumerating}, SourceCount: {sourceCount}, ActionCount: {actionCount}");
        
        //Was enumerated: False, SourceCount: 5, ActionCount: 5
        //Was enumerated: True, SourceCount: 0, ActionCount: 5

    }
}