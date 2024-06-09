using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;

namespace BackOffice.Server.Application.Requests.AddEditRequest
{
    public class AddEditRequestCommandHandler : IRequestHandler<AddEditRequestCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AddEditRequestCommandHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddEditRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.RequestModel.Id is not null)
                {
                    var events = await _appDbContext.Requests
                        .Include(x => x.Event)
                        .Include(x => x.UserProfile)
                        .FirstOrDefaultAsync(el => el.Id == request.RequestModel.Id, cancellationToken: cancellationToken);

                    _mapper.Map(request.RequestModel, events);
                }
                else
                {
                    var mappedRequest = _mapper.Map<Request>(request.RequestModel);

                    await _appDbContext.Requests.AddAsync(mappedRequest, cancellationToken);
                }

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
