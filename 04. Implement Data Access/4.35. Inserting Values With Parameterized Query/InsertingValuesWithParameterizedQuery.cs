using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

class InsertingValuesWithParameterizedQuery
{
    static void Main()
    {
        Task t = InsertRowWithParameterizedQuery();

        t.Wait();
    }

    public static async Task InsertRowWithParameterizedQuery()
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(
                "INSERT INTO People([FirstName], [LastName], [MiddleName]) " +
                "VALUES(@firstName, @lastName, @middleName)", connection);
            await connection.OpenAsync();

            command.Parameters.AddWithValue("@firstName", "John");
            command.Parameters.AddWithValue("lastName", "Doe");
            command.Parameters.AddWithValue("@middleName", "Little");

            int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
            Console.WriteLine("Inserted {0} rows", numberOfInsertedRows);
        }
    }
}