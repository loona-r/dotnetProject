﻿using System;
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
            // Etat Initial des villes
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("----------");
            // Ajouter une ville
            var cannes = new City { Name = "Cannes"};
            cityRepository.Update(cannes);
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("----------");
            // Mettre à jour une ville
            var epinal = cityRepository.Single("Epinal");
            if (epinal != null)
            {
                epinal.Name += " sur mer";
                cityRepository.Update(epinal);
                foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
                Console.WriteLine("----------");
            }
            // Ajout et mise à jour dans une même update
            var lyon = new City { Name = "Lyon" };
            if (epinal != null) epinal.Name = "Epinal";
            cityRepository.UpdateRange(lyon, epinal);
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("----------");

            // Ajout et mise à jour d'une personne
            var marine = new Person{
                FirstName = "Marine",
                LastName = "Accart",
                BirthDate = new DateTime(1996,5,31),
                City = cityRepository.Single("Toulon")
            };
            var person2 = personRepository.Single(2);
            person2.BirthDate =
                person2.BirthDate.Value.AddYears(-100);
            personRepository.UpdateRange(marine, person2);
            foreach(var p in personRepository.GetAll()) Console.WriteLine(p);
            Console.WriteLine("----------");
        }

    }
}