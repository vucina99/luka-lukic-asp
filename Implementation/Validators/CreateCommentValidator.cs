using Application.Dto;
using DataAccess.DAL;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<CommentDto>
    {
        private FilmContext _context;
        public CreateCommentValidator(FilmContext context)
        {
            _context = context;
            RuleFor(x => x.Comment).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Comment is required parametar").MaximumLength(250).WithMessage("Comment maximum length is 250 characters.");
            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("UserId is required parametar").Must(x => context.Users.Any(y => y.Id == x && y.isActive)).WithMessage("There is no user with a provided Id");
            RuleFor(x => x.FilmId).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("FilmId is required parametar").Must(x => context.Films.Any(y => y.Id == x && y.isActive)).WithMessage("There is no film with a provided Id");
        }
    }
}
