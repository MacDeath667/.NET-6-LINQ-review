using System.Collections.Generic;
using System.Linq;
using NewLinqFeatures.Features;

namespace NewLinqFeatures
{
    class Program
    {
        public static List<Person> People => new()
        {
            new Person {Id = 1, Name = "Gregor", Age = 33},
            new Person {Id = 2, Name = "Roman", Age = 32},
            new Person {Id = 3, Name = "Roma", Age = 28},
            new Person {Id = 4, Name = "Pavel", Age = 29},
            new Person {Id = 5, Name = "Ghost", Age = 33},
        };

        public static IEnumerable<Person> PeopleEnumerable
        {
            get
            {
                yield return new Person {Id = 1, Name = "Gregor", Age = 33};
                yield return new Person {Id = 2, Name = "Roman", Age = 32};
                yield return new Person {Id = 3, Name = "Roma", Age = 28};
                yield return new Person {Id = 4, Name = "Pavel", Age = 29};
                yield return new Person {Id = 5, Name = "Ghost", Age = 33};
                yield return new Person {Id = -1, Name = "None", Age = 0};
            }
        }

        static void Main()
        {
            MinMax.DemonstrateMinBy(People);
            MinMax.DemonstrateMaxBy(People);
            Chunks.Demonstrate(People);
            ByMethods.Demonstrate(People);
            IndexAndRange.Demonstrate(People);
            
            TryGetNonEnumeratedCount.Demonstrate(People);
            TryGetNonEnumeratedCount.Demonstrate(PeopleEnumerable);
            
            OrDefault.Demonstrate(People);
            Zip.Demonstrate(People);
        }
    }
}