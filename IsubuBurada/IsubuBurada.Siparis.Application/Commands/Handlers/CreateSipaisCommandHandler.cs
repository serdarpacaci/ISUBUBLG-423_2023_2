using IsubuBurada.Siparis.Application.Commands;
using IsubuBurada.Siparis.Application.Commands.Dtos;
using IsubuBurada.Siparis.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuBurada.Siparis.Application.Commands.Handlers
{
    internal class CreateSipaisCommandHandler : IRequestHandler<CreateSiparisCommand, CreateSiparisDto>
    {
        private readonly SiparisDbContext context;

        public CreateSipaisCommandHandler(SiparisDbContext context)
        {
            this.context = context;
        }
        public Task<CreateSiparisDto> Handle(CreateSiparisCommand request, CancellationToken cancellationToken)
        {
            // await context.Siparisler.AddAsync(new)
            // await context.SaveChangesAsync();

            return Task.FromResult(new CreateSiparisDto());

        }
    }
}
