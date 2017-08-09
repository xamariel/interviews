namespace RealmdigitalInterview.Models
{
    public class PriceModel
    {
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public string SellingPrice { get; set; }
        public string CurrencyCode { get; set; }
    }
}
