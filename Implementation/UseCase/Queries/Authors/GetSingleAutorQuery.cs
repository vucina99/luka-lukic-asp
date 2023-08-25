using Application.Dto;
using Application.Exceptions;
using Application.UseCase.Queries.Authors;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries.Authors
{
    public class GetSingleAutorQuery : EFUseCaseConnection, IGetSingleAutorQuery
    {
        public GetSingleAutorQuery(FilmContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Use case for finding single authors";

        public string Description => "Use case for finding single authors";

        public AuthorsDto Execute(int request)
        {
            var author = Context.Authors.SingleOrDefault(x => x.Id == request);

            if (author == null)
            {
                throw new EntityNotFoundException(nameof(Author), request);
            }

            return new AuthorsDto
            {
                Id = author.Id,
                Name = author.Name,
            };
        }
    }
}
