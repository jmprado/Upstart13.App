using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Upstart13.BeerApp.Domain;
using Upstart13.BeerApp.Infrastructure.HttpClients;
using Upstart13.BeerApp.ViewModel;
using Upstart13.BeerApp.WebApi.Infrastructure.BasicAuth;
using System.Collections.Generic;

namespace Upstart13.BeerApp.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [BasicAuthorize("com.upstart13.beerapp.webapi")]
    public class SearchBeerController : ControllerBase
    {
        private readonly IPunkApiHttpClient _punkApiHttpCliente;
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;

        public SearchBeerController(IPunkApiHttpClient punkApiHttpClient, IBeerService beerService, IMapper mapper)
        {
            _punkApiHttpCliente = punkApiHttpClient;
            _beerService = beerService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] SearchBeerModel searchBeerModel)
        {
            var resultSearch = await _punkApiHttpCliente.GetBeersAsync(searchBeerModel);
            var returnResult = _mapper.Map<IEnumerable<ResultSearchModel>>(resultSearch);
            return new OkObjectResult(returnResult);
        }

        [HttpPost("import")]
        public async Task<IActionResult> Post([FromQuery] SearchBeerModel searchBeerModel)
        {
            var listBeersImport = await _punkApiHttpCliente.GetBeersAsync(searchBeerModel);
            await _beerService.Import(listBeersImport);
            return Ok();
        }
    }
}