using MediatR;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfile.GetNumberOfCigarets
{
    public class GetNumberOfCigaretsQyery : IRequest<int>
    {
        public int Id { get; set; }
        public bool IsReady { get; set; }
    }

    public class GetNumberOfCigaretsQyeryHandler : IRequestHandler<GetNumberOfCigaretsQyery, int>
    {
        public GetNumberOfCigaretsQyeryHandler(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; set; }
        public async Task<int> Handle(GetNumberOfCigaretsQyery request, CancellationToken cancellationToken)
        {
            return 1;
        }
    }

}
