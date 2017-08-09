using RealmdigitalInterview.Models.Product;

namespace RealmdigitalInterview.Services.Product
{
    public interface IProductService
    {
        ProductModel GetProductByName(string productName);
    }
}
