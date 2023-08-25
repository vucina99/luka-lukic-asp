using Application.Logging;
using Application.UseCase.Queries.Users;
using FluentValidation;
using Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCase.Queries.Users
{
    public class GetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly CreateUseCaseLogSearchValidator _validator;
        private readonly IUseCaseLogger _logger;

        public GetUseCaseLogsQuery(IUseCaseLogger logger, CreateUseCaseLogSearchValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public int Id => 20;

        public string Name => "Use case for searching a use case logs";

        public string Description => "Use case for searching a use case logs with EF";

        public IEnumerable<UseCaseLog> Execute(UseCaseLogSearch request)
        {
            _validator.ValidateAndThrow(request);
            return _logger.GetLogs(request);
        }
    }
}
