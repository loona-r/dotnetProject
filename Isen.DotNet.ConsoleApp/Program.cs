using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICityRepository cityRepository = new InMemoryCityRepository();
            IPersonRepository personRepository = new InMemoryPersonRepository(cityRepository);

            // Toutes les villes
            foreach(var c in cityRepository.GetAll())
                Console.WriteLine(c);
            Console.WriteLine("----------");

            //Toutes les personnes
            foreach(var p in personRepository.GetAll())
                Console.WriteLine(p);
            Console.WriteLine("----------");

            // Toutes les personnes nées après 1996
            var personBornAfter = personRepository.Find(p =>
            p.BirthDate.HasValue &&
            p.BirthDate.Value.Year >= 1997);
            foreach (var p in personBornAfter)
                Console.WriteLine(p);
            Console.WriteLine("----------");

            // Trouver toutes les personnes avec age > 40
            var personOlderThan = personRepository
                .Find(p =>
                    p.Age.HasValue &&
                    p.Age.Value >= 40);
            foreach(var p in personOlderThan)
                Console.WriteLine(p);
            Console.WriteLine("----------");

            // Toutes les villes qui contiennent un e
            var citiesWithE = cityRepository
                .Find(c => 
                    // IndexOf : équvalent de Contains()
                    // Mais avec paramètre CurrentCultureIgnoreCase
                    c.Name.IndexOf("e",
                        StringComparison.CurrentCultureIgnoreCase) >= 0);
            foreach (var c in citiesWithE)
                Console.WriteLine(c);
            Console.WriteLine("----------");

            // Effacer 2 villes
            var epinal = cityRepository.Single("Epinal");
            var paris = cityRepository.Single("Paris");
            cityRepository.DeleteRange(epinal,paris);
            foreach(var c in cityRepository.GetAll())
                Console.WriteLine(c);
            Console.WriteLine("----------");

            // Effacer une personne
            personRepository.Delete(1);
            foreach(var p in personRepository.GetAll())
                Console.WriteLine(p);
            Console.WriteLine("----------");
        }
    }
}