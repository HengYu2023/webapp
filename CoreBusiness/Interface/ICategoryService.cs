using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Interface
{
    public interface ICategoryService
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
        Category GetProductCategory(int productId);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
