using Application.Dto;
using Application.UseCase.Queries;
using DataAccess.DAL;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries
{
    public class GetCategoriesQuery : EFUseCaseConnection, IGetCategoriesQuery
    {

        public GetCategoriesQuery(FilmContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Use case for searching categories";

        public string Description => "Use case for searching categories";

        public PagedResponse<CategoryDto> Execute(BasePagedSearch request)
        {
            var query = Context.Categories.AsQueryable();
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
            var response = new PagedResponse<CategoryDto>();
            response.TotalCount = query.Count();
            response.ItemsPerPage = request.PerPage.Value;
            response.CurrentPage = request.Page.Value;
            response.Data = query.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId
            }).ToList();
            return response;
        }

     
    }
}
