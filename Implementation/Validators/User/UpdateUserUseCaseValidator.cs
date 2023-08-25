using Application.Dto;
using DataAccess.DAL;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.User
{
    public class UpdateUserUseCaseValidator : AbstractValidator<UpdateUserUseCaseDto>
    {
        public UpdateUserUseCaseValidator(FilmContext context)
        {
            RuleFor(x => x.UserId).Must(x => context.Users.Any(z => z.Id == x && z.isActive))
                .WithMessage("User with provided ID does not exists");
            RuleFor(x => x.UseCaseIds).NotEmpty()
                .WithMessage("UseCaseIds should not be empty.")
                .Must(x => x.Distinct().Count() == x.Count())
                .WithMessage("UseCaseIds shold not contain duplicates.");
        }
    }
}
