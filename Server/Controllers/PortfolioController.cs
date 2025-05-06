using BlazorFinance.Client.Models;
using BlazorFinance.Client.Pages;
using BlazorFinance.Server.Repositories;
using BlazorFinance.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : Controller
    {
        private IAccountRepository _accRepository;
        private IAssetRepository _assRepository;
        private IInstitutionRepository _insRepository;
        private ITemplateRepository _temRepository;

        public PortfolioController(
            IAccountRepository accRepository, 
            IAssetRepository assRepository, 
            IInstitutionRepository insRepository,
            ITemplateRepository temRepository
        )
        {
            _accRepository = accRepository;
            _assRepository = assRepository;
            _insRepository = insRepository;
            _temRepository = temRepository;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportPortfolio(ImportModel model)
        {
            int institutionId = model.Institution.Id;
            int accountId = model.Account.Id;

            // Select the header row from imported assets
            List<string> header = model.AssetList
                .Where(x => x.Header == true)
                .Select(y => y.Asset)
                .DefaultIfEmpty(new List<string>())
                .First();

            // use the import template to find ordinal position of asset columns
            int description = header.IndexOf(model.Template.DescriptionLabel);
            int ticker = header.IndexOf(model.Template.TickerLabel);
            int shares = header.IndexOf(model.Template.SharesLabel);
            int price = header.IndexOf(model.Template.PriceLabel);

            // Select assets to be imported
            List<List<string>> positions = model.AssetList
                .Where(x => x.Position == true)
                .Select(y => y.Asset)
                .ToList();

            if (model.Institution.AddNew){
                Institution institution = new Institution
                {
                    Type = model.Institution.Type,
                    Name = model.Institution.Name,
                    SteetAddress = model.Institution.StreetAddress ?? "",
                    City = model.Institution.City ?? "",
                    State = model.Institution.State ?? "",
                    PostalNumber = model.Institution.PostalNumber ?? "",
                    Website = model.Institution.Website ?? "",
                    PhoneNumber = model.Institution.PhoneNumber ?? ""
                };

                // Get the new institution id for account insert
                var result = await _insRepository.CreateInstitutionAsync(institution);

                institutionId = result.AsInt32;
            }

            if (model.Account.AddNew){
                Account account = new Account
                {
                    InstitutionId = institutionId,
                    Type = model.Account.Type,
                    Name = model.Account.Name,
                    Number = model.Account.Number
                };

                // Get the new account id for asset insert
                var result = await _accRepository.CreateAccountAsync(account);

                accountId = result.AsInt32;
            }

            if (model.Template.AddNew){
                Template template = new Template
                {
                    Type = model.Template.Type,
                    Name = model.Template.Name,
                    TickerLabel = model.Template.TickerLabel,
                    DescriptionLabel = model.Template.DescriptionLabel,
                    PriceLabel = model.Template.PriceLabel,
                    SharesLabel = model.Template.SharesLabel
                };

                var result = await _temRepository.CreateTemplateAsync(template);
            }

            foreach(var position in positions)
            {
                Asset asset = new Asset
                {
                    AccountId = accountId,
                    Type = model.Template.Type,
                    Symbol = position[ticker],
                    Description = position[description],
                    Quantity = Convert.ToDecimal(position[shares]),
                    Price = Convert.ToDecimal(position[price].Replace("$", String.Empty))
                };

                List<Asset> assets = await _assRepository.ReadAssetListAsync(x => x.Symbol == asset.Symbol && x.AccountId == accountId);
                if(assets.Count > 0){
                    asset.Id = assets.Select(xx => xx.Id).FirstOrDefault();
                }

                var result = await _assRepository.UpsertAssetAsync(asset);
            }

            //if (model.AssetList.Count == 0) {
            //    return StatusCode(StatusCodes.Status400BadRequest, "yuk");
            //}

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
