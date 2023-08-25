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
    public class CreateAuthorValidator : AbstractValidator<AuthorsDto>
    {
        private FilmContext _context;

        public CreateAuthorValidator(FilmContext context)
        {
            _context = context;
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required parametar.")
                .MinimumLength(3).WithMessage("Name length must be over 2 charachters.")
                .Must(AuthorAlreadyExists).WithMessage("Author {PropertyValue} is already in use.");
        }


        private bool AuthorAlreadyExists(string name)
        {
            if (_context.Authors.Any(x => x.Name == name))
            {
                return false;
            }
            return true;
        }
    }
}
