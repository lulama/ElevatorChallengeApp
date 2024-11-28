using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Features.Elevators.Commands.Create;
using ElevatorChallengAPI.Persistence;
using MediatR;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Commands.Create
{
    public class RequestElevatorCommandHandler : IRequestHandler<RequestElevatorCommand, Guid>
    {
        private readonly AppDbContext _context;

        public RequestElevatorCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(RequestElevatorCommand request, CancellationToken cancellationToken)
        {
            var elevator = await _context.Elevators.FindAsync(request.ElevatorId);
            if ((int)request.Floor < elevator.MinFloor || (int)request.Floor > elevator.MaxFloor)
            {
                throw new ArgumentException("Floor is out of range", nameof(request.Floor));
               
            }

            if  (!elevator.Requests.Contains((int)request.Floor))
            {
                elevator.Requests.Enqueue((int)request.Floor);
            }

            else
            {
                return Guid.Empty;
            }
           
            var elevatorRequest = new ElevatorRequest(Guid.NewGuid(),request.ElevatorId, request.PersonId,request.Floor);
            _context.ElevatorRequests.Add(elevatorRequest);
            await _context.SaveChangesAsync(cancellationToken);
            return elevatorRequest.Id;
        }

        
    }
}
