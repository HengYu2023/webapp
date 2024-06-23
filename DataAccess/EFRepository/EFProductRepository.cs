using DataAccess.Interface;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFRepository
{
    public class EFProductRepository : EFRepository<Product>, IProductRepository
    {
        public IEnumerable<Product> GetByCategry(int ctgId)
        {
            return GetAll().Where(p => p.CategoryId == ctgId);
        }
    }
}
