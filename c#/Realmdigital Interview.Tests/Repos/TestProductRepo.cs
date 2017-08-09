using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealmdigitalInterview.Core.Ioc;
using RealmdigitalInterview.Repos.Product;
using RealmdigitalInterview.Core.Implementations;
using RealmdigitalInterview.Core.Interfaces;
using Autofac;
using System.Configuration;
using System.Linq;

namespace Realmdigital_Interview.Tests.Repos
{
    [TestClass]
    public class TestProductRepo
    {
        private IProductRepo _productRepo;

        [TestInitialize]
        public void Init()
        {
            //default registerations               
            RealmdigitalInterview.Repos.Ioc.IocRegistration.Register();

            //mog registration overides
            IocContainer.RegisterInstance<IConnection>(new Connection
            {
                Name = ConfigurationManager.ConnectionStrings["Default"].Name,
                ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString
            });
            //IocContainer.RegisterType<MoqRepo, IRepoService>();
            IocContainer.Build();

            _productRepo = IocContainer.Resolve<IProductRepo>();            
        }

        [TestMethod]
        public void Product_Add()
        {
            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"                
            });

            Assert.IsTrue(added.ProductId >= 0);
            Assert.AreEqual("Demo BarCode", added.BarCode);
            Assert.AreEqual("Demo Item Name", added.ItemName);

            var deleted = _productRepo.Delete(added.ProductId);

            Assert.AreEqual(added.ProductId, deleted.ProductId);
            Assert.AreEqual(added.BarCode, deleted.BarCode);
            Assert.AreEqual(added.ItemName, deleted.ItemName);
        }

        [TestMethod]
        public void Product_Delete()
        {
            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            Assert.IsTrue(added.ProductId >= 0);
            Assert.AreEqual("Demo BarCode", added.BarCode);
            Assert.AreEqual("Demo Item Name", added.ItemName);

            var deleted = _productRepo.Delete(added.ProductId);

            Assert.AreEqual(added.ProductId, deleted.ProductId);
            Assert.AreEqual(added.BarCode, deleted.BarCode);
            Assert.AreEqual(added.ItemName, deleted.ItemName);
        }

        [TestMethod]
        public void Product_Edit()
        {
            var added = _productRepo.Add(new ProductModel
            {
                BarCode = "Demo BarCode",
                ItemName = "Demo Item Name"
            });

            Assert.IsTrue(added.ProductId >= 0);
            Assert.AreEqual("Demo BarCode", added.BarCode);
            Assert.AreEqual("Demo Item Name", added.ItemName);

            added.BarCode = "Updated BarCode";
            added.ItemName = "Updated ItemName";

            var edited = _productRepo.Edit(added);
            


            var deleted = _productRepo.Delete(added.ProductId);

            Assert.AreEqual(added.ProductId, deleted.ProductId);
            Assert.AreEqual(added.BarCode, deleted.BarCode);
            Assert.AreEqual(added.ItemName, deleted.ItemName);
        }

        [TestMethod]
        public void Product_GetModel()
        {
            //Product_Add();

            //_getmodel = _productRepo.GetModel(_add.ProductId);

            //Assert.AreEqual(_add.ProductId, _getmodel.ProductId);
            //Assert.AreEqual(_add.BarCode, _getmodel.BarCode);
            //Assert.AreEqual(_add.ItemName, _getmodel.ItemName);

            //Product_Delete();
        }

        [TestMethod]
        public void Product_GetCollection()
        {
            var collection = _productRepo.GetCollection();

            Assert.AreEqual(3, collection.Count);
        }
    }
}
