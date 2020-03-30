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
        private List<Contact> contactList;
        private Activity parent;

        public ContactListAdapter(List<Contact> contacts, Activity parent)
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
                return this.Count;
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
                viewHolder = new ContactViewHolder();
                viewHolder.NameTextView = convertView.FindViewById<TextView>(Resource.Id.nameTextView);
                viewHolder.EmailImageView = convertView.FindViewById<ImageView>(Resource.Id.emailImageView);
                viewHolder.PhoneNumberTextView = convertView.FindViewById<TextView>(Resource.Id.phoneNumberTextView);
                viewHolder.PhoneImageView = convertView.FindViewById<ImageView>(Resource.Id.phoneNumberImageView);

                convertView.Tag = viewHolder;
            }

            if(viewHolder == null)
            {
                viewHolder = convertView.Tag as ContactViewHolder;
            }
            var contact = contactList[position];

            viewHolder.NameTextView.Text = contact.Name;
            viewHolder.PhoneNumberTextView.Text = contact.PhoneNumber;

                   
            return convertView;
        }
    }
}