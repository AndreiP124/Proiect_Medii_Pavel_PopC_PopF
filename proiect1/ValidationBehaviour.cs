using System;
using System.Collections.Generic;
using System.Text;
using proiect1.Models;
using Xamarin.Forms;

namespace proiect1
{
    class ValidationBehaviour : Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Editor entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            ((Editor)sender).BackgroundColor =
            string.IsNullOrEmpty(args.NewTextValue) ? Color.DarkSlateBlue : Color.Default;
        }
    }
}
