using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class IndexAndRange
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        Console.WriteLine("----Index and Range----");

        Person secondLastPersonOld = source.TakeLast(2).FirstOrDefault();
        Person secondLastPerson = source.ElementAt(^2);
        Console.WriteLine(secondLastPerson.Name);
        //Pavel

        IEnumerable<Person> take3PeopleOld = source.Take(3);
        IEnumerable<Person> take3People = source.Take(..3);
        Console.WriteLine(string.Join(", ", take3People.Select(person => person.Name)));
        //Gregor, Roman, Roma

        IEnumerable<Person> skip1PersonOld = source.Skip(1);
        IEnumerable<Person> skip1Person = source.Take(1..);
        Console.WriteLine(string.Join(", ", skip1Person.Select(person => person.Name)));
        //Roman, Roma, Pavel, Ghost
        
        IEnumerable<Person> take3Skip1PeopleOld = source.Take(3).Skip(1);
        IEnumerable<Person> take3Skip1People = source.Take(1..3);
        Console.WriteLine(string.Join(", ", take3Skip1People.Select(person => person.Name)));
        //Roman, Roma

        IEnumerable<Person> takeLast2PeopleOld = source.TakeLast(2);
        IEnumerable<Person> takeLast2People = source.Take(^2..);
        Console.WriteLine(string.Join(", ", takeLast2People.Select(person => person.Name)));
        //Pavel, Ghost

        IEnumerable<Person> skipLast3PeopleOld = source.SkipLast(3);
        IEnumerable<Person> skipLast3People = source.Take(..^3);
        Console.WriteLine(string.Join(", ", skipLast3People.Select(person => person.Name)));
        //Gregor, Roman

        IEnumerable<Person> takeLast3SkipLast2Old = source.TakeLast(3).SkipLast(2);
        IEnumerable<Person> takeLast3SkipLast2 = source.Take(^3..^2);
        Console.WriteLine(string.Join(", ", takeLast3SkipLast2.Select(person => person.Name)));
        //Roma
    }
}