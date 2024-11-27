using ElevatorChallengAPI.Shared;

namespace ElevatorChallengAPI.Domain
{
    public class Building : AuditDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Elevator> Elevators { get; set; } = [];

        public Building()
        {
            
        }

        public Building(string name, string address, List<Elevator> elevators)
        {
            Name = name;
            Address = address;
            Elevators = elevators;
        }

       
    }

    
}
