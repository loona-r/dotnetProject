﻿using System;

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
            var time = DateTime.Now.ToString("HH:mm");
            var oldMessage = String.Format("Hello {0}, it is {1}.", name, time);
            var message = $"Hello {name}, it is {time}.";
            return message;
        }

        // expression body =>
        // même symbole qu'une lamba expression
        public static string GreetUpper (string name) => Greet(name.ToUpper());
    }
}