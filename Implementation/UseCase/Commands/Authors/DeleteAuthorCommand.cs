using Application.Exceptions;
using Application.UseCase.Commands.Authors;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands.Authors
{
    public class DeleteAuthorCommand : EFUseCaseConnection, IDeleteAuthorCommand
    {
        public DeleteAuthorCommand(FilmContext context) : base(context)
        {
        }
        public int Id => 6;

        public string Name => "Use case for deleting a author.";

        public string Description => "Use case for deleting a author.";

        public void Execute(int request)
        {
            var author = Context.Authors.Include(x => x.Films).FirstOrDefault(x => x.Id == request  && x.isActive);
            if (author == null)
            {
                throw new EntityNotFoundException(nameof(Author), request);
            }
            if (author.Films.Any())
            {
                throw new UseCaseConflctException("Deleting author is denied because it contains films that reference to it." +
                    string.Join(", ", author.Films.Select(x => x.Name)));
            }
            author.DeletedAt = DateTime.Now;
            author.isActive = false;

            Context.SaveChanges();
        }
    }
}
