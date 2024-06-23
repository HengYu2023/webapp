using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByCategry(int ctgId);
    }
}
