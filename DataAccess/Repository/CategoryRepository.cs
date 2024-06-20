using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryRepository()
        {
            _context = new NorthwindContext();
        }

        public void Add(Category category)
        {
            _context.Add(category);
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int ctgId)
        {
            return _context.Categories.Find(ctgId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
