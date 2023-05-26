using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpApi.DataAccess.Abstract;
using SimpApi.Entities.Model;
using SimpApi.Schema;   
using SimpApi.Services.Abstract;

namespace SimpApi.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
      
        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
            
        }
        public Product CreateOneProduct(Product product)
        {
          
          
            if (product is null)
                throw new ArgumentNullException(nameof(product));
            product.CreatedBy = "simpapi";
            product.CreatedAt = DateTime.Now;
            _manager.ProductRepository.CreateOneProduct(product);
            _manager.Save();
            return product;
        }

        public void DeleteOneProduct(int id, bool trackChanges)
        {
            var entity = _manager.ProductRepository.GetOneProductById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Product with id:{id} could not found.");
            _manager.ProductRepository.DeleteOneProduct(entity);
            _manager.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
          
            return _manager.ProductRepository.GetAllProducts(trackChanges);
        }

        public Product GetOneProductById(int id, bool trackChanges)
        {
          
            return _manager.ProductRepository.GetOneProductById(id, trackChanges);
        }

        public void UpdateOneProduct(int id, Product product, bool trackChanges)
        {
            var entity = _manager.ProductRepository.GetOneProductById(id, trackChanges);
           
            if (entity is null)
                throw new Exception($"Prdouct with id:{id} could not found.");

            if (product is null)
                throw new ArgumentNullException(nameof(product));

            entity.Id = id;
            entity.Name = product.Name;
            entity.Tag = product.Tag;
            entity.Url = product.Url;
            entity.UpdatedBy = "simapi2";
            entity.UpdatedAt = DateTime.Now;
            _manager.ProductRepository.UpdateOneProduct(entity);
            _manager.Save();
        }
    }
}
