﻿using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Queries
{
    public interface IFindCategoryQuery : IQuery<int, FindCategoryDto>
    {
    }
}
