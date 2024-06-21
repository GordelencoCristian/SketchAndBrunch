using AutoMapper;
using MediatR;
using Persistance.Contexts;
using Persistance.Entities;
using Persistance.Enums;

namespace FrontOffice.Server.Application.Requests.AddRequest
{
    public class AddRequestCommandHandler : IRequestHandler<AddRequestCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AddRequestCommandHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedRequest = _mapper.Map<Request>(request.RequestModel);
                mappedRequest.Status = RequestStatusEnum.New;

                await _appDbContext.Requests.AddAsync(mappedRequest, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return mappedRequest.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
