using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace MobileApp
{
    [Activity(Label = "RestaurantAddActivity")]
    public class RestaurantAddActivity : Activity
    {
        private TextView _discountDate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_restaurant_add);

            _discountDate = FindViewById<TextView>(Resource.Id.discountAddDate);
            _discountDate.Click += _discountDate_Click;

            FindViewById<Button>(Resource.Id.applyButton).Click += RestaurantAddActivity_Click;
        }

        private void RestaurantAddActivity_Click(object sender, EventArgs e)
        {
            var restaurantName = FindViewById<EditText>(Resource.Id.restaurantAddName);
            var restaurantDesc = FindViewById<EditText>(Resource.Id.restaurantAddDesc);
            var discountValue = FindViewById<EditText>(Resource.Id.discountAddValue);
            var discountDate = FindViewById<TextView>(Resource.Id.discountAddDate);

            if(restaurantName.Text == string.Empty)
            {
                Toast.MakeText(this, "Dodaj nazwę restauracji", ToastLength.Long).Show();
                return;
            }

            if (restaurantDesc.Text == string.Empty)
            {
                Toast.MakeText(this, "Dodaj opis restauracji", ToastLength.Long).Show();
                return;
            }

            if (discountValue.Text == string.Empty)
            {
                Toast.MakeText(this, "Dodaj ilość zniżki", ToastLength.Long).Show();
                return;
            }

            if (discountDate.Text == string.Empty)
            {
                Toast.MakeText(this, "Wpisz datę zniżki", ToastLength.Long).Show();
                return;
            }

            var restaurant = new RestaurantItem()
            {
                Name = restaurantName.Text,
                Description = restaurantDesc.Text,
                DiscountValue = $"-{discountValue.Text}%",
                DiscountDate = discountDate.Text,
            };

            DataBase.Instance.AddRestaurant(restaurant);

            Toast.MakeText(this, "Dodano restaurację", ToastLength.Long).Show();
        }

        private void _discountDate_Click(object sender, EventArgs e)
        {
            DatePickerDialog datePicker = new DatePickerDialog(this);
            datePicker.DateSet += DatePicker_DateSet;
            datePicker.Show();
        }

        private void DatePicker_DateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            var date = e.Date;
            _discountDate.Text = $"{date.Day}.{date.Month:D2}";
        }
    }
}