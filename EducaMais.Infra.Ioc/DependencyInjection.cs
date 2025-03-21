using EducaMais.Application.Interfaces;
using EducaMais.Application.Mappings;
using EducaMais.Application.Services;
using EducaMais.Domain.Repositories;
using EducaMais.Infra.Context;
using EducaMais.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducaMais.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();

            services.AddAutoMapper(typeof(Mapeamento));

            return services;
        }
    }
}