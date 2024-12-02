﻿using ElevatorChallengAPI.Features.Buildings.Dtos;
using ElevatorChallengAPI.Features.Elevators.Dtos;
using ElevatorChallengAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
namespace ElevatorChallengAPI.Features.Buildings.Queries.List
{
    public class ListBuildingsQueryHandler(AppDbContext context) : IRequestHandler<ListBuildingsQuery, List<BuildingDto>>
    {
        public async Task<List<BuildingDto>> Handle(ListBuildingsQuery request, CancellationToken cancellationToken)
        {
            return await context.Buildings
                .Select(b => new BuildingDto(b.Id, b.Name, b.Address, b.Status, b.Elevators
                    .Select(e => new ElevatorDto(e.Id, e.Name, e.CurrentFloor, e.ElevatorStatus,e.Status, e.BuildingId))
                    .ToList() 
                ))
                .ToListAsync(cancellationToken);
        }
    }
}