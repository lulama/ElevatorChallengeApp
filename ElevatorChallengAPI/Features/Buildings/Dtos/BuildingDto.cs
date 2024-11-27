using ElevatorChallengAPI.Features.Elevators.Dtos;

namespace ElevatorChallengAPI.Features.Buildings.Dtos
{
    public record BuildingDto(Guid Id, string Name, string Address, List<ElevatorDto> Elevators);
    
}
