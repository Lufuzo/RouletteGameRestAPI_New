using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameRestApi.PresetantionLayer.Controllers
{
    [Route("api/spin/{spinId}/bets/{betId}/payouts")]
    [ApiController]
    public class PayoutController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PayoutController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetPayouts(Guid spinId, Guid betId)
        {
            var payouts = await _service.PayoutService.GetAllPayoutsAsync(spinId, betId, trackChanges: false);

            return Ok(payouts);
        }

        [HttpGet("{id:guid}", Name = "PayoutById")]
        public async Task<IActionResult> GetPayout(Guid id, Guid spinId, Guid betId)
        {
            var payout = await _service.PayoutService.GetPayoutAsync(id, spinId, betId, trackChanges: false);

            return Ok(payout);
        }
    }
}
