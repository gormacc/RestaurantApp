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
    [Activity(Label = "RestaurantActivity")]
    public class RestaurantActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_restaurant);
            var restaurant = JsonConvert.DeserializeObject<RestaurantItem>(Intent.GetStringExtra("Restaurant"));

            FindViewById<Button>(Resource.Id.backButton).Click += RestaurantActivity_Click;

            FindViewById<TextView>(Resource.Id.restaurantDescName).Text = restaurant.Name;
            FindViewById<TextView>(Resource.Id.restaurantDesc).Text = restaurant.Description;
            FindViewById<TextView>(Resource.Id.discountValue).Text = restaurant.DiscountValue;
            FindViewById<TextView>(Resource.Id.discountDate).Text = restaurant.DiscountDate;

            new DownloadImageTask(FindViewById<ImageView>(Resource.Id.restuarantDescLogo)).Execute(restaurant.ImageUrl);

        }

        private void RestaurantActivity_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}