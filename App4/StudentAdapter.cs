using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App4
{
    public class PersonAdapter : BaseAdapter<Person>
    {
        public List<Person> objects;
        private Context context;
        public PersonAdapter(Context context, List<Person> list)
        {
            objects = list;
            this.context = context;
        }
        public override Person this[int position]
        {
            get
            {
                return objects[position];
            }
        }
        public override int Count
        {
            get
            {
                return objects.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (convertView == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.listviewLayout, null, false);
            }
            TextView tv1 = view.FindViewById<TextView>(Resource.Id.id);
            TextView tv2 = view.FindViewById<TextView>(Resource.Id.name);
            Person std = objects[position];
            if (std != null)
            {
                tv1.Text = "" + std.PersonId;
                tv2.Text = std.Name;
            }
            return view;
        }
    }
}