using DesireDelivery.Models.OwnersA;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DesireDelivery.Gateway.Owner
{
    public class FoodsGateway : CommonGateway
    {
        public bool IsFoodExist(Foods foods)
        {
            Query = "SELECT * FROM Food WHERE food_name = @food AND restaurant_id = @resturant;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("food", SqlDbType.VarChar);
            Command.Parameters["food"].Value = foods.FoodName;

            Command.Parameters.Add("resturant", SqlDbType.VarChar);
            Command.Parameters["resturant"].Value = foods.RestaurantName;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasrows = false;

            if (Reader.HasRows)
            {
                hasrows = true;
            }
            Reader.Close();
            Connection.Close();

            return hasrows;
        }

        public int Save(Foods foods)
        {
            Query = "INSERT INTO Food VALUES(@name, @restaurant, @price, @image);";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = foods.FoodName;

            Command.Parameters.Add("image", SqlDbType.VarChar);
            Command.Parameters["image"].Value = foods.ImagePath;

            Command.Parameters.Add("price", SqlDbType.VarChar);
            Command.Parameters["price"].Value = foods.Price;

            Command.Parameters.Add("restaurant", SqlDbType.Int);
            Command.Parameters["restaurant"].Value = foods.RestaurantName;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public List<Foods> GetFoodBySearching(string stri)
        {
            Query = "SELECT * FROM ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Foods> foods = new List<Foods>();
            while (Reader.Read())
            {
                Foods food = new Foods();
                food.FoodName = Reader["food_name"].ToString();
                food.Restaurant = Reader["restaurant_name"].ToString();
                food.Price = Reader["food_price"].ToString();
                food.ImagePath = Reader["food_image"].ToString();

                foods.Add(food);
            }
            Reader.Close();
            Connection.Close();

            return foods;
        }
    }
}