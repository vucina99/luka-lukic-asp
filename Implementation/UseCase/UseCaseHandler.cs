﻿using Application;
using Application.Exceptions;
using Application.Logging;
using Application.UseCase;
using Application.UseCase.Commands;
using Application.UseCase.Queries;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;


namespace Implementation.UseCases
{
    public class UseCaseHandler
    {
        private IExceptionLogger _exceptionLogger;
        private IUseCaseLogger _useCaseLogger;
        private IApplicationUser _user;

        public UseCaseHandler(IExceptionLogger logger, IUseCaseLogger useCaseLogger, IApplicationUser user)
        {
            _exceptionLogger = logger;
            _useCaseLogger = useCaseLogger;
            _user = user;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command,TRequest data)
        {
            try
            {
                LogAndAuthorize(command, data);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _exceptionLogger.Log(ex);
                throw;
            }
        }

      

        public TResponse HandleQuery<TRequest,TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                LogAndAuthorize(query, data);
                 var stopwatch = new Stopwatch();
                stopwatch.Start();

                var result = query.Execute(data);
               
                stopwatch.Stop();
                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
                return result;
            }
            catch (Exception ex)
            {
                _exceptionLogger.Log(ex);
                throw;
            }
        }
        private void LogAndAuthorize<TRequest>(IUseCase usecase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(usecase.Id);
            var log = new UseCaseLog
            {
                User = _user.Identity,
                UseCaseName = usecase.Name,
                ExecutionDateTime = DateTime.Now,
                UserId = _user.Id,
                Data = JsonConvert.SerializeObject(data),

                IsAuthorized = isAuthorized

            };
            _useCaseLogger.Log(log);
            if (!log.IsAuthorized)
            {
                throw new ForbbidenUseCaseException(usecase.Name, _user.Email);
            }
        }
    }
}
