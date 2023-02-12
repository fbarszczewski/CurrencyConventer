using CurrencyConventer.Core;
using CurrencyConventer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyConventer.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertychanger
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(params string[] names)
        {
            if (PropertyChanged != null)
            {
                foreach (string name in names)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion


        private CurrencyRoot currencyRoot;
        private Dictionary<string, double> rates;
        private double selectedFromRate;
        private double selectedToRate;
        private double convertedValue;
        private double enteredValue;
        private string lastUpdate;

        public Dictionary<string, double> Rates
        {
            get => rates;
            set
            {
                rates = value;
                OnPropertyChanged(nameof(Rates));
            }
        }
        public string LastUpdate 
        { 
            get => lastUpdate;
            set
            {
                lastUpdate = value;
                OnPropertyChanged(nameof(LastUpdate));
            }
        }
        public double EnteredValue
        {
            get { return enteredValue; }
            set
            {
                enteredValue = value;
                OnPropertyChanged(nameof(EnteredValue));

            }
        }

        public double SelectedFromRate
        {
            get => selectedFromRate;
            set
            {
                selectedFromRate = value;
                OnPropertyChanged(nameof(SelectedFromRate));
            }
        }
        public double SelectedToRate
        {
            get => selectedToRate;
            set
            {
                selectedToRate = value;
                OnPropertyChanged(nameof(SelectedToRate));
            }
        }
        public double ConvertedValue
        {
            get => convertedValue;
            set
            {
                convertedValue = value;
                OnPropertyChanged(nameof(ConvertedValue));
            }
        }


        public MainViewModel()
        {
            GetValues();

        }


        public ICommand ClearCommand
        {
            get
            {
                return new RelayCommand(argument =>
            {
                ConvertedValue = 0;
                EnteredValue = 0;
                Rates = null;
                Rates = currencyRoot.Rates;
            });
            }
        }

        public ICommand UpdateCommand
        {
            get => new RelayCommand(argument => GetValues());
        }
        public ICommand ConvertCommand
        {
            get => new RelayCommand(argument =>{ ConvertedValue = currencyRoot.Calc(SelectedFromRate, SelectedToRate, EnteredValue); });
        }

        private async void GetValues()
        {
            currencyRoot = await GetCurrency.GetData<CurrencyRoot>("https://openexchangerates.org/api/latest.json?app_id=b720b5beb4c74bb2beb85f64352010cb");
            Rates = currencyRoot.Rates;
            LastUpdate = currencyRoot.TimeStamp.ToString();
        }



    }
}
