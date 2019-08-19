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
            var login = FindViewById<EditText>(Resource.Id.loginValue).Text.ToLower();
            var password = FindViewById<EditText>(Resource.Id.passwordValue).Text.ToLower();

            if(login == "robert" && password == "flaga")
            {
                StartActivity(typeof(RestaurantAddActivity));
            }
            else if(login == "wyczysc" && password == "liste")
            {
                DataBase.Instance.DropDataBase();
            }
            else
            {
                Toast.MakeText(this, "Błędny login lub hasło", ToastLength.Short).Show();
            }

        }
    }
}