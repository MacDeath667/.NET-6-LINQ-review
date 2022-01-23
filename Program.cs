using System.Collections.Generic;
using NewLinqFeatures.Features;

namespace NewLinqFeatures
{
    class Program
    {
        public static List<Cyclist> Cyclists => new()
        {
            new Cyclist {Id = 1, Name = "Gregor", Age = 33},
            new Cyclist {Id = 2, Name = "Roman", Age = 32},
            new Cyclist {Id = 3, Name = "Roma", Age = 28},
            new Cyclist {Id = 4, Name = "Pavel", Age = 29},
            new Cyclist {Id = 5, Name = "Ghost", Age = 33},
        };

        public static IEnumerable<Cyclist> CyclistsEnumerable
        {
            get
            {
                yield return new Cyclist {Id = 1, Name = "Gregor", Age = 33};
                yield return new Cyclist {Id = 2, Name = "Roman", Age = 32};
                yield return new Cyclist {Id = 3, Name = "Roma", Age = 28};
                yield return new Cyclist {Id = 4, Name = "Pavel", Age = 29};
                yield return new Cyclist {Id = 5, Name = "Ghost", Age = 33};
            }
        }

        static void Main()
        {
            MinMax.DemonstrateMinBy(Cyclists);
            MinMax.DemonstrateMaxBy(Cyclists);
            Chunks.Demonstrate(Cyclists);
            ByMethods.Demonstrate(Cyclists);
            IndexAndRange.Demonstrate(Cyclists);
            TryGetNonEnumeratedCount.Demonstrate(Cyclists);
            TryGetNonEnumeratedCount.Demonstrate(CyclistsEnumerable);
            OrDefault.Demonstrate(Cyclists);
            Zip.Demonstrate(Cyclists);
        }
    }
}