using System.Collections.Generic;

namespace RealmdigitalInterview.Core.Interfaces
{
    public interface IRepoContract<T>
    {
        T Add(T model);
        T Delete(int id);
        T Edit(T model);
        T GetModel(int id);
        List<T> GetCollection();
    }
}
