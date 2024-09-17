using BookMyHome.Application;
using BookMyHome.Application.Command;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.Queries;
using BookMyHome.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMyHome.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookingQuery, BookingQuery>();

        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IAccommodationRepository, AccommodationRepository>();
        services.AddScoped<IHostRepository, HostRepository>();

        // Add-Migration InitialMigration -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
        // Update-Database -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration

        services.AddDbContext<BookMyHomeContext>(options => 
            options.UseSqlServer(
                configuration.GetConnectionString("BookMyHomeDbConnection"),
            x => x.MigrationsAssembly("BookMyHome.DatabaseMigration")));


        services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
        {
            var db = p.GetService<BookMyHomeContext>();
            return new UnitOfWork(db);
        });

        return services;
    }
}