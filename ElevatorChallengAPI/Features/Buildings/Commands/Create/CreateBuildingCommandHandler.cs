using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Commands.Create
{
    public class CreateBuildingCommandHandler(AppDbContext context) : IRequestHandler<CreateBuildingCommand, Guid>
    {
        public async Task<Guid> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = new Building(request.Name, request.Address, request.Status, request.Elevators);
            context.Buildings.Add(building);
            await context.SaveChangesAsync(cancellationToken);
            return building.Id;
        }

        
    }
}
