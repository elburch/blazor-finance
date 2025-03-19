using BlazorFinance.Client.Helpers;
using BlazorFinance.Shared.Types;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Client.Models
{
    public class InstitutionModel : INotifyPropertyChanged
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
            get{ return this.id; }
            set{ 
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

        public InstitutionType Type { get; set; } = InstitutionType.NoneSelected;

        public string Name { get; set; } = string.Empty;
        
        public string? StreetAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalNumber { get; set; }

        public string? Website { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
