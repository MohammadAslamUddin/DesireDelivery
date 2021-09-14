using DesireDelivery.Models.OwnersA;
using System.Data;
using System.Data.SqlClient;

namespace DesireDelivery.Gateway.Owner
{
    public class FoodsViewGateway : CommonGateway
    {
        public bool IsFoodExist(Foods foods)
        {
            Query = "";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = foods.FoodName;

            Command.Parameters.Add("mobile", SqlDbType.VarChar);
            Command.Parameters["mobile"].Value = foods.RestaurantName;

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
            Query = "";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = foods.FoodName;

            Command.Parameters.Add("", SqlDbType.VarChar);
            Command.Parameters[""].Value = foods.ImagePath;

            Command.Parameters.Add("price", SqlDbType.VarChar);
            Command.Parameters["price"].Value = foods.Price;

            Command.Parameters.Add("address", SqlDbType.Int);
            Command.Parameters["address"].Value = foods.RestaurantName;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }
    }
}