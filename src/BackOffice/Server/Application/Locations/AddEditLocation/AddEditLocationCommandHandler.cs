using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;

namespace BackOffice.Server.Application.Locations.AddEditLocation
{
    public class AddEditLocationCommandHandler : IRequestHandler<AddEditLocationCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AddEditLocationCommandHandler(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        public async Task<Unit> Handle(AddEditLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.LocationModel.Id is not null)
                {
                    var locations = await _appDbContext.EventLocations.FirstOrDefaultAsync(el => el.Id == request.LocationModel.Id);

                    _mapper.Map(request.LocationModel, locations);
                }
                else
                {
                    var mappedLocation = _mapper.Map<EventLocation>(request.LocationModel);

                    await _appDbContext.EventLocations.AddAsync(mappedLocation);
                }

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
