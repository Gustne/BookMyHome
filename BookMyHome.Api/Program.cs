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


app.MapGet("/Hello", () => "Hello World");
app.MapGet("/Booking", (IBookingQuery query) => query.GetBookings());
app.MapGet("/booking/{id}", (int id, IBookingQuery query) => query.GetBooking(id));
app.MapPost("/booking", (CreateBookingDto booking, IBookingCommand command) => command.CreateBooking(booking));
app.MapPut("/booking", (UpdateBookingDto booking, IBookingCommand command) => command.UpdateBooking(booking));
app.MapDelete("/Delete", ([FromBody] DeleteBookingDto booking, IBookingCommand command) => command.DeleteBooking(booking));


app.Run();
