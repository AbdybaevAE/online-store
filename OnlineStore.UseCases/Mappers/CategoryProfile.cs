using AutoMapper;
using OnlineStore.Domain.CategoryAggregate;
using OnlineStore.UseCases.Interfaces.Data;

namespace OnlineStore.UseCases.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResult>()
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ParentCategoryID, opt => opt.MapFrom(src => src.ParentCategoryID))
            ;
        }
    }
}
