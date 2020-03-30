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
using ContactList2.Droid.Models;

namespace ContactList2.Droid.Adapters
{
    class ContactListAdapter : BaseAdapter<Contact>
    {
        private List<Models.Contact> contactList;
        private Activity parent;

        public ContactListAdapter(List<Models.Contact> contacts, Activity parent)
        {
            this.contactList = contacts;
            this.parent = parent;
        }

        public override Contact this[int position] {

            get
            {
                return contactList[position];
            }

        }

        public override int Count
        {
            get
            {
                return contactList.Count;
            }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ContactViewHolder viewHolder = null;

            if(convertView == null)
            {
                convertView = this.parent.LayoutInflater.Inflate(Resource.Layout.view_contact, null);
                viewHolder = new ContactViewHolder
                {
                    NameTextView = convertView.FindViewById<TextView>(Resource.Id.nameTextView),
                    EmailImageView = convertView.FindViewById<ImageView>(Resource.Id.emailImageView),
                    PhoneNumberTextView = convertView.FindViewById<TextView>(Resource.Id.phoneNumberTextView),
                    PhoneImageView = convertView.FindViewById<ImageView>(Resource.Id.phoneImageView)
                };
                viewHolder.EmailImageView.Click += EmailImageView_Click;
                viewHolder.PhoneImageView.Click += PhoneImageView_Click;
                convertView.Tag = viewHolder;
            }

            if(viewHolder == null)
            {
                viewHolder = convertView.Tag as ContactViewHolder;
            }
            var contact = contactList[position];

            viewHolder.NameTextView.Text = contact.Name;
            viewHolder.PhoneNumberTextView.Text = contact.PhoneNumber;
            viewHolder.PhoneImageView.Tag = position;
            viewHolder.EmailImageView.Tag = position;
            return convertView;
        }

        private void PhoneImageView_Click(object sender, EventArgs e)
        { 
            //Otwieranie dialera
            var contact = contactList[(int)(sender as ImageView).Tag];
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse(string.Format("tel: {0}", contact.PhoneNumber)));
            parent.StartActivity(intent);
        }

        private void EmailImageView_Click(object sender, EventArgs e)
        {
            //Otwieranie tworzenia maila
            var contact = contactList[(int)(sender as ImageView).Tag];
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("plain/text");
            intent.PutExtra(Intent.ExtraEmail, new string[] { contact.Email });
            parent.StartActivity(intent);

        }

        
    }
}