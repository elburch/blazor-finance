using BlazorFinance.Server.Repositories;
using BlazorFinance.Server.Services;
using BlazorFinance.Shared.Entities;
using BlazorFinance.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using YahooFinanceApi;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : Controller
    {
        private IAssetRepository _repository;
        private readonly IQuoteService _quoteService;
        private List<Asset> _assets;

        public PositionController(IAssetRepository repository, IQuoteService quoteService)
        {
            _repository = repository;
            _quoteService = quoteService;
            _assets = new List<Asset>();
        }

        [HttpGet("read")]
        public async Task<List<StockModel>> Get()
        {
            _assets = await _repository.ReadAssetListAsync(x => x.Symbol.Length > 0);

            IReadOnlyDictionary<string, Security> quotes = await _quoteService.GetQuotes(
                _assets.Select(x => x.Symbol).ToList()
            );

            return PrepareModel(quotes);
        }

        internal List<StockModel> PrepareModel(IReadOnlyDictionary<string, Security> quotes)
        {
            List<StockModel> models = new List<StockModel>();

            foreach (var quote in quotes)
            {
                double shares = _assets
                    .Where(x => x.Symbol == quote.Value.Symbol)
                    .Select(x => x.Quantity)
                    .FirstOrDefault();

                StockModel model = new StockModel();

                model.Symbol = quote.Value.Symbol;
                model.Name = quote.Value.LongName;
                model.Quote = (decimal)quote.Value.RegularMarketPrice;
                model.Shares = shares;
                model.MarketValue = (decimal)shares * (decimal)quote.Value.RegularMarketPrice;

                models.Add(model);
            }

            return models;
        }
    }
}
