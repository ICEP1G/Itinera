using Itinera.Client.ViewModels.Components;
using Itinera.Client.Views.Pages;
using Mopups.Pages;
using Mopups.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Itinera.Client.Views.Modals;

public partial class ReviewDetailModal : PopupPage
{
    public ReviewDetailModal(ReviewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


    private void CloseModal(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}