using BlazorFinance.Server.Repositories;
using BlazorFinance.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private IAccountRepository _repository;

        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([Bind("InstitutionId", "Type", "Name", "Number", "MarketValue", "AnnualGrowth")] Account account)
        {
            if (account == null) {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateAccountAsync(account) > 0
                ? StatusCode(StatusCodes.Status201Created, account)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet("read")]
        public async Task<List<Account>> ReadAccountList()
        {
            return await _repository.ReadAccountListAsync();
        }

        //[HttpGet]
        //public async Task<List<Account>> ReadAccountList([FromQuery] string key, int value)
        //{
        //    ParameterExpression type = Expression.Parameter(typeof(Account), "t");
        //    Expression member = Expression.Property(type, key);
        //    ConstantExpression? constant= Expression.Constant(value, typeof(int));
        //    Expression expression = Expression.Equal(member, constant);

        //    return await _repository.ReadAccountListAsync(Expression.Lambda<Func<Account, bool>>(expression, type));
        //}

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] int id, Account account)
        {
            if (id != account.Id){
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            if (await _repository.ReadAccountAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.UpdateAccountAsync(account) == true
                ? StatusCode(StatusCodes.Status200OK, account)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id)
        {
            if (await _repository.ReadAccountAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.DeleteAccountAsync(id) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
