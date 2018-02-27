using System;

namespace Isen.DotNet.Library {
    public class Hello {
        // private static string _world = "Hello, World";
        // public static string World {
        //     get { return _world; }
        //     set { _world = value; }
        // }

        public static string World { get; set; } = "Hello, World";

        // Renvoie des salutations
        public static string Greet (string name)
        {
            string message = "Hello, " + name;
            return message;
        }
    }
}