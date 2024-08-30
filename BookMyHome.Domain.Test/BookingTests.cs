using BookMyHome.Domain.Test.Fakes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace BookMyHome.Domain.Test;

public class BookingTests
{
    [Theory]
    [InlineData("2023-08-10", "2023-08-1")] // Start er efter 
    [InlineData("2023-08-01", "2023-08-1")] // på dagen
    [InlineData("2023-08-02", "2023-08-1")]  // dagen efter
    public void Given_StartDate_in_future__then_no_exception(string start, string now)
    {
        // Arrange
        var startDate = DateOnly.Parse(start);
        var nowDate = DateOnly.Parse(now);
        var sut = new FakeBooking(startDate, nowDate);

        // Act + Assert

        sut.AssureBookingIsInTheFuture(nowDate);

    }

    [Theory]
    [InlineData("2023-07-01", "2023-08-01")] // Start er før nu
    [InlineData("2023-08-01", "2023-08-02")] // Start dagen før

    public void Given_StartDate_in_the_past__then_exception(string start, string now)
    {
        // Arrange
        var startDate = DateOnly.Parse(start);
        var nowDate = DateOnly.Parse(now);
        var sut = new FakeBooking(startDate, nowDate);

        // Act + Assert
        Assert.Throws<ArgumentException>(() => sut.AssureBookingIsInTheFuture(nowDate));

    }

    [Theory]
    [InlineData("2023-08-01", "2023-08-10", true)] // Start langt før
    [InlineData("2023-08-01", "2023-08-2", true)]  // Start Dagen før
    public void Given_EndDate_is_After_Start_Date__No_Exception(string start, string end, bool expectedResult)
    {
        // Arrange
        var startDate = DateOnly.Parse(start);
        var endDate = DateOnly.Parse(end);
        var sut = new FakeBooking(startDate, endDate);

        //act + Assert
        sut.AssureStartDateBeforeEndDate();

    }


    [Theory]
    [InlineData("2023-08-02", "2023-07-10")] // Slut meget før
    [InlineData("2023-08-02", "2023-08-1")] // slut dagen før
    [InlineData("2023-08-02", "2023-08-2")]  // Slut på dagen
    public void Given_EndDate_is_Before_Start_Date__Then_Exception(string start, string end)
    {
        // Arrange
        var startDate = DateOnly.Parse(start);
        var endDate = DateOnly.Parse(end);
        var sut = new FakeBooking(startDate, endDate);

        //act + Assert
        Assert.Throws<ArgumentException>(() => sut.AssureStartDateBeforeEndDate());
    }


    [Theory]
    [InlineData("2023-07-10", "2023-07-15")] // Interval er før
    [InlineData("2023-07-01", "2023-08-1")] // Interval er lige før
    [InlineData("2023-08-11", "2023-08-15")] // interval er lige efter
    [InlineData("2023-08-15", "2023-08-25")] // interval er efter
    public void Given_Booking_dont_overlap__No_Exception(string start, string end)
    {
        //arrange
        var sut = new FakeBooking(DateOnly.Parse(start), DateOnly.Parse(end));
        List<FakeBooking> otherBookings = new List<FakeBooking>();
        otherBookings.Add(new FakeBooking(
            new DateOnly(2023, 08, 2),
            new DateOnly(2023, 08, 10)
        ));
        //act + Assert
        sut.AssureBookingIsNotOverlapping(otherBookings);

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
        var sut = new FakeBooking(DateOnly.Parse(start), DateOnly.Parse(end));
        List<FakeBooking> otherBookings = new List<FakeBooking>();
        otherBookings.Add(new FakeBooking(
            new DateOnly(2023, 08, 2),
            new DateOnly(2023, 08, 10)
        ));
        //act & Assert
        Assert.Throws<ArgumentException>(() => sut.AssureBookingIsNotOverlapping(otherBookings));
    }
}