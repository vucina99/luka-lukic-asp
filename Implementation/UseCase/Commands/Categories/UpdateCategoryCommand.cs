using Application.Dto;
using Application.Exceptions;
using Application.UseCase.Commands.Categories;
using DataAccess.DAL;
using Domain;
using FluentValidation;
using Implementation.Validators.Category;
using Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Implementation.UseCase.Commands.Categories
{
    public class UpdateCategoryCommand : EFUseCaseConnection, IUpdateCategoryCommand
    {
        private readonly UpdateCategoryValidator _validator;

        public UpdateCategoryCommand(FilmContext context, UpdateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Command for editing a category";

        public string Description => "Command for editing a category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = Context.Categories.FirstOrDefault(x => x.Id == request.Id && x.isActive);
            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), (int)request.Id);
            }
           
            category.Name = request.Name;
            category.ParentId = request.ParentId;
            Context.SaveChanges();
        }
    }
}
