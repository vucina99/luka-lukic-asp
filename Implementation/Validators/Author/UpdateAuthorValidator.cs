using Application.Dto;
using DataAccess.DAL;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Author
{
    public class UpdateAuthorValidator : AbstractValidator<AuthorsDto>
    {
        private FilmContext _context;
        public UpdateAuthorValidator(FilmContext context)
        {
            _context = context;
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required parametar.")
                .MinimumLength(3).WithMessage("Name length must be over 2 charachters");
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop).Must(x => _context.Authors.Any(z => z.Id == x)).WithMessage("Author wth a id {PropertyValue} doesnt exists.");
            RuleFor(x => x).Cascade(CascadeMode.Stop).Must(x => !_context.Authors.Any(y => y.Name == x.Name && x.Id != y.Id)).WithMessage("Author with a given name is already in use.");

        }
    }
}
