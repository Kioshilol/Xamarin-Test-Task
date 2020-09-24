using HyperTestTask.Behaviors;
using HyperTestTask.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperTestTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private EmailValidationBehavior _emailValidationBehavior;
        private PasswordValidationBehavior _passwordValidationBehavior;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
            SetupBehaviors();
            SetupBindings();
        }

        private void SetupBehaviors()
        {
            _emailValidationBehavior = new EmailValidationBehavior();
            loginInput.Behaviors.Add( _emailValidationBehavior);

            _passwordValidationBehavior = new PasswordValidationBehavior();
            passwordInput.Behaviors.Add( _passwordValidationBehavior);
        }

        private void SetupBindings()
        {
            _emailValidationBehavior.SetBinding(EmailValidationBehavior.IsEmailCorrectBindableProperty,
                new Binding { Source = BindingContext, Path = "IsEmailCorrect", Mode = BindingMode.OneWayToSource });
            _passwordValidationBehavior.SetBinding(PasswordValidationBehavior.IsPasswordCorrectBindableProperty,
                new Binding { Source = BindingContext, Path = "IsPasswordCorrect", Mode = BindingMode.OneWayToSource });
        }
    }
}