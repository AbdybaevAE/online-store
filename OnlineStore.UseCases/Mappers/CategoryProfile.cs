using AutoMapper;
using OnlineStore.Domain.CategoryAggregate;
using OnlineStore.UseCases.Interfaces.Data;

namespace OnlineStore.UseCases.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResult>();
        }
    }
}
