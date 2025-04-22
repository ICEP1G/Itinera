using Foundation;
using UIKit;

namespace Itinera.Client;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        //UIApplication.SharedApplication.SetStatusBarHidden(true, UIStatusBarAnimation.None);
        return base.FinishedLaunching(app, options);
    }
}
