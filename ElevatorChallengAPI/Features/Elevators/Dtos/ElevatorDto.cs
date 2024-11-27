using ElevatorChallengAPI.Enums;

namespace ElevatorChallengAPI.Features.Elevators.Dtos
{
    public record ElevatorDto(int Id, string Name, Floor CurrentFloor, ElevatorStatus Status, int BuildingId);
   
}
