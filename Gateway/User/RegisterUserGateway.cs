using DesireDelivery.Models;
using System.Data;
using System.Data.SqlClient;

namespace DesireDelivery.Gateway.User
{
    public class RegisterUserGateway : CommonGateway
    {
        public bool IsEmailExist(RegisterUser user)
        {

            Query = "SELECT * FROM Users WHERE user_email = @email OR user_contact = @contact;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = user.UserEmail;

            Command.Parameters.Add("contact", SqlDbType.VarChar);
            Command.Parameters["contact"].Value = user.UserContact;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasrow = false;

            if (Reader.HasRows)
            {
                hasrow = true;
            }
            Reader.Close();
            Connection.Close();

            return hasrow;
        }

        public int Save(RegisterUser user)
        {
            Query = "INSERT INTO Users VALUES(@name, @email, @mobile, @image, @address, @dob, @password);";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = user.UserName;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = user.UserEmail;

            Command.Parameters.Add("mobile", SqlDbType.VarChar);
            Command.Parameters["mobile"].Value = user.UserContact;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = user.USerAddress;

            Command.Parameters.Add("dob", SqlDbType.VarChar);
            Command.Parameters["dob"].Value = user.UserDateOfBirth;

            Command.Parameters.Add("password", SqlDbType.VarChar);
            Command.Parameters["password"].Value = user.Password;

            Command.Parameters.Add("image", SqlDbType.VarChar);
            Command.Parameters["image"].Value = user.ImagePath;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }
    }
}