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
    public class OrderLineValidator : AbstractValidator<OrderLineDto>
    {
        private readonly FilmContext _context;
        public OrderLineValidator(FilmContext context)
        {
            _context = context;
            RuleFor(x => x.Quantity).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Quantity is required parametar.").ExclusiveBetween(0, 21).WithMessage("Quantity must be between 1 and 20");
            RuleFor(x => x.FilmName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name of the film is required parametar.").Must(x => context.Films.Any(y => y.Name == x)).WithMessage("There is no film with a provided name in the system.");
            RuleFor(x => x.Price).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Price is required parametar.").Must(x => context.Films.Any(y => y.Price == x)).WithMessage("There is no film with a provided price in the system.");
            RuleFor(x => x.FilmId).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("FilmId is required parametar.").Must(x => context.Films.Any(y => y.Id == x)).WithMessage("There is no film with a provided id in the system.");
            RuleFor(x => x).Must(x => context.Films.Find(x.FilmId).Name == x.FilmName && context.Films.Find(x.FilmId).Price == x.Price).WithMessage("The name and price of the film must match the provided id");

        }
    }
}
