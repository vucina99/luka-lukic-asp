using Application.Dto;
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
    public class CreateCategoryCommand : EFUseCaseConnection ,ICreateCategoryCommand
    {
        private CreateCategoryValidator _validator;

        public CreateCategoryCommand(FilmContext context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Command for creating a category.";

        public string Description => "Command for creating a category.";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = new Category
            {
                Name = request.Name,
                ParentId = request.ParentId
            };
            
            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}
