using ElevatorChallengAPI.Enums;

namespace ElevatorChallengAPI.Domain.Interfaces
{
    public interface IElevatorRequest
    {
        Guid ElevatorId { get; set; }
        Floor Floor { get; set; }
        Guid Id { get; set; }
        int PersonId { get; set; }

        void RequestElevator(int floor);
    }
}