using CoreBusiness.Interface;
using DataAccess.Repository;
using DataAccess.Entities;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreBusiness.Dto;
using DataAccess.UnitOfWork;

namespace CoreBusiness.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepo,
                                IRepository<Product> productRepo,
                                IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            //_categoryRepo = _unitOfWork.GetRepository<Category>();
            //_productRepo = _unitOfWork.GetRepository<Product>();
            _mapper = mapper;
        }

        public CategoryDto Get(int categoryId)
        {
            return _mapper.Map<CategoryDto>(_categoryRepo.GetById(categoryId));
        }

        public CategoryDto GetProductCategory(int productId)
        {
            var categoryId = _mapper.Map<ProductDto>(_productRepo.GetById(productId))?.CategoryId;

            if (categoryId == null)
            {
                return new CategoryDto();
            }

            return _mapper.Map<CategoryDto>(_categoryRepo.GetById((int)categoryId));
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
        public void Delete(int categoryId)
        {
            _categoryRepo.Delete(categoryId);
            _categoryRepo.Save();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _categoryRepo.GetAll()
                                .Select(c => _mapper.Map<CategoryDto>(c));
        }
    }
}
