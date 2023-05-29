using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using avengerapi.Models;
using avengerapi.Services.AvengerService;
using Microsoft.AspNetCore.Mvc;

namespace avengerapi.Controllers
{
    [ApiController]
    [Route("api/avenger")]
    public class AvengerController : ControllerBase
    {
        private readonly IAvengerService _avengerService;
        public AvengerController(IAvengerService avengerService)
        {
            this._avengerService = avengerService;

        }


        [HttpGet]
        public async Task<ActionResult<List<Avenger>>> GetAvengers()
        {
            return Ok(await _avengerService.GetAvengers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avenger>> GetAvengerById(int id)
        {
            return Ok(await _avengerService.GetAvengerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Avenger>> AddAvenger(Avenger avenger)
        {
            return Ok(await _avengerService.AddAvenger(avenger));
        }

        [HttpPut]
        public async Task<ActionResult<Avenger>> UpdateAvenger(Avenger avenger)
        {
            return Ok(await _avengerService.UpdateAvenger(avenger));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Avenger>> DeleteAvenger(int id)
        {

            return Ok(await _avengerService.DeleteAvenger(id));
        }
    }
}