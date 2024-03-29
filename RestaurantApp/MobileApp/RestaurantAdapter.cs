﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobileApp
{
    public class RestaurantAdapter : BaseAdapter<RestaurantItem>
    {
        List<RestaurantItem> items;
        Activity context;
        public RestaurantAdapter(Activity context, List<RestaurantItem> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override RestaurantItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.list_item, null);

            view.FindViewById<TextView>(Resource.Id.restaurantName).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.restaurantDescription).Text = item.Description;
            new DownloadImageTask(view.FindViewById<ImageView>(Resource.Id.restaurantLogo)).Execute(item.ImageUrl);

            return view;
        }
    }
}