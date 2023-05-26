using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpApi.Entities.Model;
using SimpApi.Schema;
using SimpApi.Services.Abstract;

namespace SimpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
        public CategoryController(IServiceManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _manager.CategoryService.GetAllCategories(false);
                return Ok(categories);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetOneCategory([FromRoute] int id)
        {
            try
            {
                var category = _manager.CategoryService.GetOneCategoryById(id, false);
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }
        

        [HttpPost]
        public IActionResult CreateOneCategory([FromBody] CategoryRequest category)
        {
            
            try
            {
                if (category == null)
                {

                    return BadRequest();

                }
               
                var mapped=_mapper.Map<CategoryRequest,Category>(category);
                _manager.CategoryService.CreateOneCategory(mapped);

                return StatusCode(201, category);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateOneCategory([FromRoute] int id, [FromBody] CategoryRequest category)
        {
         
            try
            {
                if (category == null)
                    return BadRequest();
                
                var mapped = _mapper.Map<CategoryRequest, Category>(category);
                mapped.Id = id;
                _manager.CategoryService.UpdateOneCategory(id, mapped, true);

                return Ok(category);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneCategory([FromRoute] int id)
        {
            try
            {

                _manager.CategoryService.DeleteOneCategory(id, false);

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
