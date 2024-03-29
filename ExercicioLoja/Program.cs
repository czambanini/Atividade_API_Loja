
using ExercicioLoja.Filters;
using ExercicioLoja.Repository;
using ExercicioLoja.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ExercicioLoja
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<FiltroExcecao>();
                options.Filters.Add<FiltroLogAcoes>();
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IEstoque, Estoque>();
            builder.Services.AddSingleton<IOperacoesRepository, OperacoesRepository>();
            builder.Services.AddSingleton<IOperacoesService, OperacoesService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(policyBuilder =>
            {
                policyBuilder.WithOrigins("http://localhost:55");
            }); 

            app.MapControllers();

            app.Run();
        }
    }
}
