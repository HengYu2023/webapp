using AutoMapper;
using CoreBusiness.Dto;
using DataAccess.Entities;
using DataAccess.EFRepository;
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
        public IActionResult Get(int ctgId)
        {
            CategoryViewModel? ctg = _mapper.Map<CategoryViewModel>(_categoryService.Get(ctgId));
            

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
            var productViewModel = _categoryService.GetAll()
                                        .Select(c => _mapper.Map<CategoryViewModel>(c));
            
            if (productViewModel == null)
            {
                return NotFound();
            }

            return Ok(productViewModel);
        }

        [HttpGet]
        [Route("ProductCategory")]
        public IActionResult GetByCategory(int ctgId)
        {
            var productViewModel = _mapper.Map<CategoryViewModel>(_categoryService.GetProductCategory(ctgId));


            if (productViewModel == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }

            return Ok(productViewModel);
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
        public IActionResult Delete(int ctgId)
        {
            _categoryService.Delete(ctgId);

            return Ok($"Remove {ctgId} category.");
        }
    }
}
