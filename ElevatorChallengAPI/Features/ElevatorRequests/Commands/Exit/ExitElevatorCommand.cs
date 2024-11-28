using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Features.Buildings.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Commands.Exit
{
    public record ExitElevatorCommand(Guid ElevatorId, int PersonId, Floor Floor) : IRequest<Guid>;
    
}
