using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Enitity;
using BookMyHome.Domain.Test.Fakes;

namespace BookMyHome.Domain.Test;

public class CheckBookingTest
{
    [Theory]
    [InlineData("2023-07-10", "2023-07-15")] // Interval er før
    [InlineData("2023-07-01", "2023-08-1")] // Interval er lige før
    [InlineData("2023-08-11", "2023-08-15")] // interval er lige efter
    [InlineData("2023-08-15", "2023-08-25")] // interval er efter
    public void Given_Booking_dont_overlap__No_Exception(string start, string end)
    {
        //arrange
        var booking = new FakeBooking(DateOnly.Parse(start), DateOnly.Parse(end));
        List<FakeBooking> otherBookings = new List<FakeBooking>();
        otherBookings.Add(new FakeBooking(
            new DateOnly(2023, 08, 2), 
            new DateOnly(2023, 08, 10)
        ));
        //act
        var checkBooking = new CheckBooking();

        // Assert
        checkBooking.AssureBookingIsNotOverlapping(booking, otherBookings);
    }

    [Theory]
    [InlineData("2023-07-01", "2023-08-2")] // Interval slutter startdag
    [InlineData("2023-07-10", "2023-08-5")] // Interval slutter i booking
    [InlineData("2023-08-04", "2023-08-7")] // interval er midt i anden bookning
    [InlineData("2023-08-7", "2023-08-25")] // interval starter i bookning
    [InlineData("2023-08-10", "2023-08-15")] // interval starter på slutdag
    public void Given_Booking_overlap__Cast_Exception(string start, string end)
    {
        //arrange
        var booking = new FakeBooking(DateOnly.Parse(start), DateOnly.Parse(end));
        List<FakeBooking> otherBookings = new List<FakeBooking>();
        otherBookings.Add(new FakeBooking(
            new DateOnly(2023, 08, 2),
            new DateOnly(2023, 08, 10)
        ));
        //act
        var checkBooking = new CheckBooking();

        // Assert
        Assert.Throws<ArgumentException>(() => checkBooking.AssureBookingIsNotOverlapping(booking, otherBookings));
    }
}