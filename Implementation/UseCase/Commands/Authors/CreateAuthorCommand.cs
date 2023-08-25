using Application.Dto;
using Application.UseCase.Commands.Authors;
using DataAccess.DAL;
using Domain;
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
    public class CreateAuthorCommand : EFUseCaseConnection, ICreateAuthorCommand
    {
        private readonly CreateAuthorValidator _validator;
        public CreateAuthorCommand(FilmContext context, CreateAuthorValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Use case for creating a author.";

        public string Description => "Use case for creating a author.";

        public void Execute(AuthorsDto request)
        {
            _validator.ValidateAndThrow(request);

            var author = new Author
            {
                Name = request.Name

            };
            Context.Add(author);
            Context.SaveChanges();
        }
    }
}
