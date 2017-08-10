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

            AssignProductPrices(products);

            return products;
        }

        public ProductModel GetProductById(int productId)
        {
            var product = _productRepo.GetModel(productId);

            AssignProductPrices(product);

            return product;
        }

        public List<ProductModel> GetProducts()
        {
            var products = _productRepo.GetCollection();

            AssignProductPrices(products);

            return products;
        }

        private void AssignProductPrices(List<ProductModel> products) {
            foreach (var product in products)
            {
                AssignProductPrices(product);
            }
        }

        private void AssignProductPrices(ProductModel product)
        {
            var prices = _priceRepo.GetCollection(new PriceFilter
            {
                ProductId = product.ProductId
            });
            product.PriceRecords = prices;            
        }
    }
}
