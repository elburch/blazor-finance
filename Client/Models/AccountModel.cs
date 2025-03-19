using BlazorFinance.Client.Helpers;
using BlazorFinance.Shared.Types;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Client.Models
{
    public class AccountModel
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
            set { 
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

        public int InstitutionId { get; set; }

        public AccountType Type { get; set; } = AccountType.None;

        public string Name { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;
    }
}
