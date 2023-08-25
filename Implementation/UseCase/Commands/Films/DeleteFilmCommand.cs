using Application.Exceptions;
using Application.UseCase.Commands.Films;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands.Films
{
    public class DeleteFilmCommand : EFUseCaseConnection, IDeleteFilmCommand
    {
        public DeleteFilmCommand(FilmContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Command for deleting film.";

        public string Description => "Command for deleting film.";

        public void Execute(int request)
        {
            var film = Context.Films.Include(x => x.CategoryFilms).Include(x => x.Comments).Include(x => x.FilmImages).FirstOrDefault(x => x.Id == request && x.isActive);
            if (film == null)
            {
                throw new EntityNotFoundException(nameof(Film), request);
            }
            var filmCategories = Context.FilmCategories.Where(x => x.FilmId == request);
            var filmPublishers = Context.FilmImages.Where(x => x.FilmId == request);
            var filmComments = Context.Comments.Where(x => x.FilmId == request);
            Context.RemoveRange(filmCategories);
            Context.RemoveRange(filmPublishers);
            Context.RemoveRange(filmComments);
            film.isActive = false;
            film.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
