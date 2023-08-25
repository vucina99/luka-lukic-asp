using Application.Dto;
using Application.UseCase.Commands.Authors;
using DataAccess.DAL;
using FluentValidation;
using Implementation.Validators.Author;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands.Authors
{
    public class UpdateAuthorsCommand : EFUseCaseConnection, IUpdateAuthorsCommand
    {
        private readonly UpdateAuthorValidator _validator;
        public UpdateAuthorsCommand(FilmContext context, UpdateAuthorValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Use case for updating a author.";

        public string Description => "Use case for updating a author.";

        public void Execute(AuthorsDto request)
        {
            _validator.ValidateAndThrow(request);
            var author = Context.Authors.FirstOrDefault(x => x.Id == request.Id);
            author.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
