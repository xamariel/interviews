using System.Collections.Generic;

namespace RealmdigitalInterview.Core.Interfaces
{
    public interface IRepoService
    {
        T Add<T>(string command, object parameters);
        T Delete<T>(string command, object id);
        T Edit<T>(string command, object parameters);
        T GetModel<T>(string command, object id);
        List<T> GetCollection<T>(string command);
        List<T> GetCollection<T>(string command, object parameters);
    }
}
