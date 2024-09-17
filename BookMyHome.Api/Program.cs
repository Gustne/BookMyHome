using BookMyHome.Application;
using BookMyHome.Application.Command;
using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Application.Queries;
using BookMyHome.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// User story: As a Host I want to create, update and delete my Accommodation
app.MapPost("/Accommodation", (CreateAccommodationDto accommodation, IAccommodationCommand command) => command.CreateAccommodation(accommodation));
app.MapPut("/Accommodation", (UpdateAccommodationDto accommodation, IAccommodationCommand command) => command.UpdateAccommodation(accommodation));
app.MapDelete("/accommodation", ([FromBody] DeleteAccommodtationDto accommodation, IAccommodationCommand command) => command.DeleteAccommodation(accommodation));

//User story: As a Host I want to see a list of bookings for each of my Accommodation
app.MapGet("/Bookings/{hostId}", (int hostId, IBookingQuery query) => query.GetBookings(hostId));


app.MapGet("/booking/", (int id, IBookingQuery query) => query.GetBooking(id));
app.MapPost("/booking", (CreateBookingDto booking, IBookingCommand command) => command.CreateBooking(booking));
app.MapPut("/booking", (UpdateBookingDto booking, IBookingCommand command) => command.UpdateBooking(booking));
app.MapDelete("/Booking", ([FromBody] DeleteBookingDto booking, IBookingCommand command) => command.DeleteBooking(booking));










app.Run();
