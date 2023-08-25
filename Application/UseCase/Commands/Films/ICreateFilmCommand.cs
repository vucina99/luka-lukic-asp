using Application.Dto;
using Application.UseCase.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Commands.Films
{

    public interface ICreateFilmCommand : ICommand<CreateFilmApiDto>
    {
    }
}
