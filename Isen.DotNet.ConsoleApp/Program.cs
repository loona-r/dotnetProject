using System;
using Isen.DotNet.Library;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = Hello.Greet("Loona");
            Console.WriteLine(result);

            string result2 = Hello.World;
            Console.WriteLine(result2);
        }
    }
}