using DataAccess.Entities;
using DataAccess.EFRepository;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using CoreBusiness.Interface;
using CoreBusiness.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {        
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get(int ctgId)
        {
            Category? ctg = _categoryService.Get(ctgId);
            

            if (ctg == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }
            return Ok(ctg);
        }

        [HttpGet]
        [Route("AllProduct")]
        public IActionResult GetAll()
        {
            var prds = _categoryService.GetAll();


            if (prds == null)
            {
                return NotFound();
            }

            return Ok(prds);
        }

        [HttpGet]
        [Route("ProductCategory")]
        public IActionResult GetByCategory(int ctgId)
        {
            var prds = _categoryService.GetProductCategory(ctgId);


            if (prds == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }

            return Ok(prds);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _categoryService.Insert(category);
            
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _categoryService.Update(category);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int ctgId)
        {
            _categoryService.Delete(ctgId);

            return Ok($"Remove {ctgId} category.");
        }
    }
}
