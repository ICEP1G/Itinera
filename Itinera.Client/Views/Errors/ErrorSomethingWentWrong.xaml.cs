using System.ComponentModel;

namespace Itinera.Client.Views.Errors;

public partial class ErrorSomethingWentWrong : ContentView
{
    public static readonly BindableProperty ErrorMessageProperty =
        BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ErrorSomethingWentWrong), default(string), propertyChanged: OnErrorMessageChanged);

    private static void OnErrorMessageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ErrorSomethingWentWrong)bindable;
        control.labelErrorMessage.Text = (string)newValue;
    }


    public ErrorSomethingWentWrong()
	{
		InitializeComponent();
    }


    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }
}