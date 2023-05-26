namespace SimpApi.DataAccess.Abstract;

public interface IRepositoryManager
{
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    void Save();
}
