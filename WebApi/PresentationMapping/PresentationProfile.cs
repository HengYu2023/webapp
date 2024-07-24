using AutoMapper;
using CoreBusiness.Dto;
using WebApi.ViewModel;

namespace WebApi.PresentationMapping;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        CreateMap<CategoryViewModel, CategoryDto>()
            .ReverseMap();
        CreateMap<ProductViewModel, ProductDto>()
            .ReverseMap();
    }
}