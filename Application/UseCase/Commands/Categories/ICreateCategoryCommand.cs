using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Commands.Categories
{
    public interface ICreateCategoryCommand : ICommand<CategoryDto>
    {
    }
}
