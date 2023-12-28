using BlazorFinance.Server.Repositories;
using BlazorFinance.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : Controller
    {
        private IExpenseRepository _repository;

        public ExpenseController(IExpenseRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateExpense(
            [Bind("Institution", "Description", "Amount", "Frequency", "StartingDate", "EndingDate")] Expense expense
        )
        {
            if (expense == null){
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateExpenseAsync(expense) > 0
                ? StatusCode(StatusCodes.Status201Created, expense)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet]
        public async Task<List<Expense>> ReadExpenseList()
        {
            return await _repository.ReadExpenseListAsync();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateExpense([FromRoute] int id, Expense expense)
        {
            if (id != expense.Id){
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            if (await _repository.ReadExpenseAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.UpdateExpenseAsync(expense) == true
                ? StatusCode(StatusCodes.Status200OK, expense)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int id)
        {
            if (await _repository.ReadExpenseAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.DeleteExpenseAsync(id) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
