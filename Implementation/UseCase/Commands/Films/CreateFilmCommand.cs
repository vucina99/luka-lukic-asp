using Application.Dto;
using Application.UseCase.Commands;
using Application.UseCase.Commands.Films;
using DataAccess.DAL;
using Domain;
using FluentValidation;
using Implementation.Validators.Film;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands.Films
{


    public class CreateFilmCommand : EFUseCaseConnection, ICreateFilmCommand
    {
        private CreateFilmValidator _validator;
        public CreateFilmCommand(FilmContext context, CreateFilmValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Use case for creating a film.";

        public string Description => "Use case for creating a film .";

        public void Execute(CreateFilmApiDto request)
        {
            _validator.ValidateAndThrow(request);
            var film = new Film();

            film.Name = request.Name;
            film.Duration = request.Duration;
            film.Price = request.Price;
            film.Language = request.Language;
            film.Description = request.Description;
            film.AuthorId = request.AuthorId;
            film.CategoryFilms = request.FilmCategoryIds.Select(x => new CategoryFilm
            {
                Film = film,
                CategoryId = x
            }).ToList();

            if (!string.IsNullOrEmpty(request.PathName))
            {
                var image = new FilmImage
                {
                    Path = request.PathName,
                    Film = film,
                    ContentType = request.File.ContentType,

                };
                Context.FilmImages.Add(image);
            }
            Context.Films.Add(film);
            Context.SaveChanges();
        }
    }
}
