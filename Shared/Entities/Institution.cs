using BlazorFinance.Shared.Helpers;

namespace BlazorFinance.Shared.Entities
{
    public class Institution : IEntity
    {
        public int Id { get; set; }

        public InstitutionType Type { get; set; }

        public string Name { get; set; } = string.Empty;

        public string SteetAddress { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string PostalNumber { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
