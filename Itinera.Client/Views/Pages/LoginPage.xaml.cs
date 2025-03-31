using Itinera.Client.ViewModels;

namespace Itinera.Client
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }

        public void GoCreateAccount(object sender, EventArgs e)
        {
            // Thomas M : Je le laisse le temps de finir le viewModel sinon BOOM
        }
    }
}
