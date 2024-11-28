using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Commands.Delete
{
    public record DeleteBuildingCommand(Guid Id) : IRequest;
    
}
