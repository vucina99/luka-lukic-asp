using Application.Dto;
using Application.Exceptions;
using Application.UseCase.Queries;
using Application;
using Application.UseCase.Queries.Orders;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAL;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCase.Queries.Orders
{
    public class GetUserOrdersQuery : EFUseCaseConnection, IGetUsersOrderQuery
    {
        private IApplicationUser _user;
        public GetUserOrdersQuery(FilmContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 18;

        public string Name => "Use case for searching a user orders.";

        public string Description => "Use case for searching a user orders.";

        public PagedResponse<GetOrderDto> Execute(OrderBasePagedSearch request)
        {
            if (request.UserId != _user.Id)
            {
                throw new ForbbidenUseCaseException(Name, _user.Identity);
            }

            var orders = Context.Orders.Include(x => x.OrderLines).Where(x => x.UserId == request.UserId).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                orders = orders.Where(x => x.Recipient.Contains(request.Keyword) || x.Adress.Contains(request.Keyword));
            }
            if (request.PerPage == null || request.PerPage < 10)
            {
                request.PerPage = 10;
            }
            if (request.Page == null || request.Page < 1)
            {
                request.Page = 1;
            }
            var toSkip = (request.Page - 1) * request.PerPage;
            var response = new PagedResponse<GetOrderDto>();
            response.TotalCount = orders.Count();
            response.ItemsPerPage = request.PerPage.Value;
            response.CurrentPage = request.Page.Value;
            response.Data = orders.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new GetOrderDto
            {
                Adress = x.Adress,
                Recipient = x.Recipient,
                OrderId = x.Id,
                OrderLines = x.OrderLines.Select(y => new OrderLineDto
                {
                    FilmId = y.FilmId,
                    FilmName = y.FilmName,
                    Price = y.Price,
                    Quantity = y.Quantity,
                })
            }).ToList();
            return response;

        }
    }
}
