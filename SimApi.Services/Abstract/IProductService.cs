using SimpApi.Entities.Model;

namespace SimpApi.Services.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product GetOneProductById(int id, bool trackChanges);
        Product CreateOneProduct(Product product);
        void UpdateOneProduct(int id, Product product, bool trackChanges);
        void DeleteOneProduct(int id, bool trackChanges);
    }
}
