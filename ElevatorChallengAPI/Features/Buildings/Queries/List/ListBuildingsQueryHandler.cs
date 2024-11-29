using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
namespace ElevatorChallengAPI.Features.Buildings.Queries.List
{
    public class ListBuildingsQueryHandler : IRequestHandler<ListBuildingsQuery, List<BuildingDto>>
    {
        private readonly AppDbContext _context;

        public ListBuildingsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BuildingDto>> Handle(ListBuildingsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Buildings
                .Select(b => new BuildingDto(b.Id, b.Name, b.Address, b.Status, b.Elevators
                    .Select(e => new ElevatorDto(e.Id, e.Name,e.Capacity, e.CurrentFloor, e.ElevatorStatus,e.Status, e.BuildingId))
                    .ToList() 
                ))
                .ToListAsync(cancellationToken);
        }
    }
}