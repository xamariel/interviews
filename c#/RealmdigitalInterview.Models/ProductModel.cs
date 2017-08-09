using RealmdigitalInterview.Models.Price;
using System.Collections.Generic;

namespace RealmdigitalInterview.Models.Product
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public List<PriceModel> PriceRecords { get; set; }
    }
}
