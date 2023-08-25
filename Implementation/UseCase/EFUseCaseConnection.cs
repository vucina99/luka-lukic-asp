using DataAccess;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations.UseCases
{
    public abstract class EFUseCaseConnection
    {
        protected FilmContext Context;

        protected EFUseCaseConnection(FilmContext context)
        {
            Context = context;
        }
    }
}
