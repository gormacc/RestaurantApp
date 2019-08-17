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
using Newtonsoft.Json;

namespace MobileApp
{
    [Activity(Label = "RestaurantListActivity")]
    public class RestaurantListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_list);

            var restaurantList = FindViewById<ListView>(Resource.Id.restaurantList);
            restaurantList.Adapter = new RestaurantAdapter(this, MockItems);

            restaurantList.ItemClick += RestaurantList_ItemClick;
        }

        private void RestaurantList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var activity = new Intent(this, typeof(RestaurantActivity));

            var restaurant = MockItems[e.Position];
            activity.PutExtra("Restaurant", JsonConvert.SerializeObject(restaurant));

            StartActivity(activity);
        }

        private List<RestaurantItem> MockItems = new List<RestaurantItem>()
        {
            new RestaurantItem() {Name = "Nazwa1", Description = "Opis1"},
            new RestaurantItem() {Name = "Nazwa2", Description = "Opis2"},
            new RestaurantItem() {Name = "Nazwa3", Description = "Opis3"},
        };

    }
}