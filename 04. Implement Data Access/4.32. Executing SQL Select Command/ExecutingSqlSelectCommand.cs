using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

class ExecutingSqlSelectCommand
{
    static void Main()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "CREATE TABLE dbo.People([id] INT NOT NULL IDENTITY, [FirstName] VARCHAR(30) NOT NULL, [MiddleName] VARCHAR(30) NULL, [LastName] VARCHAR(30) NOT NULL)", con))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Task t = SelectDataFromTable();

        //t.Wait();
    }

    public static async Task SelectDataFromTable()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"]
            .ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("SELECT * FROM People", connection);
            await connection.OpenAsync();

            SqlDataReader dataReader = await command.ExecuteReaderAsync();

            while (await dataReader.ReadAsync())
            {
                string formatStringWithMiddleName = "Person ({0}) is name {1} {2} {3}";
                string formatStringWithoutMiddleName = "Person ({0}) is name {1} {3}";

                if ((dataReader["middlename"] == null))
                {
                    Console.WriteLine(formatStringWithoutMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["lastname"]);
                }
                else
                {
                    Console.WriteLine(formatStringWithMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["middlename"],
                        dataReader["lastname"]);
                }
            }

            dataReader.Close();
        }
    }
}