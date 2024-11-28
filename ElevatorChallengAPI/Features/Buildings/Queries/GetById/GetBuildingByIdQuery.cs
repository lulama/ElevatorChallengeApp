using ElevatorChallengAPI.Features.Buildings.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Queries.GetByName
{
    public record GetBuildingByIdQuery(Guid Id) : IRequest<BuildingDto>;


}
