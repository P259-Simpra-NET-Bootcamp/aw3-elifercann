using SimpApi.Entities.Model;

namespace SimpApi.DataAccess.Abstract;

public interface IProductRepository:IRepositoryBase<Product>
{
    IQueryable<Product> GetAllProducts(bool trankChanges);
    Product GetOneProductById(int id, bool trankChanges);
    void CreateOneProduct(Product product);
    void DeleteOneProduct(Product product);
    void UpdateOneProduct(Product product);
}
