using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Itinera.Client;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Allow the app window to extend within the status bar
        Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);

        var navigationBar = Window.DecorView;
        navigationBar.ViewTreeObserver.GlobalLayout += (sender, args) =>
        {
            UpdateTabBarPosition();
        };
    }

    private void UpdateTabBarPosition()
    {
        var navigationBarHeight = GetNavigationBarHeight();
        var shell = AppShell.Current as AppShell;

        if (shell is not null)
        {
            // Adjust the position of the TabBar based on the navigation bar height
            shell.Padding = new Thickness(0, 0, 0, navigationBarHeight);
        }
    }

    private int GetNavigationBarHeight()
    {
        int navigationBarHeight = 0;
        var resources = Resources;
        int resourceId = resources.GetIdentifier("navigation_bar_height", "dimen", "android");

        if (resourceId > 0)
        {
            navigationBarHeight = resources.GetDimensionPixelSize(resourceId);
        }

        return navigationBarHeight;
    }

}
