using OoplesFinance.YahooFinanceAPI;
using OoplesFinance.YahooFinanceAPI.Models;
using YahooFinanceApi;

namespace BlazorFinance.Server.Services
{
    public class QuoteService : IQuoteService
    {
        public async Task<IReadOnlyDictionary<string, Security>> GetQuotes(List<string> symbols)
        {
            // ** requested information not available on yahoo finance **
            //
            //var yahooClient = new YahooClient();
            //var securities_test = await yahooClient.GetEarningsHistoryAsync("GOOG");

            var securities = await Yahoo.Symbols(symbols.ToArray())
                .Fields(
                    Field.Symbol, 
                    Field.LongName,
                    Field.RegularMarketPrice, 
                    Field.FiftyTwoWeekHigh,
                    Field.TrailingAnnualDividendRate)
                .QueryAsync();

            return securities;
        }

    }
}
