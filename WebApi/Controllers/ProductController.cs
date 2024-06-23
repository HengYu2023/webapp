using DataAccess.Interface;
using DataAccess.Entities;
using DataAccess.EFRepository;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]   //route用controller名稱
    [Route("PRD")]             //直接指定api名稱
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _prdRepo = new EFProductRepository();

        [HttpGet]
        public IActionResult Get(int prdId)
        {
            var prd = _prdRepo.GetById(prdId);


            if (prd == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }

            return Ok(prd);
        }
        
        [HttpGet]
        [Route("AllProduct")]
        public IActionResult GetALL()
        {
            var prds = _prdRepo.GetAll();


            if (prds == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }

            return Ok(prds);
        }

        [HttpGet]
        [Route("ProductOfCategory")]
        public IActionResult Get()
        {
            var prds = _prdRepo.GetAll();


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

            _prdRepo.Insert(product);
            _prdRepo.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _prdRepo.Update(product);
            _prdRepo.Save();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int prdId)
        {          
            _prdRepo.Delete(prdId);
            _prdRepo.Save();

            return Ok($"Remove {prdId} product.");
        }
    }
}