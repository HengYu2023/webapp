using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Interface
{
    public interface IProductService
    {
        Product Get(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategry(int ctgId);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
