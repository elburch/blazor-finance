using BlazorFinance.Server.Repositories;
using BlazorFinance.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : Controller
    {
        private IAssetRepository _repository;

        public AssetController(IAssetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsset([Bind("AccountId", "Type", "Symbol", "Description", "Quantity", "Price", "MarketValue", "PurchaseDate", "CostBasis", "AnnualGrowth", "PurchaseDate", "SnapshotDate")] Asset asset)
        {
            if (asset == null){
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return await _repository.CreateAssetAsync(asset) > 0
                ? StatusCode(StatusCodes.Status201Created, asset)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet("read")]
        public async Task<List<Asset>> ReadAssetList()
        {
            return await _repository.ReadAssetListAsync();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsset([FromRoute] int id, Asset asset)
        {
            if (id != asset.Id){
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            if (await _repository.ReadAssetAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.UpdateAssetAsync(asset) == true
                ? StatusCode(StatusCodes.Status200OK, asset)
                : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsset([FromRoute] int id)
        {
            if (await _repository.ReadAssetAsync(id) == null){
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _repository.DeleteAssetAsync(id) == true
                ? StatusCode(StatusCodes.Status200OK)
                : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
