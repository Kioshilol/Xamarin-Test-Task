using Xamarin.Forms;

namespace HyperTestTask.ViewModels
{
    public class DrawingViewModel : BaseViewModel
    {
        public int Height { get; set; }
        public int Width { get; set; }
        
        public DrawingViewModel(INavigation navigation) : base(navigation)
        {
        }
    }
}