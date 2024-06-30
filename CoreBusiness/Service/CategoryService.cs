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
        private readonly IRepository<Category> _categoryRepository = new EFRepository<Category>();
        public Category Get(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetProductCategory(int prdId)
        {
            return _categoryRepository.GetAll().FirstOrDefault(c => c.Products.Any(p => p.ProductId == prdId));
        }

        public void Insert(Category category)
        {
            _categoryRepository.Insert(category);
            _categoryRepository.Save();

        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
            _categoryRepository.Save();
        }
        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
