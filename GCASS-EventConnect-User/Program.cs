using GCASS_EventConnect.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsersDbContext>(
    opts => { 
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
    }, ServiceLifetime.Transient
);

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

#region API Design
//Get a user by Id
app.MapGet("/users/{userId}", async (string userId, UsersDbContext db) =>
{
    var results = await db.Users.Where(user => user.id.ToString() == userId).ToListAsync();

    return Results.Ok(results);
});

//Create a user
app.MapPost("/user", async (User user, UsersDbContext db) =>
{
    user.createdTime = user.createdTime.ToUniversalTime();
    await db.AddAsync(user);
    await db.SaveChangesAsync();
});

#endregion


app.Run();

