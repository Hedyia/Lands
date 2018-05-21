
namespace Lands.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            imgOnu.Source = ImageSource.FromResource("Lands.Images.onu.png");
            imgFb.Source = ImageSource.FromResource("Lands.Images.fb.png");
            imgGoogle.Source = ImageSource.FromResource("Lands.Images.google.png");
            imgTwitter.Source = ImageSource.FromResource("Lands.Images.twitter.png");
        }
	}
}