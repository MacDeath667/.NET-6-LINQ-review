using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLinqFeatures.Features;

internal class IndexAndRange
{
    public static void Demonstrate(IEnumerable<Person> source)
    {
        Console.WriteLine("----Index and Range----");

        Person secondLastPerson = source.ElementAt(^2);
        Console.WriteLine(secondLastPerson.Name);
        //Pavel

        IEnumerable<Person> take3People = source.Take(..3);
        Console.WriteLine(string.Join(", ", take3People.Select(person => person.Name)));
        //Gregor, Roman, Roma

        IEnumerable<Person> skip1Person = source.Take(1..);
        Console.WriteLine(string.Join(", ", skip1Person.Select(person => person.Name)));
        //Roman, Roma, Pavel, Ghost

        IEnumerable<Person> take3Skip1People = source.Take(1..3);
        Console.WriteLine(string.Join(", ", take3Skip1People.Select(person => person.Name)));
        //Roman, Roma

        IEnumerable<Person> takeLast2People = source.Take(^2..);
        Console.WriteLine(string.Join(", ", takeLast2People.Select(person => person.Name)));
        //Pavel, Ghost

        IEnumerable<Person> skipLast3People = source.Take(..^3);
        Console.WriteLine(string.Join(", ", skipLast3People.Select(person => person.Name)));
        //Gregor, Roman

        IEnumerable<Person> takeLast3SkipLast2 = source.Take(^3..^2);
        Console.WriteLine(string.Join(", ", takeLast3SkipLast2.Select(person => person.Name)));
        //Roma
        
        //What was before:
        IEnumerable<Person> takeLast3SkipLast2Old = source.TakeLast(3).SkipLast(2);
        Console.WriteLine("It's equals:");
        Console.WriteLine(string.Join(", ", takeLast3SkipLast2Old.Select(person => person.Name)));
        
    }
}