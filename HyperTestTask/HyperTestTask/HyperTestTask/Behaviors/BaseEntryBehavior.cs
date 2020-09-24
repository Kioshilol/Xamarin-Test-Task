using System;
using HyperTestTask.CustomUI;
using Xamarin.Forms;

namespace HyperTestTask.Behaviors
{
    public class BaseEntryBehavior : Behavior<CustomEntry>
    {
        protected Func<string, bool> IsValid;

        protected override void OnAttachedTo(CustomEntry bindable)
        {
            base.OnAttachedTo(bindable);
            
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(CustomEntry bindable)
        {
            base.OnDetachingFrom(bindable);
            
            bindable.TextChanged -= BindableOnTextChanged;
        }
        
        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textValue = e.NewTextValue;
            var emailEntry = sender as CustomEntry;

            if (emailEntry != null) 
                emailEntry.BorderColor = IsValid(textValue) ? Color.Black : Color.Red;
        }
    }
}