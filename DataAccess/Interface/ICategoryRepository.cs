using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByProduct(int prdId);
    }
}
