using AutoMapper;
using BackOffice.Server.Application.Events.GetEvents;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.Requests.GetRequests
{
    public class GetRequestsQueryHandler : IRequestHandler<GetRequestsQuery, List<RequestModel>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetRequestsQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<RequestModel>> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            var requests = await _appDbContext.Requests.OrderByDescending(e => e.CreateDate)
                .Include(e => e.Event)
                .ThenInclude(x => x.EventLocation)
                .Include(x => x.UserProfile)
                .Include(x => x.ApplicantUser)
                .ToListAsync();

            try
            {
                return _mapper.Map<List<RequestModel>>(requests);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
