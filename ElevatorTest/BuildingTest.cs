using ElevatorChallengAPI.Features.Buildings.Queries.List;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ElevatorChallengeTest
{
    public class BuildingTest
    {
        [Fact]
        public async Task ListAllBuildings()
        {
            // Arrange
            var services = new ServiceCollection();
            var serviceProvider = services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ListBuildingsQueryHandler).Assembly))
                .BuildServiceProvider();

            var mediator = serviceProvider.GetRequiredService<IMediator>();

            var query = new ListBuildingsQuery();

            // Act
            var response = await mediator.Send(query);

            // Assert
            
        }
    }
}