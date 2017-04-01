using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Complete
{
  public  class logger
    {
public static void LogIt(string MethodName ,string MessageError)
        {
            SqlConnection conn = new SqlConnection("data source= HOMEPC;initial catalog=USA; integrated security= truue");
            string sql = "insert into ActivrlyLog values('" + MethodName + "','" + MessageError + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

        }
    }
}
