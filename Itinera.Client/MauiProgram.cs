using CommunityToolkit.Maui;
using Itinera.Client.CustomControls;
using Itinera.Client.Helpers;
using Itinera.Client.Services;
using Itinera.Client.ViewModels;
using Itinera.Client.ViewModels.Components;
using Itinera.Client.ViewModels.Pages;
using Itinera.Client.Views.Components;
using Itinera.Client.Views.Modals;
using Itinera.Client.Views.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls.Embedding;
using Mopups.Hosting;
using System.Security.Claims;

namespace Itinera.Client;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureMopups()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("Roboto-SemiBold.ttf", "RobotoSemiBold");
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                fonts.AddFont("WorkSans-Light.ttf", "WorkSansLight");
                fonts.AddFont("WorkSans-Regular.ttf", "WorkSansRegular");
                fonts.AddFont("WorkSans-SemiBold.ttf", "WorkSansSemiBold");
            });


        // Get the configuration file when building on any devices type
        builder.Configuration.AddJsonFile(new EmbeddedFileProvider
            (typeof(App).Assembly, typeof(App).Namespace), "appsettings.json", false, true);

        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
        builder.Services.AddSingleton<FakeDataService>();
        builder.Services.AddSingleton<IItinerosService, FakeItinerosService>();
        builder.Services.AddSingleton<IPlaceService, FakePlaceService>();
        builder.Services.AddSingleton<IPlacelistService, FakePlacelistService>();
        builder.Services.AddSingleton<IReviewService, FakeReviewService>();
        // Pages
        builder.Services.AddTransient<TestsPage, TestsPageViewModel>();
        builder.Services.AddTransient<TestsReviewsPage, TestsReviewsPageViewModel>();
        builder.Services.AddTransient<PlacelistPage, PlacelistPageViewModel>();
        builder.Services.AddTransient<PlacePage, PlacePageViewModel>();
        builder.Services.AddTransient<ItinerosPage, ItinerosPageViewModel>();
        // ContentViews
        builder.Services.AddTransient<PlacelistHeader, PlacelistHeaderViewModel>();
        builder.Services.AddTransient<PlaceHeader, PlaceHeaderViewModel>();
        // Modals

        //builder.Services.AddHttpClient<IItinerosService, ItinerosService>(Client => Client.BaseAddress = new Uri("http://localhost:5001/"));
        //builder.Services.AddHttpClient<IPlaceService, PlaceService>(Client => Client.BaseAddress = new Uri("http://localhost:5001/"));
        //builder.Services.AddHttpClient<IPlacelistService, PlacelistService>(Client => Client.BaseAddress = new Uri("http://localhost:5001/"));


#if DEBUG
        builder.Logging.AddDebug();
#endif

        MauiApp mauiApp = builder.Build();
        return mauiApp;
	}

}
