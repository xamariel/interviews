using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Models.Price;
using System.Collections.Generic;

namespace RealmdigitalInterview.Repos.Price
{
    public class PriceRepo : IPriceRepo
    {
        private IRepoService _repo;

        public PriceRepo(IRepoService repo)
        {
            _repo = repo;
        }

        public PriceModel Add(PriceModel model)
        {
            return _repo.Add<PriceModel>("usp_PriceAdd", model);
        }
        

        public PriceModel Delete(int id)
        {
            return _repo.Delete<PriceModel>("usp_PriceDelete", id);
        }
        
        public PriceModel Edit(PriceModel model)
        {
            return _repo.Edit<PriceModel>("usp_PriceEdit", model);
        }
        
        public PriceModel GetModel(int id)
        {
            return _repo.GetModel<PriceModel>("usp_PriceGetModel", id);
        }

        public List<PriceModel> GetCollection()
        {
            return _repo.GetCollection<PriceModel>("usp_PriceGetCollection");
        }

        public List<PriceModel> GetCollection(PriceModel filter)
        {
            return _repo.GetCollection<PriceModel>("usp_PriceGetCollectionByFilter", filter);
        }

        
    }
}
