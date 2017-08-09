using RealmdigitalInterview.Repos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmdigitalInterview.Services.Product
{
    public class ProductService : IProductService
    {
        private IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public ProductModel GetProductByName(string productName)
        {
            //return _productRepo.GetModelByName(string productName);
            return new ProductModel();
        }
    }
}
