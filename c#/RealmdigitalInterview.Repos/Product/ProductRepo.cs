using RealmdigitalInterview.Core.Implementations;
using RealmdigitalInterview.Core.Interfaces;
using System.Collections.Generic;
using System;

namespace RealmdigitalInterview.Repos.Product
{
    public class ProductRepo : IProductRepo
    {
        private IRepoService _repo;

        public ProductRepo(IRepoService repo)
        {
            _repo = repo;
        }

        public ProductModel Add(ProductModel model)
        {
            return _repo.Add<ProductModel>("usp_ProductAdd", new {
                model.BarCode,
                model.ItemName
            });
        }
        
        public ProductModel Delete(int id)
        {
            return _repo.Delete<ProductModel>("usp_ProductDelete", new { ProductId = id });
        }
        
        public ProductModel Edit(ProductModel model)
        {
            return _repo.Edit<ProductModel>("usp_ProductEdit", model) ;
        }
        
        public List<ProductModel> GetCollection()
        {
            return _repo.GetCollection<ProductModel>("usp_ProductGetCollection");
        }
        
        public ProductModel GetModel(int id)
        {
            return _repo.GetModel<ProductModel>("usp_ProductGetModel", new { productId = id});
        }
        
        public ProductModel GetModelByFilter(ProductModel filter)
        {
            return _repo.GetModelByFilter<ProductModel>("usp_ProductGetModelByFilter", filter);
        }
        
    }
}
