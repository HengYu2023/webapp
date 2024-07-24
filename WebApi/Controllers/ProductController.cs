using AutoMapper;
using CoreBusiness.Dto;
using DataAccess.Interface;
using DataAccess.Entities;
using DataAccess.EFRepository;
using Microsoft.AspNetCore.Mvc;
using CoreBusiness.Interface;
using CoreBusiness.Service;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]   //route��controller�W��
    [Route("PRD")]             //�������wapi�W��
    public class ProductController : ControllerBase
    {        
        private readonly IProductService _prdService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
                                    IMapper mapper)
        {
            _prdService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int prdId)
        {
            var prd = _mapper.Map<ProductViewModel>(_prdService.Get(prdId));


            if (prd == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }

            return Ok(prd);
        }
        
        [HttpGet]
        [Route("AllProduct")]
        public IActionResult GetAll()
        {
            var prds = _prdService.GetAll()
                                    .Select(p => _mapper.Map<ProductViewModel>(p));


            if (prds == null)
            {
                return NotFound();
            }

            return Ok(prds);
        }

        [HttpGet]
        [Route("ProductOfCategory")]
        public IActionResult GetByCategory(int ctgId)
        {
            var prds = _prdService.GetByCategry(ctgId)
                                    .Select(p => _mapper.Map<ProductViewModel>(p));


            if (prds == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }

            return Ok(prds);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _prdService.Insert(_mapper.Map<ProductDto>(product));

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _prdService.Update(_mapper.Map<ProductDto>(product));

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int prdId)
        {
            _prdService.Delete(prdId);

            return Ok($"Remove {prdId} product.");
        }
    }
}