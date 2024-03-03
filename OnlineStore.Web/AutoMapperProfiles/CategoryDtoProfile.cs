using AutoMapper;
using OnlineStore.UseCases.Interfaces.Data;
using OnlineStore.Web.Dto;

namespace OnlineStore.Web.AutoMapperProfiles
{
    public class CategoryDtoProfile : Profile
    {
        public CategoryDtoProfile()
        {
            CreateMap<CategoryResult, CategoryDTO>()
                .ForMember(src => src.CategoryID, dst => dst.MapFrom(src => src.CategoryID.Value));
        }
    }
}
