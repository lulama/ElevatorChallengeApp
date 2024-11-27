using ElevatorChallengAPI.Features.Buildings.Commands.Create;
using ElevatorChallengAPI.Features.Buildings.Queries.List;
using ElevatorChallengAPI.Persistence;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/buildings", async (ISender mediatr) =>
{
    var products = await mediatr.Send(new ListBuildingsQuery());
    return Results.Ok(products);
});

app.MapPost("/buildings", async (CreateBuildingCommand command, ISender mediatr) =>
{
    var buildingId = await mediatr.Send(command);
    if (Guid.Empty == buildingId) return Results.BadRequest();
    return Results.Created($"/buildings/{buildingId}", new { id = buildingId });
});


app.Run();


