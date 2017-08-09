using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Models.Price;
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
        new List<PriceModel> GetCollection(PriceModel filter);
    }
}
