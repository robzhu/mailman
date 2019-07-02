using System.Configuration;

namespace Mailman.Models
{
    public class DBConfig
    {
        // https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/create_deploy_NET.rds.html#dotnet-rds-connect
        // Note the addition of the PORT in the connection string
        public static string GetConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;
            // look for RDS connection string settings inside app config
            string dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) {
                // use SQL Server Express
                return @"Server=.\SQLExpress;Database=mailman;Trusted_Connection=Yes";
            } else
            {
                // use RDS connection string
                string username = appConfig["RDS_USERNAME"];
                string password = appConfig["RDS_PASSWORD"];
                string hostname = appConfig["RDS_HOSTNAME"];
                string port = appConfig["RDS_PORT"];

                var connectionStr = $"Data Source={hostname},{port};Initial Catalog={dbname};User ID={username};Password={password};";
                return connectionStr;
            }
        }
    }
}