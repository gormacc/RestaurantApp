using System.Collections.Generic;

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
                new RestaurantItem() {Name = "Nazwa1", Description = "Opis1", DiscountValue = "-10%", DiscountDate = "21.09"},
                new RestaurantItem() {Name = "Nazwa2", Description = "Opis2", DiscountValue = "-30%", DiscountDate = "12.09"},
                new RestaurantItem() {Name = "Nazwa3", Description = "Opis3", DiscountValue = "-40%", DiscountDate = "05.09"},
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

        public void DropDataBase()
        {
            _restautants.Clear();
        }
    }
}