using BlazorFinance.Client.Helpers;
using BlazorFinance.Shared.Types;
using System.ComponentModel;

namespace BlazorFinance.Client.Models
{
    public class TemplateModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged<T>(string propertyName, T value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs<T>(propertyName, value));
        }

        private int id = 0;
        private bool addNew = false;

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    NotifyPropertyChanged(nameof(Id), value);
                }
            }
        }

        public bool AddNew
        {
            get { return this.addNew; }
            set
            {
                if (value != this.addNew)
                {
                    this.addNew = value;
                    NotifyPropertyChanged(nameof(AddNew), value);
                }
            }
        }

        public string Name { get; set; } = String.Empty;

        public AssetType Type { get; set; } = AssetType.None;

        public string TickerLabel { get; set; } = String.Empty;

        public string DescriptionLabel { get; set; } = String.Empty;

        public string SharesLabel { get; set; } = String.Empty;

        public string PriceLabel { get; set; } = String.Empty;
    }
}
