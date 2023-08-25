using Application.Dto;
using Application.Exceptions;
using Application.UseCase.Queries.Comments;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries.Comments
{
    public class FindFilmCommentsQuery : EFUseCaseConnection, IFindFilmCommentsQuery
    {
        public FindFilmCommentsQuery(FilmContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Use case for fetching all comments for a film.";

        public string Description => "Use case for fetching all comments for a film.";

        public IEnumerable<GetCommentDto> Execute(int request)
        {
            var film = Context.Films.FirstOrDefault(x => x.Id == request);
            if (film == null)
            {
                throw new EntityNotFoundException(nameof(Film), request);
            }
            var comments = Context.Comments.Include(x => x.User).Include(x => x.Film).Where(x => x.FilmId == request && x.isActive);

            var response = comments.Select(x => new GetCommentDto
            {
                Comment = x.Message,
                Date = x.CreatedAt,
                Film = x.Film.Name,
                User = x.User.Email
            });

            return response;


        }
    }
}
