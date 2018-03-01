using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel
    {
        public virtual IList<T> ModelCollection { get; }
        public virtual IList<T> GetAll() => ModelCollection;
        public virtual T Single(int id) => 
            ModelCollection.SingleOrDefault(c => c.Id == id);
        public virtual T Single(string name) => 
            ModelCollection.FirstOrDefault(c => c.Name == name);
    }
}