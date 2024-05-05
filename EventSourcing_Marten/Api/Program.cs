using Api.Endpoints;
using Application.Projections;
using Marten;
using Marten.Events.Daemon.Resiliency;
using Marten.Events.Projections;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMarten(opts =>
{
    var connString = builder.Configuration.GetConnectionString("marten");

    opts.Connection(connString);
    opts.Projections.Add(new CarMaintenanceEventProjection(), ProjectionLifecycle.Inline);
    opts.Projections.Add(new CurrentCarPositionEventProjection(), ProjectionLifecycle.Async);

    // There will be more here later...
})
// Turn on the async daemon in "Solo" mode
.AddAsyncDaemon(DaemonMode.Solo);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};



var events = app.MapGroup("/events");
events.AddEventsEndpoint();

var crud = app.MapGroup("/crud");
crud.AddCrudEndpoint();

app.Run();

