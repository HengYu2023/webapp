using DataAccess.Interface;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]   //route用controller名稱
    [Route("PRD")]             //直接指定api名稱
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prdRepo = new ProductRepository();

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

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _prdRepo.Add(product);
            _prdRepo.SaveChanges();

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
            _prdRepo.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {

            if (product == null)
            {
                return NotFound();
                //return BadRequest("Invalid ctgId.");
            }

            _prdRepo.Delete(product);
            _prdRepo.SaveChanges();

            return Ok($"Remove {product}.");
        }
    }
}