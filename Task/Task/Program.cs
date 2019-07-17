using System;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    class Program
    {

        static void Main(string[] args)
        {
            var persons = new List<Person>();

            persons.Add(new Person { Name = "Goda", Surname = "Goda", Age = 21 });
            persons.Add(new Person { Name = "Livija", Surname = "Goda", Age = 20 });
            persons.Add(new Person { Name = "Agne", Surname = "Goda", Age = 13 });
            persons.Add(new Person { Name = "Tomas", Surname = "Goda", Age = 16 });
            persons.Add(new Person { Name = "Jonas", Surname = "Goda", Age = 25 });
            persons.Add(new Person { Name = "Mantas", Surname = "Goda", Age = 17 });
            persons.Add(new Person { Name = "Angele", Surname = "Goda", Age = 20 });
            persons.Add(new Person { Name = "Arnas", Surname = "Goda", Age = 19 });
            persons.Add(new Person { Name = "Arturas", Surname = "Goda", Age = 26 });

            // The first 3 who are older than 18 and the name starts with letter A
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].Age > 18 && persons[i].Name[0].Equals('A'))
                {
                    Console.WriteLine(persons[i].Name);
                }
            }

            var chosenPersons = persons.Where(p => p.Name.StartsWith("A"))
                                       .Where(p => p.Age > 18)
                                       .Take(3)
                                       //.Select(p => p.Name)
                                       //.OrderBy(n => n)
                                       .Sum(p => p.Age);
                                       //.ToList();


            // Vardas ilgesnis nei 5 simboliai ir suskaiciuoti ju amziaus vidurki
            var chosen = persons.Where(p => p.Name.Length > 5)
                                .Select(p => p.Age)
                                .Average();
            Console.WriteLine(chosen);

            // Tik vardai ir pavardes
            // Jeigu nori globaliai naudot, reiks susikurt nauja klase, kitaip tiks ir anonimiskai
            var onlyNames = persons.Select(p => new Fullname { Name = p.Name, Surname = p.Surname})
                                   .ToList();
            onlyNames.ForEach(Console.WriteLine);

        }
        

    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

    }

    public class Fullname
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
