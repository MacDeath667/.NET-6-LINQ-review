using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class OrDefault
{
    public static void Demonstrate() //todo: was - now - and for struct -age less 10
    {
        Console.WriteLine("----FirstOrDefault/LastOrDefault/SingleOrDefault overloads with default----");

        VmSize[] vmSizesA =
        {
            new("Medium", 300),
            new("Small", 100)
        };

        VmSize[] vmSizesB =
        {
            new("Huge", 1500),
            new("Large", 500)
        };

        IEnumerable<VmSize> vmSizes = vmSizesA.IntersectBy(vmSizesB.Select(x => x.Name), x => x.Name);
        VmSize firstOrDefault = vmSizes.FirstOrDefault();
        VmSize overridedFirstOrDefault = vmSizes.FirstOrDefault(VmSize.Empty);

        Console.WriteLine($"Overrided FirstOrDefault: {overridedFirstOrDefault}; Old FirstOrDefault: {firstOrDefault}");
    }

    private class VmSize
    {
        public static readonly VmSize Empty = new VmSize("Empty", 0);

        public VmSize(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; }
        public int Cost { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}