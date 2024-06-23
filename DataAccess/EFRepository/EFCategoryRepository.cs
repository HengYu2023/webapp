using DataAccess.Interface;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFRepository
{
    public class EFCategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public Category GetByProduct(int prdId)
        {
            return GetAll().FirstOrDefault(c => c.Products.Any(p => p.ProductId == prdId));
        }
    }
        
}
