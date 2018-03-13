using Dapper;
using Lcgoc.Common;
using System.Data;
using System.Linq;

namespace Lcgoc.DAL
{
    public class CommonDAL
    {
        public string GetMaxBillNo(string prefix="", int length = 5)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { inprefix = prefix, inlength = length });
                var res = connection.Query<string>("sp_GetMaxBillNo", myparams, commandType: CommandType.StoredProcedure);
                return res.FirstOrDefault();
            }
        }
    }
}
