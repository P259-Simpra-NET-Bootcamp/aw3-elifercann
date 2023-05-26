using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpApi.DataAccess.Abstract;
using SimpApi.Entities.Model;
using SimpApi.Schema;
using SimpApi.Services.Abstract;

namespace SimpApi.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
      
        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
            
        }

        public Category CreateOneCategory( Category category)
        {
           
            if (category is null)
                throw new ArgumentNullException(nameof(category));
             category.CreatedBy = "simapi";
             category.CreatedAt = DateTime.Now;
            _manager.CategoryRepository.CreateOneCategory(category);
            _manager.Save();
            return category;
        }

        public void DeleteOneCategory(int id, bool trackChanges)
        {
            var entity = _manager.CategoryRepository.GetOneCategoryById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Category with id:{id} could not found.");
            _manager.CategoryRepository.DeleteOneCategory(entity);
            _manager.Save();
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            
            return _manager.CategoryRepository.GetAllCategories(trackChanges);
        }

        public Category GetOneCategoryById(int id, bool trackChanges)
        {
          
            return _manager.CategoryRepository.GetOneCategoryById(id, trackChanges);
        }

        public void UpdateOneCategory(int id, Category category, bool trackChanges)
        {
            var entity = _manager.CategoryRepository.GetOneCategoryById(id, trackChanges);
           
            if (entity is null)
                throw new Exception($"Category with id:{id} could not found.");

            if (category is null)
                throw new ArgumentNullException(nameof(category));

            entity.Id = id;
            entity.Name = category.Name;
            entity.Order = category.Order;
            entity.UpdatedBy = "simapi2";
            entity.UpdatedAt = DateTime.Now;
            _manager.CategoryRepository.UpdateOneCategory(entity);
            _manager.Save();
        }
    }
}
