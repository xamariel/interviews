using RealmdigitalInterview.Models;

namespace RealmdigitalInterview.Services.Product
{
    public interface IProductService
    {
        ProductModel GetProductByName(string productName);
    }
}
