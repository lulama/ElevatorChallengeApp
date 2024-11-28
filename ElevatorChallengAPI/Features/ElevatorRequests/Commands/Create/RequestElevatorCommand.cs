using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Features.Buildings.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Commands.Create
{
    public record RequestElevatorCommand(Guid Id, Guid ElevatorId, int PersonId, Floor Floor) : IRequest<Guid>;
    
}
