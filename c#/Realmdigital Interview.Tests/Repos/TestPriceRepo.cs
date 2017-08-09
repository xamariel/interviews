using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealmdigitalInterview.Core.Ioc;
using RealmdigitalInterview.Repos.Price;
using RealmdigitalInterview.Core.Interfaces;
using System.Configuration;
using RealmdigitalInterview.Models;
using RealmdigitalInterview.Core.Implementations;
using RealmdigitalInterview.Filters;

namespace Realmdigital_Interview.Tests.Repos
{
    [TestClass]
    public class TestPriceRepo
    {
        public TestPriceRepo()
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
        public void Price_Add()
        {
            var _priceRepo = IocContainer.Resolve<IPriceRepo>();

            var added = _priceRepo.Add(new PriceModel
            {
                ProductId = 1,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });

            Assert.IsTrue(added.PriceId >= 0);
            Assert.IsTrue(added.ProductId == 1);
            Assert.AreEqual("Demo SellingPrice", added.SellingPrice);
            Assert.AreEqual("Demo CurrencyCode", added.CurrencyCode);

            _priceRepo.Delete(added.PriceId);
        }

        [TestMethod]
        public void Price_Delete()
        {
            var _priceRepo = IocContainer.Resolve<IPriceRepo>();

            var added = _priceRepo.Add(new PriceModel
            {
                ProductId = 1,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });

            var deleted = _priceRepo.Delete(added.PriceId);

            Assert.AreEqual(added.PriceId, deleted.PriceId);
            Assert.AreEqual(added.ProductId, deleted.ProductId);
            Assert.AreEqual(added.SellingPrice, deleted.SellingPrice);
            Assert.AreEqual(added.CurrencyCode, deleted.CurrencyCode);
        }

        [TestMethod]
        public void Price_Edit()
        {
            var _priceRepo = IocContainer.Resolve<IPriceRepo>();

            var added = _priceRepo.Add(new PriceModel
            {
                ProductId = 1,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });

            added.ProductId = 2;
            added.SellingPrice = "Updated BarCode";
            added.CurrencyCode = "Updated ItemName";

            var edited = _priceRepo.Edit(added);

            Assert.AreEqual(added.PriceId, edited.PriceId);
            Assert.AreEqual(added.ProductId, edited.ProductId);
            Assert.AreEqual(added.SellingPrice, edited.SellingPrice);
            Assert.AreEqual(added.CurrencyCode, edited.CurrencyCode);

            _priceRepo.Delete(added.PriceId);
        }

        [TestMethod]
        public void Price_GetModel()
        {
            var _priceRepo = IocContainer.Resolve<IPriceRepo>();

            var added = _priceRepo.Add(new PriceModel
            {
                ProductId = 1,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });

            var getModel = _priceRepo.GetModel(added.PriceId);

            Assert.AreEqual(added.PriceId, getModel.PriceId);
            Assert.AreEqual(added.ProductId, getModel.ProductId);
            Assert.AreEqual(added.SellingPrice, getModel.SellingPrice);
            Assert.AreEqual(added.CurrencyCode, getModel.CurrencyCode);

            _priceRepo.Delete(added.PriceId);
        }

        [TestMethod]
        public void Price_GetCollection()
        {
            var _priceRepo = IocContainer.Resolve<IPriceRepo>();

            _priceRepo.Add(new PriceModel
            {
                ProductId = 1,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });
            _priceRepo.Add(new PriceModel
            {
                ProductId = 2,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });
            _priceRepo.Add(new PriceModel
            {
                ProductId = 3,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });

            var collection = _priceRepo.GetCollection();

            Assert.AreEqual(3, collection.Count);

            foreach (var item in collection)
            {
                _priceRepo.Delete(item.PriceId);
            }
        }

        [TestMethod]
        public void Price_GetCollectionByFilter()
        {
            var _priceRepo = IocContainer.Resolve<IPriceRepo>();

            _priceRepo.Add(new PriceModel
            {
                ProductId = 1,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });
            _priceRepo.Add(new PriceModel
            {
                ProductId = 2,
                SellingPrice = "Bogus",
                CurrencyCode = "Bogus"
            });
            _priceRepo.Add(new PriceModel
            {
                ProductId = 1,
                SellingPrice = "Demo SellingPrice",
                CurrencyCode = "Demo CurrencyCode"
            });

            var collection = _priceRepo.GetCollection(new PriceFilter {
                ProductId = 1
            });

            Assert.AreEqual(2, collection.Count);
            
            foreach (var item in collection)
            {
                _priceRepo.Delete(item.PriceId);
            }
        }
    }
}
