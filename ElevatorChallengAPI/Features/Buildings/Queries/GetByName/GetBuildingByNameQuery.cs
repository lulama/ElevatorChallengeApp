using ElevatorChallengAPI.Features.Buildings.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Queries.GetByName
{
    public record GetBuildingByNameQuery(string Name) : IRequest<BuildingDto>;


}
