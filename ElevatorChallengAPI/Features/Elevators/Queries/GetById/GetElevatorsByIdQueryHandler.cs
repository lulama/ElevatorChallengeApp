using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Features.Elevators.Queries.GetById;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.Buildings.Queries.GetByName
{
    public class GetElevatorsByIdQueryHandler(AppDbContext context): IRequestHandler<GetElevatorsByIdQuery, ElevatorDto>
    {
        public async Task<ElevatorDto> Handle(GetElevatorsByIdQuery request, CancellationToken cancellationToken)
        {
            var elevator = await context.Elevators.FindAsync(request.Id);
            if (elevator == null)
            {
                return null;
            }
            return new ElevatorDto(request.Id, request.Name,request.Capacity, request.CurrentFloor,request.ElevatorStatus,request.Status, request.BuildingId);
        }
    }
}
