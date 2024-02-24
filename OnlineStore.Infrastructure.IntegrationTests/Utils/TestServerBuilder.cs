using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.IntegrationTests.Fixtures;
using OnlineStore.Infrastructure.Repositories;
using OnlineStore.UseCases.Mappers;
using OnlineStore.UseCases.Services;
using OnlineStore.UseCases.Validation;

namespace OnlineStore.Infrastructure.IntegrationTests.Utils
{
    public class TestServerBuilder
    {
        public static TestServer Create(PostgreSqlFixture postgreSqlFixture)
        {
            var webHostBuilder =
                new WebHostBuilder()
                    .UseDefaultServiceProvider(s => { })
                    .Configure(app =>
                        {
                            app.Run(async (context) =>
                            {
                                await context.Response.WriteAsync("Hello, world!");
                            });
                        })
                        .ConfigureAppConfiguration(configurationBuilder =>
                        {

                        })
                    .ConfigureServices(services =>
                    {
                        services.AddAutoMapper(typeof(CategoryProfile));
                        services.AddScoped<CreateCategoryValidator>();
                        services.AddScoped<UpdateCategoryValidator>();
                        services.AddDbContext<AppDbContext>(cf => cf.UseNpgsql(postgreSqlFixture.ConnectionString));
                        services.AddTransient<ICategoryRepository, CategoryRepository>();
                        services.AddTransient<CategoryService>();
                    });
            return new TestServer(webHostBuilder);
        }
    }
}
