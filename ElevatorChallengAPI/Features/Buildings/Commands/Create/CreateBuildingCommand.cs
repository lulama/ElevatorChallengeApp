using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Features.Buildings.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Commands.Create
{
    public record CreateBuildingCommand(string Name, string Address, List<Elevator> Elevators) : IRequest<Guid>;
    
}
