using BlazorFinance.Server.Repositories;
using BlazorFinance.Server.Services;
using BlazorFinance.Shared.Entities;
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
            List<Asset> assets = await _repository.ReadAssetListAsync(x => x.Symbol.Length > 0 && x.Symbol.Length < 6 && x.SnapshotDate.Date < DateTime.Today);

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
                    //try
                    //{
                        dynamic? price;
                        if (quote.Value.Fields.TryGetValue("RegularMarketPrice", out price)){
                            asset.Price = (decimal)price;
                        }

                        dynamic? rate;
                        if (quote.Value.Fields.TryGetValue("TrailingAnnualDividendRate", out rate)){
                            asset.DividendRate = (decimal)rate;
                        }

                        asset.MarketValue = (decimal)asset.Quantity * (decimal)asset.Price;
                        asset.SnapshotDate = DateTime.Now;
                    //}
                    //catch(Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //}
                }
            }

            return await _repository.UpdateAssetsAsync(assets) == quotes.Count
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
