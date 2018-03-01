using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.Library.Repositories.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseModel
    {
        IList<T> GetAll();
        T Single(int id);
        T Single(string name);
    }
}