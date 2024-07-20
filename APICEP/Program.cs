using APICEP.Integracao;
using APICEP.Integracao.Interfaces;
using APICEP.Integracao.Refit;
using Refit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace APICEP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicione servi�os ao cont�iner.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adicione os servi�os necess�rios
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

            builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

            // Construa o aplicativo
            var app = builder.Build();

            // Configure o pipeline de requisi��o HTTP
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
