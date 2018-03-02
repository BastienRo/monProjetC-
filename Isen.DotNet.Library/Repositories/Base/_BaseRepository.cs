using System;
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
        public abstract IQueryable<T> ModelCollection { get; }
        public virtual IEnumerable<T> GetAll() => ModelCollection;

        public virtual IEnumerable<T> Find(
            Func<T, bool> predicate)
        {
            var queryable = ModelCollection;
            //Filter
            queryable = queryable
                .Where(m => predicate(m));
            return queryable;
        }

        public virtual T Single(int id) =>
            ModelCollection.SingleOrDefault(c => c.Id == id);

        public virtual T Single(string name) =>
            ModelCollection.FirstOrDefault(c => c.Name == name);

        public virtual void Delete(int id)
        {
            foreach (var m in ModelCollection)
            {
                if (m.Id == id)
                {
                    var list = ModelCollection.ToList();
                    list.Remove(m);
                }
                ModelCollection.ToList().Remove(m);
            }
        }
        
        public void Delete(T model) =>
            Delete(model.Id);
    }
}