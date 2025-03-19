

namespace BlazorFinance.Client.Models
{
    public class ImportModel
    {
        public List<AssetRow> AssetList { get; set; } = new List<AssetRow>();

        public InstitutionModel Institution { get; set; } = new InstitutionModel();

        public AccountModel Account { get; set; } = new AccountModel();

        public TemplateModel Template { get; set; } = new TemplateModel();
    }

    public record AssetRow
    {
        public Boolean Header { get; set; }
        public Boolean Position { get; set; }
        public List<string> Asset { get; set; } = new List<string>();
    }
}
