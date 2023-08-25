using Application.Dto;
using Application.UseCase.Commands;
using DataAccess.DAL;
using Domain;
using FluentValidation;
using Implementation.Validators.User;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands
{
    public class RegisteUserCommand : EFUseCaseConnection, IRegisterUserCommand
    {
        private RegisterUserValidator _validator;
        public RegisteUserCommand(FilmContext context, RegisterUserValidator validator) : base(context)
        {
            _validator = validator;
        }
        
        public int Id => 1;

        public string Name => "Use case for registering a user.";

        public string Description => "Use case for registering a user with EF.";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };
            Context.Users.Add(user);
            Context.SaveChanges();

        }
    }
}
