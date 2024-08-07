using AutoMapper;
using CoreBusiness.Dto;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using CoreBusiness.Interface;
using CoreBusiness.Service;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {        
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,
                                    IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int categoryId)
        {
            CategoryViewModel? ctg = _mapper.Map<CategoryViewModel>(_categoryService.Get(categoryId));
            

            if (ctg == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }
            return Ok(ctg);
        }

        [HttpGet]
        [Route("AllCategory")]
        public IActionResult GetAll()
        {
            var categoryViewModel = _categoryService.GetAll()
                                        .Select(c => _mapper.Map<CategoryViewModel>(c));
            
            if (categoryViewModel == null)
            {
                return NotFound();
            }

            return Ok(categoryViewModel);
        }

        [HttpGet]
        [Route("ProductCategory")]
        public IActionResult GetByProduct(int productId)
        {
            var categoryViewModel = _mapper.Map<CategoryViewModel>(_categoryService.GetProductCategory(productId));


            if (categoryViewModel == null || categoryViewModel.CategoryId == 0)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }

            return Ok(categoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _categoryService.Insert(_mapper.Map<CategoryDto>(category));
            
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _categoryService.Update(_mapper.Map<CategoryDto>(category));

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);

            return Ok($"Remove {categoryId} category.");
        }
    }
}
