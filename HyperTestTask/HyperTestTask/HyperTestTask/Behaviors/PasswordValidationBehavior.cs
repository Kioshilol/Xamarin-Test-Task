using Xamarin.Forms;

namespace HyperTestTask.Behaviors
{
    public class PasswordValidationBehavior : BaseEntryBehavior
    {
        public static BindableProperty IsPasswordCorrectBindableProperty =
            BindableProperty.Create(nameof(IsPasswordCorrect), typeof(bool), typeof(PasswordValidationBehavior), false);
        
        public bool IsPasswordCorrect
        {
            get => (bool)GetValue(IsPasswordCorrectBindableProperty);
            set => SetValue(IsPasswordCorrectBindableProperty, value);
        }
        
        public PasswordValidationBehavior()
        {
            IsValid = OnIsValid;
        }
        
        private bool OnIsValid(string password)
        {
            IsPasswordCorrect = password.Length > 6 && password.Length < 30;
            return IsPasswordCorrect;
        }
    }
}