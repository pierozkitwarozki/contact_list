using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace ContactList2.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private List<Models.Contact> contacts;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button addButton = FindViewById<Button>(Resource.Id.addButton);
            addButton.Click += delegate { };

            var contactListView = FindViewById<ListView>(Resource.Id.contactListView);
            contactListView.Adapter = new Adapters.ContactListAdapter(this.contacts, this);
        }

        private void Initialize()
        {
            this.contacts = new List<Models.Contact>();
            for(int i=1; i<=20; i++)
            {
                this.contacts.Add(new Models.Contact("My contact nr " + i,
                    "email@gmail.com",
                    "123-456-789"));
            }
        }
       
    }
}