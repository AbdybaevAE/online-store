using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Infrastructure.IntegrationTests.Config;
using OnlineStore.Infrastructure.IntegrationTests.Fixtures;
using OnlineStore.UseCases.Interfaces.Data;
using OnlineStore.UseCases.Services;
namespace OnlineStore.Infrastructure.IntegrationTests.Utils
{
    public class CategoriesService_IntegrationTests : IClassFixture<PostgreSqlFixture>, IDisposable
    {
        private readonly PostgreSqlFixture _postgreSqlFixture;
        private readonly TestServer _testServer;
        public CategoriesService_IntegrationTests(PostgreSqlFixture postgreSqlFixture)
        {
            _postgreSqlFixture = postgreSqlFixture;
            new SetupDatabase(postgreSqlFixture.ConnectionString).InitDatabase();
            _testServer = TestServerBuilder.Create(postgreSqlFixture);
        }

        [Fact]
        public async Task EmptyCategories()
        {
            // Given, When
            var categoryService = _testServer.Services.GetService<CategoryService>()!;
            var foundCategories = await categoryService.GetAllCategories(CancellationToken.None);

            // Then
            Assert.Empty(foundCategories);
        }

        [Fact]
        public async Task AddAndGetCategories()
        {
            // Given
            var createCategoryArguments = new CreateCategoryArguments("Name", "Description", null);

            // When
            var s1 = _testServer.Services.GetService<CategoryService>()!;
            await s1.CreateCategory(createCategoryArguments, CancellationToken.None);

            // Then
            var s2 = _testServer.Services.GetService<CategoryService>()!;
            var foundCategories = await s2.GetAllCategories(CancellationToken.None)!;
            Assert.Single(foundCategories);
            var category = foundCategories.First();
            Assert.Equal(createCategoryArguments.Name, category.CategoryName);
            Assert.Equal(createCategoryArguments.Description, category.CategoryDescription);
            Assert.Null(createCategoryArguments.ParentID);
        }
        public async Task<CategoryResult> CreatedCategory()
        {
            var createCategoryArguments = new CreateCategoryArguments("Name", "Description", null);
            var s1 = _testServer.Services.GetService<CategoryService>()!;
            return await s1.CreateCategory(createCategoryArguments, CancellationToken.None);
        }
        // public async Task CreatedCategory
        [Fact]
        public async Task UpdateCategory()
        {
            // Given
            var createdCategory = await CreatedCategory();
            var updateCategoryArguments = new UpdateCategoryArguments(
                createdCategory.CategoryID,
                "UpdatedName",
                "UpdatedDescription",
                null
            );

            // When
            var s2 = _testServer.Services.GetService<CategoryService>()!;
            await s2.UpdateCategory(updateCategoryArguments, CancellationToken.None);

            // Then
            var s3 = _testServer.Services.GetService<CategoryService>()!;
            var foundCategories = await s3.GetAllCategories(CancellationToken.None);
            Assert.Single(foundCategories);
            var foundCategory = foundCategories.First();
            Assert.Equal(updateCategoryArguments.Name, foundCategory.CategoryName);
            Assert.Equal(updateCategoryArguments.Description, foundCategory.CategoryDescription);
            Assert.Null(foundCategory.ParentCategoryID);
        }
        [Fact]
        public async Task DeleteCategory()
        {
            // Given
            var createdCategory = await CreatedCategory();

            // When
            var s2 = _testServer.Services.GetService<CategoryService>()!;
            await s2.DeleteCategory(createdCategory.CategoryID, CancellationToken.None);

            //Then
            var s3 = _testServer.Services.GetService<CategoryService>()!;
            Assert.Empty(await s3.GetAllCategories(CancellationToken.None));
        }
        public void Dispose()
        {
            new SetupDatabase(_postgreSqlFixture.ConnectionString).ClearDatabase();
        }
    }
}
