using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.Elevators.Queries.List
{
    public record ListElevatorsQuery : IRequest<List<ElevatorDto>>;
   
}
