using System.Windows.Input;
using HyperTestTask.Views;
using Xamarin.Forms;

namespace HyperTestTask.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsEmailCorrect { get; set; }
        public bool IsPasswordCorrect { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            LoginCommand = new Command(OnLoginCommand);
        }

        private async void OnLoginCommand()
        {
            ErrorMessage = string.Empty;
            
            if (IsEmailCorrect && IsPasswordCorrect)
            {
                await Navigation.PushAsync(new DrawingPage());
            }
            else
            {
                if (!IsEmailCorrect)
                    ErrorMessage += "Email is incorrect ";
                if(!IsPasswordCorrect)
                    ErrorMessage += "Password is incorrect ";
            }
        }
    }
}