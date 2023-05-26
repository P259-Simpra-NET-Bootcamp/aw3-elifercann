using Microsoft.EntityFrameworkCore;
using SimpApi.DataAccess.Abstract;
using SimpApi.DataAccess.Context;
using SimpApi.Entities.Model;

namespace SimpApi.DataAccess.Concrete
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void CreateOneCategory(Category category)=>Create(category);

        public void DeleteOneCategory(Category category)=>Delete(category);
       

        public IEnumerable<Category> GetAllCategories(bool trankChanges)
        {
            return _context.Set<Category>().Include(x=>x.Products).ToList();
        }

        public Category GetOneCategoryById(int id, bool trankChanges)
        {
            return _context.Set<Category>().Where(x=>x.Id==id).Include(x=>x.Products).FirstOrDefault();
        }

        public void UpdateOneCategory(Category category)=>Update(category); 
    }
}
