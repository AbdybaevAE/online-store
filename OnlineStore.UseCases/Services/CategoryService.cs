using AutoMapper;
using FluentValidation;
using OnlineStore.Domain.CategoryAggregate;
using OnlineStore.Domain.Exceptions;
using OnlineStore.Domain.Interfaces;
using OnlineStore.UseCases.Interfaces;
using OnlineStore.UseCases.Interfaces.Data;
using OnlineStore.UseCases.Validation;

namespace OnlineStore.UseCases.Services
{
    public class CategoryService(
        IMapper mapper,
        ICategoryRepository categoryRepository,
        CreateCategoryValidator createCategoryValidator,
        UpdateCategoryValidator updateCategoryValidator
        ) : ICategoryService
    {
        public async Task<CategoryResult> CreateCategory(CreateCategoryArguments arguments, CancellationToken cancellationToken)
        {
            createCategoryValidator.ValidateAndThrow(arguments);
            var category = new Category(
                new CategoryID(Guid.NewGuid()),
                arguments.Name,
                arguments.Description,
                arguments.ParentID
            );
            var result = await categoryRepository.AddAsync(category, cancellationToken);
            return mapper.Map<Category, CategoryResult>(result);
        }

        public async Task DeleteCategory(CategoryID categoryID, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(categoryID, cancellationToken) ?? throw new CategoryNotFoundException();
            await categoryRepository.DeleteAsync(category, cancellationToken);
        }

        public Task<IEnumerable<CategoryResult>> GetAllCategories(CancellationToken cancellationToken)
        {
            return Task.FromResult(
                categoryRepository
                    .FindAll(cancellationToken)
                    .AsEnumerable()
                    .Select(mapper.Map<Category, CategoryResult>)
            );
        }

        public async Task<CategoryResult> GetCategoryByID(CategoryID categoryID, CancellationToken cancellationToken)
        {
            var foundCategory = await categoryRepository.GetByIdAsync(categoryID, cancellationToken) ?? throw new CategoryNotFoundException();
            return mapper.Map<Category, CategoryResult>(foundCategory);
        }

        public async Task UpdateCategory(UpdateCategoryArguments arguments, CancellationToken cancellationToken)
        {
            updateCategoryValidator.ValidateAndThrow(arguments);
            var foundCategory = await categoryRepository.GetByIdAsync(arguments.CategoryID, cancellationToken) ?? throw new CategoryNotFoundException();
            foundCategory.Name = arguments.Name;
            foundCategory.Description = arguments.Description;
            foundCategory.ParentCategoryID = arguments.ParentCategoryID;
            await categoryRepository.UpdateAsync(foundCategory, cancellationToken);
        }
    }
}
