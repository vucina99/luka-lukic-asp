using Application.Exceptions;
using Application.UseCase.Commands.Comments;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands.Comments
{
    public class DeleteCommentCommand : EFUseCaseConnection, IDeleteCommentCommand
    {
        public DeleteCommentCommand(FilmContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Use case for deleting comment on a film.";

        public string Description => "Use case for deleting comment on a film.";

        public void Execute(int request)
        {
            var comment = Context.Comments.FirstOrDefault(x => x.Id == request && x.isActive);
            if (comment == null)
            {
                throw new EntityNotFoundException(nameof(Comment), request);
            }
            Context.Comments.Remove(comment);
            Context.SaveChanges();
        }
    }
}
