using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class ByMethods
{
    public static void Demonstrate(IEnumerable<Cyclist> source)
    {
        Console.WriteLine("----DistinctBy, UnionBy, IntersectBy, ExceptBy----");

        IEnumerable<Cyclist> evenAgedPeople = source.Where(person => person.Age % 2 == 0);
        //Roma, Ghost
        IEnumerable<Cyclist> personAbove30 = source.Where(person => person.Age > 30);
        //Gregor,Roman, Ghost

        UnionBy(evenAgedPeople, personAbove30);
        IntersectBy(evenAgedPeople, personAbove30);
        DistinctBy(evenAgedPeople, personAbove30);
        ExceptBy(evenAgedPeople, personAbove30);

        Console.WriteLine("Two last actions do one action, but old method needs IEqualityComparer<T> ");
    }

    private static void UnionBy(IEnumerable<Cyclist> evenAgedPeople, IEnumerable<Cyclist> personAbove30)
    {
        //What we did before:
        IEnumerable<Cyclist> union = evenAgedPeople.Union(personAbove30, new PersonByAgeComparer());
        Console.WriteLine($"Union: {string.Join(", ", union.Select(person => person.Name))}");

        IEnumerable<Cyclist> unionBy = evenAgedPeople.UnionBy(personAbove30, x => x.Age).ToArray();
        //Roman, Roma, Gregor
        Console.WriteLine($"Union: {string.Join(", ", unionBy.Select(person => person.Name))}");
    }

    private static void IntersectBy(IEnumerable<Cyclist> evenAgedPeople, IEnumerable<Cyclist> personAbove30)
    {
        //What we did before:
        IEnumerable<Cyclist> intersection = evenAgedPeople.Intersect(personAbove30, new PersonByAgeComparer());
        Console.WriteLine($"Intersection: {string.Join(",", intersection.Select(person => person.Name))}");

        IEnumerable<Cyclist> intersectionBy =
            evenAgedPeople.IntersectBy(personAbove30, x => x, new PersonByAgeComparer());
        //Roman
        Console.WriteLine($"Intersection: {string.Join(",", intersectionBy.Select(person => person.Name))}");
    }

    private static void DistinctBy(IEnumerable<Cyclist> evenAgedPeople, IEnumerable<Cyclist> personAbove30)
    {
        //What we did before:
        IEnumerable<Cyclist> distinct = evenAgedPeople.Distinct(new PersonByAgeComparer());
        Console.WriteLine($"Distinct: {string.Join(",", distinct.Select(person => person.Name))}");

        IEnumerable<Cyclist> distinctBy =
            evenAgedPeople.DistinctBy(x => x, new PersonByAgeComparer());
        //Ghost
        Console.WriteLine($"Distinct: {string.Join(",", distinctBy.Select(person => person.Name))}");
    }

    private static void ExceptBy(IEnumerable<Cyclist> evenAgedPeople, IEnumerable<Cyclist> personAbove30)
    {
        //What we did before:
        IEnumerable<Cyclist> except = evenAgedPeople.Except(personAbove30, new PersonByAgeComparer());
        Console.WriteLine($"Except: {string.Join(",", except.Select(person => person.Name))}");

        IEnumerable<Cyclist> exceptBy =
            evenAgedPeople.ExceptBy(personAbove30, x => x, new PersonByAgeComparer());
        //Ghost
        Console.WriteLine($"Except: {string.Join(",", exceptBy.Select(person => person.Name))}");
    }


    private static Func<Cyclist, string> KeySelector()
    {
        return x => $"{x.Age}_{x.Name}";
    }

    class PersonByAgeComparer : IEqualityComparer<Cyclist>
    {
        public bool Equals(Cyclist x, Cyclist y)
        {
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            return x.Age == y.Age;
        }

        public int GetHashCode(Cyclist obj) => HashCode.Combine(obj.Age);
    }
}