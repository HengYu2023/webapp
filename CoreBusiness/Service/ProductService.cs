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
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepo,
                                IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetByCategry(int ctgId)
        {
            return _productRepo.GetAll()
                                .Where(p => p.CategoryId == ctgId)
                                .Select(p => _mapper.Map<ProductDto>(p));
        }

        public ProductDto Get(int id)
        {
            return _mapper.Map<ProductDto>(_productRepo.GetById(id));
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _productRepo.GetAll()
                                .Select(p => _mapper.Map<ProductDto>(p));
        }

        public void Insert(ProductDto productDto)
        {
            _productRepo.Insert(_mapper.Map<Product>(productDto));
            _productRepo.Save();
        }

        public void Update(ProductDto productDto)
        {
            _productRepo.Update(_mapper.Map<Product>(productDto));
            _productRepo.Save();
        }
        public void Delete(int id)
        {
            _productRepo.Delete(id);
            _productRepo.Save();
        }        
    }
}
