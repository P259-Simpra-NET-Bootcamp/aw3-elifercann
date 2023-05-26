using SimpApi.Entities.Model;

namespace SimpApi.Services.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category GetOneCategoryById(int id, bool trackChanges);
        Category CreateOneCategory(Category category);
        void UpdateOneCategory(int id, Category category, bool trackChanges);
        void DeleteOneCategory(int id, bool trackChanges);
    }
}
