using Application.Dto;
using Application.Exceptions;
using Application.UseCase.Queries.Films;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries.Films
{
    public class FindFilmQuery :  EFUseCaseConnection , IFindFilmQuery
    {
        public FindFilmQuery(FilmContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Usecase for finding single film";

        public string Description => "Usecase for finding single film";

        public ExtendendFilmDto Execute(int request)
        {
            var film = Context.Films.Include(x => x.Author).Include(x => x.CategoryFilms).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == request && x.isActive);
            if (film == null)
            {
                throw new EntityNotFoundException(nameof(Film), request);
            }
            return new ExtendendFilmDto
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                Language = film.Language,
                Duration = film.Duration,
                Price = film.Price,
                Author = film.Author.Name,
                Category = film.CategoryFilms.Select(x => new CategoryDto
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                    ParentId = x.Category.ParentId,
                })

            };
        }
    }
}
