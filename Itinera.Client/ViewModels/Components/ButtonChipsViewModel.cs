using Itinera.Client.Helpers;
using System.ComponentModel;

namespace Itinera.Client.ViewModels.Components
{
    public class ButtonChipsViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private bool isLoading;
        private bool isToggleState;
        private string actualStateString;
        private string iconImageUri;
        private string defaultStateText;
        private string toggleStateText;

        private Brush brushColor;
        private Color color;
        private double? size;
        private double? translationY;
        #endregion

        public ButtonChipsViewModel(bool isToggleState, string defaultStateText, string toggleStateText, string iconImageUri, double? size = 12, double? translationY = null)
        {
            IsToggleState = isToggleState;
            ActualStateString = IsToggleState ? toggleStateText : defaultStateText;
            DefaultStateText = defaultStateText;
            ToggleStateText = toggleStateText;
            IconImageUri = iconImageUri;
            Size = size;
            TranslationY = translationY;
        }


        #region Public porperties
        public bool IsToggleState
        {
            get { return isToggleState; }
            set { isToggleState = value; OnPropertyChanged(nameof(IsToggleState)); ChangeButtonChipsStyle(value); }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(nameof(IsLoading)); ChangeButtonChipsToLoadingStyle(value); }
        }

        public string ActualStateString
        {
            get { return actualStateString; }
            set { actualStateString = value; OnPropertyChanged(nameof(ActualStateString)); }
        }

        public string IconImageUri
        {
            get { return iconImageUri; }
            set { iconImageUri = value; OnPropertyChanged(nameof(IconImageUri)); }
        }

        public string DefaultStateText
        {
            get { return defaultStateText; }
            set { defaultStateText = value; OnPropertyChanged(nameof(DefaultStateText)); }
        }

        public string ToggleStateText
        {
            get { return toggleStateText; }
            set { toggleStateText = value; OnPropertyChanged(nameof(ToggleStateText)); }
        }


        public Brush BrushColor
        {
            get { return brushColor; }
            set { brushColor = value; OnPropertyChanged(nameof(BrushColor)); }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(nameof(Color)); }
        }

        public double? Size
        {
            get { return size; }
            set { size = value; OnPropertyChanged(nameof(Size)); }
        }

        public double? TranslationY
        {
            get { return translationY; }
            set { translationY = value; }
        }
        #endregion


        private void ChangeButtonChipsToLoadingStyle(bool isLoading)
        {
            if (isLoading)
            {
                Color greyColor = ResourceHelper.GetColor("LightDarkerGrey");
                BrushColor = (Brush)greyColor;
                Color = greyColor;
            }
        }

        private void ChangeButtonChipsStyle(bool IsToggleState)
        {
            if (IsToggleState)
            {
                Color accentColor = ResourceHelper.GetColor("Accent");
                BrushColor = (Brush)accentColor;
                Color = accentColor;
                ActualStateString = ToggleStateText;
            }
            else
            {
                Color tertiaryColor = ResourceHelper.GetColor("Tertiary");
                BrushColor = (Brush)tertiaryColor;
                Color = tertiaryColor;
                ActualStateString = DefaultStateText;
            }
        }
    }
}
