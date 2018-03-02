using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryCityRepository : BaseInMemoryRepository<City>, ICityRepository
    {
 
        public override IQueryable<City> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<City>
                    {
                        new City { Id = 1, Name = "Toulon" },
                        new City { Id = 2, Name = "Marseille" },
                        new City { Id = 3, Name = "Nice" },
                        new City { Id = 4, Name = "Paris" },
                        new City { Id = 5, Name = "Epinal"}
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }

        public override void Delete(int id)
        {
            var list = ModelCollection.ToList();
            foreach (var m in list)
            {
                if (m.Id == id)
                {
                    list.Remove(m);
                    _modelCollection = list;
                    break;
                }
            }
        }
    }
}