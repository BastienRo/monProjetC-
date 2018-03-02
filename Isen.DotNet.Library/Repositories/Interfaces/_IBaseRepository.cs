using System;
using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.Library.Repositories.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(
            Func<T, bool> predicate);
        T Single(int id);
        T Single(string name);
        void Delete(int id);
        void Delete(T model);
    }
}