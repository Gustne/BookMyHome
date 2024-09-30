using BookMyHome.Application.Command;
using Microsoft.Extensions.DependencyInjection;

namespace BookMyHome.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookingCommand, BookingCommand>();
        services.AddScoped<IAccommodationCommand, AccommodationCommand>();
        services.AddScoped<IRatingCommand, RatingCommand>();
        services.AddScoped<IReviewCommand, ReviewCommand>();

        return services;
    }
}