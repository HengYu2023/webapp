using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;
        public ProductRepository() 
        {
            _context = new NorthwindContext();
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);            
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
