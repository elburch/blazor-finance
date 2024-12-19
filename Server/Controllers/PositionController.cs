using BlazorFinance.Server.Repositories;
using BlazorFinance.Server.Services;
using BlazorFinance.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : Controller
    {
        private IAssetRepository _repository;

        public PositionController(IAssetRepository repository, IQuoteService quoteService)
        {
            _repository = repository;
        }

        [HttpGet("read")]
        public async Task<List<Asset>> ReadAssetList()
        {
            return await _repository.ReadAssetListAsync(x => x.Symbol.Length > 0);
        }
    }
}
