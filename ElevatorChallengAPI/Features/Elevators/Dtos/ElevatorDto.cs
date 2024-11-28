using ElevatorChallengAPI.Enums;

namespace ElevatorChallengAPI.Features.Elevators.Dtos
{
    public record ElevatorDto(Guid Id, string Name, Floor CurrentFloor, ElevatorStatus ElevatorStatus, Status Status, Guid BuildingId);
   
}
