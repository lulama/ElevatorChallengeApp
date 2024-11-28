using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Queries.GetByName
{
    public class GetBuildingByNameQueryHandler(AppDbContext context): IRequestHandler<GetBuildingByNameQuery, BuildingDto>
    {
        public async Task<BuildingDto> Handle(GetBuildingByNameQuery request, CancellationToken cancellationToken)
        {
            var building = await context.Buildings.FindAsync(request.Name);
            if (building == null)
            {
                return null;
            }
            return new BuildingDto(building.Id, building.Name, building.Address,building.Status, building.Elevators.Select(request => new ElevatorDto(request.Id, request.Name, request.CurrentFloor, request.ElevatorStatus,request.Status, request.BuildingId)).ToList());
        }
    }
}
