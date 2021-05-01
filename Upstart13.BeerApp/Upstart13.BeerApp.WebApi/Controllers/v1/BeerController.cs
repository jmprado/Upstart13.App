using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// This call returns a beer.
        /// </summary>
        /// <remarks>
        ///
        ///     GET /v1/beer/{id}
        ///     {
        ///     }
        ///     curl -X GET "/v1/beer/{id}" -H  "accept: text/plain"
        ///
        /// </remarks>
        /// <response code="200">Returns a beer from id</response>
        /// <response code="404">Validation errors</response>
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var beerResult = await _beerService.Get(id);
            
            if(beerResult != null)            
                return new OkObjectResult(beerResult);

            return new NotFoundObjectResult($"Beer with id #{id} not found");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(BeerModel beerModel)
        {
            if (ModelState.IsValid)
            {
                var beerResult = await _beerService.Add(beerModel);
                return new CreatedAtRouteResult("Get", new { id = beerResult.BeerId });
            }

            return new BadRequestObjectResult(ModelState);
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
