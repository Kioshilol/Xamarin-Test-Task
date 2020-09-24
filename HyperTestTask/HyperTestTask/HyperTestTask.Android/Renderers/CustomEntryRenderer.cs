using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using HyperTestTask.Android.Renderers;
using HyperTestTask.CustomUI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace HyperTestTask.Android.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntry ElementV2 => Element as CustomEntry;

        public CustomEntryRenderer(Context context) : base(context)
        {
            
        }

        protected override FormsEditText CreateNativeControl()
        {
            var control = base.CreateNativeControl();
            UpdateBackground(control);
            return control;
        }
        
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CustomEntry.BorderColorProperty.PropertyName)
            {
                UpdateBackground(Control);
            }

            base.OnElementPropertyChanged(sender, e);
        }

        private void UpdateBackground(FormsEditText formsEditText)
        {
            if(formsEditText == null)
                return;
            
            var gd = new GradientDrawable();
            gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
            formsEditText.SetBackground(gd);
        }
    }
}