using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Helpers
{
    public static class ServiceProviderHelper
    {
        /// <summary>
        /// Allow to retrieve any register services for the whole application with all it's dependency resolved
        /// </summary>
        public static TService GetService<TService>()
            => Current.GetService<TService>();

        public static IServiceProvider Current =>
    #if WINDOWS10_0_17763_0_OR_GREATER
        MauiWinUIApplication.Current.Services;
    #elif ANDROID
            MauiApplication.Current.Services;
    #elif IOS || MACCATALYST
            MauiUIApplicationDelegate.Current.Services;
    #else
        null;
    #endif
    }
}
