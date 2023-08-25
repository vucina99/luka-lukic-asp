using Application.Dto;
using Application.UseCase.Queries;
using Application.UseCase.Queries.Films;
using DataAccess.DAL;
using Implementations.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries.Films
{


    public class GeFilmQuery : EFUseCaseConnection, IGeFilmQuery
    {
        public GeFilmQuery(FilmContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Use case for searching films";

        public string Description => "Use case for searching films";

        public PagedResponse<ExtendendFilmDto> Execute(BasePagedSearch request)
        {
            var query = Context.Films.Include(x => x.Author).Include(x => x.CategoryFilms).ThenInclude(x => x.Category).AsQueryable();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword) || x.Author.Name.Contains(request.Keyword) || x.Description.Contains(request.Keyword));
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
            var response = new PagedResponse<ExtendendFilmDto>
            {
                TotalCount = query.Count(),
                CurrentPage = request.Page.Value,
                ItemsPerPage = request.PerPage.Value,
                Data = query.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new ExtendendFilmDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Author = x.Author.Name,
                    Description = x.Description,

                    Price = x.Price,
                    Duration = x.Duration,
                    Language = x.Language,
                    Category = x.CategoryFilms.Select(y => new CategoryDto
                    {
                        Id = y.Category.Id,
                        Name = y.Category.Name,
                        ParentId = y.Category.ParentId
                    })
                }).ToList()
            };
            return response;

        }
    }
}
