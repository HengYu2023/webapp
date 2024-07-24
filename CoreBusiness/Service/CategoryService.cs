using CoreBusiness.Interface;
using DataAccess.EFRepository;
using DataAccess.Entities;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreBusiness.Dto;

namespace CoreBusiness.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepo,
                                IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public CategoryDto Get(int id)
        {
            return _mapper.Map<CategoryDto>(_categoryRepo.GetById(id));
        }

        public CategoryDto GetProductCategory(int prdId)
        {
            return _mapper.Map<CategoryDto>(_categoryRepo.GetAll().FirstOrDefault(c => c.Products.Any(p => p.ProductId == prdId)));
        }

        public void Insert(CategoryDto categoryDto)
        {
            _categoryRepo.Insert(_mapper.Map<Category>(categoryDto));
            _categoryRepo.Save();

        }

        public void Update(CategoryDto categoryDto)
        {
            _categoryRepo.Update(_mapper.Map<Category>(categoryDto));
            _categoryRepo.Save();
        }
        public void Delete(int id)
        {
            _categoryRepo.Delete(id);
            _categoryRepo.Save();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _categoryRepo.GetAll()
                                .Select(c => _mapper.Map<CategoryDto>(c));
        }
    }
}
