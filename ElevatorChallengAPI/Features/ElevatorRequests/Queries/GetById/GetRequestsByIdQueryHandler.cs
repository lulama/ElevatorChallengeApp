using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.ElevatorRequests.Dtos;
using ElevatorChallengAPI.Features.ElevatorRequests.Queries.GetById;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Queries.GetByName
{
    public class GetRequestsByIdQueryHandler(AppDbContext context): IRequestHandler<GetRequestsByIdQuery, ElevatorRequestDto>
    {
        public async Task<ElevatorRequestDto> Handle(GetRequestsByIdQuery request, CancellationToken cancellationToken)
        {
            var elevatorRequest = await context.ElevatorRequests.FindAsync(request.Id);
            if (elevatorRequest == null)
            {
                return null;
            }
            return new ElevatorRequestDto(Guid .NewGuid(), elevatorRequest.ElevatorId, elevatorRequest.Floor);
        }
    }
}
