using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_pp
{
    public static class SQLclass
    {
        public static SqlConnection conn;

        public static void OpenConnection()
        {
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=LAPTOP-5REMVTON;Initial Catalog=flowers;Integrated Security=True"
            };
            conn.Open();
        }

        public static void CloseConnection()
        {
            conn.Close();
        }

        public static void Insert(String text)
        {
            SqlCommand command = new SqlCommand(text, conn);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public static List<string> Select(String Text)
        {
            List<string> results = new List<string>();
            SqlCommand command = new SqlCommand(Text, conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i).ToString());
            }
            reader.Close();
            command.Dispose();

            return results;
        }
    }
}
