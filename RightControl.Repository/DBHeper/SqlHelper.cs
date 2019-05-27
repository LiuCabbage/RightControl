using System.Configuration;
using System.Data.SqlClient;

namespace RightControl.Repository
{
    public class SqlHelper
    {
       static string sqlconnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        public static SqlConnection SqlConnection()
        {
            var connection = new SqlConnection(sqlconnectionString);
            connection.Open();
            return connection;
        }
    }
}
