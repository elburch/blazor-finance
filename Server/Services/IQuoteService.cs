using OoplesFinance.YahooFinanceAPI.Models;
using YahooFinanceApi;

namespace BlazorFinance.Server.Services
{
    public interface IQuoteService
    {
        public  Task<IReadOnlyDictionary<string, Security>> GetQuotes(List<string> symbols);
    }
}
