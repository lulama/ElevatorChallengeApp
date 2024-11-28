using ElevatorChallengAPI.Domain.Interfaces;
using ElevatorChallengAPI.Enums;
using ElevatorChallengAPI.Shared;

namespace ElevatorChallengAPI.Domain
{
    public class ElevatorRequest : AuditDetails, IElevatorRequest
    {
        public Guid Id { get; set; }
        public Guid ElevatorId { get; set; }
        public int PersonId { get; set; } //Link to a person
        public Floor Floor { get; set; }
        private Queue<int> Requests = new Queue<int>();  
        private List<int> Occupants = new List<int>();   
        public ElevatorRequest()
        {

        }

        public ElevatorRequest(Guid id, Guid elevatorId, int personId, Floor floor)
        {
            Id = id;
            ElevatorId = elevatorId;
            PersonId = personId;
            Floor = floor;
        }

        
        
    }
}
