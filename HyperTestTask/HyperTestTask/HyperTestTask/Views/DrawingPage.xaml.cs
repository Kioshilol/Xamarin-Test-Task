using System;
using HyperTestTask.CustomUI;
using HyperTestTask.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperTestTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawingPage : ContentPage
    {
        private const int MaxCellCount = MaxColumns * MaxRows;
        private const int MaxColumns = 15;
        private const int MaxRows = 15;
        private int _cellWidth = App.ScreenWidth / MaxColumns;
        private int _cellHeight = (App.ScreenHeight / MaxRows) / 2;
        private int _cellSpacing;
        
        public DrawingPage()
        {
            InitializeComponent();
            BindingContext = new DrawingViewModel(Navigation);
            SetupView();
        }

        private void SetupView()
        {
            _cellSpacing = _cellHeight / 2;
            
            while (AbsoluteLayout.Children.Count < MaxCellCount)
            {
                var cell = new HyperCell(_cellHeight + _cellSpacing);
                AbsoluteLayout.Children.Add(cell);
            }
            
            rowsPicker.SelectedIndexChanged += RowsPickerOnSelectedIndexChanged;
            columnsPicker.SelectedIndexChanged += ColumnsPickerOnSelectedIndexChanged;
            CreateGrid();
            UpdateGrid((int)columnsPicker.SelectedItem, (int)rowsPicker.SelectedItem);
        }

        private void RowsPickerOnSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid((int)columnsPicker.SelectedItem, (int)rowsPicker.SelectedItem);
        }
        
        private void ColumnsPickerOnSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid((int)columnsPicker.SelectedItem, (int)rowsPicker.SelectedItem);
        }

        private void CreateGrid()
        {
            int index = 0;
            
            for (int c = 0; c < MaxColumns; c++)
            {
                for (int r = 0; r < MaxRows; r++)
                {    
                    
                    HyperCell lifeCell = lifeCell = (HyperCell)AbsoluteLayout.Children[index];
                    lifeCell.Rows = c;
                    lifeCell.Columns = r;
                    lifeCell.IsVisible = false;
                    
                    Rectangle rect = new Rectangle(r * _cellWidth, c * _cellHeight, _cellWidth + _cellSpacing, _cellHeight + _cellSpacing);
                    AbsoluteLayout.SetLayoutBounds(lifeCell, rect);
                    index++;
                }
            }
        }
       
        private void UpdateGrid(int columns, int rows)
        {
            foreach (var child in AbsoluteLayout.Children)
            {
                var hyperCell = (HyperCell) child;

                if (hyperCell.Rows < rows && hyperCell.Columns < columns)
                    hyperCell.IsVisible = true;
                else
                    hyperCell.IsVisible = false;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            rowsPicker.SelectedIndexChanged -= RowsPickerOnSelectedIndexChanged;
            columnsPicker.SelectedIndexChanged -= ColumnsPickerOnSelectedIndexChanged;
        }
    }
}