using System.ComponentModel;
using HyperTestTask.CustomUI;
using HyperTestTask.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace HyperTestTask.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntry ElementV2 => Element as CustomEntry;
        
        protected override UITextField CreateNativeControl()
        {
            var control = new UITextField
            {
                BorderStyle = UITextBorderStyle.RoundedRect
            };
            
            control.Layer.BorderWidth = ElementV2.BorderThickness;
            UpdateBackground(control);
            return control;
        }
        
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == CustomEntry.BorderColorProperty.PropertyName)
                UpdateBackground(Control);
            
            base.OnElementPropertyChanged(sender, e);
        }

        private void UpdateBackground(UITextField uiTextField)
        {
            uiTextField.Layer.BorderColor = ElementV2.BorderColor.ToCGColor();
        }
    }
}