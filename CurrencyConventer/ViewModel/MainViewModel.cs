using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConventer.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged   
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
                foreach (string propertyName in propertyNames)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
        
        public List<string> Currency { get; set; }

        public MainViewModel()
        {
            Currency = new List<string> { "PLN", "USD", "EUR" };
        }

    }
}
