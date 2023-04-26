using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace novaltyAPI.Conexion
{
    public class ConexionDB
    {
        private string connectionString = string.Empty;

        public ConexionDB()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:cnn").Value;
        }

        public string CadenaSQL()
        {
            return connectionString;
        }
    }
}