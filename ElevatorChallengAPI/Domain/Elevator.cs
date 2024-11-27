using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Shared;

namespace ElevatorChallengAPI.Domain
{
    public class Elevator : AuditDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Floor CurrentFloor { get; set; }
        public ElevatorStatus Status { get; set; } = ElevatorStatus.Working;
        
        public int BuildingId { get; set; }

        public Elevator()
        {
            
        }

        public Elevator(string name, Floor currentFloor, ElevatorStatus status, int buildingId)
        {
           
            Name = name;
            CurrentFloor = currentFloor;
            Status = status;
            BuildingId = buildingId;
        }

    }
}
