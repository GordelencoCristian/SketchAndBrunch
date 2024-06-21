using MediatR;
using Persistance.Contexts;
using Persistance.Enums;

namespace BackOffice.Server.Application.Requests.ChangeRequestStatus
{
    public class ChangeRequestStatusCommandHandler : IRequestHandler<ChangeRequestStatusCommand, int>
    {
        private readonly AppDbContext _appDbContext;

        public ChangeRequestStatusCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(ChangeRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var dbRequest = _appDbContext.Requests.FirstOrDefault(x => x.Id == request.Model.Id);
            dbRequest.Status = (RequestStatusEnum?)request.Model.Status;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            return dbRequest.Id;
        }
    }
}
