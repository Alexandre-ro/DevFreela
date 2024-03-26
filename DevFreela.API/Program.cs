using DevFreela.API.Models;
using DevFreela.Application.Commands.Comment.CreateComment;
using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Application.Commands.Projects.DeleteProjet;
using DevFreela.Application.Commands.Projects.UpdateProject;
using DevFreela.Application.Commands.Skills;
using DevFreela.Application.Queries.Projects.GetProjectById;
using DevFreela.Application.Queries.Skills.GetById;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Validators;
using DevFreela.Core.Repositories;
using DevFreela.CORE.Repositories;
using DevFreela.CORE.Services;
using DevFreela.Infrastructure.AuthService;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace DevFreela.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
           
            builder.Services.AddSwaggerGen(c => {
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name            = "Authorization",
                    Type            = SecuritySchemeType.ApiKey,
                    Scheme          = "Bearer",
                    BearerFormat    = "JWT",
                    In              = ParameterLocation.Header,
                    Description     = "JWT Authorization header usando o esquema Bearer."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}
                     }
                 });

            });
            
            builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

            var ConnectionString = builder.Configuration.GetConnectionString("DevFreelaCs");

            builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(ConnectionString));

            //Banco de dados em memória temporária para testes
            //builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("devfreela"));

            //Services
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IUserService, UserService>();
            //builder.Services.AddScoped<IUserService, UserService>();

            //Mediator
            builder.Services.AddMediatR(typeof(CreateProjectCommand));
            builder.Services.AddMediatR(typeof(CreateCommentCommand));
            builder.Services.AddMediatR(typeof(DeleteProjectCommand));
            builder.Services.AddMediatR(typeof(UpdateProjectCommand));
            builder.Services.AddMediatR(typeof(GetSkillByIdQuery));
            builder.Services.AddMediatR(typeof(CreateSkillCommand));
            builder.Services.AddMediatR(typeof(GetProjectByIdQuery));

            //Repositories
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //Validator
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProjectValidator>();

            //AuthService
            builder.Services.AddScoped<IAuthService, AuthService>();

            //Autenticação
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,

                                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                    ValidAudience = builder.Configuration["Jwt:Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                                };
                            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();


            app.MapControllers();

            app.Run();
        }
    }
}