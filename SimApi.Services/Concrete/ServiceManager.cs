using SimpApi.DataAccess.Abstract;
using SimpApi.Services.Abstract;

namespace SimpApi.Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IProductService> _productService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _categoryService= new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager));
            _productService= new Lazy<IProductService>(() => new ProductManager(repositoryManager));
        }
        public ICategoryService CategoryService =>_categoryService.Value;

        public IProductService ProductService => _productService.Value;
    }
}
