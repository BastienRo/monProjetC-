using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryPersonRepository : BaseInMemoryRepository<Person>, IPersonRepository
    {
       

        private ICityRepository _cityRepository;

        public InMemoryPersonRepository(ICityRepository cityRepository)
        {
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
                       new Person
                       {
                           Id = 1,
                           FirstName = "Bastien",
                           LastName = "Rodrigue",
                           BirthDate = new DateTime(1995,10,13),
                           City = _cityRepository.Single("Toulon")
                       },
                        new Person
                        {
                            Id = 2,
                            FirstName = "Quelqun",
                            LastName = "Quelqun",
                            BirthDate = new DateTime(2000,10,13),
                            City = _cityRepository.Single("Toulon")
                        },
                        new Person
                        {
                            Id = 3,
                            FirstName = "Quelqun2",
                            LastName = "Quelqun2",
                            BirthDate = new DateTime(2033,10,13),
                            City = _cityRepository.Single("Toulon")
                        },
                        new Person
                        {
                            Id = 4,
                            FirstName = "Quelqun3",
                            LastName = "Quelqun3",
                            BirthDate = new DateTime(1993,10,13),
                            City = _cityRepository.Single("Toulon")
                        },
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }
    }
}