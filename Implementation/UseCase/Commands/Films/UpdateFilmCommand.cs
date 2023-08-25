using Application.Dto;
using Application.Exceptions;
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
    public class UpdateFilmCommand : EFUseCaseConnection, IUpdateFilmCommand
    {
        private readonly UpdateFilmValidator _validator;
        public UpdateFilmCommand(FilmContext context, UpdateFilmValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Command for updating film.";

        public string Description => "Command for updating film.";

        public void Execute(UpdateFilmDto request)
        {
            _validator.ValidateAndThrow(request);

            var film = Context.Films.SingleOrDefault(x => x.Id == request.Id && x.isActive);
            if (film == null)
            {
                throw new EntityNotFoundException(nameof(Film), (int)request.Id);
            }
            if (!string.IsNullOrEmpty(request.PathName))
            {
                var image = Context.FilmImages.FirstOrDefault(x => x.FilmId == request.Id);
                if (image == null)
                {
                    var filmImg = new FilmImage
                    {
                        CreatedAt = DateTime.Now,
                        ContentType = request.File.ContentType,
                        FilmId = film.Id,
                        Path = request.PathName
                    };
                    Context.FilmImages.Add(filmImg);
                }
                else
                {
                    image.ContentType = request.File.ContentType;
                    image.Path = request.PathName;
                    image.UpdatedAt = DateTime.Now;
                }
               
            }
            film.Name = request.Name;
            film.Language = request.Language;
            film.Description = request.Description;
            film.Price = request.Price;
            film.Duration = request.Duration;
            film.AuthorId = request.AuthorId;
            film.UpdatedAt = DateTime.Now;

            var filmCategories = Context.FilmCategories.Where(x => x.FilmId == film.Id);
            Context.FilmCategories.RemoveRange(filmCategories);
            film.CategoryFilms = request.FilmCategoryIds.Select(x => new CategoryFilm
            {
                FilmId = (int)request.Id,
                CategoryId = x
            }).ToList();
            Context.SaveChanges();
        }
    }
}
