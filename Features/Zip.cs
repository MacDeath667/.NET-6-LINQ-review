using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

public class Zip
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        Console.WriteLine("----Zip with 3 parameters----");

        const string Separator = "-";
        IEnumerable<int> ids = Enumerable.Range(1, 4);
        IEnumerable<Person> allPeople = source;
        IEnumerable<int> allAges = source.Select(person => person.Age);

        IEnumerable<(int Id, Person Person, int Age)> zipped = ids.Zip(allPeople, allAges);
        Console.WriteLine(string.Join(", ", zipped.Select(x => x.Id + Separator+ x.Person.Name + Separator + x.Age)));
    }
}