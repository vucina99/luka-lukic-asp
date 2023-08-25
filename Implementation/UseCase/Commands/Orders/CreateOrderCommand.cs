using Application.Dto;
using Application.UseCase.Commands.Orders;
using DataAccess.DAL;
using Domain;
using FluentValidation;
using Implementation.Validators.Order;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands.Orders
{
    public class CreateOrderCommand : EFUseCaseConnection, ICreateOrderCommand
    {
        private CreateOrderValidator _validator;
        private OrderLineValidator _validatorOrderLine;

        public CreateOrderCommand(FilmContext context, CreateOrderValidator validator, OrderLineValidator validatorLine) : base(context)
        {
            _validator = validator;
            _validatorOrderLine = validatorLine;
        }

        public int Id => 19;

        public string Name => "Use case for creating a order";

        public string Description => "Use case for creating a order.";

        public void Execute(MakeOrderDto request)
        {
            _validator.ValidateAndThrow(request);
            var order = new Order
            {
                Adress = request.Adress,
                Phone = request.Phone,
                Name = request.Name,
                Recipient = request.Recipient,
                UserId = request.UserId,
                SumPrice = request.OrderLines.Sum(x => x.Quantity * x.Price),
                OrderLines = request.OrderLines.Select(x => new OrderLine
                {
                    FilmId = x.FilmId,
                    Quantity = x.Quantity,
                    FilmName = x.FilmName,
                    Price = x.Price
                }).ToList()
            };
            Context.Add(order);
            Context.SaveChanges();
        }


    }
}
