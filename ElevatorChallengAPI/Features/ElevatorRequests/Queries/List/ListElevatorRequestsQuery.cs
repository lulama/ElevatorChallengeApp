using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.ElevatorRequests.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Queries.List
{
    public record ListElevatorRequestsQuery : IRequest<List<ElevatorRequestDto>>;
   
}
