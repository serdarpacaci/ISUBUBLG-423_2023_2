using IsubuBurada.Siparis.Application.Query.Dtos;
using IsubuBurada.Siparis.Persistence;
using MediatR;

namespace IsubuBurada.Siparis.Application.Query
{
    public class GetSiparislerbyUserIdQueryHandler : IRequestHandler<GetSiparislerByUserIdQuery, List<SiparisDto>>
    {
        private readonly SiparisDbContext siparisDbContext;

        public GetSiparislerbyUserIdQueryHandler(SiparisDbContext siparisDbContext)
        {
            this.siparisDbContext = siparisDbContext;
        }
        public Task<List<SiparisDto>> Handle(GetSiparislerByUserIdQuery request, CancellationToken cancellationToken)
        {
            //siparisDbContext.

            return Task.FromResult(new List<SiparisDto>());
        }
    }
}
