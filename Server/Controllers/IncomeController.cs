using BlazorFinance.Server.Repositories;
using BlazorFinance.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomeController : Controller
    {
        private IIncomeRepository _repository;

        public IncomeController(IIncomeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateIncome(
            [Bind("Institution", "Account", "Asset", "Description", "Amount", "Frequency", "StartingDate", "EndingDate")] Income income
        )
        {
            if (income == null){
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateIncomeAsync(income) > 0
                ? StatusCode(StatusCodes.Status201Created, income)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet("read")]
        public async Task<List<Income>> ReadIncomeList()
        {
            return await _repository.ReadIncomeListAsync();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateIncome([FromRoute] int id, Income income)
        {
            if (id != income.Id){
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            if (await _repository.ReadIncomeAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.UpdateIncomeAsync(income) == true
                ? StatusCode(StatusCodes.Status200OK, income)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteIncome([FromRoute] int id)
        {
            if (await _repository.ReadIncomeAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.DeleteIncomeAsync(id) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
