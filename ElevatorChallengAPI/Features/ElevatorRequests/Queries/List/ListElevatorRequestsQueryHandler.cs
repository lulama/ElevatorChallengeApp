using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.ElevatorRequests.Dtos;
using ElevatorChallengAPI.Features.ElevatorRequests.Queries.List;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Features.Elevators.Queries.List;
using ElevatorChallengAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
namespace ElevatorChallengAPI.Features.ElevatorRequests.Queries.List
{
    public class ListElevatorRequestsQueryHandler(AppDbContext context) : IRequestHandler<ListElevatorRequestsQuery, List<ElevatorRequestDto>>
    {
        public async Task<List<ElevatorRequestDto>> Handle(ListElevatorRequestsQuery request, CancellationToken cancellationToken)
        {
           
            return await context.ElevatorRequests
                .Select(e => new ElevatorRequestDto(e.Id,e.ElevatorId,e.Floor))
                
               .ToListAsync(cancellationToken);
              
               
        }
    }
}