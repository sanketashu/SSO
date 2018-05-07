using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalcBase
    {
        string Con = string.Empty;
        public DalcBase()
        {
            Con = "";
        }
        public DalcBase(string connectionString)
        {
            Con = connectionString;
        }
        public SqlConnection GetConnection()
        {
            SqlConnection oj = new SqlConnection(Con);
            return oj;
        }
    }
}
