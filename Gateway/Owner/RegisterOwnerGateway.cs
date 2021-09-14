using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DesireDelivery.Gateway
{
    public class RegisterOwnerGateway : CommonGateway
    {
        public bool IsEmailExist(Models.Owner owner)
        {
            Query = "SELECT * FROM Owner WHERE owner_email = @email OR owner_mobile = @mobile";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = owner.Email;

            Command.Parameters.Add("mobile", SqlDbType.VarChar);
            Command.Parameters["mobile"].Value = owner.MobileNumber;

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

        public int Save(Models.Owner owner)
        {
            Query = "INSERT INTO Owner VALUES(@name, @email, @mobile, @address, @dob, @password, @image);";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = owner.Name;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = owner.Email;

            Command.Parameters.Add("mobile", SqlDbType.VarChar);
            Command.Parameters["mobile"].Value = owner.MobileNumber;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = owner.Address;

            Command.Parameters.Add("dob", SqlDbType.VarChar);
            Command.Parameters["dob"].Value = owner.DateOfBirth;

            Command.Parameters.Add("password", SqlDbType.VarChar);
            Command.Parameters["password"].Value = owner.Password;

            Command.Parameters.Add("image", SqlDbType.VarChar);
            Command.Parameters["image"].Value = owner.ImagePath;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public List<SelectListItem> GetAllOwner()
        {
            Query = "SELECT * FROM Owner";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<SelectListItem> owners = new List<SelectListItem>();

            while (Reader.Read())
            {
                SelectListItem owner = new SelectListItem();

                owner.Value = Reader["owner_id"].ToString();
                owner.Text = Reader["owner_name"].ToString();

                owners.Add(owner);
            }

            Reader.Close();
            Connection.Close();

            return owners;
        }
    }
}