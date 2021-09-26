using DesireDelivery.Models;
using System.Data;
using System.Data.SqlClient;

namespace DesireDelivery.Gateway
{
    public class LogGateway : CommonGateway
    {
        public bool isUserAvailable(LoginViewModel user)
        {
            Query = "SELECT * FROM LogInfo WHERE log_email= @email AND log_password = @password AND log_action = @action";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.NVarChar);
            Command.Parameters["email"].Value = user.Email;
            Command.Parameters.Add("password", SqlDbType.NVarChar);
            Command.Parameters["password"].Value = user.Password;
            Command.Parameters.Add("action", SqlDbType.Int);
            Command.Parameters["action"].Value = user.LogInAs;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = false;
            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRows;
        }
    }
}