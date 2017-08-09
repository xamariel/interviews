
using RealmdigitalInterview.Models.Product;
using RealmdigitalInterview.Repos.Price;
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
        private IPriceRepo _priceRepo;

        public ProductService(IProductRepo productRepo, IPriceRepo priceRepo)
        {
            _productRepo = productRepo;
            _priceRepo = priceRepo;
        }

        public ProductModel GetProductByName(string productName)
        {
            var products = _productRepo.GetCollection(new ProductModel {
                ItemName = productName
            });

            foreach (var product in products)
            {

            }

            return new ProductModel();
        }

        public ProductModel GetProductById(int productId)
        {
            //return _productRepo.GetModelByName(string productName);
            return new ProductModel();
        }
    }
}
