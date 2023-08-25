using Application.Dto;
using Application.UseCase.Commands;
using DataAccess.DAL;
using Domain;
using Implementation.Validators.User;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands
{
    public class UpdateUserUseCases : EFUseCaseConnection, IUpdateUserUseCasesCommand
    {
        private UpdateUserUseCaseValidator _validator;
        public UpdateUserUseCases(FilmContext context, UpdateUserUseCaseValidator validator)
            : base(context)
        {
            _validator = validator;
        }
        public int Id => 2;

        public string Name => "Use case for registering a user.";

        public string Description => "Use case for registering a user with EF.";

        public void Execute(UpdateUserUseCaseDto request)
        {
            var userUseCases = Context.UserUseCases.Where(x => x.UserId == request.UserId);
            Context.UserUseCases.RemoveRange(userUseCases);
            var newUserUseCases = request.UseCaseIds.Select(x => new UserUseCase
            {
                UserId = request.UserId,
                UseCaseId = x
            });
            Context.UserUseCases.AddRange(newUserUseCases);
            Context.SaveChanges();
        }
    }
}
