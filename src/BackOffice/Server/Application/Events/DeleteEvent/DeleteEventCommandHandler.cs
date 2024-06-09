using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.Events.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteEventCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var selectedEvent = await _appDbContext.Events.FirstOrDefaultAsync(el => el.Id == request.EventId);

            _appDbContext.Events.Remove(selectedEvent);
            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
