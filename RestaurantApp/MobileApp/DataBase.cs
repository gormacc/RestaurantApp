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
    public class DataBase
    {
        private List<RestaurantItem> _restautants = new List<RestaurantItem>();

        private static DataBase _instance = null;

        public static DataBase Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataBase();
                }

                return _instance;
            }
        }

        private DataBase()
        {
            _restautants = new List<RestaurantItem>()
            {
                new RestaurantItem() {Name = "Nazwa1", Description = "Opis1"},
                new RestaurantItem() {Name = "Nazwa2", Description = "Opis2"},
                new RestaurantItem() {Name = "Nazwa3", Description = "Opis3"},
            };
        }

        public List<RestaurantItem> Restaurants
        {
            get
            {
                return _restautants;
            }
        }

        public void AddRestaurant(RestaurantItem restaurant)
        {
            _restautants.Add(restaurant);
        }
    }
}