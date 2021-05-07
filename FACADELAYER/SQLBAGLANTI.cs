using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace FACADELAYER
{
   public class SQLBAGLANTI
    {
      public static SqlConnection baglanti = new SqlConnection(@"Data Source=MUSTAFA;Initial Catalog=Db_Katman;Integrated Security=True");

    }
}
