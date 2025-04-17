using Itinera.Client.Helpers;
using Itinera.Client.Views.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Components
{
    public class TabMenuViewModel : INotifyPropertyChanged, IDisposable
    {
        #region NotifyChanges declaration
        public event EventHandler<int>? TabChanged;
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        // First Tab
        private string firstTabText;
        private int? firstTabCount;
        private bool firstTabHasCount;
        private bool isFirstTabSelected;

        private Color firstTabBorderBackgroundColor;
        private Color firstTabLabelTextColor;
        private string firstTabLabelFontFamily;
        private Color firstTabBadgeBackgroundColor;
        private Color firstTabBadgeTextColor;

        // Second Tab
        private string secondTabText;
        private int? secondTabCount;
        private bool secondTabHasCount;
        private bool isSecondTabSelected;

        private Color secondTabBorderBackgroundColor;
        private Color secondTabLabelTextColor;
        private string secondTabLabelFontFamily;
        private Color secondTabBadgeBackgroundColor;
        private Color secondTabBadgeTextColor;
        #endregion

        #region Commands declaration
        public ICommand ChangeForFirstTabCommand { get; }
        public ICommand ChangeForSecondTabCommand { get; }
        #endregion

        public TabMenuViewModel(string firstTabText, int? firstTabCount, string secondTabText, int? secondTabCount)
        {
            FirstTabText = firstTabText;
            FirstTabCount = firstTabCount;
            if (FirstTabCount is not null) { FirstTabHasCount = true; }

            SecondTabText = secondTabText;
            SecondTabCount = secondTabCount;
            if (SecondTabCount is not null) { SecondTabHasCount = true; }

            ChangeToFirstTab();

            // Commands
            ChangeForFirstTabCommand = new Command(ChangeToFirstTab);
            ChangeForSecondTabCommand = new Command(ChangeToSecondTab);
        }


        #region FirstTab
        public string FirstTabText
        {
            get { return firstTabText; }
            set { firstTabText = value; OnPropertyChanged(nameof(FirstTabText)); }
        }

        public int? FirstTabCount
        {
            get { return firstTabCount; }
            set { firstTabCount = value; OnPropertyChanged(nameof(FirstTabCount)); }
        }

        public bool FirstTabHasCount
        {
            get { return firstTabHasCount; }
            set { firstTabHasCount = value; OnPropertyChanged(nameof(FirstTabHasCount)); }
        }

        public bool IsFirstTabSelected
        {
            get { return isFirstTabSelected; }
            set { isFirstTabSelected = value; OnPropertyChanged(nameof(IsFirstTabSelected)); }
        }

        // Style
        public Color FirstTabBorderBackgroundColor
        {
            get => firstTabBorderBackgroundColor;
            set { firstTabBorderBackgroundColor = value; OnPropertyChanged(nameof(FirstTabBorderBackgroundColor)); }
        }

        public Color FirstTabLabelTextColor
        {
            get => firstTabLabelTextColor;
            set { firstTabLabelTextColor = value; OnPropertyChanged(nameof(FirstTabLabelTextColor)); }
        }

        public string FirstTabLabelFontFamily
        {
            get => firstTabLabelFontFamily;
            set { firstTabLabelFontFamily = value; OnPropertyChanged(nameof(FirstTabLabelFontFamily)); }
        }

        public Color FirstTabBadgeBackgroundColor
        {
            get { return firstTabBadgeBackgroundColor; }
            set { firstTabBadgeBackgroundColor = value; OnPropertyChanged(nameof(FirstTabBadgeBackgroundColor)); }
        }

        public Color FirstTabBadgeTextColor
        {
            get { return firstTabBadgeTextColor; }
            set { firstTabBadgeTextColor = value; OnPropertyChanged(nameof(FirstTabBadgeTextColor)); }
        }
        #endregion

        #region SecondTab
        public string SecondTabText
        {
            get { return secondTabText; }
            set { secondTabText = value; OnPropertyChanged(nameof(SecondTabText)); }
        }

        public int? SecondTabCount
        {
            get { return secondTabCount; }
            set { secondTabCount = value; OnPropertyChanged(nameof(SecondTabCount)); }
        }

        public bool SecondTabHasCount
        {
            get { return secondTabHasCount; }
            set { secondTabHasCount = value; OnPropertyChanged(nameof(SecondTabHasCount)); }
        }

        public bool IsSecondTabSelected
        {
            get { return isSecondTabSelected; }
            set { isSecondTabSelected = value; OnPropertyChanged(nameof(IsSecondTabSelected)); }
        }

        // Style
        public Color SecondTabBorderBackgroundColor
        {
            get => secondTabBorderBackgroundColor;
            set { secondTabBorderBackgroundColor = value; OnPropertyChanged(nameof(SecondTabBorderBackgroundColor)); }
        }

        public Color SecondTabLabelTextColor
        {
            get => secondTabLabelTextColor;
            set { secondTabLabelTextColor = value; OnPropertyChanged(nameof(SecondTabLabelTextColor)); }
        }

        public string SecondTabLabelFontFamily
        {
            get => secondTabLabelFontFamily;
            set { secondTabLabelFontFamily = value; OnPropertyChanged(nameof(SecondTabLabelFontFamily)); }
        }

        public Color SecondTabBadgeBackgroundColor
        {
            get { return secondTabBadgeBackgroundColor; }
            set { secondTabBadgeBackgroundColor = value; OnPropertyChanged(nameof(SecondTabBadgeBackgroundColor)); }
        }

        public Color SecondTabBadgeTextColor
        {
            get { return secondTabBadgeTextColor; }
            set { secondTabBadgeTextColor = value; OnPropertyChanged(nameof(SecondTabBadgeTextColor)); }
        }

        #endregion


        private void ChangeToFirstTab()
        {
            if (IsFirstTabSelected is not true)
            {
                IsFirstTabSelected = true;
                FirstTabBorderBackgroundColor = ResourceHelper.GetColor("Primary");
                FirstTabLabelTextColor = ResourceHelper.GetColor("White");
                FirstTabLabelFontFamily = "PoppinsSemiBold";

                IsSecondTabSelected = false;
                SecondTabBorderBackgroundColor = Color.FromRgba(0, 0, 0, 0);
                SecondTabLabelTextColor = ResourceHelper.GetColor("PrimaryDarkText");
                SecondTabLabelFontFamily = "PoppinsMedium";

                // Change the badge color if there is one
                if (FirstTabCount is not null)
                {
                    FirstTabBadgeBackgroundColor = ResourceHelper.GetColor("White");
                    FirstTabBadgeTextColor = ResourceHelper.GetColor("Primary");
                }

                if (SecondTabCount is not null)
                {
                    SecondTabBadgeBackgroundColor = ResourceHelper.GetColor("Primary");
                    SecondTabBadgeTextColor = ResourceHelper.GetColor("White");
                }

                TabChanged?.Invoke(this, 0);
            }
        }

        private void ChangeToSecondTab()
        {
            if (IsSecondTabSelected is not true)
            {
                IsSecondTabSelected = true;
                SecondTabBorderBackgroundColor = ResourceHelper.GetColor("Primary");
                SecondTabLabelTextColor = ResourceHelper.GetColor("White");
                SecondTabLabelFontFamily = "PoppinsSemiBold";

                IsFirstTabSelected = false;
                FirstTabBorderBackgroundColor = Color.FromRgba(0, 0, 0, 0);
                FirstTabLabelTextColor = ResourceHelper.GetColor("PrimaryDarkText");
                FirstTabLabelFontFamily = "PoppinsMedium";

                // Change the badge color if there is one
                if (SecondTabCount is not null)
                {
                    SecondTabBadgeBackgroundColor = ResourceHelper.GetColor("White");
                    SecondTabBadgeTextColor = ResourceHelper.GetColor("Primary");
                }

                if (FirstTabCount is not null)
                {
                    FirstTabBadgeBackgroundColor = ResourceHelper.GetColor("Primary");
                    FirstTabBadgeTextColor = ResourceHelper.GetColor("White");
                }

                TabChanged?.Invoke(this, 1);
            }
        }



        public void Dispose()
        {
            TabChanged = null;
        }
    }
}

