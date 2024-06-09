using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.Locations.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Unit>
    {

        private readonly AppDbContext _appDbContext;

        public DeleteLocationCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {

            var location = await _appDbContext.EventLocations.FirstOrDefaultAsync(el => el.Id == request.LocationId);
            
            _appDbContext.EventLocations.Remove(location);
            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
