using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

namespace MobileApp
{
    [Activity(Label = "RestaurantAddActivity")]
    public class RestaurantAddActivity : Activity
    {
        private TextView _discountDate;
        private string _imageUrl;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_restaurant_add);

            _discountDate = FindViewById<TextView>(Resource.Id.discountAddDate);
            _discountDate.Click += _discountDate_Click;

            FindViewById<Button>(Resource.Id.applyButton).Click += RestaurantAddActivity_Click;

            FindViewById<ImageView>(Resource.Id.restuarantAddLogo).Click += RestaurantAddActivity_Click1;
        }

        private void RestaurantAddActivity_Click1(object sender, EventArgs e)
        {
            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Podaj link do logo");
            var editText = new EditText(this);
            editText.InputType = Android.Text.InputTypes.TextVariationUri;
            dialog.SetView(editText);

            dialog.SetPositiveButton("Dodaj", (c, ev) =>
            {
                _imageUrl = editText.Text;
                new DownloadImageTask(FindViewById<ImageView>(Resource.Id.restuarantAddLogo)).Execute(_imageUrl);
            });

            dialog.Show();
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

            if (string.IsNullOrEmpty(_imageUrl))
            {
                Toast.MakeText(this, "Dodaj logo restauracji", ToastLength.Long).Show();
                return;
            }

            var restaurant = new RestaurantItem()
            {
                Name = restaurantName.Text,
                Description = restaurantDesc.Text,
                DiscountValue = $"-{discountValue.Text}%",
                DiscountDate = discountDate.Text,
                ImageUrl = _imageUrl
            };

            DataBase.Instance.AddRestaurant(restaurant);
            SaveDataBase();

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
            _discountDate.Text = $"{date.Day:D2}.{date.Month:D2}";
        }

        private void SaveDataBase()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("RESTAURACJE", FileCreationMode.Private);
            var restaurants = JsonConvert.SerializeObject(DataBase.Instance.Restaurants);
            pref.Edit().PutString("Restauracje", restaurants).Apply();
        }
    }
}