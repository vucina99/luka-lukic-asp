using Application.Dto;
using DataAccess.DAL;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Order
{
    public class CreateOrderValidator : AbstractValidator<MakeOrderDto>
    {
        private readonly FilmContext _context;
        public CreateOrderValidator(FilmContext context)
        {
            _context = context;
            RuleFor(x => x.Phone).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Phone is required parametar");
            RuleFor(x => x.Recipient).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Recipient is required parametar").MaximumLength(50).WithMessage("Recipient cannot be longer than 80 characters");
            RuleFor(x => x.Adress).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Adress is required parametar").Matches("^([A-ZŠĐĆČŽ][a-zšđčćž]{2,15}|[0-9])+(\\s[A-ZŠĐĆČŽ[a-zšđčćž0-9\\.\\-]{2,20})+$").WithMessage("Adress must be a valid adress.").MaximumLength(70).WithMessage("Adress cannot be longer than 80 characters");
            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("UserId is requrired parametar").Must(x => context.Users.Any(y => y.Id == x && y.isActive)).WithMessage("User with a provided id is a unvalid.");

            RuleFor(x => x.OrderLines).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("OrderLines is required parametar")
                 .Must(x => x.Count() > 0)
                 .WithMessage("Minimum number of order lines is 1.");
            RuleForEach(x => x.OrderLines).SetValidator(new OrderLineValidator(context));
        }
    }
}
