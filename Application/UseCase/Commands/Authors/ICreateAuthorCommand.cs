using Application.Dto;
using Application.UseCase.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Commands.Authors
{
    public interface ICreateAuthorCommand : ICommand<AuthorsDto>
    {
    }
}
