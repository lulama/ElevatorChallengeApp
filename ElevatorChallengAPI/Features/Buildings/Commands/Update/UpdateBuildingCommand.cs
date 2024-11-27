using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Enums;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Commands.Update
{
    public record UpdateBuildingCommand(Guid Id, string Name, string Address, List<Elevator> Elevators, Status Status) : IRequest;
    
}
