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
    public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly FilmContext _context;
        public UpdateCategoryValidator(FilmContext context)
        {
            _context = context;
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Name is required parametar.")
               .MinimumLength(4).WithMessage("Name length must be over 3 charachters");

            RuleFor(x => x.ParentId).Must(x => _context.Categories.Any(y => y.Id == x))
                .When(x => x.ParentId != null).WithMessage("There is no parent category with a provided id.");
            RuleFor(x => x).Must(x => !_context.Categories.Any(z => z.Name == x.Name && x.Id != z.Id)).WithMessage("Category with a given name is already in use.");

        }
    }
}
