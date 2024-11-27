using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Shared;
using System.ComponentModel.DataAnnotations;

namespace ElevatorChallengAPI.Domain
{
    public class Building : AuditDetails
    {
        public Guid Id { get; set; }
        [Key]
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Active;
        public List<Elevator> Elevators { get; set; } = [];

        public Building()
        {
            
        }

        public Building(string name, string address, Status status, List<Elevator> elevators)
        {
            Name = name;
            Address = address;
            Status = status;
            Elevators = elevators;
        }

       
    }

    
}
