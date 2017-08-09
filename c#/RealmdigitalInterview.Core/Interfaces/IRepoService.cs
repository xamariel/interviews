using System.Collections.Generic;

namespace RealmdigitalInterview.Core.Interfaces
{
    public interface IRepoService
    {
        T Add<T>(string command, object parameters);
        T Delete<T>(string command, object id);
        T Edit<T>(string command, object parameters);
        List<T> GetCollection<T>(string command);
        T GetModel<T>(string command, object id);
        T GetModelByFilter<T>(string command, object parameters);
    }
}
