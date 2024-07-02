using DataAccess.Interface;
using DataAccess.Entities;
using DataAccess.EFRepository;
using Microsoft.AspNetCore.Mvc;
using CoreBusiness.Interface;
using CoreBusiness.Service;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]   //route��controller�W��
    [Route("PRD")]             //�������wapi�W��
    public class ProductController : ControllerBase
    {        
        private readonly IProductService _prdService;

        public ProductController(NorthwindContext context)
        {
            _prdService = new ProductService(context);
        }

        [HttpGet]
        public IActionResult Get(int prdId)
        {
            var prd = _prdService.Get(prdId);


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
            var prds = _prdService.GetAll();


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
            var prds = _prdService.GetByCategry(ctgId);


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

            _prdService.Insert(product);

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _prdService.Update(product);

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