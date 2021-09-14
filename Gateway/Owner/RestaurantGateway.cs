using DesireDelivery.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DesireDelivery.Gateway.Owner
{
    public class RestaurantGateway : CommonGateway
    {
        public bool NameExist(Restaurant restaurant)
        {
            Query = "SELECT * FROM Restaurant WHERE restaurant_name = @name OR restaurant_mobile = @mobile;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = restaurant.RestaurantName;

            Command.Parameters.Add("mobile", SqlDbType.VarChar);
            Command.Parameters["mobile"].Value = restaurant.Mobile;

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

        public int Save(Restaurant restaurant)
        {
            Query = "INSERT INTO Restaurant VALUES(@name, @date, @address, @mobile, @ownerId);";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = restaurant.RestaurantName;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = restaurant.Address;

            Command.Parameters.Add("mobile", SqlDbType.VarChar);
            Command.Parameters["mobile"].Value = restaurant.Mobile;

            Command.Parameters.Add("ownerId", SqlDbType.Int);
            Command.Parameters["ownerId"].Value = restaurant.OwnerId;

            Command.Parameters.Add("date", SqlDbType.DateTime);
            Command.Parameters["date"].Value = restaurant.AddingDate;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public List<SelectListItem> GetAllRestaurants()
        {
            Query = "SELECT * FROM Restaurant";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SelectListItem> restaurants = new List<SelectListItem>();
            while (Reader.Read())
            {
                SelectListItem restaurant = new SelectListItem();
                restaurant.Value = Reader["restaurant_id"].ToString();
                restaurant.Text = Reader["restaurant_name"].ToString();

                restaurants.Add(restaurant);
            }
            Reader.Close();
            Connection.Close();

            return restaurants;
        }
    }
}