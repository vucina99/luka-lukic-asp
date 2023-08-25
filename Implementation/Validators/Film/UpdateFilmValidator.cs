using Application.Dto;
using DataAccess.DAL;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Film
{
   
    public class UpdateFilmValidator : AbstractValidator<UpdateFilmDto>
    {

        private readonly FilmContext _context;
        public UpdateFilmValidator(FilmContext context)
        {
            _context = context;
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name is required parametar.");
            RuleFor(x => x.Description).Length(5, 150).WithMessage("Film description length must be between 5 and 150 characters.");
            RuleFor(x => x.Language).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Language is required parametar.").Length(1, 21).WithMessage("Film language length must be between 2 and 20 characters.");
            RuleFor(x => x.Duration).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Duratio is required parametar.").ExclusiveBetween(10, 3001).WithMessage("Durattion must be between 10 and 3000 minutes");
            RuleFor(x => x.Price).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Price is required parametar.").ExclusiveBetween(4, 1001).WithMessage("Price must be between 5 and 1000 eur.");
            RuleFor(x => x.AuthorId).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Film author is required parametar.").Must(x => context.Authors.Any(y => y.Id == x)).WithMessage("There is no author with provided Id");
            RuleFor(x => x.FilmCategoryIds).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("CategoryIds parametar must have a value")
                .Must(x => x.Count() == x.Distinct().Count()).WithMessage("There is a duplicates in the set of the provided ids.");
            RuleForEach(x => x.FilmCategoryIds).NotEmpty().WithMessage("Every provided id must have a value").Must(x => context.Categories.Any(z => z.Id == x)).WithMessage("There is no category with provided Id {PropertyValue}");

        }
    }
}
