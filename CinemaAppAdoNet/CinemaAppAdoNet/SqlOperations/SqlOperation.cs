using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CinemaAppAdoNet.SqlOperations
{
    public class SqlOperation
    {
        private const string _connectionString = "Server=DESKTOP-SVLLJGP;Database=CinemaDb;Trusted_Connection=True;";
        public static SqlConnection conn = new SqlConnection(_connectionString);
        public static void Select(string query)
        {
            using (conn)
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //string columnNames = "";
                    //for (int i = 0; i < dt.Columns.Count; i++)
                    //{
                    //    columnNames += dt.Columns[i].ColumnName + "  ";
                    //}
                    //Console.WriteLine(columnNames);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string result = "";
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            result += dr[i] + " ";
                        }
                        Console.WriteLine(result);
                    }
                }
            }
        }

        public static void Execute(string query)
        {
            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    int affectedRows = command.ExecuteNonQuery();
                    try
                    {
                        if (affectedRows > 0)
                        {
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine($"({affectedRows} row affected)");
                            Console.WriteLine(DateTime.Now);
                            Console.WriteLine("-------------------------------");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }
    }
}
