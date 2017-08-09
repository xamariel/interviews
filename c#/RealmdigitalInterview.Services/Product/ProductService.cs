using RealmdigitalInterview.Filters;
using RealmdigitalInterview.Models;
using RealmdigitalInterview.Repos.Price;
using RealmdigitalInterview.Repos.Product;
using System.Collections.Generic;

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

        public List<ProductModel> GetProductsByName(string itemName)
        {
            var products = _productRepo.GetCollection(new ProductFilter {
                ItemName = itemName
            });

            foreach (var product in products)
            {
                var prices = _priceRepo.GetCollection(new PriceFilter {
                    ProductId = product.ProductId
                });
            }

            return products;
        }

        public ProductModel GetProductById(int productId)
        {
            return _productRepo.GetModel(productId);
        }

        public List<ProductModel> GetProducts()
        {
            return _productRepo.GetCollection();
        }
    }
}
