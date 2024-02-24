using Npgsql;

namespace OnlineStore.Infrastructure.IntegrationTests.Config
{
    public class SetupDatabase(string connectionString)
    {
        public void InitDatabase()
        {
            var con = new NpgsqlConnection(connectionString);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = File.ReadAllText("Resources/create_tables.sql");
            cmd.ExecuteNonQuery();
        }
        public void ClearDatabase()
        {
            var con = new NpgsqlConnection(connectionString);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = File.ReadAllText("Resources/delete_tables.sql");
            cmd.ExecuteNonQuery();
        }
    }
}
