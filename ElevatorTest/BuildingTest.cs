using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Domain.Interfaces;
using ElevatorChallengAPI.Features.Buildings.Queries.List;
using ElevatorChallengAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace ElevatorChallengeTest
{
    //Add dependency to appDbContext
    
    public class BuildingTest
    {

        [Fact]
        public async Task ListAllBuildings()
        {
            // Arrange
            var services = new ServiceCollection();
            var serviceProvider = services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ListBuildingsQueryHandler).Assembly))
                .AddScoped<IBuilding, Building>()
                .BuildServiceProvider();
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase("elevatordb");
            var context = new AppDbContext(optionsBuilder.Options);

            var mediator = serviceProvider.GetRequiredService<IMediator>();

            var query = new ListBuildingsQuery();

            // Act
            var response = await mediator.Send(query);

            // Assert
            
        }
    }
}