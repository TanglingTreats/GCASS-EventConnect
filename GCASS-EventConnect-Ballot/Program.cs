using GCASS_EventConnect_Ballot;
using GCASS_EventConnect_Ballot.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI services
builder.Services.AddDbContext<BallotDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddScoped<IBallotRepository, BallotRepository>();

builder.Services.AddScoped<IBallotService, BallotService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

