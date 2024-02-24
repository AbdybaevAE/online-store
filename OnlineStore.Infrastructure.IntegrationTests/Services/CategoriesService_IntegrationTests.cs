using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.IntegrationTests.Config;
using OnlineStore.Infrastructure.IntegrationTests.Fixtures;
using OnlineStore.Infrastructure.Repositories;
using OnlineStore.UseCases.Mappers;
using OnlineStore.UseCases.Services;
using OnlineStore.UseCases.Validation;
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
        public async Task AddCategories()
        {
            var categoryService = _testServer.Services.GetService<CategoryService>()!;
            var foundCategories = await categoryService.GetAllCategories(CancellationToken.None);
            Assert.Empty(foundCategories);
        }

        public void Dispose()
        {
            new SetupDatabase(_postgreSqlFixture.ConnectionString).ClearDatabase();
        }
    }
}
