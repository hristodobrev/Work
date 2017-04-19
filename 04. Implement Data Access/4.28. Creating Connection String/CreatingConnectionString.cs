using System;
using System.Data.SqlClient;

class CreatingConnectionString
{
    static void Main()
    {
        var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

        sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
        sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";

        string connectionString = sqlConnectionStringBuilder.ToString();
        Console.WriteLine(connectionString);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
        }
    }
}