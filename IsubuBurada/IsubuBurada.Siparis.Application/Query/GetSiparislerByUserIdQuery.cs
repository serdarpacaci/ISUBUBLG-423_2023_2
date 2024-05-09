using IsubuBurada.Siparis.Application.Query.Dtos;
using MediatR;

namespace IsubuBurada.Siparis.Application.Query
{
    public class GetSiparislerByUserIdQuery : IRequest<List<SiparisDto>>
    {
        public string UserId { get; set; }
    }
}
