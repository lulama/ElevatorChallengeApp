using ElevatorChallengAPI.Enums;

namespace ElevatorChallengAPI.Domain.Interfaces
{
    public interface IElevator
    {
        Guid BuildingId { get; set; }
        int Capacity { get; set; }
        int CurrentCapacity { get; set; }
        Floor CurrentFloor { get; set; }
        ElevatorStatus ElevatorStatus { get; set; }
        Guid Id { get; set; }
        int MaxFloor { get; set; }
        int MinFloor { get; set; }
        string Name { get; set; }
        Status Status { get; set; }

        //void RequestElevator(int floor);
    }
}