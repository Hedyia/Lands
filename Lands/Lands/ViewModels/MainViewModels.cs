
namespace Lands.ViewModels
{
    using Lands.Models;
    using System.Collections.Generic;

    public class MainViewModels
    {

        #region Proprties
        public List<Land> _landList { get; set; }
        public LoginViewModel Login { get; set; }
        public LandsViewModels Lands { get; set; }
        public LandViewModel Land { get; set; }
        #endregion

        #region Constructor
        public MainViewModels()
        {
            _instance = this;
            Login = new LoginViewModel();
        }
        #endregion

        #region StaticAccess
        private static MainViewModels _instance;
        public static MainViewModels Instance()
        {

            if (_instance == null)
                _instance = new MainViewModels();
            return _instance;
        }
        #endregion
    }

}

