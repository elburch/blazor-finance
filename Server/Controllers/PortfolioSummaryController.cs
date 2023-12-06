using Microsoft.AspNetCore.Mvc;
using BlazorFinance.Server.Services;
using BlazorFinance.Shared.Models;
using YahooFinanceApi;
using OoplesFinance.YahooFinanceAPI.Models;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioSummaryController : ControllerBase
    {
        private readonly ILogger<PortfolioSummaryController> _logger;
        private readonly IQuoteService _quoteService;

        public PortfolioSummaryController(ILogger<PortfolioSummaryController> logger, IQuoteService portfolioSummaryService)
        {
            _logger = logger;
            _quoteService = portfolioSummaryService;
        }

        [HttpGet]
        public async Task<List<StockModel>> Get()
        {
            // TO DO: hard-coded - need to get stock symbols from LiteDB service layer
            List<string> symbols = new List<string>() { "AAPL", "GOOG" };

            IReadOnlyDictionary<string, Security> quotes = await _quoteService.GetQuotes(symbols);

            return PrepareModel(quotes);
        }

        internal List<StockModel> PrepareModel(IReadOnlyDictionary<string, Security> quotes)
        {
            List<StockModel> models = new List<StockModel>();

            foreach (var quote in quotes) {
                StockModel model = new StockModel();

                model.Symbol = quote.Value.Symbol;
                model.Name = quote.Value.LongName;
                //model.Shares - need number of shares from "database" here
                model.Quote = (decimal)quote.Value.RegularMarketPrice;

                models.Add(model);
            }

            return models;
        }
    }
}
