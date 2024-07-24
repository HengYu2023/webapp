using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness.Dto;

namespace CoreBusiness.Interface
{
    public interface ICategoryService
    {
        CategoryDto Get(int categoryId);
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetProductCategory(int productId);
        void Insert(CategoryDto category);
        void Update(CategoryDto categoryDto);
        void Delete(int categoryId);
    }
}
