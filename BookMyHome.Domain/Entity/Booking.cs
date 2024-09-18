using System.Runtime.CompilerServices;

namespace BookMyHome.Domain.Enitity;


public class Booking : DomainEntity
{
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }
    
    public Accommodation Accomodation { get; protected set; }

    protected Booking(){}

    private Booking(DateOnly startDate, DateOnly endDate, Accommodation accommodation)
    {
        StartDate = startDate;
        EndDate = endDate;
        Accomodation = accommodation;
        ValidateBooking(accommodation.Bookings);
    }


    private void ValidateBooking(IEnumerable<Booking> otherBookings)
    {
        AssureStartDateBeforeEndDate();
        AssureBookingIsInTheFuture(DateOnly.FromDateTime(DateTime.Now));
        AssureBookingIsNotOverlapping(otherBookings);
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
     
    public static Booking Create(DateOnly startDate, DateOnly endDate, Accommodation accommodation)
    {
        return new Booking(startDate, endDate, accommodation);
    }

    public void Update(DateOnly startDate, DateOnly endDate, Accommodation accommodation)
    {
        // fjerner dens egen booking fra listen fordi den må jo gerne overlappe med sig selv :D
        var otherBookings = accommodation.Bookings.Where(b => b.Id != this.Id);

        StartDate = startDate;
        EndDate = endDate;

        ValidateBooking(otherBookings);
    }
}