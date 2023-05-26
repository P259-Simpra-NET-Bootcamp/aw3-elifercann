using SimpApi.DataAccess.Abstract;
using SimpApi.DataAccess.Context;
using SimpApi.Entities.Model;

namespace SimpApi.DataAccess.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);
       

        public void DeleteOneProduct(Product product)=> Delete(product);
       

        public IQueryable<Product> GetAllProducts(bool trankChanges)
        {
         return FindAll(trankChanges).OrderBy(x => x.Id);
        }

        public Product GetOneProductById(int id, bool trankChanges)
        {
            return FindByCondition(x => x.Id == id, trankChanges).SingleOrDefault();
        }

        public void UpdateOneProduct(Product product)=>Update(product);

    }
}
