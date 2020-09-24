using System.ComponentModel;
using Xamarin.Forms;

namespace HyperTestTask.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set;}
        
        public BaseViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
    }
}