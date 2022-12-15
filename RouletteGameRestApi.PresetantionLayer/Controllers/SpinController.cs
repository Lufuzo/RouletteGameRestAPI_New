using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace RouletteGameRestApi.PresetantionLayer.Controllers
{

    [Route("api/spin")]
    public class SpinController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SpinController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetSpins()
        {
            var spins = await _service.SpinService.GetAllSpinsAsync(trackChanges: false);

            return Ok(spins);
        }

        [HttpGet("bets/{betId}/nextspin")]
        public async Task<IActionResult> GetNextSpin(Guid betId)
        {
            var spin = await _service.SpinService.GetNextSpinAsync(betId, trackChanges: false);

            return Ok(spin);
        }

        [HttpGet("{id:guid}", Name = "SpinById")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetSpin(Guid id)
        {
            var spins = await _service.SpinService.GetSpinAsync(id, trackChanges: false);

            return Ok(spins);
        }
    }
}
