using ElevatorChallengAPI.Domain.Interfaces;
using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Shared;
using MediatR;

namespace ElevatorChallengAPI.Domain
{
    public class Elevator : AuditDetails, IElevator
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Floor CurrentFloor { get; set; }
        public int Capacity { get; set; } = 2;
        public int CurrentCapacity { get; set; }
        public ElevatorStatus ElevatorStatus { get; set; } = ElevatorStatus.Working;
        public Status Status { get; set; } = Status.Active;
        public int MinFloor { get; set; } = 1;
        public int MaxFloor { get; set; } = 5;
        public Queue<int> Requests = new Queue<int>();
        public Guid BuildingId { get; set; }

        public List<int> Occupants { get; set; } = new List<int>();
        public Elevator()
        {

        }

        public Elevator(string name, Floor currentFloor, int capacity, int currentCapacity, Status status, ElevatorStatus elevatorStatus, Guid buildingId)
        {

            Name = name;
            CurrentFloor = currentFloor;
            Status = status;
            Capacity = capacity;
            CurrentCapacity = currentCapacity;
            ElevatorStatus = elevatorStatus;
            BuildingId = buildingId;
        }


        
    }
}
