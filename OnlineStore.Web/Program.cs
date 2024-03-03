using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure;
using OnlineStore.Infrastructure.Repositories;
using OnlineStore.UseCases.Interfaces;
using OnlineStore.UseCases.Mappers;
using OnlineStore.UseCases.Services;
using OnlineStore.UseCases.Validation;
using OnlineStore.Web.AutoMapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("OnlineStoreDb")));
builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(CategoryDtoProfile));
builder.Services.AddScoped<CreateCategoryValidator>();
builder.Services.AddScoped<UpdateCategoryValidator>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();


app.Run();
