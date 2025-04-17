using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Microsoft.Maui.Controls.Shapes;

namespace Itinera.Client.Views.Components;

public partial class ReviewHeader : ContentView
{

	public ReviewHeader()
	{
		InitializeComponent();
    }


    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is ReviewViewModel viewModel)
        {
            ToggleReviewStyleDirection(viewModel);
            if (viewModel.IsViewFromItinerosPage)
                ChangeReviewStyleToViewedFromItinerosPage(viewModel);

            if (viewModel.ImageUrl is null)
                ToggleImageReviewVisibility();
        }
    }


    private void ToggleImageReviewVisibility()
    {
        // Remove one column in order to only display the text on the top of the review
        this.GridReviewDetails.ColumnDefinitions.Remove(this.GridReviewColumnDetailsOne);
        this.GridReviewDetails.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
    }

    private void ChangeReviewStyleToViewedFromItinerosPage(ReviewViewModel viewModel)
    {
        this.BorderItinerosOrPlaceImage.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(60) };
        this.IconType.Source = ImageSource.FromFile("itineros_icon.png");
        this.LabelPlaceOrItinerosRelated.Text = $"{viewModel.ItinerosFirstName}, {viewModel.ItinerosCity}";
        this.ImageItinerosOrPlace.Source = viewModel.PlaceFirstPictureUrl;
    }

    /// <summary>
    /// Change the component style in order to look differently when it's "odd" or "even" in a collection
    /// </summary>
    /// <param name="viewModel"></param>
    private void ToggleReviewStyleDirection(ReviewViewModel viewModel)
    {
        if (viewModel.IsEven)
        {
            // Main grid component section
            this.GridMainContent.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
            this.GridMainContent.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Auto);
            this.GridMainContent.SetColumn(this.BorderItinerosOrPlaceImage, 1);
            this.GridMainContent.SetColumn(this.BorderReviewDetails, 0);
            this.BorderItinerosOrPlaceImage.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(60, 60, 0, 60) };

            // Children grid component section
            this.GridReviewDetails.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Auto);
            this.GridReviewDetails.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            this.GridReviewDetails.SetColumn(this.BorderImageReview, 0);
            this.GridReviewDetails.SetColumn(this.LabelMessageText, 1);
            this.GridReviewDetails.SetColumn(this.StackLayoutPlaceType, 1);
            this.GridReviewDetails.SetColumn(this.LabelRelativeDate, 0);

            this.BorderImageReview.HorizontalOptions = LayoutOptions.Start;
            this.LabelMessageText.HorizontalOptions = LayoutOptions.Start;
            this.LabelRelativeDate.HorizontalOptions = LayoutOptions.Start;
            this.StackLayoutPlaceType.HorizontalOptions = LayoutOptions.End;

            this.BorderReviewDetails.BackgroundColor = ResourceManager.GetColor("LightRed");
            this.BorderReviewDetails.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(10, 10, 10, 0) };
            if (viewModel.ImageUrl is not null)
            {
                this.BorderImageReview.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(8, 0, 8, 8) };
            }
        }
        else
        {
            this.GridMainContent.SetColumn(this.BorderItinerosOrPlaceImage, 0);
            this.GridMainContent.SetColumn(this.BorderReviewDetails, 1);
            this.GridReviewDetails.SetColumn(this.StackLayoutPlaceType, 0);
            this.GridReviewDetails.SetColumn(this.LabelRelativeDate, 1);
            this.BorderItinerosOrPlaceImage.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(60, 60, 60, 0) };

            this.BorderImageReview.HorizontalOptions = LayoutOptions.End;
            this.LabelMessageText.HorizontalOptions = LayoutOptions.Start;
            this.LabelRelativeDate.HorizontalOptions = LayoutOptions.End;
            this.StackLayoutPlaceType.HorizontalOptions = LayoutOptions.Start;

            this.BorderReviewDetails.BackgroundColor = ResourceManager.GetColor("LightGrey");
            this.BorderReviewDetails.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(10, 10, 0, 10) };
            if (viewModel.ImageUrl is not null)
            {
                this.BorderImageReview.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(0, 8, 8, 8) };
            }

            if (viewModel.IsBackgroundDarker)
                this.BorderReviewDetails.BackgroundColor = ResourceManager.GetColor("LightDarkerGrey");
        }
    }

}