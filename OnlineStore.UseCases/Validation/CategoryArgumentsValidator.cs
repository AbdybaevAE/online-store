using FluentValidation;
using OnlineStore.UseCases.Interfaces.Data;

namespace OnlineStore.UseCases.Validation
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryArguments>
    {
        public CreateCategoryValidator()
        {
            RuleFor(arguments => arguments.Name).MinimumLength(3).MaximumLength(100);
            RuleFor(arguments => arguments.Description).MinimumLength(3).MaximumLength(100);
        }
    }
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryArguments>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(arguments => arguments.Name).MinimumLength(3).MaximumLength(100);
            RuleFor(arguments => arguments.Description).MinimumLength(3).MaximumLength(100);
        }
    }
}
