using IsubuBurada.Siparis.Application.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuBurada.Siparis.Application.Commands
{
    public class CreateSiparisCommand : IRequest<CreateSiparisDto>
    {
        public string UserId { get; set; }
        public List<SiparisItemDto> SiparisUrunleri { get; set; }
        public AddressDto Address { get; set; }
    }
}
