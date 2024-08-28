using BookMyHome.Domain.Enitity;

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
        // Act + Assert
        Booking.AssureBookingIsInTheFuture(startDate, nowDate);

    }

    [Theory]
    [InlineData("2023-07-01", "2023-08-01")] // Start er før nu
    [InlineData("2023-08-01", "2023-08-02")] // Start dagen før

    public void Given_StartDate_in_the_past__then_exception(string start, string now)
    {
        // Arrange
        var startDate = DateOnly.Parse(start);
        var nowDate = DateOnly.Parse(now);
        // Act + Assert
        Assert.Throws<ArgumentException>(() => Booking.AssureBookingIsInTheFuture(startDate, nowDate));

    }

    [Theory]
    [InlineData("2023-08-01", "2023-08-10", true)] // Start langt før
    [InlineData("2023-08-01", "2023-08-2", true)]  // Start Dagen før
    public void Given_EndDate_is_After_Start_Date__No_Exception(string start, string end, bool expectedResult)
    {
        // Arrange
        var startDate = DateOnly.Parse(start);
        var endDate = DateOnly.Parse(end);


        //act + Assert
        Booking.AssureStartDateBeforeEndDate(startDate,endDate);

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

        //act + Assert
        Assert.Throws<ArgumentException>(() => Booking.AssureStartDateBeforeEndDate(startDate, endDate));
    }
}