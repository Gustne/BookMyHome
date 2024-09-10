using BookMyHome.Domain.DomainServices;
using System.Runtime.CompilerServices;

namespace BookMyHome.Domain.Enitity;


public class Booking : DomainEntity
{
    public int Id { get; protected set; }
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }


    protected Booking(){}

    private Booking(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        StartDate = startDate;
        EndDate = endDate;

<<<<<<< Updated upstream:BookMyHome.Domain/Enitity/Booking.cs
=======
        ValidateBooking(bookingDomainService);

    }
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }

    protected void ValidateBooking(IBookingDomainService bookingDomainService)
    {
>>>>>>> Stashed changes:BookMyHome.Domain/Entity/Booking.cs
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
<<<<<<< Updated upstream:BookMyHome.Domain/Enitity/Booking.cs
=======

    public void Update(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        StartDate = startDate;
        EndDate = endDate;

        ValidateBooking(bookingDomainService);
    }

>>>>>>> Stashed changes:BookMyHome.Domain/Entity/Booking.cs
}