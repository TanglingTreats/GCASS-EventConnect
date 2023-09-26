using GCASS_EventConnect_User.BusinessLayer;
using GCASS_EventConnect_User.Config;
using GCASS_EventConnect_User.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddTransient<ITransactionAggregator, TransactionAggregator>();
builder.Services.AddOptions();
builder.Services.Configure<TransactionConfig>(builder.Configuration.GetSection("TransactionConfig"));

builder.Services.AddDbContext<UsersDbContext>(
    opts => {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
    }, ServiceLifetime.Transient
);

builder.Services.AddDbContext<TransactionDbContext>(
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


//Compute transaction by ballotId
app.MapGet("/transaction/{ballotId}", async (string ballotId, ITransactionAggregator transAgg) =>
{
    var trans = await transAgg.BuildTransaction(ballotId);
    return Results.Ok(trans);
});

#endregion


app.Run();
