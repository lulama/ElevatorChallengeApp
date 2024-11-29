using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Features.Elevators.Dtos;

namespace ElevatorChallengAPI.Features.Buildings.Dtos
{
    public record BuildingDto(Guid Id, string Name, string Address, Status Status, List<ElevatorDto> Elevators);

}
