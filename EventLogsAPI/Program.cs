using EventLogsAPI.Data;
using EventLogsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SQLConnection");
builder.Services.AddDbContext<EventLogsDB>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/eventlogs/", async (EventLogs u, EventLogsDB db) =>
{
    db.EventLogs.Add(u);
    await db.SaveChangesAsync();

    return Results.Created($"/eventlogs/{u.EventId}", u);
});

app.MapGet("/eventlogs/{id:int}", async (int id, EventLogsDB db) =>
{
    return await db.EventLogs.FindAsync(id)
        is EventLogs u
        ? Results.Ok(u)
        : Results.NotFound();
});

app.MapGet("/eventlogs", async (EventLogsDB db) =>
{
    return await db.EventLogs.ToListAsync();
});

app.MapPut("/eventlogs/{id:int}", async (int id, EventLogs u, EventLogsDB db) =>
{
    if (u.EventId != id)
        return Results.BadRequest();

    var eventLogs = await db.EventLogs.FindAsync(id);

    if (eventLogs is null) return Results.NotFound();

    eventLogs.EventDate = u.EventDate;
    eventLogs.Description = u.Description;
    eventLogs.EventType = u.EventType;

    await db.SaveChangesAsync();

    return Results.Ok(eventLogs);
});

app.MapDelete("/eventlogs/{id:int}", async (int id, EventLogsDB db) =>
{
    var eventLogs = await db.EventLogs.FindAsync(id);
    if (eventLogs is not null)
    {
        db.EventLogs.Remove(eventLogs);
        await db.SaveChangesAsync();

        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
