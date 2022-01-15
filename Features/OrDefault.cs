using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class OrDefault
{
    public static void Demonstrate(IEnumerable<Person> enumerable)
    {
        Console.WriteLine("----FirstOrDefault/LastOrDefault/SingleOrDefault overloads with default----");

        OrDefaultReferenceType();
        OrDefaultValueType(enumerable);
        
        var listWithZero = enumerable.ToList();
        listWithZero.Add(new Person {Id = -1, Name = "None", Age = 0});
        OrDefaultValueType(listWithZero);
    }

    private static void OrDefaultReferenceType()
    {
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
        VmSize overloadedFirstOrDefault = vmSizes.FirstOrDefault(VmSize.Empty);

        Console.WriteLine(
            $"Overloaded FirstOrDefault: {overloadedFirstOrDefault}; Old FirstOrDefault: {firstOrDefault}");
    }

    private static void OrDefaultValueType(IEnumerable<Person> enumerable)
    {
        var firstOrDefault = enumerable.Where(x => x.Age < 10).Select(x => x.Age).FirstOrDefault();
        var overloadedFirstOrDefault = enumerable.Where(x => x.Age < 10).Select(x => x.Age).FirstOrDefault(-1);

        Console.WriteLine(
            $"Overloaded FirstOrDefault: {overloadedFirstOrDefault}; Old FirstOrDefault: {firstOrDefault}");
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