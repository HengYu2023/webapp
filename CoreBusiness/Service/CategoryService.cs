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
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public Category Get(int id)
        {
            return _categoryRepo.GetById(id);
        }

        public Category GetProductCategory(int prdId)
        {
            return _categoryRepo.GetAll().FirstOrDefault(c => c.Products.Any(p => p.ProductId == prdId));
        }

        public void Insert(Category category)
        {
            _categoryRepo.Insert(category);
            _categoryRepo.Save();

        }

        public void Update(Category category)
        {
            _categoryRepo.Update(category);
            _categoryRepo.Save();
        }
        public void Delete(int id)
        {
            _categoryRepo.Delete(id);
            _categoryRepo.Save();
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepo.GetAll();
        }
    }
}
