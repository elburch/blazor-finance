using BlazorFinance.Server.Repositories;
using BlazorFinance.Server.Services;
using BlazorFinance.Shared.Entities;
using BlazorFinance.Shared.Types;
using Microsoft.AspNetCore.Mvc;
using YahooFinanceApi;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : Controller
    {
        private IAssetRepository _repository;
        private readonly IQuoteService _quoteService;

        public QuoteController(IAssetRepository assetRepository, IQuoteService quoteService)
        {
            _repository = assetRepository;
            _quoteService = quoteService;
        }

        [HttpGet("update")]
        public async Task<IActionResult> UpdateStaleMarketValuesAsync()
        {
            List<Asset> assets = await _repository.ReadAssetListAsync(x => x.Symbol.Length > 0 && x.SnapshotDate.Date < DateTime.Today);

            if (assets == null || assets.Count == 0){
                return StatusCode(StatusCodes.Status204NoContent);
            }

            IReadOnlyDictionary<string, Security> quotes = await _quoteService.GetQuotes(
                assets.Select(x => x.Symbol).ToList()
            );

            foreach (var quote in quotes){
                Asset asset = assets
                    .Where(x => x.Symbol == quote.Value.Symbol)
                    .First();

                if (asset != null){
                    asset.Price = (decimal)quote.Value.RegularMarketPrice;
                    asset.MarketValue = (decimal)asset.Quantity * (decimal)quote.Value.RegularMarketPrice;
                    asset.SnapshotDate = DateTime.Now;
                }
            }

            return await _repository.UpdateAssetsAsync(assets) == quotes.Count
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
