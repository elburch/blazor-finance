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
        public async Task<IActionResult> CreateAccount([Bind("Institution", "Type", "Name", "Number")] Account account)
        {
            if (account == null) {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateAccountAsync(account) > 0
                ? StatusCode(StatusCodes.Status201Created)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet]
        public async Task<List<Account>> ReadAccountList()
        {
            return await _repository.ReadAccountListAsync();
        }

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
                ? StatusCode(StatusCodes.Status200OK)
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
