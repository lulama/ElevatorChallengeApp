using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Commands.Update
{  

    namespace ElevatorChallengAPI.Features.Buildings.Commands.Update
    {
        public class UpdateBuildingCommandHandler(AppDbContext context) : IRequestHandler<UpdateBuildingCommand>
        {
            public async Task Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
            {
                var building = await context.Buildings.FindAsync(request.Id);
                if (building == null) return;
                building.Name = request.Name;
                building.Address = request.Address;
                building.Elevators = request.Elevators;
                building.Status = request.Status;
                await context.SaveChangesAsync();
            }

        }
    }
}
