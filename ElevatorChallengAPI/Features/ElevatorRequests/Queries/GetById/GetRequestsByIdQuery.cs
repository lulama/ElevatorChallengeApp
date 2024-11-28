using ElevatorChallengAPI.Features.ElevatorRequests.Dtos;
using MediatR;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Queries.GetById
{
    public record GetRequestsByIdQuery(Guid Id) : IRequest<ElevatorRequestDto>;


}
