using IsubuBurada.Shared.Mesajlar;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuBurada.Siparis.Application.Consumers
{
    public class SiparisOlusturMessageCommandConsumer : IConsumer<SiparisOlusturMessageCommand>
    {
        public Task Consume(ConsumeContext<SiparisOlusturMessageCommand> context)
        {
            var message = context.Message;

            return Task.CompletedTask;
        }
    }
}
