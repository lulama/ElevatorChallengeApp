using ElevatorChallengAPI.Features.Buildings.Commands.Create;
using ElevatorChallengAPI.Features.Buildings.Commands.Delete;
using ElevatorChallengAPI.Features.Buildings.Commands.Update;
using ElevatorChallengAPI.Features.Buildings.Queries.GetByName;
using ElevatorChallengAPI.Features.Buildings.Queries.List;
using ElevatorChallengAPI.Features.ElevatorRequests.Commands.Create;
using ElevatorChallengAPI.Features.ElevatorRequests.Commands.Exit;
using ElevatorChallengAPI.Features.ElevatorRequests.Queries.List;
using ElevatorChallengAPI.Features.Elevators.Commands.Create;
using ElevatorChallengAPI.Features.Elevators.Queries.List;
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
    var buildings = await mediatr.Send(new ListBuildingsQuery());
    return Results.Ok(buildings);
});

app.MapPost("/buildings", async (CreateBuildingCommand command, ISender mediatr) =>
{
    var buildingId = await mediatr.Send(command);
    if (Guid.Empty == buildingId) return Results.BadRequest();
    return Results.Created($"/buildings/{buildingId}", new { id = buildingId });
});

app.MapDelete("/buildings/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteBuildingCommand(id));
    return Results.NoContent();
});

app.MapPut("/buildings/{id:guid}", async (Guid id,string name, UpdateBuildingCommand command, ISender mediatr) =>
{
    var building = await mediatr.Send(new GetBuildingByIdQuery(id));
    await mediatr.Send(command);
    return Results.Ok(building);
});

#region Elevator
app.MapPost("/elevators", async (CreateElevatorCommand command, ISender mediatr) =>
{
    var elevatorId = await mediatr.Send(command);
    if (Guid.Empty == elevatorId) return Results.BadRequest();
    return Results.Created($"/elevators/{elevatorId}", new { id = elevatorId });
});
app.MapGet("/elevators", async (ISender mediatr) =>
{
    var elevators = await mediatr.Send(new ListElevatorsQuery());
    return Results.Ok(elevators);
});
#endregion

#region ElevatorReuests
app.MapPost("/elevatorsrequests", async (RequestElevatorCommand command, ISender mediatr) =>
{
    var elevatorRequestId = await mediatr.Send(command);
    if (Guid.Empty == elevatorRequestId) return Results.BadRequest();
    return Results.Created($"/elevatorsrequests/{elevatorRequestId}", new { id = elevatorRequestId });
});

app.MapPut("/elevatorsrequests", async (ExitElevatorCommand command, ISender mediatr) =>
{
    var elevatorId = await mediatr.Send(command);
    if (Guid.Empty == elevatorId) return Results.BadRequest();
    return Results.Created($"/elevatorsrequests/{elevatorId}", new { id = elevatorId });
});
app.MapGet("/elevatorsrequests", async (ISender mediatr) =>
{
    var elevatorRequests = await mediatr.Send(new ListElevatorRequestsQuery());
    return Results.Ok(elevatorRequests);
});
#endregion

app.Run();


