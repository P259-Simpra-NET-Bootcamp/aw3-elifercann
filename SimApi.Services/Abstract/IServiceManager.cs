namespace SimpApi.Services.Abstract
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
    }
}
