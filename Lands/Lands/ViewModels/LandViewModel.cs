
namespace Lands.ViewModels
{
    using Lands.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Border> _borders;
        private ObservableCollection<Currency> _currencies;
        private ObservableCollection<Language> _languages;
        private Translation _translations;


        #endregion
        #region Proprites
        public Land Land { get; set; }
        public ObservableCollection<Border> Borders
        {
            get
            {
                return this._borders;
            }
            set
            {
                SetValue(ref this._borders, value);
            }
        }
        public ObservableCollection<Currency> Currencies
        {
            get
            {
                return this._currencies;
            }
            set
            {
                SetValue(ref this._currencies, value);
            }
        }
        public ObservableCollection<Language> Languages
        {
            get
            {
                return this._languages;
            }
            set
            {
                SetValue(ref this._languages, value);
            }
        }
        public Translation Translations
        {
            get
            {
                return this._translations;
            }
            set
            {
                SetValue(ref this._translations, value);
            }
        }


        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languages = new ObservableCollection<Language>(this.Land.Languages);
            this.Translations = this.Land.Translations;

        }
        #endregion
        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModels.Instance()._landList.
                    Where(l => l.Alpha3Code == (string)border).FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name
                    });
                }
            }
        } 
        #endregion

    }
}
