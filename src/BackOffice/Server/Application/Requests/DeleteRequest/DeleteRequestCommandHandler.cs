using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.Requests.DeleteRequest
{
    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteRequestCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var requestOption = await _appDbContext.Requests.FirstOrDefaultAsync(el => el.Id == request.RequestId);

            _appDbContext.Requests.Remove(requestOption);
            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
