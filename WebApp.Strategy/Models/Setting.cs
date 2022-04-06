namespace WebApp.Strategy.Models
{
    public class Setting
    {
        public static string claimDatabaseType = "databaseType";

        public DatabaseType DatabaseType;

        public DatabaseType GetDefaultDatabaseType()
        {
            return DatabaseType.SqlServer;
        }
    }
}
