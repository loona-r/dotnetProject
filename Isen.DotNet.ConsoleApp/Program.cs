using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.InMemory;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        /****** HELLO WORLD ******/
        // static void Main(string[] args)
        // {
        //     string world = Hello.World;
        //     Console.WriteLine(world);

        //     string greet = Hello.Greet("Loona");
        //     Console.WriteLine(greet);

        //     string greetUpper = Hello.GreetUpper("Loona");
        //     Console.WriteLine(greetUpper);
        // }

        /****** PERSON *****/
        // static void Main(string[] args)
        // {
        //     var me = new Person
        //     {
        //         FirstName = "Loona",
        //         LastName = "Rivière",
        //         BirthDate = new DateTime(1997,1,17),
        //         City = new City { Name = "Toulon" },
        //     };
        //     Console.WriteLine(me);
        // }

        /***** INMEMORY *****/
        static void Main(string[] args)
        {
            var cityRepo = new InMemoryCityRepository();
            Console.WriteLine(cityRepo.Single(3));
            Console.WriteLine(cityRepo.Single("Toulon"));
            var allCities = cityRepo.GetAll();
            foreach(var c in allCities) Console.WriteLine(c);
        }
    }
}