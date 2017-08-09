using System.Collections.Generic;

namespace RealmdigitalInterview.Core.Interfaces
{
    public interface IRepoContract<T>
    {
        T Add(T model);
        T Delete(int id);
        T Edit(T model);
        List<T> GetCollection();
        T GetModel(int id);
        T GetModelByFilter(T filter);
    }
}
