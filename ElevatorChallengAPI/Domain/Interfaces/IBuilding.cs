using ElevatorChallengAPI.Enums;

namespace ElevatorChallengAPI.Domain.Interfaces
{
    public interface IBuilding
    {
        string Address { get; set; }
        List<Elevator> Elevators { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
        Status Status { get; set; }
    }
}