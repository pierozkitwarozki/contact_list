using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ContactList2.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static string NEW_CONTACT_KEY = "NEW_CONTACT_KEY";
        private static int ADD_CONTACT_REQUEST_CODE = 200;
        private Adapters.ContactListAdapter adapter;

        private List<ContactList2.Models.Contact> contacts = new List<ContactList2.Models.Contact>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button addButton = FindViewById<Button>(Resource.Id.addButton);
            addButton.Click += delegate
            {
                StartActivityForResult(typeof(Activities.AddActivity), ADD_CONTACT_REQUEST_CODE);
            };
            contacts = ContactList2.BLL.ContactListDataSource.GetContacts();
            ListView contactListView = FindViewById<ListView>(Resource.Id.contactListView);
            adapter = new Adapters.ContactListAdapter(contacts, this);
            contactListView.Adapter = adapter;
            contactListView.ItemLongClick += ItemLongClicked;
            
        }

        

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == ADD_CONTACT_REQUEST_CODE && data != null)
            {
                var newContact =
                    JsonConvert.DeserializeObject<ContactList2.Models.Contact>(data.GetStringExtra(NEW_CONTACT_KEY));
                contacts.Add(newContact);
                adapter.NotifyDataSetChanged();
            }
        }

        private void ItemLongClicked(object sender, AdapterView.ItemLongClickEventArgs args)
        {
            var contact = contacts[args.Position];

            var alert = new Android.App.AlertDialog.Builder(this).Create();
            alert.SetTitle("Delete contact");
            alert.SetMessage(string.Format("Are you sure you want to delete {0}?", contact.Name));
            alert.SetButton("Yes", delegate
            {
                contacts.Remove(contact);
                adapter.NotifyDataSetChanged();
            });
            alert.SetButton2("No", delegate{ });
            alert.Show();


        }

    }
}