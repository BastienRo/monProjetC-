using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryCityRepository : BaseRepository<City>, ICityRepository
    {
        private IList<City> _cityCollection;
        public override IList<City> ModelCollection
        {
            get
            {
                if (_cityCollection == null)
                {
                    _cityCollection = new List<City>
                    {
                        new City { Id = 1, Name = "Toulon" },
                        new City { Id = 2, Name = "Marseille" },
                        new City { Id = 3, Name = "Nice" },
                        new City { Id = 4, Name = "Paris" }
                    };
                }
                return _cityCollection;
            }
        }
    }
}