using AutoMapper;
using OnlineStore.UseCases.Mappers;

namespace OnlineStore.UseCases.UnitTests.Profiles
{
    public class CategoryProfile_Tests
    {
        [Fact]
        public void CategoryProfileCorrect()
        {
            var cfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoryProfile>();
            });
            cfg.AssertConfigurationIsValid();
        }
    }
}
