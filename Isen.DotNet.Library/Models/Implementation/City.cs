using System;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class City
    {
        public int Id{ get; set; }
        public string Name { get; set; }

// int? => peut etre nul
// ? => Si
        public string Display
        => $"[Id={Id}]|{Name}";

        public override string ToString()
        => Display;
    }
}