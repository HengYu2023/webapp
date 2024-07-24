using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness.Dto;

namespace CoreBusiness.Interface
{
    public interface IProductService
    {
        ProductDto Get(int productId);
        IEnumerable<ProductDto> GetAll();
        IEnumerable<ProductDto> GetByCategory(int categoryId);
        void Insert(ProductDto productDto);
        void Update(ProductDto productDto);
        void Delete(int productId);
    }
}
