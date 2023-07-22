using System.Configuration;

namespace SPServiceCRUDApp.DALSPService
{
    public class UERPDataAccess : DataAccessBase
    {

        public UERPDataAccess()
        {

        }

        protected override ConnectionStringSettings LoadConnectionStringSetting()
        {
            var connectionSrings = ConfigurationManager.ConnectionStrings["CRUDAppContext"];
            //TO DO: Load connection string values from web.config file, any other source.
            ConnectionStringSettings _dbConnectionStringSetting = connectionSrings;// new ConnectionStringSettings("DCURDB", @"Data Source=10.10.10.40;Initial Catalog=DCURDB;User ID=sa;Password=sa1234;Connect Timeout=45;Pooling=false", "System.Data.SqlClient");

            return _dbConnectionStringSetting;
        }
      
    }
}
