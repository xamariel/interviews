using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Models;
using System.Collections.Generic;

namespace RealmdigitalInterview.Repos.Product
{
    public interface IProductRepo : IRepoContract<ProductModel>
    {
        //default repo operations
        new ProductModel Add(ProductModel model);
        new ProductModel Delete(int id);
        new ProductModel Edit(ProductModel model);
        new ProductModel GetModel(int id);
        new List<ProductModel> GetCollection();
        List<ProductModel> GetCollection(ProductFilter filter);        
    }
}
