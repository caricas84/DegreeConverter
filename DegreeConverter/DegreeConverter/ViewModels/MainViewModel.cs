using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeConverter.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        string _fahrenheit;
        string _centigrade;
        #endregion

        #region Properties
        public string Temperature
        {
            get;
            set;
        }

        public string Fahrenheit
        {
            get
            {
                return _fahrenheit;
            }
            set
            {
                if (value != _fahrenheit)
                {
                    _fahrenheit = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Fahrenheit)));
                }
            }
        }

        public string Centigrade
        {
            get
            {
                return _centigrade;
            }
            set
            {
                if (value != _centigrade)
                {
                    _centigrade = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Centigrade)));
                }
            }
        }

        #endregion

        #region Constructors
        public MainViewModel()
        {
        }
        #endregion

        #region Commands
        public ICommand ConvertCommand
        {
            get { return new RelayCommand(Convert); }
        }

        async void Convert()
        {
            if (string.IsNullOrEmpty((Temperature)))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a value in degree",
                    "Accept");
                return;
            }

            decimal temperature = 0;
            if (!decimal.TryParse(Temperature, out temperature))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a value in degrees",
                    "Accept");
                return;
            }

            var fahrenheit = (temperature * 1.8M) + 32;
           
            Fahrenheit = string.Format("{0:N2}", fahrenheit);
            }

        public ICommand OtherCommand
        {
            get { return new RelayCommand(Other); }
        }

        async void Other()
        {
            if (string.IsNullOrEmpty((Temperature)))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a value in degree",
                    "Accept");
                return;
            }

            decimal temperature = 0;
            if (!decimal.TryParse(Temperature, out temperature))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a value in degree",
                    "Accept");
                return;
            }

            var centigrade = (temperature - 32) / 1.8M;

            Centigrade = string.Format("{0:N2}", centigrade);
        }
        #endregion
    }
}
