using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class ByMethods
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        //todo split to methods, 
        Console.WriteLine("----DistinctBy, UnionBy, IntersectBy, ExceptBy----");

        IEnumerable<Person> evenAgedPeople = source.Where(person => person.Age % 2 == 0);
        //Roma, Ghost
        IEnumerable<Person> personAbove30 = source.Where(person => person.Age > 30);
        //Gregor,Roman, Ghost

        UnionBy(evenAgedPeople, personAbove30);
        IntersectBy(evenAgedPeople, personAbove30);
        DistinctBy(evenAgedPeople, personAbove30);
        ExceptBy(evenAgedPeople, personAbove30);

        Console.WriteLine("Two last actions do one action, but old method needs IEqualityComparer<T> ");
    }

    private static void UnionBy(IEnumerable<Person> evenAgedPeople, IEnumerable<Person> personAbove30)
    {
        //What we did before:
        IEnumerable<Person> union = evenAgedPeople.Union(personAbove30, new PersonByAgeComparer());
        Console.WriteLine($"Union: {string.Join(", ", union.Select(person => person.Name))}");

        IEnumerable<Person> unionBy = evenAgedPeople.UnionBy(personAbove30, x => x.Age);
        //Roman, Roma, Gregor, Ghost
        Console.WriteLine($"Union: {string.Join(", ", unionBy.Select(person => person.Name))}");
    }

    private static void IntersectBy(IEnumerable<Person> evenAgedPeople, IEnumerable<Person> personAbove30)
    {
        //What we did before:
        IEnumerable<Person> intersection = evenAgedPeople.Intersect(personAbove30, new PersonByAgeComparer());
        Console.WriteLine($"Intersection: {string.Join(",", intersection.Select(person => person.Name))}");

        IEnumerable<Person> intersectionBy =
            evenAgedPeople.IntersectBy(personAbove30, x => x, new PersonByAgeComparer());
        //Roman
        Console.WriteLine($"Intersection: {string.Join(",", intersectionBy.Select(person => person.Name))}");
    }

    private static void DistinctBy(IEnumerable<Person> evenAgedPeople, IEnumerable<Person> personAbove30)
    {
        //What we did before:
        IEnumerable<Person> distinct = evenAgedPeople.Distinct(new PersonByAgeComparer());
        Console.WriteLine($"Distinct: {string.Join(",", distinct.Select(person => person.Name))}");

        IEnumerable<Person> distinctBy =
            evenAgedPeople.DistinctBy(x=>x, new PersonByAgeComparer());
        //Ghost
        Console.WriteLine($"Distinct: {string.Join(",", distinctBy.Select(person => person.Name))}");
    }
    private static void ExceptBy(IEnumerable<Person> evenAgedPeople, IEnumerable<Person> personAbove30)
    {
        //What we did before:
        IEnumerable<Person> except = evenAgedPeople.Except(personAbove30, new PersonByAgeComparer());
        Console.WriteLine($"Except: {string.Join(",", except.Select(person => person.Name))}");

        IEnumerable<Person> exceptBy =
            evenAgedPeople.ExceptBy(personAbove30, x => x, new PersonByAgeComparer());
        //Ghost
        Console.WriteLine($"Except: {string.Join(",", exceptBy.Select(person => person.Name))}");
    }


    private static Func<Person, string> KeySelector()
    {
        return x => $"{x.Age}_{x.Name}";
    }

    class PersonByAgeComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            //if (ReferenceEquals(x, null)) return false;
            //if (ReferenceEquals(y, null)) return false;
            return x.Age == y.Age;
        }

        public int GetHashCode(Person obj) => HashCode.Combine(obj.Name, obj.Age);
    }
}