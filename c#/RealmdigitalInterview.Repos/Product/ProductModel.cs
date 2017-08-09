using RealmdigitalInterview.Repos.Price;
using System.Collections.Generic;

namespace RealmdigitalInterview.Repos.Product
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public List<PriceModel> PriceRecords { get; set; }
    }
}
