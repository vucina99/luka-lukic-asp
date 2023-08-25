using Application.Dto;
using Application.Exceptions;
using Application.UseCase.Queries;
using DataAccess.DAL;
using Domain;
using Implementations.UseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries
{
   

    public class FindCategoryQuery : EFUseCaseConnection, IFindCategoryQuery
    {
        public FindCategoryQuery(FilmContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Use case for finding a category";

        public string Description => "Use case for finding a category.";

        public FindCategoryDto Execute(int request)
        {
            var category = Context.Categories.Include(x => x.SubCategories).Include(x => x.CategoryFilms).ThenInclude(x => x.Film).FirstOrDefault(c => c.Id == request);
            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }
            return new FindCategoryDto
            {
                Name = category.Name,
                ParentId = category.ParentId,
                Films = category.CategoryFilms.Select(y => new FilmDto
                {
                    Name = y.Film.Name,
                    Price = y.Film.Price,
                }),
                ChildCategories = category.SubCategories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                }).ToList(),

            };
        }
    }
}
