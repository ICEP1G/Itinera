using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    class HomePageViewModel : INotifyPropertyChanged
    {

        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _greetingMessage;
        public string GreetingMessage
        {
            get => _greetingMessage;
            set
            {
                _greetingMessage = value;
                OnPropertyChanged(nameof(GreetingMessage));
            }
        }
        #endregion


        #region Commands Declaration
        public ICommand GreetingsCommand { get; }
        #endregion

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public HomePageViewModel()
        {
            GreetingsCommand = new Command(Greetings);
            Greetings();
        }

        /// <summary>
        /// Method to set the greeting message based on the current time.
        /// </summary>
        private void Greetings()
        {
            int hour = DateTime.Now.Hour;

            switch (hour > 17)
            {
                case true:
                    GreetingMessage = "Good evening";
                    break;
                case false when hour > 12:
                    GreetingMessage = "Good afternoon";
                    break;
                case false when hour > 5:
                    GreetingMessage = "Good morning";
                    break;
                default:
                    GreetingMessage = "Good night";
                    break;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
