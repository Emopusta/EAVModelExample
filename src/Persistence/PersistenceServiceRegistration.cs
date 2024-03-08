using Core.Application.GenericRepository;
using Core.Persistence.UoW;
using DataAccess.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<EAVContext>(options => 
            options.UseNpgsql(
                configuration.GetConnectionString("EAVDb")));

        services.AddScoped<IUnitOfWork, UnitOfWork<EAVContext>>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
    
}
