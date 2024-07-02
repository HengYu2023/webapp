using CoreBusiness.Interface;
using DataAccess.EFRepository;
using DataAccess.Entities;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<Product> GetByCategry(int ctgId)
        {
            return _productRepo.GetAll().Where(p => p.CategoryId == ctgId);
        }

        public Product Get(int id)
        {
            return _productRepo.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public void Insert(Product product)
        {
            _productRepo.Insert(product);
            _productRepo.Save();
        }

        public void Update(Product product)
        {
            _productRepo.Update(product);
            _productRepo.Save();
        }
        public void Delete(int id)
        {
            _productRepo.Delete(id);
            _productRepo.Save();
        }        
    }
}
