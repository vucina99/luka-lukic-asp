using Application;
using Application.UseCase.Commands;
using Application.UseCase.Commands.Authors;
using Application.UseCase.Commands.Categories;
using Application.UseCase.Commands.Comments;
using Application.UseCase.Commands.Films;
using Application.UseCase.Commands.Orders;
using Application.UseCase.Queries;
using Application.UseCase.Queries.Authors;
using Application.UseCase.Queries.Comments;
using Application.UseCase.Queries.Films;
using Application.UseCase.Queries.Orders;
using Application.UseCase.Queries.Users;
using DataAccess.DAL;
using Implementation.UseCase.Commands;
using Implementation.UseCase.Commands.Authors;
using Implementation.UseCase.Commands.Categories;
using Implementation.UseCase.Commands.Comments;
using Implementation.UseCase.Commands.Films;
using Implementation.UseCase.Commands.Orders;
using Implementation.UseCase.Queries;
using Implementation.UseCase.Queries.Authors;
using Implementation.UseCase.Queries.Comments;
using Implementation.UseCase.Queries.Films;
using Implementation.UseCase.Queries.Orders;
using Implementation.UseCase.Queries.Users;
using Implementation.Validators;
using Implementation.Validators.Author;
using Implementation.Validators.Category;
using Implementation.Validators.Film;
using Implementation.Validators.Order;
using Implementation.Validators.User;
using Implementations.UseCases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Presentation.PL.Auth;
using Presentation.PL.Auth.Auth;
using System.Text;

namespace Presentation.PL.Extensions
{
    public static class ConteinerExtension
    {
        public static void AddJwt(this IServiceCollection collection, JwtSettings settings)
        {
            collection.AddTransient(x =>
            {
                var context = x.GetService<FilmContext>();
                var jwtSettings = x.GetService<JwtSettings>();

                return new JwtManager(context, settings);
            });

            collection.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
        public static void AddUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var request = x.GetService<IHttpContextAccessor>();
                //var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = request.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymousUser();
                }

                var user = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return user;
            });
        }

        public static void AddUseCases(this IServiceCollection collection)
        {
            collection.AddTransient<IRegisterUserCommand, RegisteUserCommand>();
            collection.AddTransient<IUpdateUserUseCasesCommand, UpdateUserUseCases>();
            collection.AddTransient<IGetUseCaseLogsQuery, GetUseCaseLogsQuery>();
            //Categories
            collection.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
            collection.AddTransient<IFindCategoryQuery, FindCategoryQuery>();
            collection.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            collection.AddTransient<IUpdateCategoryCommand, UpdateCategoryCommand>();
            collection.AddTransient<IDeleteCategoryCommand, DeleteCategoryCommand>();
            //Films
            collection.AddTransient<ICreateFilmCommand, CreateFilmCommand>(); 
            collection.AddTransient<IGeFilmQuery, GeFilmQuery>();
            collection.AddTransient<IFindFilmQuery, FindFilmQuery>();
            collection.AddTransient<IDeleteFilmCommand, DeleteFilmCommand>();
            collection.AddTransient<IUpdateFilmCommand, UpdateFilmCommand>();

            //Authors
            collection.AddTransient<IGetAuthorsQuery, GetAuthorsQuery>();
            collection.AddTransient<IGetSingleAutorQuery, GetSingleAutorQuery>();
            collection.AddTransient<ICreateAuthorCommand, CreateAuthorCommand>();
            collection.AddTransient<IUpdateAuthorsCommand, UpdateAuthorsCommand>();
            collection.AddTransient<IDeleteAuthorCommand, DeleteAuthorCommand>();

            //Orders
            collection.AddTransient<IGetUsersOrderQuery, GetUserOrdersQuery>();
            collection.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
            //Commets
            collection.AddTransient<IFindFilmCommentsQuery, FindFilmCommentsQuery>();
            collection.AddTransient<ICreateCommentCommand, CreateCommentCommand>();
            collection.AddTransient<IDeleteCommentCommand, DeleteCommentCommand>();




        }
        public static void AddValidators(this IServiceCollection collection)
        {
            collection.AddTransient<UpdateFilmValidator>();
            collection.AddTransient<CreateUseCaseLogSearchValidator>();
            collection.AddTransient<CreateCommentValidator>();
            collection.AddTransient<CreateOrderValidator>();
            collection.AddTransient<OrderLineValidator>();
            collection.AddTransient<CreateAuthorValidator>();
            collection.AddTransient<CreateCategoryValidator>();
            collection.AddTransient<RegisterUserValidator>();
            collection.AddTransient<UpdateAuthorValidator>();
            collection.AddTransient<UpdateCategoryValidator>();
            collection.AddTransient<CreateFilmValidator>();
            collection.AddTransient<UpdateUserUseCaseValidator>();
        }

    }
}
