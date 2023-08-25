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
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        private FilmContext _context;
        public RegisterUserValidator(FilmContext context)
        {
            _context = context;
            var nameRegex = "^[A-Z][a-z]{2,}(\\s[A-Z][a-z]{2,})*$";
            RuleFor(x => x.UserName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Username is required")
                .MinimumLength(3).WithMessage("Username must have atleast 3 chars.")
                .MaximumLength(20).WithMessage("Username can not have over 20 chars.")
                .Matches("^(?=[a-zA-Z0-9._]{3,20}$)(?!.*[_.]{2})[^_.].*[^_.]$").WithMessage("Username can only conatin letters,digits and _ ")
                .Must(x => !_context.Users.Any(y => y.UserName == x)).WithMessage("Username {PropertyValue} has been taken.");

            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name can not have over 50 chars.")
                .Matches(nameRegex).WithMessage("Name must have atleast 3 chars and begin with the capital letter.");

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Lastname is required.")
                .MaximumLength(50).WithMessage("Lastname can not have over 50 chars.")
                .Matches(nameRegex).WithMessage("Lastname must have atleast 3 chars and begin with the capital letter.");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email: {PropertyValue} is not valid.").Must(x => !_context.Users.Any(y => y.Email == x)).WithMessage("Email {PropertyValue} has been taken.");

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Password is required").Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$").WithMessage("Password most contain atleast one lowercase,uppercase,digin and special char.");

        }
    }
}
