using CommunityToolkit.Maui;
using Itinera.Client.CustomControls;
using Microsoft.Extensions.Logging;

namespace Itinera.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("Roboto-SemiBold.ttf", "RobotoSemiBold");
                fonts.AddFont("WorkSans-Light.ttf", "WorkSansLight");
                fonts.AddFont("WorkSans-Regular.ttf", "WorkSansRegular");
                fonts.AddFont("WorkSans-SemiBold.ttf", "WorkSansSemiBold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
