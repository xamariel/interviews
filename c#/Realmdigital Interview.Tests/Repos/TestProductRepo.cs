using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealmdigitalInterview.Core.Ioc;
using RealmdigitalInterview.Repos.Product;
using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Filters;
using RealmdigitalInterview.Models;
using RealmdigitalInterview.Core.Implementations;

namespace Realmdigital_Interview.Tests.Repos
{
    [TestClass]
    public class TestProductRepo
    {
        public TestProductRepo()
        {
            //default registerations               
            RealmdigitalInterview.Repos.Ioc.IocRegistration.Register();

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
        public void ProductRepo_Add()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();

            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"                
            });

            Assert.IsTrue(added.ProductId >= 0);
            Assert.AreEqual("Demo BarCode", added.BarCode);
            Assert.AreEqual("Demo Item Name", added.ItemName);

            _productRepo.Delete(added.ProductId);
        }

        [TestMethod]
        public void ProductRepo_Delete()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();

            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            var deleted = _productRepo.Delete(added.ProductId);

            Assert.AreEqual(added.ProductId, deleted.ProductId);
            Assert.AreEqual(added.BarCode, deleted.BarCode);
            Assert.AreEqual(added.ItemName, deleted.ItemName);
        }

        [TestMethod]
        public void ProductRepo_Edit()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();

            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            added.BarCode = "Updated BarCode";
            added.ItemName = "Updated ItemName";

            var edited = _productRepo.Edit(added);

            Assert.AreEqual(added.ProductId, edited.ProductId);
            Assert.AreEqual(added.BarCode, edited.BarCode);
            Assert.AreEqual(added.ItemName, edited.ItemName);

            _productRepo.Delete(added.ProductId);
        }

        [TestMethod]
        public void ProductRepo_GetModel()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();

            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            var getModel = _productRepo.GetModel(added.ProductId);

            Assert.AreEqual(added.ProductId, getModel.ProductId);
            Assert.AreEqual(added.BarCode, getModel.BarCode);
            Assert.AreEqual(added.ItemName, getModel.ItemName);

            _productRepo.Delete(added.ProductId);
        }

        [TestMethod]
        public void ProductRepo_GetCollection()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();

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
            var collection = _productRepo.GetCollection();

            Assert.AreEqual(3, collection.Count);

            foreach (var item in collection)
            {
                _productRepo.Delete(item.ProductId);
            }
        }

        [TestMethod]
        public void ProductRepo_GetCollectionByFilter()
        {
            var _productRepo = IocContainer.Resolve<IProductRepo>();

            _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });
            _productRepo.Add(new ProductModel
            {
                BarCode = "Bogus",
                ItemName = "Bogus"
            });
            _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            var collection = _productRepo.GetCollection(new ProductFilter {
                ItemName = "Demo Item Name"
            });

            Assert.AreEqual(2, collection.Count);

            foreach (var item in collection)
            {
                _productRepo.Delete(item.ProductId);
            }
        }
    }
}
