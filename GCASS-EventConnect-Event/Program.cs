using GCASS_EventConnect_Event.DAL;
using GCASS_EventConnect_Event.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<EventDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddScoped<IEventRepository, EventRepository>();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

