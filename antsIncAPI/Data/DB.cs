using System.Data;
using System.Data.SqlClient;

namespace antsIncAPI.Data
{
    public class DB
    {
        public static string connectionString = "Data Source=DESKTOP-3J73F5V\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Initial Catalog=antsINC";
        /**
         * Receives the storedProcedureName which is the same stored in 
         * the database and a list with the parameters for such 
         * stored procedure. If there is none, then it defaults null
         * 
         * It excutes the stored procedure and returns a table. 
         */
        public static DataTable RetriveTable(string storedProcedureName, List<Parameter> parameters = null)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(storedProcedureName, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if(parameters != null)
                {
                    foreach (Parameter p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);

                return table;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally { connection.Close(); }
        }
    }
}
