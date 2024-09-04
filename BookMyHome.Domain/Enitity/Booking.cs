using BookMyHome.Domain.DomainServices;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BookMyHome.Domain.Enitity;


public class Booking
{

    public Booking()
    {
        
    }

    public Booking(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        StartDate = startDate;
        EndDate = endDate;

        ValidateBooking(bookingDomainService);

    }
    public int Id { get; protected set; }
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }
    [Timestamp]
    public byte[] RowVersion { get; protected set; }

    protected void ValidateBooking(IBookingDomainService bookingDomainService)
    {
        AssureStartDateBeforeEndDate();
        AssureBookingIsInTheFuture(DateOnly.FromDateTime(DateTime.Now));
        AssureBookingIsNotOverlapping(bookingDomainService.GetOtherBookings(this));
    }

    protected void AssureStartDateBeforeEndDate()
    {
        if (!(StartDate < EndDate))
        {
            throw new ArgumentException("StartDato skal være før Slutdato");
        }
    }
    protected void AssureBookingIsInTheFuture(DateOnly now)
    {
        if (StartDate < now)
        {
            throw new ArgumentException("Booking skal være i fremtiden");
        }
    }

    protected void AssureBookingIsNotOverlapping(IEnumerable<Booking> otherBookings)
    {
        foreach (var otherBooking in otherBookings)
        {
            if (this.StartDate <= otherBooking.EndDate && otherBooking.StartDate <= this.EndDate) // Der er mange senarier men dette dobbeltsenarie skal være gældende for overlap
            {
                throw new ArgumentException("Booking Overlapper med en eksisterende Booking");
            }
        }
    }
     
    public static Booking Create(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        return new Booking(startDate, endDate, bookingDomainService);
    }

    public void Update(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        StartDate = startDate;
        EndDate = endDate;

        ValidateBooking(bookingDomainService);
    }
}