using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Shared;

namespace ElevatorChallengAPI.Domain
{
    public class Elevator : AuditDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Floor CurrentFloor { get; set; }
        public ElevatorStatusEnum Status { get; set; } = ElevatorStatusEnum.Working;
        
        public int BuildingId { get; set; }

        public Elevator()
        {
            
        }

        public Elevator(int id, string name, Floor currentFloor, ElevatorStatusEnum status, int buildingId)
        {
            Id = id;
            Name = name;
            CurrentFloor = currentFloor;
            Status = status;
            BuildingId = buildingId;
        }

    }
}
