using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using SharedData.Models;

namespace FrontOffice.Server.Application.Events.GetEvents
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, List<EventModel>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetEventQueryHandler(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<EventModel>> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var events = await _appDbContext.Events.OrderByDescending(e => e.CreateDate).Include(e => e.EventLocation).ToListAsync();

            try
            {
                return _mapper.Map<List<EventModel>>(events);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
