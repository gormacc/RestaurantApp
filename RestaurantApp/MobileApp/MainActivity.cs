using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using Newtonsoft.Json;
using System.Collections.Generic;
using Android.Preferences;

namespace MobileApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            SetContentView(Resource.Layout.activity_main);

            var restuarantButton = FindViewById<Button>(Resource.Id.startRestaurantButton);
            restuarantButton.Click += RestuarantButton_Click;

            var clientButton = FindViewById<Button>(Resource.Id.startClientButton);
            clientButton.Click += ClientButton_Click;

            LoadDataBase();
        }

        private void ClientButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RestaurantListActivity));
        }

        private void RestuarantButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void LoadDataBase()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("RESTAURACJE", FileCreationMode.Private);
            var restaurants = pref.GetString("Restauracje", null);

            if (restaurants != null)
            {
                DataBase.Instance.DropDataBase();
                var restaurantsList = JsonConvert.DeserializeObject<List<RestaurantItem>>(restaurants);
                foreach(var rest in restaurantsList)
                {
                    DataBase.Instance.AddRestaurant(rest);
                }
            }
        }


    }
}