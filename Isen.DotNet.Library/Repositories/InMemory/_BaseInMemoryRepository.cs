using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public abstract class BaseInMemoryRepository<T> :
        BaseRepository<T>
        where T : BaseModel
    {
        protected IList<T> _modelCollection;

        public override void Delete(int id)
        {
            var list = ModelCollection.ToList();
            var modelToRemove = Single(id);
            list.Remove(modelToRemove);
            _modelCollection = list;
        }
    }
}