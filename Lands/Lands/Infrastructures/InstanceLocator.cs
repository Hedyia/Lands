namespace Lands.Infrastructures
{
    using ViewModels;
    public class InstanceLocator
    {
        #region Proprties
        public MainViewModels Main { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            Main = new MainViewModels();
        }
        #endregion

    }
}
