using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Features.Elevators.Queries.List;
using ElevatorChallengAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
namespace ElevatorChallengAPI.Features.Buildings.Queries.List
{
    public class ListElevatorsQueryHandler(AppDbContext context) : IRequestHandler<ListElevatorsQuery, List<ElevatorDto>>
    {
        public async Task<List<ElevatorDto>> Handle(ListElevatorsQuery request, CancellationToken cancellationToken)
        {
            return await context.Elevators
                .Select(e => new ElevatorDto(e.Id, e.Name,e.CurrentFloor,e.ElevatorStatus,e.Status,e.BuildingId))
               .ToListAsync(cancellationToken);
              
               
        }
    }
}