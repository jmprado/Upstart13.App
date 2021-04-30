using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upstart13.BeerApp.Domain;
using Upstart13.BeerApp.ViewModel;

namespace Upstart13.BeerApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var beerResult = await _beerService.Get(id);
            return new OkObjectResult(beerResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BeerModel beerModel)
        {
            var beerResult = await _beerService.Add(beerModel);
            return new OkObjectResult(beerResult);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BeerModel beerModel)
        {
            var beerResult = await _beerService.Update(beerModel);
            return new OkObjectResult(beerResult);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _beerService.Delete(id);
            return Ok();
        }
    }
}
