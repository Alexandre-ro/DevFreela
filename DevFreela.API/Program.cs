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
using DevFreela.Core.Repositories;
using DevFreela.CORE.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

            var ConnectionString = builder.Configuration.GetConnectionString("DevFreelaCs");

            builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(ConnectionString));
            
            //Banco de dados em memória temporária para testes
            //builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("devfreela"));

            //Services
            builder.Services.AddScoped<IProjectService, ProjectService>(); 
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserService, UserService>();

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}