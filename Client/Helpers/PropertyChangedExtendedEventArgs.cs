using System.ComponentModel;

namespace BlazorFinance.Client.Helpers
{
    public class PropertyChangedExtendedEventArgs<T> : PropertyChangedEventArgs
    {
        public virtual T Value { get; private set; }

        public PropertyChangedExtendedEventArgs(string propertyName, T value)
            : base(propertyName)
        {
            Value = value;
        }
    }
}
