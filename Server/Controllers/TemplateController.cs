using BlazorFinance.Server.Repositories;
using BlazorFinance.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : Controller
    {
        private ITemplateRepository _repository;

        public TemplateController(ITemplateRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTemplate([Bind("Id", "Type", "Name")] Template template)
        {
            if (template == null) {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateTemplateAsync(template) > 0
                ? StatusCode(StatusCodes.Status201Created, template)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet("read")]
        public async Task<List<Template>> ReadTemplateList()
        {
            return await _repository.ReadTemplateListAsync();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTemplate([FromRoute] int id, Template template)
        {
            if (id != template.Id) {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            if (await _repository.ReadTemplateAsync(id) == null) {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.UpdateTemplateAsync(template) == true
                ? StatusCode(StatusCodes.Status200OK, template)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTemplate([FromRoute] int id)
        {
            if (await _repository.ReadTemplateAsync(id) == null) {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.DeleteTemplateAsync(id) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
