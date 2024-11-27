using ElevatorChallengAPI.Features.Buildings.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Queries.List
{
    public record ListBuildingsQuery : IRequest<List<BuildingDto>>;
   
}
