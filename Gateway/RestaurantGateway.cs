﻿using DesireDelivery.Models;
using System.Data;
using System.Data.SqlClient;

namespace DesireDelivery.Gateway
{
    public class RestaurantGateway : CommonGateway
    {
        public bool NameExist(Restaurant restaurant)
        {
            Query = "SELECT * FROM Restaurant WHERE restaurant_name = @name || restaurant_mobile = @mobile;";
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
            Query = "INSERT INTO Restaurant VALUES(@name,@address, @mobile, @ownerId);";
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

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

    }
}