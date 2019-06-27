using System.Configuration;

namespace Mailman.Models
{
    public class DBConfig
    {
        public static string GetConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;
            string dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) {
                return @"Server=.\SQLExpress;AttachDbFilename=|DataDirectory|mailman.mdf;Database=mailman;Trusted_Connection=Yes";
            };
            string username = appConfig["RDS_USERNAME"];
            string password = appConfig["RDS_PASSWORD"];
            string hostname = appConfig["RDS_HOSTNAME"];
            string port = appConfig["RDS_PORT"];

            var connectionStr = $"Data Source={hostname},{port};Initial Catalog={dbname};User ID={username};Password={password};";
            return connectionStr;
        }
    }
}