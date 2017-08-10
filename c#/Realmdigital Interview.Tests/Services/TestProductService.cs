using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealmdigitalInterview.Core.Ioc;
using RealmdigitalInterview.Repos.Product;
using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Models;
using RealmdigitalInterview.Core.Implementations;
using RealmdigitalInterview.Services.Product;
using System.Linq;

namespace Realmdigital_Interview.Tests.Repos
{
    [TestClass]
    public class TestProductService
    {
        public TestProductService()
        {
            //default registerations               
            RealmdigitalInterview.Repos.Ioc.IocRegistration.Register();
            RealmdigitalInterview.Services.Ioc.IocRegistration.Register();

            //mog registration overides
            //IocContainer.RegisterInstance<IConnection>(new Connection
            //{
            //    Name = ConfigurationManager.ConnectionStrings["Default"].Name,
            //    ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString
            //});
            IocContainer.RegisterType<MoqRepo, IRepoService>();
            IocContainer.Build();                      
        }
        
        [TestMethod]
        public void ProductService_GetProductsByName()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();
            var _productService = IocContainer.Resolve<IProductService>();

            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            var collection = _productService.GetProductsByName("Demo Item Name");
            Assert.IsTrue(collection.Count == 1);
            var model = collection.FirstOrDefault();
            Assert.AreEqual(added.ProductId, model.ProductId);
            Assert.AreEqual(added.BarCode, model.BarCode);
            Assert.AreEqual(added.ItemName, model.ItemName);

            _productRepo.Delete(added.ProductId);
        }

        [TestMethod]
        public void ProductService_GetProductById()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();
            var _productService = IocContainer.Resolve<IProductService>();

            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            var model = _productService.GetProductById(added.ProductId);

            Assert.AreEqual(added.ProductId, model.ProductId);
            Assert.AreEqual(added.BarCode, model.BarCode);
            Assert.AreEqual(added.ItemName, model.ItemName);

            _productRepo.Delete(added.ProductId);
        }

        [TestMethod]
        public void ProductService_GetProducts()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();
            var _productService = IocContainer.Resolve<IProductService>();

            _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });
            _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });
            _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            var collection = _productService.GetProducts();

            Assert.AreEqual(3, collection.Count);

            foreach (var item in collection)
            {
                _productRepo.Delete(item.ProductId);
            }
        }
    }
}
