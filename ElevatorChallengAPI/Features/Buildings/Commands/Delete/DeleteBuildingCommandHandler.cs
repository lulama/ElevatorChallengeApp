using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Commands.Delete
{
    public class DeleteBuildingCommandHandler(AppDbContext context) : IRequestHandler<DeleteBuildingCommand>
    {
        public async Task Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await context.Buildings.FindAsync(request.Id);
            if (building == null) return;                 
            building.Status = Status.Deleted;
            await context.SaveChangesAsync();
           
        }
        
    }
}
