﻿using IsubuBurada.Siparis.Application.Commands;
using IsubuBurada.Siparis.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuBurada.Siparis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SiparisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetSiparisler()
        {
            var sonuc = await _mediator.Send(new GetSiparislerByUserIdQuery
            {
                UserId = "1"
            });

            return Ok(sonuc);
        }

        [HttpPost]
        public async Task<IActionResult> SiparisKaydet(CreateSiparisCommand createSiparisCommand)
        {
            createSiparisCommand.UserId = "1";

            var sonuc = await _mediator.Send(createSiparisCommand);

            return Ok(sonuc);
        }
    }
}
