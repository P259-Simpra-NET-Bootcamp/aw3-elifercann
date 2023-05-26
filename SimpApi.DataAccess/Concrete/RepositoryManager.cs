using SimpApi.DataAccess.Abstract;
using SimpApi.DataAccess.Context;

namespace SimpApi.DataAccess.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _context;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        public RepositoryManager(ApplicationContext context)
        {
            _context = context;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
        }
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IProductRepository ProductRepository => _productRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
