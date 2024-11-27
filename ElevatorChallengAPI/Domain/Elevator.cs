using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Shared;

namespace ElevatorChallengAPI.Domain
{
    public class Elevator : AuditDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Floor CurrentFloor { get; set; }
        public int Capacity { get; set; }
        public ElevatorStatus ElevatorStatus { get; set; } = ElevatorStatus.Working;
        public Status Status { get; set; } = Status.Active;
        public int BuildingId { get; set; }

        public Elevator()
        {
            
        }

        public Elevator(string name, Floor currentFloor, int capacity, Status status, int buildingId)
        {
           
            Name = name;
            CurrentFloor = currentFloor;
            Status = status;
            Capacity = capacity;

            BuildingId = buildingId;
        }

    }
}
