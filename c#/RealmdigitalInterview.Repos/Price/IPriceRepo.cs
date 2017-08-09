using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Filters;
using RealmdigitalInterview.Models;
using System.Collections.Generic;

namespace RealmdigitalInterview.Repos.Price
{
    public interface IPriceRepo : IRepoContract<PriceModel>
    {
        //default repo operations
        new PriceModel Add(PriceModel model);
        new PriceModel Delete(int id);
        new PriceModel Edit(PriceModel model);
        new PriceModel GetModel(int id);
        new List<PriceModel> GetCollection();
        List<PriceModel> GetCollection(PriceFilter filter);
    }
}
