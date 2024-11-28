using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Features.Buildings.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.Elevators.Commands.Create
{
    public record CreateElevatorCommand(string Name,Floor CurrentFloor, int Capacity, int CurrentCapacity, Status Status, ElevatorStatus ElevatorStatus, Guid BuildingId) : IRequest<Guid>;
    
}
