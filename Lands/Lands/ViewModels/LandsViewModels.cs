

namespace Lands.ViewModels
{
    using Services;
    using Models;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Linq;

    public class LandsViewModels : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion
        #region Attributes
        private ObservableCollection<LandItemViewModel> _lands;
        private bool _isRefreshing;
        private string _filter;
        #endregion

        #region Proprties
        public ObservableCollection<LandItemViewModel> Lands
        {
            get
            {
                return this._lands;
            }
            set
            {
                SetValue(ref this._lands, value);
            }
        }
        public bool IsRefreshing
        {
            get
            {
                return this._isRefreshing;
            }
            set
            {
                SetValue(ref this._isRefreshing, value);
            }
        }
        public string Filter
        {
            get
            {
                return this._filter;
            }
            set
            {
                SetValue(ref this._filter, value);
                Search();
            }
        }
        #endregion

        #region Constructors
        public LandsViewModels()
        {
            apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var resoponse = await this.apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            if (!resoponse.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", resoponse.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            MainViewModels.Instance()._landList = (List<Land>)resoponse.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel());
            this.IsRefreshing = false;
        }


        #endregion
        #region Methods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModels.Instance()._landList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        } 
        #endregion
        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }

        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (String.IsNullOrEmpty(Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel());

            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel().Where(f => f.Name.ToLower().StartsWith(Filter.ToLower())
                    || f.Capital.ToLower().StartsWith(Filter.ToLower())));
            }

        }
        #endregion
    }
}
