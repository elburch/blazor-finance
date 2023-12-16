using BlazorFinance.Shared.Helpers;

namespace BlazorFinance.Shared.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public Institution Institution { get; set; } = new Institution();
        public AccountType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
}
