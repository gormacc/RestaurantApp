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

namespace MobileApp
{
    [Activity(Label = "RestaurantListActivity")]
    public class RestaurantListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_list);

            var resturantList = FindViewById<ListView>(Resource.Id.restaurantList);
            resturantList.Adapter = new RestaurantAdapter(this, MockItems);
        }

        private List<RestaurantItem> MockItems = new List<RestaurantItem>()
        {
            new RestaurantItem() {RestaurantName = "Nazwa1", RestaurantDescription = "Opis1"},
            new RestaurantItem() {RestaurantName = "Nazwa2", RestaurantDescription = "Opis2"},
            new RestaurantItem() {RestaurantName = "Nazwa3", RestaurantDescription = "Opis3"},
        };

    }
}