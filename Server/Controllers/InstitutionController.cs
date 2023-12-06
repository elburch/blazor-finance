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

        // GET: api/Product
        [HttpGet]
        public async Task<List<Institution>> GetBrokerageList()
        {
            return await _repository.GetInstitutionListAsync();
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertBrokerage([Bind("Type","Name","SteetAddress","City","State","PostalNumber","Website","PhoneNumber")]Institution institution) 
        {
            if (institution == null) {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.InsertInstitutionAsync(institution) > 0 
                ? StatusCode(StatusCodes.Status201Created)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateInstitution(Institution institution)
        {
            //if (id != institution.Id){
            //    StatusCode(StatusCodes.Status401Unauthorized);
            //}

            return await _repository.UpdateInstitutionAsync(institution) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> DeleteBrokerage(int id)
        //{

        //}
    }
}
