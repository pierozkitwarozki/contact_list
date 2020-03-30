using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ContactList2.Droid.Models
{
    class ContactViewHolder: Java.Lang.Object
    {
        public TextView NameTextView { get; set; }
        public TextView PhoneNumberTextView { get; set; }
        public ImageView EmailImageView { get; set; }
        public ImageView PhoneImageView { get; set; }
    }
}