using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace HyperTestTask.Behaviors
{
    public class EmailValidationBehavior : BaseEntryBehavior
    {
        public static BindableProperty IsEmailCorrectBindableProperty =
            BindableProperty.Create(nameof(IsEmailCorrect), typeof(bool), typeof(EmailValidationBehavior), false);
        
        public bool IsEmailCorrect
        {
            get => (bool)GetValue(IsEmailCorrectBindableProperty);
            set => SetValue(IsEmailCorrectBindableProperty, value);
        }
        
        public EmailValidationBehavior()
        {
            IsValid = OnIsValid;
        }
        
        private bool OnIsValid(string emailAddress)
        {
            IsEmailCorrect = Regex.IsMatch(emailAddress, Constants.EmailPattern);
            return IsEmailCorrect;
        }
    }
}