using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Features.ElevatorRequests.Commands.Exit;
using ElevatorChallengAPI.Features.Elevators.Commands.Create;
using ElevatorChallengAPI.Persistence;
using MediatR;
using System.Diagnostics.Contracts;

namespace ElevatorChallengAPI.Features.ElevatorRequests.Commands.Create
{
    public class ExitElevatorCommandHandler : IRequestHandler<ExitElevatorCommand, Guid>
    {
        private readonly AppDbContext _context;

        public ExitElevatorCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(ExitElevatorCommand request, CancellationToken cancellationToken)
        {
            Contract.Requires(request != null);
            var elevator = await _context.Elevators.FindAsync(request.ElevatorId);           
            if (elevator != null && elevator.Occupants.Count > 0)
            {
                elevator.Occupants.Remove(request.PersonId);
                _context.Elevators.Update(elevator);
                await _context.SaveChangesAsync();
                return elevator.Id;
            }
            else
            {
                throw new ArgumentException("Elevator not found or it is empty", nameof(request));
            }
           
         
        }

        
    }
}
