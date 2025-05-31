using CommunityToolkit.Maui.Views;

namespace Itinera.Client.Views.Elements;

public partial class PasswordForgot : Popup
{
	public PasswordForgot()
	{
		InitializeComponent();
	}

	private async void OnSendResetClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            return;
        }
        await CloseAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await CloseAsync();
    }
}