using AutoMapper;
using CoreBusiness.Dto;
using DataAccess.Entities;

namespace CoreBusiness.BusinessMapping;

public class BusinessProfile : Profile
{
    public BusinessProfile()
    {
        CreateMap<CategoryDto,Category>()
            .ForMember(x=>x.Products,y=>y.Ignore())
            .ReverseMap();
        CreateMap<ProductDto,Product>()
            .ForMember(x=>x.Category,y=>y.Ignore())
            .ReverseMap();
    }
}