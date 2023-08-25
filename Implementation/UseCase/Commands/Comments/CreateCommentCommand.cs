using Application.Dto;
using Application.Exceptions;
using Application.UseCase.Commands.Comments;
using Application;
using Domain;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAL;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.UseCase.Commands.Comments
{
    public class CreateCommentCommand : EFUseCaseConnection, ICreateCommentCommand
    {
        private IApplicationUser _user;
        private CreateCommentValidator _validator;
        public CreateCommentCommand(FilmContext context, IApplicationUser user, CreateCommentValidator validator) : base(context)
        {
            _user = user;
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Use case for creating comment";

        public string Description => "Use case for creating comment.";
        public void Execute(CommentDto request)
        {
            _validator.ValidateAndThrow(request);
            if (_user.Id != request.UserId)
            {
                throw new ForbbidenUseCaseException(Name, _user.Email);
            }
            var comment = new Comment
            {
                Message = request.Comment,
                FilmId = request.FilmId,
                UserId = request.UserId,
                isActive = true,
                
            };
            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
    }
}
