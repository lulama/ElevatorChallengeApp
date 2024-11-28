using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Features.Elevators.Commands.Create;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.Elevators.Commands.Create
{
    public class CreateElevatorCommandHandler(AppDbContext context) : IRequestHandler<CreateElevatorCommand, Guid>
    {
        public async Task<Guid> Handle(CreateElevatorCommand request, CancellationToken cancellationToken)
        {
            var elevator = new Elevator(request.Name, request.CurrentFloor,request.Capacity,request.CurrentCapacity, request.Status,request.ElevatorStatus,request.BuildingId);
            context.Elevators.Add(elevator);
            await context.SaveChangesAsync(cancellationToken);
            return elevator.Id;
        }

        
    }
}
