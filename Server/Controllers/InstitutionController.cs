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

        [HttpPost("create")]
        public async Task<IActionResult> CreateInstitution([Bind("Type","Name","SteetAddress","City","State","PostalNumber","Website","PhoneNumber")] Institution institution) 
        {
            if (institution == null){
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateInstitutionAsync(institution) > 0 
                ? StatusCode(StatusCodes.Status201Created, institution)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet]
        public async Task<List<Institution>> ReadInstitutionList()
        {
            return await _repository.ReadInstitutionListAsync();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInstitution([FromRoute] int id, Institution institution)
        {
            if (id != institution.Id){
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            if (await _repository.ReadInstitutionAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.UpdateInstitutionAsync(institution) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInstitution([FromRoute] int id)
        {
            if (await _repository.ReadInstitutionAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.DeleteInstitutionAsync(id) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
