namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandItemViewModel : Land
    {
        #region MyRegion
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }
        #endregion

        #region Methods
        private async void SelectLand()
        {
            MainViewModels.Instance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        } 
        #endregion
    }
}
