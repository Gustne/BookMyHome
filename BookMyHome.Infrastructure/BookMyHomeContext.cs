using BookMyHome.Domain.Enitity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure;

public class BookMyHomeContext : DbContext
{
    public BookMyHomeContext(DbContextOptions<BookMyHomeContext> options)
        : base(options)
    {
    }

    public DbSet<Booking> Bookings { get; set; }

}