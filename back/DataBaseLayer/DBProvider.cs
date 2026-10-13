using Microsoft.Extensions.Configuration;

namespace DataBaseLayer
{
    public class DBProvider
    {
        private readonly IConfiguration _configuration;
        private readonly string connstring;

        public DBProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            string? con = configuration.GetConnectionString("MSSQL");
            if (con == null)
            {
                throw new ArgumentNullException("Отсутствует строка подключения, проверьте appsetting.json");            
            }
            connstring = con;
        }
    }
}
