using System.Data.SqlClient;
using System.Web.Configuration;

namespace DesireDelivery.Gateway
{
    public class CommonGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        private string connectionString = WebConfigurationManager.ConnectionStrings["DesireDeliveryDB"].ConnectionString;
        public int RowAffected { get; set; }
        public string Query { get; set; }

        public CommonGateway()
        {
            Connection = new SqlConnection(connectionString);
        }

    }
}