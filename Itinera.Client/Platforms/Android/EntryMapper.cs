using Android.Graphics.Drawables;
using Itinera.Client.CustomControls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Android.Graphics;
using Microsoft.Maui.Graphics;
using Color = Android.Graphics.Color;

namespace Itinera.Client.Platforms.Android
{
    public static class EntryMapper
    {
        public static void Map(IElementHandler handler, IElement view)
        {
            if (view is BaseEntry baseEntry)
            {
                var casted = (EntryHandler)handler;
                var gd = new GradientDrawable();

                Color color = new(205, 79, 57, 1);

                gd.SetCornerRadius(baseEntry.CornerRadius);
                gd.SetStroke(baseEntry.BorderThickness, color);
            }
        }
    }
}
