using System.Data.SqlClient;

namespace NextBus_API.Configs
{
    public sealed class ApiManager
    {
        private readonly string Environment = Configs.Environment.Localhost.ToString();

        private ApiManager() { }
        private static ApiManager instance = null;
        public static ApiManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiManager();
                }
                return instance;
            }
        }

        #region GetConnectionString
        public SqlConnectionStringBuilder GetConnectionString()
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            if (this.Environment == Configs.Environment.Localhost.ToString())
            {
                // Localhost
                builder.DataSource = @".\SQLExpress";
                builder.IntegratedSecurity = true;
                builder.InitialCatalog = "NextBus_DB";
            }
            else if (this.Environment == Configs.Environment.Development.ToString())
            {
                // not created
            }

            return builder;
        }
        #endregion

        #region GetEnvironment
        public string GetEnvironment()
        {

            return this.Environment;
        }
        #endregion
    }


    enum APIResponse
    {
        Success,
        Fail
    }

    enum Environment
    {
        Localhost,
        Development
    }
}
