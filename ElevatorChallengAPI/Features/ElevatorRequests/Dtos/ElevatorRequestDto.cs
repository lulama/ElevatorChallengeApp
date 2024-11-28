using ElevatorChallengAPI.Enums;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Dtos
{
    public record ElevatorRequestDto(Guid Id, Guid ElevatorId, Floor Floor);
   
}
