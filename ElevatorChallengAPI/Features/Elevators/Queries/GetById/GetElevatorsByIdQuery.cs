using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Features.ElevatorRequests.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.Elevators.Queries.GetById
{
    public record GetElevatorsByIdQuery(Guid Id, string Name, Floor CurrentFloor, ElevatorStatus ElevatorStatus, Status Status, Guid BuildingId) : IRequest<ElevatorDto>;


}
