using BlazorFinance.Server.Repositories;
using BlazorFinance.Shared.Entities;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionController : Controller
    {
        private IInstitutionRepository _repository;

        public InstitutionController(IInstitutionRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet("read")]
        public async Task<List<Institution>> GetBrokerageList()
        {
            return await _repository.ReadInstitutionListAsync();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBrokerage([Bind("Type","Name","SteetAddress","City","State","PostalNumber","Website","PhoneNumber")] Institution institution) 
        {
            if (institution == null) {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateInstitutionAsync(institution) > 0 
                ? StatusCode(StatusCodes.Status201Created)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBrokerage([FromRoute] int id, Institution institution)
        {
            if (id != institution.Id){
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return await _repository.UpdateInstitutionAsync(institution) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBrokerage([FromRoute] int id)
        {
            return await _repository.DeleteInstitutionAsync(new BsonValue(id)) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
