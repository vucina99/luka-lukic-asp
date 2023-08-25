using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Commands.Authors
{
    public interface IUpdateAuthorsCommand : ICommand<AuthorsDto>
    {
    }
}
