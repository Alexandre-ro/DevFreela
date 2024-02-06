using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
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

            builder.Services.AddScoped<IProjectService, ProjectService>(); 
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddMediatR(typeof(CreateProjectCommand));

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