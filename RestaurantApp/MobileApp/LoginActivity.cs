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
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            FindViewById<Button>(Resource.Id.loginButton).Click += LoginActivity_Click;
        }

        private void LoginActivity_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RestaurantAddActivity));
        }
    }
}