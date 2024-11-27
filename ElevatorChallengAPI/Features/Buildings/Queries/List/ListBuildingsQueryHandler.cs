using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq; // Make sure to include this namespace

namespace ElevatorChallengAPI.Features.Buildings.Queries.List
{
    public class ListBuildingsQueryHandler(AppDbContext context) : IRequestHandler<ListBuildingsQuery, List<BuildingDto>>
    {
        public async Task<List<BuildingDto>> Handle(ListBuildingsQuery request, CancellationToken cancellationToken)
        {
            return await context.Buildings
                .Select(b => new BuildingDto(b.Id, b.Name, b.Address, b.Elevators
                    .Select(e => new ElevatorDto(e.Id, e.Name, e.CurrentFloor, e.Status, e.BuildingId))
                    .ToList() // Materialize the query here
                ))
                .ToListAsync(cancellationToken);
        }
    }
}