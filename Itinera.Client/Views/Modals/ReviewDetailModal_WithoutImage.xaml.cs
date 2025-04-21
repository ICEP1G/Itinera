using Itinera.Client.Shapes;
using Itinera.Client.ViewModels.Components;
using Mopups.Pages;
using Mopups.Services;

namespace Itinera.Client.Views.Modals;

public partial class ReviewDetailModal_WithoutImage : PopupPage
{
	public ReviewDetailModal_WithoutImage(ReviewViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;

        //this.graphicViewModalShape.Drawable = new ReviewDetailModal_WithoutImage_Shape();
    }


    private void CloseModal(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}