using System.Collections.Generic;
using Xamarin.Forms;

namespace HyperTestTask.ViewModels
{
    public class DrawingViewModel : BaseViewModel
    {
        public int ColumnsFirstItemIndex { get; set; }
        public int RowsFirstItemIndex { get; set; }
        public List<int> PickerItems { get; set; }
        
        public DrawingViewModel(INavigation navigation) : base(navigation)
        {
            ColumnsFirstItemIndex = 0;
            RowsFirstItemIndex = 0;
            PickerItems = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        }
    }
}