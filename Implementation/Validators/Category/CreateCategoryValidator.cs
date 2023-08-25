using Application.Dto;
using DataAccess.DAL;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly FilmContext _context;
        public CreateCategoryValidator(FilmContext context)
        {
            _context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required parametar.")
                .MinimumLength(4).WithMessage("Name length must be over 3 charachters")
                .Must(x => !_context.Categories.Any(y => y.Name == x)).WithMessage("Category {PropertyValue} is already in use.");

            RuleFor(x => x.ParentId).Must(x => _context.Categories.Any(y => y.Id == x))
                .When(x => x.ParentId != null).WithMessage("There is no parent category with a provided id.");
        }
    }
}
