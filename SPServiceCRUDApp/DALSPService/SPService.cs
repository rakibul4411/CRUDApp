using System.Data;


namespace SPServiceCRUDApp.DALSPService
{
    //public interface ISPService
    //{
       
    //    DataSet GetDataWithParameter<TParamOType>(TParamOType target, string storeProcedureName) where TParamOType : class;
    //    DataSet GetDataWithoutParameter(string storeProcedureName);
    //    DataSet GetDataBySqlCommand(string sqlString);
    //}
    public class SPService
    {
     
        public DataSet GetDataWithParameter<TParamOType>(TParamOType target, string storeProcedureName) where TParamOType : class
        {
            using (var gbData = new UERPDataAccess())
            {
                return gbData.GetDataOnDateset(storeProcedureName, target);
            }
        }

        public DataSet GetDataWithoutParameter(string storeProcedureName)
        {
            using (var gbData = new UERPDataAccess())
            {
                return gbData.GetDataOnDatesetWithoutParam(storeProcedureName);
            }
        }

        public DataSet GetDataBySqlCommand(string sql)
        {
            using (var gbData = new UERPDataAccess())
            {
                return gbData.GetDataOnDatesetBySqlCommand(sql);
            }
        }
    }
}
