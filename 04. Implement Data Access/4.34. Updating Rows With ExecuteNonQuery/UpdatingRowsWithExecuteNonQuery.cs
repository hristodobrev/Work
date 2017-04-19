using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

class UpdatingRowsWithExecuteNonQuery
{
    static void Main()
    {
        Task t = UpdateRows();

        t.Wait();
    }

    public static async Task UpdateRows()
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("UPDATE People SET FirstName='John'", connection);

            await connection.OpenAsync();
            int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
            Console.WriteLine("Updated {0} rows", numberOfUpdatedRows);
        }
    }
}