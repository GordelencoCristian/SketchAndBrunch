using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;

namespace BackOffice.Server.Application.Events.AddEditEvent
{
    public class AddEditEventCommandHandler : IRequestHandler<AddEditEventCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AddEditEventCommandHandler(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(AddEditEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.EventModel.Id is not null)
                {
                    var events = await _appDbContext.Events.FirstOrDefaultAsync(el => el.Id == request.EventModel.Id);

                    _mapper.Map(request.EventModel, events);
                }
                else
                {
                    var mappedEvent= _mapper.Map<Event>(request.EventModel);

                    await _appDbContext.Events.AddAsync(mappedEvent);
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
