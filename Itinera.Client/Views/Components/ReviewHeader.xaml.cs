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
            if (viewModel.IsViewedFromItinerosPage)
                ChangeReviewStyleToViewedFromItinerosPage(viewModel);

            if (viewModel.IsViewedFromPlacePage)
                ChangeReviewStyleToViewedFromPlacePage(viewModel);

            if (viewModel.ImageUrl is null)
                ToggleImageReviewVisibility();
        }
    }


    private void ToggleImageReviewVisibility()
    {
        // Remove one column in order to only display the text on the top of the review
        this.GridReviewDetailsTop.ColumnDefinitions.Remove(this.GridReviewColumnDetailsTopOne);
        this.GridReviewDetailsTop.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);

    }

    private void ChangeReviewStyleToViewedFromPlacePage(ReviewViewModel viewModel)
    {
        this.IconType.Source = ImageSource.FromFile("itineros_icon.png");
        this.LabelPlaceOrItinerosRelated.Text = $"{viewModel.ItinerosFirstName}, {viewModel.ItinerosCity}";
    }

    private void ChangeReviewStyleToViewedFromItinerosPage(ReviewViewModel viewModel)
    {
        this.BorderItinerosOrPlaceImage.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(60) };
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
            this.GridReviewDetailsTop.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Auto);
            this.GridReviewDetailsTop.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            this.GridReviewDetailsBottom.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Auto);
            this.GridReviewDetailsBottom.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            this.GridReviewDetailsTop.SetColumn(this.BorderImageReview, 0);
            this.GridReviewDetailsTop.SetColumn(this.LabelMessageText, 1);
            this.GridReviewDetailsBottom.SetColumn(this.GridPlaceType, 1);
            this.GridReviewDetailsBottom.SetColumn(this.LabelRelativeDate, 0);

            this.BorderReviewDetails.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(10, 10, 10, 0) };
            this.BorderReviewDetails.BackgroundColor = ResourceHelper.GetColor("LightRed");

            this.BorderImageReview.HorizontalOptions = LayoutOptions.Start;
            this.LabelMessageText.HorizontalOptions = LayoutOptions.Start;
            this.GridPlaceType.HorizontalOptions = LayoutOptions.End;
            this.LabelRelativeDate.HorizontalOptions = LayoutOptions.Start;

            this.BorderImageReview.Margin = new Thickness(0, 0, 10, 0);
            this.GridPlaceType.Margin = new Thickness(24, 0, 0, 0);

            if (viewModel.ImageUrl is not null)
                this.BorderImageReview.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(8, 0, 8, 8) };
        }
        else
        {
            // Main grid component section
            this.GridMainContent.SetColumn(this.BorderItinerosOrPlaceImage, 0);
            this.GridMainContent.SetColumn(this.BorderReviewDetails, 1);
            this.GridReviewDetailsBottom.SetColumn(this.GridPlaceType, 0);
            this.GridReviewDetailsBottom.SetColumn(this.LabelRelativeDate, 1);
            this.BorderItinerosOrPlaceImage.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(60, 60, 60, 0) };

            // Children grid component section
            this.GridReviewDetailsBottom.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
            this.GridReviewDetailsBottom.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Auto);

            this.BorderReviewDetails.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(10, 10, 0, 10) };
            this.BorderReviewDetails.BackgroundColor = ResourceHelper.GetColor("LightGrey");

            this.BorderImageReview.HorizontalOptions = LayoutOptions.End;
            this.LabelMessageText.HorizontalOptions = LayoutOptions.Start;
            this.GridPlaceType.HorizontalOptions = LayoutOptions.Start;
            this.LabelRelativeDate.HorizontalOptions = LayoutOptions.End;

            this.BorderImageReview.Margin = new Thickness(10, 0, 0, 0);
            this.GridPlaceType.Margin = new Thickness(0, 0, 16, 0);

            if (viewModel.ImageUrl is not null)
                this.BorderImageReview.StrokeShape = new RoundRectangle() { CornerRadius = new CornerRadius(0, 8, 8, 8) };

            if (viewModel.IsBackgroundDarker)
                this.BorderReviewDetails.BackgroundColor = ResourceHelper.GetColor("LightDarkerGrey");
        }
    }

}