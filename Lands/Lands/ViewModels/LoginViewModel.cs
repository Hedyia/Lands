namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region DataMembers
        private string _email;
        private string _password;
        private bool _isRunnning;
        private bool _isEnabled;
        #endregion
        #region Properties
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetValue(ref _email, value);
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetValue(ref _password, value);
            }
        }
        public bool IsRunning
        {
            get
            {
                return _isRunnning;
            }
            set
            {
                SetValue(ref _isRunnning, value);
            }
        }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                SetValue(ref _isEnabled, value);
            }
        }
        public bool IsRemembered { get; set; }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "muo.cpp@gmail.com";
            this.Password = "123456";
            //http://restcountries.eu/rest/v2/all
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login); 
            }

        }

        private async void Login()
        {
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter an email.", "Accept");
                return;
            }

            if (String.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a password.", "Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;
            if(this.Email != "muo.cpp@gmail.com" || this.Password!="123456")
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Email or Paswword is incorrect.", "Accept");
                this.Password = string.Empty;
                return;
            }
            IsRunning = false;
            IsEnabled = true;

            MainViewModels.Instance().Lands = new LandsViewModels();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());


        }
        #endregion

    }
}
