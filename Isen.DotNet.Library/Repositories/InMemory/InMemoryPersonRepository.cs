using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{

    public class InMemoryPersonRepository : BaseInMemoryRepository<Person>, IPersonRepository
    {
        private ICityRepository _cityRepository;
        // Constructeur avec pattern d'injection de dépendances (DI)
        public InMemoryPersonRepository(ICityRepository cityRepository){
            _cityRepository = cityRepository;
        }
        public override IQueryable<Person> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<Person>
                    {
                        new Person{
                            Id = 0,
                            FirstName = "Loona",
                            LastName = "RIVIERE",
                            BirthDate = new System.DateTime(1997,1,17),
                            City = _cityRepository.Single("Le Pradet")
                        },
                        new Person{
                            Id = 1,
                            FirstName = "Lisa",
                            LastName = "ANTHONIOZ",
                            BirthDate = new System.DateTime(1996,8,10),
                            City = _cityRepository.Single("Vetraz-Monthoux")
                        },
                        new Person{
                            Id = 2,
                            FirstName = "Matthieu",
                            LastName = "RUIZ",
                            BirthDate = new System.DateTime(1996,8,13),
                            City = _cityRepository.Single("Toulon")
                        },
                        new Person{
                            Id = 3,
                            FirstName = "Matthieu",
                            LastName = "REYNIER",
                            BirthDate = new System.DateTime(1996,10,18),
                            City = _cityRepository.Single("Cuers")
                        },
                    };
                }
                return  _modelCollection.AsQueryable();
            }
        }
    }
}