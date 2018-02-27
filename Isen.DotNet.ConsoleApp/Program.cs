using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        /****** HELLO WORLD ******
        static void Main(string[] args)
        {
            string world = Hello.World;
            Console.WriteLine(world);

            string greet = Hello.Greet("Loona");
            Console.WriteLine(greet);

            string greetUpper = Hello.GreetUpper("Loona");
            Console.WriteLine(greetUpper);
        }*/

        static void Main(string[] args)
        {
            var me = new Person
            {
                FirstName = "Loona",
                LastName = "Rivière",
                BirthDate = new DateTime(1997,1,17),
                City = new City { Name = "Toulon" },
            };
            Console.WriteLine(me);
        }
    }
}