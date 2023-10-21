using GCASS_EventConnect_Event;
using GCASS_EventConnect_Event.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.Services.AddDbContext<Event>(opts =>
{
    opts.EnableSensitiveDataLogging();
    opts.EnableDetailedErrors();
    opts.UseNpgsql(builder.Configuration.GetConnectionString("EventDb"));
}, ServiceLifetime.Transient
);
app.MapGet("", ([FromQuery] string? eventName , EventDbContext eventDb) => {
    if (eventName == null)
    {
        return Results.BadRequest("Please provide a valid Event Name");
    }
    var results = eventDb.Event.Where( currentEvent => currentEvent.Title == eventName && currentEvent.Status==1).ToListAsync();
    return Results.Ok(results);
});

app.Run();

