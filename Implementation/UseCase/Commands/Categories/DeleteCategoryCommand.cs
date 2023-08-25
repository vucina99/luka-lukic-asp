using Application.Exceptions;
using Application.UseCase.Commands.Categories;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Commands.Categories
{
    public class DeleteCategoryCommand : EFUseCaseConnection ,IDeleteCategoryCommand
    {
        public DeleteCategoryCommand(FilmContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Command for deleting a category";

        public string Description => "Command for deleting a category";

        public void Execute(int request)
        {
            var category = Context.Categories.Include(x => x.CategoryFilms).FirstOrDefault(x => x.Id == request && x.isActive);
            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }
            if (category.CategoryFilms.Any())
            {
                throw new UseCaseConflctException("You can not delete category because it has films related to it.");
            }
            category.isActive = false;
            category.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
