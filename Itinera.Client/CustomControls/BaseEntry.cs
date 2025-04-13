using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.CustomControls
{
    public sealed class BaseEntry : Entry
    {
        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(BaseEntry), 0);

        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(BaseEntry), 1);

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColorProperty), typeof(int), typeof(BaseEntry), Color.FromArgb("E1DEE0"));

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public int BorderColor
        {
            get => (int)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
    }
}
