using CurrencyConventer.Model;
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
        private Dictionary<string, double> rates;
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
        public CurrencyRoot CurrencyRates { get; set; }
        public Dictionary<string, double> Rates 
        { 
            get => rates; 
            set
            {
                rates = value;
                OnPropertyChanged(nameof(Rates));
            }
            
        }



        public MainViewModel()
        {
            GetValue();
        }

        private async void GetValue()
        {
            CurrencyRates = await GetCurrency.GetData<CurrencyRoot>("https://openexchangerates.org/api/latest.json?app_id=b720b5beb4c74bb2beb85f64352010cb");

            Rates = CurrencyRates.Rates;
        }

    }
}
