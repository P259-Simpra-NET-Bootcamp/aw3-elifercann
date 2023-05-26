using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpApi.Entities.Model;
using SimpApi.Schema;
using SimpApi.Services.Abstract;

namespace SimpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
        public ProductController(IServiceManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _manager.ProductService.GetAllProducts(false);
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetOneProduct([FromRoute] int id)
        {
            try
            {
                var product = _manager.ProductService.GetOneProductById(id, false);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }


        }


        [HttpPost]
        public IActionResult CreateOneProduct([FromBody] ProductRequest product)
        {
           
            try
            {
                if (product == null)
                {


                    return BadRequest();

                }
               
                var mapped=_mapper.Map<ProductRequest,Product>(product);
                _manager.ProductService.CreateOneProduct(mapped);

                return StatusCode(201, product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateOneProduct([FromRoute] int id, [FromBody] ProductRequest product)
        {
          
            try
            {
                if (product == null)
                    return BadRequest();
               
                var mapped = _mapper.Map<ProductRequest, Product>(product);
                mapped.Id = id;
                
                _manager.ProductService.UpdateOneProduct(id, mapped, true);

                return Ok(product);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneProduct([FromRoute] int id)
        {
            try
            {

                _manager.ProductService.DeleteOneProduct(id, false);

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
