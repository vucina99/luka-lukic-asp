using Application.Dto;
using Application.UseCase.Queries;
using Application.UseCase.Queries.Authors;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries.Authors
{
    public class GetAuthorsQuery : EFUseCaseConnection,IGetAuthorsQuery
    {
        public GetAuthorsQuery(FilmContext context) : base(context)
        {
        }
        public int Id => 3;

        public string Name => "Use case for searching authors";

        public string Description => "Use case for searching authors";

        public PagedResponse<AuthorsDto> Execute(BasePagedSearch request)
        {
            var query = Context.Authors.AsQueryable();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
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
            var response = new PagedResponse<AuthorsDto>();
            response.TotalCount = query.Count();
            response.ItemsPerPage = request.PerPage.Value;
            response.CurrentPage = request.Page.Value;
            response.Data = query.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new AuthorsDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return response;
        }
    }
}
