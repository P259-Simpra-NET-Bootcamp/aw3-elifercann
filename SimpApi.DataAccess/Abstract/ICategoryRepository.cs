using SimpApi.Entities.Model;

namespace SimpApi.DataAccess.Abstract;

public interface ICategoryRepository:IRepositoryBase<Category>
{
    IEnumerable<Category> GetAllCategories(bool trankChanges);
    Category GetOneCategoryById(int id, bool trankChanges);
    void CreateOneCategory(Category category);
    void DeleteOneCategory(Category category);
    void UpdateOneCategory(Category category);
}
