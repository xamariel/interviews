using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Models.Price;
using System.Collections.Generic;
using System.Linq;

namespace RealmdigitalInterview.Repos.Price
{
    public class PriceRepo : IPriceRepo
    {
        private IRepoService _repo;

        public PriceRepo(IRepoService repo)
        {
            _repo = repo;
        }

        public PriceModel Add(object parameters)
        {
            return _repo.Add<PriceModel>("usp_PriceAdd", parameters);
        }

        public PriceModel Delete(object parameters)
        {
            return _repo.Delete<PriceModel>("usp_PriceDelete", parameters);
        }

        public PriceModel Edit(object parameters)
        {
            return _repo.Edit<PriceModel>("usp_PriceEdit", parameters);
        }

        public List<PriceModel> GetCollection()
        {
            return _repo.GetCollection<PriceModel>("usp_PriceGetCollection");
        }

        public PriceModel GetModel(object parameters)
        {
            return _repo.GetModel<PriceModel>("usp_PriceGetModel", parameters) ;
        }
    }
}
